using System;
using System.Globalization;
using System.Text;
using System.Xml;
namespace IDTP.Utility
{
    public static class ISOComposer
    {

        #region Pacs.008.Message
        public static XmlDocument GetPacs008Data(string senderBankBIC, string receiverBankBIC, string senderName, string receiverName, string transactionId, string senderAccount, string senderBranchRoutingNo, string sendingBankCBAccount, string receiverBranchRoutingNo, string receivingBankCBAccount, string receiverAccount, string amount, string paymentPurpose)
        {
            //Guid transactionId = Guid.NewGuid();
            //_ = new StringBuilder();
            XmlDocument pacsXml = new XmlDocument();
            StringBuilder footerXML = GetPacsFooter();
            StringBuilder pacsData = GetPacsHeader();
            pacsData.AppendLine(GetHeaderBody(transactionId, senderBankBIC, "pacs.008.001.04", "RTGS"));
            pacsData.AppendLine(GetDocumentHeader());
            pacsData.AppendLine(GetGroupHeader(transactionId, "1"));
            // Add More parameters here as needed 
            pacsData.AppendLine(GetTransferData(senderBankBIC, receiverBankBIC, senderName, receiverName, transactionId, senderAccount, senderBranchRoutingNo, sendingBankCBAccount, receiverBranchRoutingNo, receivingBankCBAccount, receiverAccount, amount, paymentPurpose));
            pacsXml.LoadXml(pacsData.ToString() + footerXML);
            return pacsXml;
        }
        private static StringBuilder GetPacsHeader()
        {
            StringBuilder pacsHeader = new StringBuilder();
            pacsHeader.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            pacsHeader.AppendLine("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            pacsHeader.AppendLine("<Revision>2.0.5</Revision>");
            pacsHeader.AppendLine("<Body>");
            pacsHeader.AppendLine("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            return pacsHeader;
        }
        private static string GetHeaderBody(string transactionId, string sendingBankBic, string pacsFormat, string bizService)
        {
            string headerBody = "<Fr>"
          + "<FIId>"
          + "<FinInstnId>"
            + "<BICFI>" + sendingBankBic + "</BICFI>"
          + "</FinInstnId>"
        + "</FIId>"
      + "</Fr>"
      + "<To>"
        + "<FIId>"
          + "<FinInstnId>"
            + "<BICFI>BBHOBDDHRTG</BICFI>"
          + "</FinInstnId>"
        + "</FIId>"
      + "</To>"
      + "<BizMsgIdr>" + transactionId + "</BizMsgIdr>"
      + "<MsgDefIdr>" + pacsFormat + "</MsgDefIdr>"
      + "<BizSvc>" + bizService + "</BizSvc>"
      + "<CreDt>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) + "</CreDt>"
    + "</AppHdr>";
            return headerBody;
        }
        private static string GetDocumentHeader()
        {
            StringBuilder docHeader = new StringBuilder();
            docHeader.AppendLine("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.04\">");
            docHeader.AppendLine("<FIToFICstmrCdtTrf>");
            return docHeader.ToString();
        }
        public static object DeclinedResponsePAIN014()
        {
            throw new NotImplementedException();
        }
        private static StringBuilder GetPacsFooter()
        {
            StringBuilder pacsFooter = new StringBuilder();
            pacsFooter.AppendLine("</FIToFICstmrCdtTrf>");
            pacsFooter.AppendLine("</Document>");
            pacsFooter.AppendLine("</Body>");
            pacsFooter.AppendLine("</DataPDU>");
            return pacsFooter;
        }
        private static string GetGroupHeader(string transactionId, string numberOfTxn)
        {
            string groupHeader = "<GrpHdr>"
          + "<MsgId>" + transactionId + "</MsgId>"
          + "<CreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</CreDtTm>"
          + "<NbOfTxs>" + numberOfTxn + "</NbOfTxs>"
          + "<SttlmInf>"
            + "<SttlmMtd>CLRG</SttlmMtd>"
          + "</SttlmInf>"
        + "</GrpHdr>";
            return groupHeader;
        }
        private static string GetTransferData(string senderBankBIC, string receiverBankBIC, string senderName, string receiverName, string transactionId, string senderAccount, string senderBranchRoutingNo, string sendingBankCBAccount, string receiverBranchRoutingNo, string receivingBankCBAccount, string receiverAccount, string amount, string paymentPurpose)
        {
            string transferData = "<CdtTrfTxInf>"
            + "<PmtId>"
                + "<InstrId>" + transactionId + "</InstrId>"
                + "<EndToEndId>" + transactionId + "</EndToEndId>"
                + "<TxId>" + transactionId + "</TxId>"
            + "</PmtId>"
             + "<PmtTpInf>"
            + "<ClrChanl>RTGS</ClrChanl>"
            + "<SvcLvl>"
              + "<Prtry>0075</Prtry>"
            + "</SvcLvl>"
            + "<LclInstrm>"
              + "<Prtry>RTGS_SSCT</Prtry>"
            + "</LclInstrm>"
            + "<CtgyPurp>"
              + "<Prtry>001</Prtry>"
            + "</CtgyPurp>"
          + "</PmtTpInf>"
            + "<IntrBkSttlmAmt Ccy=\"BDT\">" + amount + "</IntrBkSttlmAmt>"
            + "<IntrBkSttlmDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</IntrBkSttlmDt>"
            + "<ChrgBr>SHAR</ChrgBr>"
            + "<InstgAgt>"
            + "<FinInstnId>"
              + "<BICFI>" + senderBankBIC + "</BICFI>"
            + "</FinInstnId>"
          + "</InstgAgt>"
           + "<InstdAgt>"
            + "<FinInstnId>"
              + "<BICFI>" + receiverBankBIC + "</BICFI>"
            + "</FinInstnId>"
          + "</InstdAgt>"
            + "<Dbtr>"
                + "<Nm>" + senderName + "</Nm>"
            + "</Dbtr>"
            + "<DbtrAcct>"
                + "<Id>"
                   + "<Othr>"
                       + "<Id>" + senderAccount + "</Id>"
                    + "</Othr>"
               + "</Id>"
            + "</DbtrAcct>"
            + "<DbtrAgt>"
                + "<FinInstnId>"
                   + "<BICFI>" + senderBankBIC + "</BICFI>"
               + "</FinInstnId>"
               + "<BrnchId>"
              + "<Id>" + senderBranchRoutingNo + "</Id>"
            + "</BrnchId>"
           + "</DbtrAgt>"
           + "<DbtrAgtAcct>"
            + "<Id>"
              + "<Othr>"
                + "<Id>" + sendingBankCBAccount + "</Id>"
              + "</Othr>"
            + "</Id>"
          + "</DbtrAgtAcct>"
            + "<CdtrAgt>"
               + "<FinInstnId>"
                   + "<BICFI>" + receiverBankBIC + "</BICFI>"
               + "</FinInstnId>"
                + "<BrnchId>"
              + "<Id>" + receiverBranchRoutingNo + "</Id>"
            + "</BrnchId>"
           + "</CdtrAgt>"
           + "<CdtrAgtAcct>"
            + "<Id>"
              + "<Othr>"
                + "<Id>" + receivingBankCBAccount + "</Id>"
              + "</Othr>"
            + "</Id>"
          + "</CdtrAgtAcct>"
           + "<Cdtr>"
               + "<Nm>" + receiverName + "</Nm>"
           + "</Cdtr>"
            + "<CdtrAcct>"
              + "<Id>"
                + "<Othr>"
                    + "<Id>" + receiverAccount + "</Id>"
                  + "</Othr>"
              + "</Id>"
          + "</CdtrAcct>"
           + " <RmtInf>"
              + "<Ustrd>" + paymentPurpose + "</Ustrd>"
            + "</RmtInf>"
        + "</CdtTrfTxInf>"
        + "<SplmtryData>"
      + "<PlcAndNm>str1234</PlcAndNm>"
      + "<Envlp />"
    + "</SplmtryData>";
            return transferData;
        }
        #endregion

        #region Pacs.002.Message.Single
        public static XmlDocument GetDataForPacs002Single(string senderBankBIC, string transactionId, string amount, string originalMessageName)
        {
            //_ = new StringBuilder();
            XmlDocument pacsXml = new XmlDocument();
            StringBuilder footerXML = GetPacs002Footer();
            StringBuilder pacsData = GetPacs002Header();
            pacsData.AppendLine(GetHeaderBodyPacs002(transactionId, senderBankBIC, "pacs.002.001.05", "RTGS"));
            pacsData.AppendLine(GetDocumentHeaderPacs002());
            pacsData.AppendLine(GetPacs002GroupHeader(transactionId));
            pacsData.AppendLine(GetOriginalGroupStatus(transactionId, originalMessageName));
            pacsData.AppendLine(GetTransactionInfoAndStatusPacs002(senderBankBIC, transactionId, amount));
            pacsXml.LoadXml(pacsData.ToString() + footerXML);
            return pacsXml;
        }
        private static StringBuilder GetPacs002Header()
        {
            StringBuilder pacsHeader = new StringBuilder();
            pacsHeader.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            pacsHeader.AppendLine("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            pacsHeader.AppendLine("<Revision>2.0.5</Revision>");
            pacsHeader.AppendLine("<Body>");
            pacsHeader.AppendLine("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            return pacsHeader;
        }
        private static string GetHeaderBodyPacs002(string transactionId, string sendingBankBic, string pacsFormat, string bizService)
        {
            string headerBody = "<Fr>"
          + "<FIId>"
          + "<FinInstnId>"
            + "<BICFI>BBHOBDDHRTG</BICFI>"
          + "</FinInstnId>"
        + "</FIId>"
      + "</Fr>"
      + "<To>"
        + "<FIId>"
          + "<FinInstnId>"
            + "<BICFI>" + sendingBankBic + "</BICFI>"
          + "</FinInstnId>"
        + "</FIId>"
      + "</To>"
      + "<BizMsgIdr>" + transactionId + "</BizMsgIdr>"
      + "<MsgDefIdr>" + pacsFormat + "</MsgDefIdr>"
      + "<BizSvc>" + bizService + "</BizSvc>"
      + "<CreDt>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) + "</CreDt>"
    + "</AppHdr>";
            return headerBody;
        }
        private static string GetDocumentHeaderPacs002()
        {
            StringBuilder docHeader = new StringBuilder();
            docHeader.AppendLine("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.002.001.05\">");
            docHeader.AppendLine("<FIToFIPmtStsRpt>");
            return docHeader.ToString();
        }
        private static StringBuilder GetPacs002Footer()
        {
            StringBuilder pacsFooter = new StringBuilder();
            pacsFooter.AppendLine("</FIToFIPmtStsRpt>");
            pacsFooter.AppendLine("</Document>");
            pacsFooter.AppendLine("</Body>");
            pacsFooter.AppendLine("</DataPDU>");
            return pacsFooter;
        }
        private static string GetPacs002GroupHeader(string transactionId)
        {
            string groupHeader = "<GrpHdr>"
                + "<MsgId>" + transactionId + "</MsgId>"
                + "<CreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</CreDtTm>"
            + "</GrpHdr>";
            return groupHeader;
        }
        private static string GetOriginalGroupStatus(string transactionId, string originalMessageName)
        {
            string originalGroupStatus = "<OrgnlGrpInfAndSts>"
                + "<OrgnlMsgId>" + transactionId + "</OrgnlMsgId>"
                + "<OrgnlMsgNmId>" + originalMessageName + "</OrgnlMsgNmId>"
                + "<OrgnlCreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</OrgnlCreDtTm>"
            + "<GrpSts>ACSC</GrpSts>"
            + "<StsRsnInf>"
                + "<Rsn>"
                    + "<Prtry>SETL</Prtry>"
                + "</Rsn>"
            + "</StsRsnInf>"
                + "</OrgnlGrpInfAndSts>";
            return originalGroupStatus;
        }
        private static string GetTransactionInfoAndStatusPacs002(string senderBic, string transactionId, string amount)
        {
            string transactionInfoAndStatus = "<TxInfAndSts>"
                + "<OrgnlInstrId>" + transactionId + "</OrgnlInstrId>"
                + "<OrgnlEndToEndId>" + transactionId + "</OrgnlEndToEndId>"
                + "<OrgnlTxId>" + transactionId + "</OrgnlTxId>"
                + "<TxSts>ACSC</TxSts>"
                + "<StsRsnInf>"
                    + "<Rsn>"
                        + "<Prtry>SETL</Prtry>"
                    + "</Rsn>"
                + "</StsRsnInf>"
                + "<InstgAgt>"
                    + "<FinInstnId>"
                        + "<BICFI>" + senderBic + "</BICFI>"
                    + "</FinInstnId>"
                + "</InstgAgt>"
                + "<OrgnlTxRef>"
                    + "<IntrBkSttlmDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</IntrBkSttlmDt>"
                    + "<IntrBkSttlmAmt Ccy=\"BDT\">" + amount + "</IntrBkSttlmAmt>"
                + "</OrgnlTxRef>"
            + "</TxInfAndSts>";

            return transactionInfoAndStatus;
        }

        #endregion

        #region Pacs.009.Message
        public static XmlDocument GetDataForPacs009Single(string senderBankBIC, string receiverBankBIC, string transactionId, string amount, string senderBranchRoutingNo, string sendingBankCBAccount, string receiverBranchRoutingNo, string receivingBankCBAccount, string paymentPurpose)
        {
            // _ = new StringBuilder();
            XmlDocument pacsXml = new XmlDocument();
            StringBuilder footerXML = GetPacs009Footer();
            StringBuilder pacsData = GetPacsHeader009();
            pacsData.AppendLine(GetHeaderBody(transactionId, senderBankBIC, "pacs.009.001.04", "RTGS_FICT"));
            pacsData.AppendLine(GetDocumentHeader009());
            pacsData.AppendLine(GetGroupHeader(transactionId, "1"));
            pacsData.AppendLine(GetTransferTransactionInfoPacs009(senderBankBIC, receiverBankBIC, transactionId, amount, senderBranchRoutingNo, sendingBankCBAccount, receiverBranchRoutingNo, receivingBankCBAccount, paymentPurpose));
            pacsXml.LoadXml(pacsData.ToString() + footerXML);
            return pacsXml;
        }
        private static StringBuilder GetPacsHeader009()
        {
            StringBuilder pacsHeader = new StringBuilder();
            pacsHeader.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            pacsHeader.AppendLine("<DataPDU xmlns=\"urn:swift:saa:xsd:saa.2.0\">");
            pacsHeader.AppendLine("<Revision>2.0.5</Revision>");
            pacsHeader.AppendLine("<Body>");
            pacsHeader.AppendLine("<AppHdr xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            return pacsHeader;
        }
        private static string GetDocumentHeader009()
        {
            StringBuilder docHeader = new StringBuilder();
            docHeader.AppendLine("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.009.001.04\">");
            docHeader.AppendLine("<FICdtTrf>");
            return docHeader.ToString();
        }
        private static StringBuilder GetPacs009Footer()
        {
            StringBuilder pacsFooter = new StringBuilder();
            pacsFooter.AppendLine("</FICdtTrf>");
            pacsFooter.AppendLine("</Document>");
            pacsFooter.AppendLine("</Body>");
            pacsFooter.AppendLine("</DataPDU>");
            return pacsFooter;
        }
        public static string GetTransferTransactionInfoPacs009(string senderBankBIC, string receiverBankBIC, string transactionId, string amount, string senderBranchRoutingNo, string sendingBankCBAccount, string receiverBranchRoutingNo, string receivingBankCBAccount, string paymentPurpose)
        {
            string transferData = "<CdtTrfTxInf>"
            + "<PmtId>"
                + "<InstrId>" + transactionId + "</InstrId>"
                + "<EndToEndId>" + transactionId + "</EndToEndId>"
                + "<TxId>" + transactionId + "</TxId>"
            + "</PmtId>"
            + "<PmtTpInf>"
            + "<ClrChanl>RTGS</ClrChanl>"
            + "<SvcLvl>"
              + "<Prtry>0075</Prtry>"
            + "</SvcLvl>"
            + "<LclInstrm>"
              + "<Prtry>RTGS_FICT</Prtry>"       // Default for type PACS.009
            + "</LclInstrm>"
            + "<CtgyPurp>"
              + "<Prtry>001</Prtry>"
            + "</CtgyPurp>"
          + "</PmtTpInf>"
            + "<IntrBkSttlmAmt Ccy=\"BDT\">" + amount + "</IntrBkSttlmAmt>"
            + "<IntrBkSttlmDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</IntrBkSttlmDt>"
             + "<InstgAgt>"
            + "<FinInstnId>"
              + "<BICFI>" + senderBankBIC + "</BICFI>"
            + "</FinInstnId>"
          + "</InstgAgt>"
          + "<InstdAgt>"
            + "<FinInstnId>"
              + "<BICFI>" + receiverBankBIC + "</BICFI>"
            + "</FinInstnId>"
          + "</InstdAgt>"
            + "<Dbtr>"
                + "<FinInstnId>"
                    + "<BICFI>" + senderBankBIC + "</BICFI>"
                + "</FinInstnId>"
                + "<BrnchId>"
                    + "<Id>" + senderBranchRoutingNo + "</Id>"
                + "</BrnchId>"
            + "</Dbtr>"
             + "<DbtrAcct>"
                + "<Id>"
                   + "<Othr>"
                       + "<Id>" + sendingBankCBAccount + "</Id>"
                    + "</Othr>"
               + "</Id>"
            + "</DbtrAcct>"
            + "<Cdtr>"
                + "<FinInstnId>"
                    + "<BICFI>" + receiverBankBIC + "</BICFI>"
                + "</FinInstnId>"
                + "<BrnchId>"
                    + "<Id>" + receiverBranchRoutingNo + "</Id>"
                + "</BrnchId>"
            + "</Cdtr>"
            + "<CdtrAcct>"
                + "<Id>"
                    + "<Othr>"
                        + "<Id>" + receivingBankCBAccount + "</Id>"
                    + "</Othr>"
                + "</Id>"
            + "</CdtrAcct>"
            + "<InstrForNxtAgt>"
            + "<InstrInf>" + paymentPurpose + "</InstrInf>"
          + "</InstrForNxtAgt>"
        + "</CdtTrfTxInf>";
            return transferData;
        }
        #endregion

        #region Request To Pay

        #region PAIN.013
        public static XmlDocument GetDataForPAIN013(string transactionId, string initiatorName, string initiatorId, string debtorName, string debtorId,
            string debtorAccount, string debtorAgentBIC, string debtorAgentName, string instructedAmount, string creditorAgentBIC, string creditorAgentName, string creditorName,
            string creditorId, string creditorAccount)
        {
            //_ = new StringBuilder();
            XmlDocument pain013Xml = new XmlDocument();
            StringBuilder pain013Data = GetPain013Header();
            pain013Data.AppendLine(GetPAIN013GroupHeader(transactionId, initiatorName, initiatorId));
            pain013Data.AppendLine(GetPAIN013PaymentGroupInfo(transactionId, debtorName, debtorId, debtorAccount, debtorAgentBIC, debtorAgentName, instructedAmount, creditorAgentBIC, creditorAgentName, creditorName, creditorId, creditorAccount));
            pain013Xml.LoadXml(pain013Data.ToString());
            return pain013Xml;
        }
        private static StringBuilder GetPain013Header()
        {
            StringBuilder painHeader = new StringBuilder();
            painHeader.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            painHeader.AppendLine("<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:pain.013.001.06\">");
            return painHeader;
        }
        private static string GetPAIN013GroupHeader(string transactionId, string initiatorName, string initiatorId)
        {
            string groupHeader = "<CdtrPmtActvtnReq><GrpHdr>" +
                              "<MsgId>" + transactionId + "</MsgId >" +
                              "<CreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</CreDtTm>" +
                              "<NbOfTxs>1</NbOfTxs>" + //numberOfTransactions
                              "<InitgPty>" +
                                  "<Nm>" + initiatorName + "</Nm>" +
                                  "<Id>" +
                                      "<OrgId>" +
                                          "<Othr>" +
                                              "<Id>" + initiatorId + "</Id>" +  // Any BIC/Unique ID
                                              "<SchmeNm>" +
                                                  "<Cd>IDTP</Cd>" +
                                              "</SchmeNm>" +
                                          "</Othr>" +
                                      "</OrgId>" +
                                  "</Id>" +
                                  "<CtryOfRes>BD</CtryOfRes>" +
                              "</InitgPty>" +
                          "</GrpHdr>";
            return groupHeader;
        }
        private static string GetPAIN013PaymentGroupInfo(string transactionId, string debtorName, string debtorId, string debtorAccount, string debtorAgentBIC, string debtorAgentName,
            string instructedAmount, string creditorAgentBIC, string creditorAgentName, string creditorName, string creditorId, string creditorAccount)
        {
            string groupHeader = "<PmtInf>" +
                            "<PmtInfId>" + transactionId + "</PmtInfId>" +
                            "<PmtMtd>TRF</PmtMtd>" +
                            "<PmtTpInf>" +
                                "<InstrPrty>NORM</InstrPrty>" +
                                "<SvcLvl>" +
                                    "<Cd>URGP</Cd>" +
                                "</SvcLvl>" +
                                "<CtgyPurp>" +
                                    "<Cd>CASH</Cd>" +
                                "</CtgyPurp>" +
                            "</PmtTpInf>" +
                            "<ReqdExctnDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</ReqdExctnDt>" +
                            "<Dbtr>" +
                                "<Nm>" + debtorName + "</Nm>" +
                                    "<Id>" +
                                        "<OrgId>" +
                                            "<Othr>" +
                                                "<Id>" + debtorId + "</Id>" +
                                                "<SchmeNm>" +
                                                    "<Cd>CUST</Cd>" +
                                                "</SchmeNm>" +
                                            "</Othr>" +
                                        "</OrgId>" +
                                    "</Id>" +
                                    "<CtryOfRes>BD</CtryOfRes>" +
                            "</Dbtr>" +
                            "<DbtrAcct>" +
                                "<Id>" +
                                    "<Othr>" +
                                        "<Id>" + debtorAccount + "</Id>" +
                                    "</Othr>" +
                                "</Id>" +
                            "</DbtrAcct>" +
                            "<DbtrAgt>" +
                                "<FinInstnId>" +
                                    "<ClrSysMmbId>" +
                                        "<ClrSysId>" +
                                            "<Cd>" + debtorAgentBIC + "</Cd>" +
                                        "</ClrSysId>" +
                                    "</ClrSysMmbId>" +
                                     "<Nm>" + debtorAgentName + "</Nm>" +
                                    "<CdtTrfTx>" +
                                        "<PmtId>" +
                                            "<EndToEndId>" + transactionId + "</EndToEndId>" +
                                        "</PmtId>" +
                                        "<Amt>" +
                                            "<InstdAmt Ccy=\"BDT\">" + instructedAmount + "</InstdAmt>" +
                                        "</Amt>" +
                                        "<ChrgBr>SHAR</ChrgBr>" +
                                    "</CdtTrfTx>" +
                                "</FinInstnId>" +
                            "</DbtrAgt>" +
                            "<CdtrAgt>" +
                                "<FinInstnId>" +
                                    "<ClrSysMmbId>" +
                                        "<ClrSysId>" +
                                            "<Cd>" + creditorAgentBIC + "</Cd>" +
                                        "</ClrSysId>" +
                                    "</ClrSysMmbId>" +
                                    "<Nm>" + creditorAgentName + "</Nm>" +
                                "</FinInstnId>" +
                            "</CdtrAgt>" +
                            "<Cdtr>" +
                                "<Nm>" + creditorName + "</Nm>" +
                                    "<Id>" +
                                        "<OrgId>" +
                                            "<Othr>" +
                                                "<Id>" + creditorId + "</Id>" +
                                                    "<SchmeNm>" +
                                                        "<Cd>CUST</Cd>" +
                                                    "</SchmeNm>" +
                                            "</Othr>" +
                                        "</OrgId>" +
                                    "</Id>" +
                            "</Cdtr>" +
                            "<CdtrAcct>" +
                                "<Id>" +
                                    "<Othr>" +
                                        "<Id>" + creditorAccount + "</Id>" +
                                    "</Othr>" +
                                "</Id>" +
                            "</CdtrAcct>" +
                            "</PmtInf>" +
                          "</CdtrPmtActvtnReq></Document>";
            return groupHeader;
        }
        #endregion PAIN.013

        #region PAIN.014

        public static XmlDocument GetDataForPAIN014(string transactionId, string initiatorId, string initiatorName,
            string debitorAgentBic, string debitorAgentName, string debitorAccount, string debitorName, string transactionAmount,
            string creditorAgentBIC, string creditorAgentName, string creditorAccount, string creditorName)
        {
            //_ = new StringBuilder();
            XmlDocument pain014Xml = new XmlDocument();
            StringBuilder pain014Data = GetPain014Header();
            pain014Data.AppendLine(GetPAIN014GroupHeader(transactionId, initiatorName, initiatorId, creditorAgentBIC, creditorAgentName, debitorAgentBic, debitorAgentName));
            pain014Data.AppendLine(GetPAIN014OriginalGroupInformationAndStatus(transactionId, transactionAmount, initiatorId, initiatorName));
            pain014Data.AppendLine(GetOriginalPaymentInfoAndStatus(transactionId, initiatorId, initiatorName, debitorAgentBic, debitorAgentName, debitorAccount, debitorName, transactionAmount, creditorAgentBIC, creditorAgentName, creditorAccount, creditorName));
            pain014Xml.LoadXml(pain014Data.ToString());
            return pain014Xml;
        }
        private static StringBuilder GetPain014Header()
        {
            StringBuilder painHeader = new StringBuilder();
            painHeader.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            painHeader.AppendLine("<Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:pain.014.001.06\">");
            return painHeader;
        }
        private static string GetPAIN014GroupHeader(string transactionId, string initiatorName, string initiatorId, string creditorAgentBIC, string creditorAgentName, string debitorAgentBic, string debitorAgentName)
        {
            string groupHeader = "<CdtrPmtActvtnReq>" +
                            "<GrpHdr>" +
                                "<MsgId>" + transactionId + "</MsgId>" +
                                "<CreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</CreDtTm>" +
                                "<InitgPty>" +
                                    "<Nm>" + initiatorName + "</Nm>" +
                                    "<Id>" + initiatorId + "</Id>" +
                                    "<CtryOfRes>BD</CtryOfRes>" +
                                "</InitgPty>" +
                                "<DbtrAgt>" +
                                    "<FinInstnId>" +
                                        "<BICFI>" + debitorAgentBic + "</BICFI>" +
                                        "<Nm>" + debitorAgentName + "</Nm>" +
                                    "</FinInstnId>" +
                                "</DbtrAgt>" +
                                "<CdtrAgt>" +
                                    "<FinInstnId>" +
                                        "<BICFI>" + creditorAgentBIC + "</BICFI>" +
                                        "<Nm>" + creditorAgentName + "</Nm>" +
                                    "</FinInstnId>" +
                                "</CdtrAgt>" +
                            "</GrpHdr>";
            return groupHeader;
        }

        private static string GetPAIN014OriginalGroupInformationAndStatus(string originalMessageId, string transactionAmount, string initiatorId, string initiatorName)
        {
            string groupheader = "<OrgnlGrpInfAndSts>" +
                                "<OrgnlMsgId>" + originalMessageId + "</OrgnlMsgId>" +
                                "<OrgnlMsgNmId>pain.013.001.06</OrgnlMsgNmId> " + // In future we'll make it parameterised
                                "<OrgnlCreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</OrgnlCreDtTm> " +
                                "<OrgnlNbOfTxs>1</OrgnlNbOfTxs> " +
                                "<OrgnlCtrlSum>" + transactionAmount + "</OrgnlCtrlSum> " +
                                "<GrpSts>ACSC</GrpSts>" +
                                "<StsRsnInf>" +
                                    "<Orgtr>" +
                                        "<Nm>" + initiatorName + "</Nm>" +
                                        "<Id>" + initiatorId + "</Id>" +
                                        "<CtryOfRes>BD</CtryOfRes>" +
                                    "</Orgtr>" +
                                    "<Rsn/>" +
                                "</StsRsnInf>" +
                            "</OrgnlGrpInfAndSts>";
            return groupheader;
        }
        private static string GetOriginalPaymentInfoAndStatus(string originalPaymentInfoId, string initiatorId, string initiatorName, string debitorAgentBic, string debitorAgentName, string debitorAccount, string debitorName, string transactionAmount, string creditorAgentBIC, string creditorAgentName, string creditorAccount, string creditorName)
        {
            string groupData = "<OrgnlPmtInfAndSts>" +
                            "<OrgnlPmtInfId>" + originalPaymentInfoId + "</OrgnlPmtInfId>" +
                            "<OrgnlNbOfTxs>1</OrgnlNbOfTxs>" +
                            "<OrgnlCtrlSum>" + transactionAmount + "</OrgnlCtrlSum>" +
                            "<PmtInfSts>ACSC</PmtInfSts>" + // ACSC / ACCC                                                     
                            "<TxInfAndSts>" +
                                "<StsId>" + originalPaymentInfoId + "</StsId>" +
                                "<OrgnlInstrId>" + originalPaymentInfoId + "</OrgnlInstrId>" +
                                "<OrgnlEndToEndId>" + originalPaymentInfoId + "</OrgnlEndToEndId>" +
                                "<TxSts>ACSC</TxSts>" +
                                "<StsRsnInf>" +
                                    "<Orgtr>" +
                                       "<Nm>" + initiatorName + "</Nm>" +
                                        "<Id>" + initiatorId + "</Id>" +
                                        "<CtryOfRes>BD</CtryOfRes>" +
                                    "</Orgtr>" +
                                    "<Rsn/>" +
                                "</StsRsnInf>" +
                                "<PmtCondSts>" +
                                    "<AccptdAmt Ccy=\"BDT\">" + transactionAmount + "</AccptdAmt>" +
                                    "<GrntedPmt>true</GrntedPmt>" +
                                    "<EarlyPmt>true</EarlyPmt>" +
                                "</PmtCondSts>" +
                                "<DbtrDcsnDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</DbtrDcsnDtTm>" +
                                "<AccptncDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</AccptncDtTm>" +
                                "<ClrSysRef>IDTP</ClrSysRef>" +     // Clearing System Reference
                                "<OrgnlTxRef>" +
                                    "<Amt>" + transactionAmount + "</Amt>" +
                                    "<ReqdExctnDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</ReqdExctnDt>" +
                                    "<XpryDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</XpryDt>" +
                                    "<PmtCond>" +
                                        "<AmtModAllwd>true</AmtModAllwd>" +
                                        "<GrntedPmtReqd>true</GrntedPmtReqd>" +
                                    "</PmtCond>" +
                                    "<PmtTpInf>" +
                                        "<InstrPrty>HIGH</InstrPrty>" +
                                        "<SvcLvl>" +
                                            "<Cd>URGP</Cd>" +    // Urgent Payment
                                        "</SvcLvl>" +
                                    "</PmtTpInf>" +
                                    "<PmtMtd>TRF</PmtMtd>" +
                                    "<Dbtr>" +
                                        "<Nm>" + debitorName + "</Nm>" +
                                    "</Dbtr>" +
                                    "<DbtrAcct>" +
                                        "<Id>" + debitorAccount + "</Id>" +
                                        "<Ccy>BDT</Ccy>" +
                                    "</DbtrAcct>" +
                                    "<DbtrAgt>" +
                                        "<FinInstnId>" +
                                        "<BICFI>" + debitorAgentBic + "</BICFI>" +
                                        "<Nm>" + debitorAgentName + "</Nm>" +
                                        "</FinInstnId>" +
                                    "</DbtrAgt>" +
                                    "<CdtrAgt>" +
                                        "<FinInstnId>" +
                                        "<BICFI>" + creditorAgentBIC + "</BICFI>" +
                                        "<Nm>" + creditorAgentName + "</Nm>" +
                                        "</FinInstnId>" +
                                    "</CdtrAgt>" +
                                    "<Cdtr>" +
                                        "<Nm>" + creditorName + "</Nm>" +
                                    "</Cdtr>" +
                                    "<CdtrAcct>" +
                                        "<Id>" + creditorAccount + "</Id>" +
                                         "<Ccy>BDT</Ccy>" +
                                    "</CdtrAcct>" +
                                "</OrgnlTxRef>" +
                            "</TxInfAndSts>" +
                        "</OrgnlPmtInfAndSts></CdtrPmtActvtnReq></Document>";
            return groupData;
        }
        #endregion PAIN.014

        #endregion Request To Pay

        #region Declined request
        public static XmlDocument DeclinedResponsePAIN014(string transactionId, string initiatorId, string initiatorName,
           string debitorAgentBic, string debitorAgentName, string debitorAccount, string debitorName, string transactionAmount,
           string creditorAgentBIC, string creditorAgentName, string creditorAccount, string creditorName, string responseStatus)
        {
            //_ = new StringBuilder();
            XmlDocument pain014Xml = new XmlDocument();
            StringBuilder pain014Data = GetPain014Header();
            pain014Data.AppendLine(GetPAIN014GroupHeader(transactionId, initiatorName, initiatorId, creditorAgentBIC, creditorAgentName, debitorAgentBic, debitorAgentName));
            pain014Data.AppendLine(GetPAIN014OriginalDeclinedGroupInformationAndStatus(transactionId, transactionAmount, initiatorId, initiatorName, responseStatus));
            pain014Data.AppendLine(GetOriginalDeclinedPaymentInfoAndStatus(transactionId, initiatorId, initiatorName, debitorAgentBic, debitorAgentName, debitorAccount, debitorName, transactionAmount, creditorAgentBIC, creditorAgentName, creditorAccount, creditorName, responseStatus));
            pain014Xml.LoadXml(pain014Data.ToString());
            return pain014Xml;
        }
        private static string GetPAIN014OriginalDeclinedGroupInformationAndStatus(string originalMessageId, string transactionAmount, string initiatorId, string initiatorName, string responseStatus)
        {
            string groupheader = "<OrgnlGrpInfAndSts>" +
                                "<OrgnlMsgId>" + originalMessageId + "</OrgnlMsgId>" +
                                "<OrgnlMsgNmId>pain.013.001.06</OrgnlMsgNmId> " + // In future we'll make it parameterised
                                "<OrgnlCreDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</OrgnlCreDtTm> " +
                                "<OrgnlNbOfTxs>1</OrgnlNbOfTxs> " +
                                "<OrgnlCtrlSum>" + transactionAmount + "</OrgnlCtrlSum> " +
                                "<GrpSts>" + responseStatus + "</GrpSts>" + //RJCT
                                "<StsRsnInf>" +
                                    "<Orgtr>" +
                                        "<Nm>" + initiatorName + "</Nm>" +
                                        "<Id>" + initiatorId + "</Id>" +
                                        "<CtryOfRes>BD</CtryOfRes>" +
                                    "</Orgtr>" +
                                    "<Rsn/>" +
                                "</StsRsnInf>" +
                            "</OrgnlGrpInfAndSts>";
            return groupheader;
        }
        private static string GetOriginalDeclinedPaymentInfoAndStatus(string originalPaymentInfoId, string initiatorId, string initiatorName, string debitorAgentBic, string debitorAgentName, string debitorAccount, string debitorName, string transactionAmount, string creditorAgentBIC, string creditorAgentName, string creditorAccount, string creditorName, string responseStatus)
        {
            string groupData = "<OrgnlPmtInfAndSts>" +
                            "<OrgnlPmtInfId>" + originalPaymentInfoId + "</OrgnlPmtInfId>" +
                            "<OrgnlNbOfTxs>1</OrgnlNbOfTxs>" +
                            "<OrgnlCtrlSum>" + transactionAmount + "</OrgnlCtrlSum>" +
                            "<PmtInfSts>" + responseStatus + "</PmtInfSts>" + // RJCT                                                     
                            "<TxInfAndSts>" +
                                "<StsId>" + originalPaymentInfoId + "</StsId>" +
                                "<OrgnlInstrId>" + originalPaymentInfoId + "</OrgnlInstrId>" +
                                "<OrgnlEndToEndId>" + originalPaymentInfoId + "</OrgnlEndToEndId>" +
                                "<TxSts>" + responseStatus + "</TxSts>" + //RJCT
                                "<StsRsnInf>" +
                                    "<Orgtr>" +
                                       "<Nm>" + initiatorName + "</Nm>" +
                                        "<Id>" + initiatorId + "</Id>" +
                                        "<CtryOfRes>BD</CtryOfRes>" +
                                    "</Orgtr>" +
                                    "<Rsn/>" +
                                "</StsRsnInf>" +
                                "<PmtCondSts>" +
                                    "<AccptdAmt Ccy=\"BDT\">" + transactionAmount + "</AccptdAmt>" +
                                    "<GrntedPmt>true</GrntedPmt>" +
                                    "<EarlyPmt>true</EarlyPmt>" +
                                "</PmtCondSts>" +
                                "<DbtrDcsnDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</DbtrDcsnDtTm>" +
                                "<AccptncDtTm>" + String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now) + "</AccptncDtTm>" +
                                "<ClrSysRef>IDTP</ClrSysRef>" +     // Clearing System Reference
                                "<OrgnlTxRef>" +
                                    "<Amt>" + transactionAmount + "</Amt>" +
                                    "<ReqdExctnDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</ReqdExctnDt>" +
                                    "<XpryDt>" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "</XpryDt>" +
                                    "<PmtCond>" +
                                        "<AmtModAllwd>true</AmtModAllwd>" +
                                        "<GrntedPmtReqd>true</GrntedPmtReqd>" +
                                    "</PmtCond>" +
                                    "<PmtTpInf>" +
                                        "<InstrPrty>HIGH</InstrPrty>" +
                                        "<SvcLvl>" +
                                            "<Cd>URGP</Cd>" +    // Urgent Payment
                                        "</SvcLvl>" +
                                    "</PmtTpInf>" +
                                    "<PmtMtd>TRF</PmtMtd>" +
                                    "<Dbtr>" +
                                        "<Nm>" + debitorName + "</Nm>" +
                                    "</Dbtr>" +
                                    "<DbtrAcct>" +
                                        "<Id>" + debitorAccount + "</Id>" +
                                        "<Ccy>BDT</Ccy>" +
                                    "</DbtrAcct>" +
                                    "<DbtrAgt>" +
                                        "<FinInstnId>" +
                                        "<BICFI>" + debitorAgentBic + "</BICFI>" +
                                        "<Nm>" + debitorAgentName + "</Nm>" +
                                        "</FinInstnId>" +
                                    "</DbtrAgt>" +
                                    "<CdtrAgt>" +
                                        "<FinInstnId>" +
                                        "<BICFI>" + creditorAgentBIC + "</BICFI>" +
                                        "<Nm>" + creditorAgentName + "</Nm>" +
                                        "</FinInstnId>" +
                                    "</CdtrAgt>" +
                                    "<Cdtr>" +
                                        "<Nm>" + creditorName + "</Nm>" +
                                    "</Cdtr>" +
                                    "<CdtrAcct>" +
                                        "<Id>" + creditorAccount + "</Id>" +
                                         "<Ccy>BDT</Ccy>" +
                                    "</CdtrAcct>" +
                                "</OrgnlTxRef>" +
                            "</TxInfAndSts>" +
                        "</OrgnlPmtInfAndSts></CdtrPmtActvtnReq></Document>";
            return groupData;
        }
        #endregion declined Response
    }


}
