using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using specflowPoC.TestDataObjects;

namespace specflowPoC.Helpers
{
    class PayloadGenerator
    {
        public static String getLoginXML(Table dataTable)
        {
            var userData  = dataTable.CreateInstance<IntegrationAPILoginPayloadObject>();
            return "<LoginRequest>\n" +
                    "  <CommandType>" + userData.Command + "</CommandType>\n" +
                    "  <UserId>" + userData.Login + "</UserId>\n" +
                    "  <Password>" + userData.Password + "</Password>\n" +
                    "</LoginRequest>";
        }

        public static String getESlipXML(Table dataTable)
        {
            var userData = dataTable.CreateInstance<IntegrationAPIeSlipPaylodObject>();

            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                 "<eSlipRq xmlns=\"http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/\" xmlns:csio=\"http://www.CSIO.org/standards/PC_Surety/CSIO1/xml/\" xmlns:acme=\"http://www.ACME.org/standards/PC_Surety/ACME1/xml/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.CSIO.org/standards/PC_Surety/CSIO1/xml/ CSIO-v1-0-0-eSlip.xsd\">\n" +
                 "<RqUID>c15e1a3f-dc80-495a-9507-c96178e1327e</RqUID>\n" +
                 "<TransactionRequestDt>" + userData.RequestDate + "</TransactionRequestDt>\n" +
                 "<TransactionSeqNumber>1</TransactionSeqNumber>\n" +
                 "<Producer>\n" +
                 "<ItemIdInfo>\n" +
                 "<OtherIdentifier>\n" +
                 "<OtherIdTypeCd>csio:CsioNetId</OtherIdTypeCd>\n" +
                 "<OtherId>" + userData.OtherID + "</OtherId>\n" +
                 "</OtherIdentifier>\n" +
                 "</ItemIdInfo>\n" +
                 "<GeneralPartyInfo>\n" +
                 "<NameInfo>\n" +
                 "<CommlName>\n" +
                 "<CommercialName>" + userData.CommercialName + "</CommercialName>\n" +
                 "</CommlName>\n" +
                 "</NameInfo>\n" +
                 "<Addr>\n" +
                 "<Addr1>321 Main Str.</Addr1>\n" +
                 "<City>Cambridge</City>\n" +
                 "<StateProvCd>ON</StateProvCd>\n" +
                 "<PostalCode>L8Q 4O8</PostalCode>\n" +
                 "</Addr>\n" +
                 "</GeneralPartyInfo>\n" +
                 "</Producer>\n" +
                 "<InsuredOrPrincipal>\n" +
                 "<GeneralPartyInfo>\n" +
                 "<NameInfo>\n" +
                 "<CommlName>\n" +
                 "<CommercialName>Sibylle &amp; Rob Lingwood</CommercialName>\n" +
                 "</CommlName>\n" +
                 "</NameInfo>\n" +
                 "<Addr>\n" +
                 "<Addr1>3782 Easy Woods</Addr1>\n" +
                 "<Addr2>Unit 4</Addr2>\n" +
                 "<City>Prospect</City>\n" +
                 "<StateProvCd>ON</StateProvCd>\n" +
                 "<PostalCode>L8Q 4O8</PostalCode>\n" +
                 "</Addr>\n" +
                 "<Communications>\n" +
                 "<PhoneInfo>\n" +
                 "<PhoneNumber>+1-555-5551212</PhoneNumber>\n" +
                 "</PhoneInfo>\n" +
                 "<EmailInfo>\n" +
                 "<EmailAddr>" + userData.UserEmail + "</EmailAddr>\n" +
                 "</EmailInfo>\n" +
                 "<LanguageCd>" + userData.Language + "</LanguageCd>\n" +
                 "</Communications>\n" +
                 "</GeneralPartyInfo>\n" +
                 "</InsuredOrPrincipal>\n" +
                 "<PartialPolicy>\n" +
                 "<PolicyNumber>" + userData.PolicyNumber + "</PolicyNumber>\n" +
                 "<LOBCd>csio:AUTO</LOBCd>\n" +
                 "<ContractTerm>\n" +
                 "<EffectiveDt>" + userData.EffectiveDate + "</EffectiveDt>\n" +
                 "<ExpirationDt>" + userData.ExpirationDate + "</ExpirationDt>\n" +
                 "</ContractTerm>\n" +
                 "<csio:CompanyCd>XYZ</csio:CompanyCd>\n" +
                 "<GeneralPartyInfo>\n" +
                 "<NameInfo>\n" +
                 "<CommlName>\n" +
                 "<CommercialName>" + userData.InsuranceCompName + "</CommercialName>\n" +
                 "</CommlName>\n" +
                 "</NameInfo>\n" +
                 "<Addr>\n" +
                 "<Addr1>123 Bay St.</Addr1>\n" +
                 "<City>Toronto</City>\n" +
                 "<StateProvCd>ON</StateProvCd>\n" +
                 "<PostalCode>1a23b4</PostalCode>\n" +
                 "</Addr>\n" +
                 "</GeneralPartyInfo>\n" +
                 "</PartialPolicy>\n" +
                 "<BusinessPurposeTypeCd>csio:NBS</BusinessPurposeTypeCd>\n" +
                 "<!-- 1st car -->\n" +
                 "<csio:PCVEH>\n" +
                 "<Manufacturer>Ford</Manufacturer>\n" +
                 "<Model>Escape</Model>\n" +
                 "<ModelYear>2017</ModelYear>\n" +
                 "<VehIdentificationNumber>1FMCU9G92HUC02638</VehIdentificationNumber>\n" +
                 "</csio:PCVEH>\n" +
                 "<!-- 2nd car -->\n" +
                 "<csio:PCVEH>\n" +
                 "<Manufacturer>Audi</Manufacturer>\n" +
                 "<Model>A8</Model>\n" +
                 "<ModelYear>2017</ModelYear>\n" +
                 "<VehIdentificationNumber>1FMCU9G92HUC02639</VehIdentificationNumber>\n" +
                 "</csio:PCVEH>\n" +
                 "<FileAttachmentInfo>\n" +
                 "<AttachmentDesc>Policy Document</AttachmentDesc>\n" +
                 "<AttachmentTypeCd>csio:DEC</AttachmentTypeCd>\n" +
                 "<AttachmentFilename>DEC_" + userData.PolicyNumber + ".jpg</AttachmentFilename>\n" +
                 "<AttachmentContent>" + Convert.ToBase64String(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\TestFiles\alpaca5mb.jpg"))) + "</AttachmentContent>\n" +
                 "</FileAttachmentInfo>\n" +
                 "<csio:RemarksInfo>\n" +
                 "<ItemIdInfo>\n" +
                 "<csio:FixedId>Salutation</csio:FixedId>\n" +
                 "</ItemIdInfo>\n" +
                 "<RemarkText>Dear Test User,</RemarkText>\n" +
                 "</csio:RemarksInfo>\n" +
                 "\n" +
                 "<csio:RemarksInfo>\n" +
                 "<ItemIdInfo>\n" +
                 "<csio:FixedId>Customer_Message</csio:FixedId>\n" +
                 "</ItemIdInfo>\n" +
                 "<RemarkText>Did you know...</RemarkText>\n" +
                 "</csio:RemarksInfo>\n" +
                 "\n" +
                 "<csio:RemarksInfo>\n" +
                 "<ItemIdInfo>\n" +
                 "<csio:FixedId>Carrier_Details</csio:FixedId>\n" +
                 "</ItemIdInfo>\n" +
                 "<RemarkText>\n" +
                 "XYZ Insurance Company\n" +
                 "Head Office:  Toronto, Ontario\n" +
                 "Claims Service:  1-800-265-8600\t\n" +
                 "</RemarkText>\n" +
                 "</csio:RemarksInfo>\n" +
                 "\n" +
                 "<csio:RemarksInfo>\n" +
                 "<ItemIdInfo>\n" +
                 "<csio:FixedId>Broker_Details</csio:FixedId>\n" +
                 "</ItemIdInfo>\n" +
                 "<RemarkText>\n" +
                 "Test Broker\n" +
                 "Contact:  Bob Smith\n" +
                 "Telephone:  +1-514-123-1234\n" +
                 "Email:  bob@abcbrokerage.com\n" +
                 "Address:  321 Main Str., Cambridge, Ontario\n" +
                 "</RemarkText>\n" +
                 "</csio:RemarksInfo>    \n" +
                 "\n" +
                 "<csio:RemarksInfo>\n" +
                 "<ItemIdInfo>\n" +
                 "<csio:FixedId>Insured_Details</csio:FixedId>\n" +
                 "</ItemIdInfo>\n" +
                 "<RemarkText>\n" +
                 "Test User \n" +
                 "\n" +
                 "3782 Easy Woods \n" +
                 "Unit 4  \n" +
                 "Prospect, ON\n" +
                 "L8Q 4O8\n" +
                 "</RemarkText>\n" +
                 "</csio:RemarksInfo>  " +
                 "</eSlipRq>";
        }
    }
}
