 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Signatures;

namespace Architect.PDF.Integrations
{
    public class Signature
    {

        public static string SerialNumber(string pathFile)
        {
            string result = string.Empty;
            if (System.IO.File.Exists(pathFile))
            {
                PdfReader reader = new PdfReader(pathFile);
                PdfDocument pdfDoc = new PdfDocument(reader);


                SignatureUtil signatureUtil = new SignatureUtil(pdfDoc);
                foreach (string signatureName in signatureUtil.GetSignatureNames())
                {
                    PdfPKCS7 pkcs7 = signatureUtil.ReadSignatureData(signatureName);
                    Org.BouncyCastle.X509.X509Certificate cert = (Org.BouncyCastle.X509.X509Certificate)pkcs7.GetSigningCertificate();
                    Org.BouncyCastle.Asn1.X509.X509Name subjectDn = cert.SubjectDN;
                    foreach (var name in subjectDn.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.SerialNumber))
                    {
                        result = name.ToString();
                        break;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException(string.Format("El archivo '{0}' no existe.", pathFile));
            }
            return result;
        }
    }
}
