using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Utilities.Exceptions
{
    [Serializable()]
    public class CustomException : Exception, ISerializable
    {
        private Collection<Object> _InvalidFields;

        protected CustomException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public CustomException() : base()
        {
        }

        public CustomException(string message) : base(message)
        {
            Log.ErrorLog("CustomException", message);
        }

        public CustomException(string message, object data) : base(message)
        {

            Data.Add("Detail", data);
            Log.ErrorLog("CustomException", message);
        }


        public CustomException(string message, Exception inner) : base(message, inner )
        {
            Log.ErrorLog("CustomException", message, inner);
        }

        public CustomException(string message, Exception inner, object data) : base(message, inner)
        {
            Data.Add("Detail", data);
            Log.ErrorLog("CustomException", message, inner);
        }

        public Collection<Object> InvalidFields
        {
            get
            {
                Collection<Object> InvalidFieldsRet = default;
                InvalidFieldsRet = _InvalidFields;
                return InvalidFieldsRet;
            }
        }

        public static string ShowError(Exception ex)
        {
            switch (ex.GetType().Name ?? "")
            {
                case "InvalidCastException":
                    {
                        return "Error: Input string was not in a correct format.";
                    }

                case "NullReferenceException":
                    {
                        return "Error: Object reference not set to an instance of an object.";
                    }

                default:
                    {
                        return "Unexpected error in the system. Verify with your administrator";
                    }
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Implements ISerializable.GetObjectData
            base.GetObjectData(info, context);
            throw new ArgumentNullException("info");
        }

        public string GetStringDataValue(string key)
        {
            string value = string.Empty;

            if (Data.Contains(key))
            {
                value = (string)Data[key];
            }

            return value;
        }
    }
}
