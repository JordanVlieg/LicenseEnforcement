using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LicenseEnforcement
{
    internal class LicenseConfirm
    {
        //private RSACryptoServiceProvider GLOBAL_RSA;

        public static void GenerateLicense(int months)
        {
            //must be 20 bytes longs
            string licenseKey = DateTime.Now.Date.AddMonths(months).ToShortDateString();
            //Debug.WriteLine(testing);
            string machineName = System.Environment.MachineName;
            licenseKey += machineName;
            while (licenseKey.Length < 20)
            {
                licenseKey += "0";
            }
            licenseKey = licenseKey.Substring(0, 20);

            byte[] byteLicenseKey = Encoding.ASCII.GetBytes(licenseKey);
            byte[] signedKey;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            string publicKey = RSA.ToXmlString(false);

            XmlDocument licenseDocument = new XmlDocument();

            XmlElement parentNode = licenseDocument.CreateElement("LicenseInfo");

            licenseDocument.AppendChild(parentNode);



            XmlElement xmlDocLicenseKey = licenseDocument.CreateElement("KEY");

            xmlDocLicenseKey.InnerText = Encoding.Default.GetString(byteLicenseKey);

            parentNode.AppendChild(xmlDocLicenseKey);

            RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(RSA);

            rsaFormatter.SetHashAlgorithm("SHA1");

            signedKey = rsaFormatter.CreateSignature(byteLicenseKey);

            XmlElement xmlDocLicenseSignature = licenseDocument.CreateElement("SignedKey");

            xmlDocLicenseSignature.InnerText = Convert.ToBase64String(signedKey);

            parentNode.AppendChild(xmlDocLicenseSignature);

            XmlDocumentFragment publicKeyNode = licenseDocument.CreateDocumentFragment();
            publicKeyNode.InnerXml = publicKey;

            parentNode.AppendChild(publicKeyNode);

            licenseDocument.Save(Environment.CurrentDirectory + @"\licenseinfo.xml");
            

        }

        
        public static bool VerifyLicense()
        {
            


            XmlDocument licenseFile = new XmlDocument();
            licenseFile.Load(Environment.CurrentDirectory + @"\licenseinfo.xml");

            //XmlNode RSAInfo = licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/RSAKeyValue/Modulus");



            RSAParameters RSAKeyInfo = new RSAParameters();
            RSAKeyInfo.Modulus = Convert.FromBase64String(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/RSAKeyValue/Modulus").InnerText);
            RSAKeyInfo.Exponent = Convert.FromBase64String(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/RSAKeyValue/Exponent").InnerText);

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //RSA = this.GLOBAL_RSA;

            RSA.ImportParameters(RSAKeyInfo);

            //Debug.WriteLine(RSAInfo.SelectSingleNode("/Modulus").InnerText);
            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(RSA);

            rsaDeformatter.SetHashAlgorithm("SHA1");
            byte[] hash =
                Encoding.ASCII.GetBytes(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/KEY").InnerText);
            byte[] sig =
                Convert.FromBase64String(
                    licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/SignedKey").InnerText);
            if (rsaDeformatter.VerifySignature(hash, sig))
            {
                return true;
                Debug.WriteLine("SUCCESS");
            }
            return false;

        }

    }
}
