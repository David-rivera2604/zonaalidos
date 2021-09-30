using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Architect.Utilities.Helpers
{
    /// <summary>
    /// Class that provides extensible properties and methods to an
    /// existing object when cast to dynamic. This
    /// dynamic object stores 'extra' properties in a dictionary or
    /// checks the actual properties of the instance passed via
    /// constructor.
    ///
    /// This class can be subclassed to extend an existing type or
    /// you can pass in an instance to extend. Properties (both
    /// dynamic and strongly typed) can be accessed through an
    /// indexer.
    ///
    /// This type allows you three ways to access its properties:
    ///
    /// Directly: any explicitly declared properties are accessible
    /// Dynamic: dynamic cast allows access to dictionary and native properties/methods
    /// Dictionary: Any of the extended properties are accessible via IDictionary interface
    /// </summary>
    // Token: 0x02000009 RID: 9
    [Serializable]
    public class Expando : DynamicObject, IDynamicMetaObjectProvider
    {
        // Token: 0x17000006 RID: 6
        // (get) Token: 0x06000047 RID: 71 RVA: 0x00002F68 File Offset: 0x00001168
        private PropertyInfo[] InstancePropertyInfo
        {
            get
            {
                if (this._InstancePropertyInfo == null && this.Instance != null)
                {
                    this._InstancePropertyInfo = (from a in this.Instance.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                                                  where a.GetIndexParameters().Length == 0
                                                  select a).ToArray<PropertyInfo>();
                }
                return this._InstancePropertyInfo;
            }
        }

        /// <summary>
        /// This constructor just works off the internal dictionary and any
        /// public properties of this object.
        ///
        /// Note you can subclass Expando.
        /// </summary>
        // Token: 0x06000048 RID: 72 RVA: 0x00002FCC File Offset: 0x000011CC
        public Expando()
        {
            this.Initialize(this);
        }

        /// <summary>
        /// Allows passing in an existing instance variable to 'extend'.
        /// </summary>
        /// <remarks>
        /// You can pass in null here if you don't want to
        /// check native properties and only check the Dictionary!
        /// </remarks>
        /// <param name="instance"></param>
        // Token: 0x06000049 RID: 73 RVA: 0x00002FE8 File Offset: 0x000011E8
        public Expando(object instance)
        {
            IDictionary<string, object> dictionary = instance as IDictionary<string, object>;
            if (dictionary == null)
            {
                this.Initialize(instance);
                return;
            }
            this.Initialize(this);
            this.InitializeAsDictionary(this, dictionary);
        }

        /// <summary>
        /// Create an Expando from a dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="expando">Expando instance</param>
        // Token: 0x0600004A RID: 74 RVA: 0x0000302C File Offset: 0x0000122C
        public Expando(IDictionary<string, object> dict)
        {
            this.Initialize(this);
            this.InitializeAsDictionary(this, dict);
        }

        // Token: 0x0600004B RID: 75 RVA: 0x0000305C File Offset: 0x0000125C
        private void InitializeAsDictionary(Expando expando, IDictionary<string, object> dict)
        {
            this.Properties = new PropertyBag();
            foreach (KeyValuePair<string, object> kvp in dict)
            {
                object kvpValue = kvp.Value;
                if (kvpValue is IDictionary<string, object>)
                {
                    Expando expandoVal = new Expando(kvpValue);
                    expando[kvp.Key] = expandoVal;
                }
                else if (kvp.Value is ICollection)
                {
                    List<object> objList = new List<object>();
                    foreach (object item in ((ICollection)kvp.Value))
                    {
                        IDictionary<string, object> itemVals = item as IDictionary<string, object>;
                        if (itemVals != null)
                        {
                            Expando expandoItem = new Expando(itemVals);
                            objList.Add(expandoItem);
                        }
                        else
                        {
                            objList.Add(item);
                        }
                    }
                    expando[kvp.Key] = objList;
                }
                else
                {
                    expando[kvp.Key] = kvpValue;
                }
            }
        }

        // Token: 0x0600004C RID: 76 RVA: 0x00003184 File Offset: 0x00001384
        protected void Initialize(object instance)
        {
            this.Instance = instance;
            if (instance != null)
            {
                this.InstanceType = instance.GetType();
            }
        }

        /// <summary>
        /// Return both instance and dynamic names.
        ///
        /// Important to return both so JSON serialization with
        /// Json.NET works.
        /// </summary>
        /// <returns></returns>
        // Token: 0x0600004D RID: 77 RVA: 0x0000319C File Offset: 0x0000139C
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            foreach (KeyValuePair<string, object> prop in this.GetProperties(true))
            {
                yield return prop.Key;
            }
            IEnumerator<KeyValuePair<string, object>> enumerator = null;
            yield break;
            yield break;
        }

        /// <summary>
        /// Try to retrieve a member by name first from instance properties
        /// followed by the collection entries.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        // Token: 0x0600004E RID: 78 RVA: 0x000031AC File Offset: 0x000013AC
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (this.Properties.Keys.Contains(binder.Name))
            {
                result = this.Properties[binder.Name];
                return true;
            }
            if (this.Instance != null)
            {
                try
                {
                    return this.GetProperty(this.Instance, binder.Name, out result);
                }
                catch
                {
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Property setter implementation tries to retrieve value from instance
        /// first then into this object
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // Token: 0x0600004F RID: 79 RVA: 0x00003220 File Offset: 0x00001420
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (this.Instance != null)
            {
                try
                {
                    bool result = this.SetProperty(this.Instance, binder.Name, value);
                    if (result)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            this.Properties[binder.Name] = value;
            return true;
        }

        /// <summary>
        /// Dynamic invocation method. Currently allows only for Reflection based
        /// operation (no ability to add methods dynamically).
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        // Token: 0x06000050 RID: 80 RVA: 0x0000327C File Offset: 0x0000147C
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (this.Instance != null)
            {
                try
                {
                    if (this.InvokeMethod(this.Instance, binder.Name, args, out result))
                    {
                        return true;
                    }
                }
                catch
                {
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Reflection Helper method to retrieve a property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        // Token: 0x06000051 RID: 81 RVA: 0x000032C8 File Offset: 0x000014C8
        protected bool GetProperty(object instance, string name, out object result)
        {
            if (instance == null)
            {
                instance = this;
            }
            MemberInfo[] miArray = this.InstanceType.GetMember(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            if (miArray != null && miArray.Length != 0)
            {
                MemberInfo mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    result = ((PropertyInfo)mi).GetValue(instance, null);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Reflection helper method to set a property value
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // Token: 0x06000052 RID: 82 RVA: 0x00003318 File Offset: 0x00001518
        protected bool SetProperty(object instance, string name, object value)
        {
            if (instance == null)
            {
                instance = this;
            }
            MemberInfo[] miArray = this.InstanceType.GetMember(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            if (miArray != null && miArray.Length != 0)
            {
                MemberInfo mi = miArray[0];
                if (mi.MemberType == MemberTypes.Property)
                {
                    ((PropertyInfo)mi).SetValue(this.Instance, value, null);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Reflection helper method to invoke a method
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        // Token: 0x06000053 RID: 83 RVA: 0x00003368 File Offset: 0x00001568
        protected bool InvokeMethod(object instance, string name, object[] args, out object result)
        {
            if (instance == null)
            {
                instance = this;
            }
            MemberInfo[] miArray = this.InstanceType.GetMember(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod);
            if (miArray != null && miArray.Length != 0)
            {
                MethodInfo mi = miArray[0] as MethodInfo;
                result = mi.Invoke(this.Instance, args);
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Convenience method that provides a string Indexer
        /// to the Properties collection AND the strongly typed
        /// properties of the object by name.
        ///
        /// // dynamic
        /// exp["Address"] = "112 nowhere lane";
        /// // strong
        /// var name = exp["StronglyTypedProperty"] as string;
        /// </summary>
        /// <remarks>
        /// The getter checks the Properties dictionary first
        /// then looks in PropertyInfo for properties.
        /// The setter checks the instance properties before
        /// checking the Properties dictionary.
        /// </remarks>
        /// <param name="key"></param>
        ///
        /// <returns></returns>
        // Token: 0x17000007 RID: 7
        public object this[string key]
        {
            get
            {
                object result2;
                try
                {
                    result2 = this.Properties[key];
                }
                catch (KeyNotFoundException)
                {
                    object result = null;
                    if (!this.GetProperty(this.Instance, key, out result))
                    {
                        throw;
                    }
                    result2 = result;
                }
                return result2;
            }
            set
            {
                if (this.Properties.ContainsKey(key))
                {
                    this.Properties[key] = value;
                    return;
                }
                MemberInfo[] miArray = this.InstanceType.GetMember(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
                if (miArray != null && miArray.Length != 0)
                {
                    this.SetProperty(this.Instance, key, value);
                    return;
                }
                this.Properties[key] = value;
            }
        }

        /// <summary>
        /// Returns and the properties of
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        // Token: 0x06000056 RID: 86 RVA: 0x0000345B File Offset: 0x0000165B
        public IEnumerable<KeyValuePair<string, object>> GetProperties(bool includeInstanceProperties = false)
        {
            if (includeInstanceProperties && this.Instance != null)
            {
                foreach (PropertyInfo prop in this.InstancePropertyInfo)
                {
                    yield return new KeyValuePair<string, object>(prop.Name, prop.GetValue(this.Instance, null));
                }
                PropertyInfo[] array = null;
            }
            foreach (string key in this.Properties.Keys)
            {
                yield return new KeyValuePair<string, object>(key, this.Properties[key]);
            }
            Dictionary<string, object>.KeyCollection.Enumerator enumerator = default(Dictionary<string, object>.KeyCollection.Enumerator);
            yield break;
            yield break;
        }

        /// <summary>
        /// Checks whether a property exists in the Property collection
        /// or as a property on the instance
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // Token: 0x06000057 RID: 87 RVA: 0x00003474 File Offset: 0x00001674
        public bool Contains(KeyValuePair<string, object> item, bool includeInstanceProperties = false)
        {
            bool res = this.Properties.ContainsKey(item.Key);
            if (res)
            {
                return true;
            }
            if (includeInstanceProperties && this.Instance != null)
            {
                foreach (PropertyInfo prop in this.InstancePropertyInfo)
                {
                    if (prop.Name == item.Key)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Instance of object passed in
        /// </summary>
        // Token: 0x04000006 RID: 6
        private object Instance;

        /// <summary>
        /// Cached type of the instance
        /// </summary>
        // Token: 0x04000007 RID: 7
        private Type InstanceType;

        // Token: 0x04000008 RID: 8
        private PropertyInfo[] _InstancePropertyInfo;

        /// <summary>
        /// String Dictionary that contains the extra dynamic values
        /// stored on this object/instance
        /// </summary>
        /// <remarks>Using PropertyBag to support XML Serialization of the dictionary</remarks>
        // Token: 0x04000009 RID: 9
        public PropertyBag Properties = new PropertyBag();
    }

}
