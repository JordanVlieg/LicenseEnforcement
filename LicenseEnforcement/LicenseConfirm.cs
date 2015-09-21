using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace LicenseEnforcement
{
    internal class LicenseConfirm
    {
        public static void GenerateLicense(int months)
        {
            // The license key, it must be 20 bytes long to be compatible with RSA
            string licenseKey = DateTime.Now.Date.AddMonths(months).ToShortDateString();
            // If a current license exists, add the new license length onto the old one.
            if (File.Exists(Environment.CurrentDirectory + @"\licenseinfo.xml"))
            {
                XmlDocument licenseFile = new XmlDocument();
                licenseFile.Load(Environment.CurrentDirectory + @"\licenseinfo.xml");
                string savedLicenseKey = licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/KEY").InnerText;
                string licenseExpiry = savedLicenseKey.Substring(0, savedLicenseKey.LastIndexOf(@"/") + 5);
                if (Convert.ToDateTime(licenseExpiry) > DateTime.Today)
                {
                    licenseKey = (Convert.ToDateTime(licenseExpiry).AddMonths(months)).ToShortDateString();
                }
            }
            string machineName = Environment.MachineName;
            licenseKey += machineName;
            // Adds trailing 0's if the date+machinename is less than 20 charachters
            while (licenseKey.Length < 20)
            {
                licenseKey += "0";
            }
            // Cuts the key down to 20 charachters if the date+machinename are too large.
            licenseKey = licenseKey.Substring(0, 20);

            // Byte arrays to store the license key
            byte[] byteLicenseKey = Encoding.ASCII.GetBytes(licenseKey);

            // The RSA handling and public key creation
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(RSA);
            rsaFormatter.SetHashAlgorithm("SHA1");
            string publicKey = RSA.ToXmlString(false);

            // The digital signature for the license
            byte[] digitalSignature = rsaFormatter.CreateSignature(byteLicenseKey);

            //An XML file that holds the public key, license key, and the Digital Signature
            XmlDocument licenseDocument = new XmlDocument();
            XmlElement parentNode = licenseDocument.CreateElement("LicenseInfo");
            licenseDocument.AppendChild(parentNode);
            XmlElement xmlDocLicenseKey = licenseDocument.CreateElement("KEY");
            xmlDocLicenseKey.InnerText = Encoding.Default.GetString(byteLicenseKey);
            parentNode.AppendChild(xmlDocLicenseKey);
            XmlElement xmlDocLicenseSignature = licenseDocument.CreateElement("SignedKey");
            xmlDocLicenseSignature.InnerText = Convert.ToBase64String(digitalSignature);
            parentNode.AppendChild(xmlDocLicenseSignature);
            XmlDocumentFragment publicKeyNode = licenseDocument.CreateDocumentFragment();
            publicKeyNode.InnerXml = publicKey;
            parentNode.AppendChild(publicKeyNode);
            licenseDocument.Save(Environment.CurrentDirectory + @"\licenseinfo.xml");
        }
        
        public static bool VerifyLicense()
        {
            //The XML file that holds the public key, license key, and the Digital Signature
            XmlDocument licenseFile = new XmlDocument();
            licenseFile.Load(Environment.CurrentDirectory + @"\licenseinfo.xml");

            // The RSA public key
            RSAParameters RSAKeyInfo = new RSAParameters
            {
                Modulus = Convert.FromBase64String(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/RSAKeyValue/Modulus").InnerText),
                Exponent = Convert.FromBase64String(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/RSAKeyValue/Exponent").InnerText)
            };

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(RSAKeyInfo);

            // A deformatter to verify the digital signature against the license
            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(RSA);
            rsaDeformatter.SetHashAlgorithm("SHA1");
            // The hash to be verified against the signature
            byte[] hash = Encoding.ASCII.GetBytes(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/KEY").InnerText);
            // The signature used to verify the hash
            byte[] signature = Convert.FromBase64String(licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/SignedKey").InnerText);

            // If the signature is valid, return true
            if (rsaDeformatter.VerifySignature(hash, signature))
            {
                return true;
            }
            return false;

        }

    }
}
