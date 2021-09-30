using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Architect.DataFactory.Contracts
{
    [DebuggerDisplay("{Text}, Parameter Count: {Parameters}")]
    public class Command
    {
        public string Text { get; set; }
        public List<Contracts.Parameter> Parameters { get; set; } = new List<Parameter>();
        public string ConnectionStringName { get; internal set; }

        /// <summary>
        /// Método para ofrecer crear un parámetro empty
        /// </summary>
        /// <param name="items">Colección base a agregar el parámetro</param>
        /// <returns></returns>
        public  Contracts.Parameter NewParameter( List<Contracts.Parameter> items)
        {
            Contracts.Parameter result = new Contracts.Parameter();
            items.Add(result);
            return result;
        }

        /// <summary>
        /// Método para ofrecer crear un parámetro
        /// </summary>
        /// <param name="items">Colección base a agregar el parámetro</param>
        /// <param name="Name">Nombre del parámetro</param>
        /// <param name="Type">Type de parámetro</param>
        /// <param name="Size">Tamaño de parámetro</param>
        /// <param name="Value">Value del parámetro</param>
        /// <returns></returns>
        public  Contracts.Parameter NewParameter(string Name, Enumerations.DbType Type, int Size, object Value, ParameterDirection direction = ParameterDirection.Input)
        {
            Contracts.Parameter result = new Contracts.Parameter();
            result.With(c =>
            {
                c.Name = Name;
                c.Type = Type;
                c.Size = Size;
                if (Value.IsEmpty())
                {
                    c.Value = Value;
                }
                else
                {
                    c.Value = DBNull.Value;
                }
                c.direction = direction;
            });
            this.Parameters.Add(result);
            return result;
        }

    }
}