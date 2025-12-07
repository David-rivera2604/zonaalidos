using Architect.API.Core.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Architect.Sugese.Utility
{
    public sealed class Validate
    {
        private static StreamWriter xx = null;

        public static List<string> XslValidate(string xslfilename, string xmlfilename)
        {
            var settings = new XsltSettings() { EnableScript = true };
            var xslArg = new XsltArgumentList();
            var xslt = new XslCompiledTransform();
            string outputFilename = string.Format(@"{0}\temp\{1}.out.txt", "app.path".StringValue(0, "C:\\Aliados\\WebApp"), xslfilename);
            var result = new List<string>();
            string xslFullFilename = string.Format(@"{0}\sugese\validators\{1}", "app.path".StringValue(0, "C:\\Aliados\\WebApp"), xslfilename);

            if (File.Exists(xslFullFilename))
            {
                xslt.Load(xslFullFilename, settings, null);

                using (var w = File.CreateText(outputFilename))
                {
                    xslt.Transform(xmlfilename, xslArg, w);
                }

                if (File.Exists(outputFilename))
                {
                    using (var objReader = new StreamReader(outputFilename))
                    {
                        int line = 1;
                        while (objReader.Peek() != -1)
                        {
                            if (line > 100)
                            {
                                result.Insert(0, "Existen más de 200 errores, la lista fue limitada solo a los primero 200 para su revisión.");
                                break;
                            }
                            result.Add(objReader.ReadLine());
                            line += 1;
                        }
                        objReader.Close();
                    }
                }
            }
            return result;
        }

        public static List<string> XsdValidate(string xsdfilename, string xmlfilename)
        {
            string outputFilename = string.Format(@"{0}\temp\{1}.xsd.out.txt", "app.path".StringValue(0, "C:\\Aliados\\WebApp"), xsdfilename);
            var booksSettings = new XmlReaderSettings();
            var result = new List<string>();

            booksSettings.Schemas.Add("", $@"{"app.path".StringValue(0, "C:\\Aliados\\WebApp")}\sugese\validators\{xsdfilename}.xsd");
            booksSettings.ValidationType = ValidationType.Schema;

            // AddHandler booksSettings.ValidationEventHandler, AddressOf booksSettingsValidationEventHandler

            booksSettings.ValidationEventHandler += (sender, e) => xx.WriteLine(string.Format("{1}({2},{3}): {0}", e.Message, e.Severity, e.Exception.LineNumber, e.Exception.LinePosition));

            using (var books = XmlReader.Create(xmlfilename, booksSettings))
            {
                xx = File.CreateText(outputFilename);

                while (books.Read())
                {
                }

                xx.Close();
                books.Close();
            }

            if (File.Exists(outputFilename))
            {
                using (var objReader = new StreamReader(outputFilename))
                {
                    int line = 1;
                    while (objReader.Peek() != -1)
                    {
                        if (line > 100)
                        {
                            result.Insert(0, "Existen más de 200 errores, la lista fue limitada solo a los primero 200 para su revisión.");
                            break;
                        }
                        result.Add(objReader.ReadLine());
                        line += 1;
                    }
                    objReader.Close();
                }
            }
            return result;
        }

        // Private Shared Sub booksSettingsValidationEventHandler(sender As Object, e As ValidationEventArgs)
        // xx.WriteLine(String.Format("{1}({2},{3}): {0}", e.Message, e.Severity, e.Exception.LineNumber, e.Exception.LinePosition))
        // End Sub
    }
}