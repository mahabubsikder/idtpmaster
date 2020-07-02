using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace IDTP.Utility
{
    public static class XMLValidator
    {
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        public static bool ValidatePain008(XmlDocument xmlDocument)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("urn:swift:saa:xsd:saa.2.0", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_008.xsd");
            schema.Add("urn:iso:std:iso:20022:tech:xsd:head.001.001.01", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_0081.xsd");
            schema.Add("urn:iso:std:iso:20022:tech:xsd:pacs.008.001.04", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_0082.xsd");

            //XDocument xmlDocument = XDocument.Load(@"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_008.xml");
            XDocument document = ToXDocument(xmlDocument);

            bool validationErrors = false;

            string errorMessage = "";
            document.Validate(schema, (s, e) =>
            {
                errorMessage = e.Message;
                validationErrors = true;
            });
            if (validationErrors)
            {
                throw new Exception("XML validation failed. Error Message: " + errorMessage);
            }
            return validationErrors;
            //ValidateXML(xmlDocument);
        }
        public static bool ValidatePain002(XmlDocument xmlDocument)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("urn:swift:saa:xsd:saa.2.0", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_002.xsd");
            schema.Add("urn:iso:std:iso:20022:tech:xsd:head.001.001.01", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_0021.xsd");
            schema.Add("urn:iso:std:iso:20022:tech:xsd:pacs.002.001.05", @"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_0022.xsd");

            //XDocument xmlDocument = XDocument.Load(@"D:\Projects\IDTP Source\HeartFoundation\FinancialApplication\IDTP\Codebase\IDTPFundTransfer-V1.1\IDTP.Utility\pacs_008.xml");
            XDocument document = ToXDocument(xmlDocument);

            bool validationErrors = false;

            string errorMessage = "";
            document.Validate(schema, (s, e) =>
            {
                errorMessage = e.Message;
                validationErrors = true;
            });
            if (validationErrors)
            {
                throw new Exception("XML validation failed. Error Message: " + errorMessage);
            }
            return validationErrors;
            //ValidateXML(xmlDocument);
        }
    }
}