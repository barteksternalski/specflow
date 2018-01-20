using specflowPoC.TestDataObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC.Helpers
{
    class PayloadGenerator
    {
        public static String getLoginXML(Table dataTable)
        {
            var userData = dataTable.CreateInstance<CreateLoginPayloadFromObject>();
            return "<LoginRequest>\n" +
                    "  <CommandType>" + userData.Command + "</CommandType>\n" +
                    "  <UserId>" + userData.Login + "</UserId>\n" +
                    "  <Password>" + userData.Password + "</Password>\n" +
                    "</LoginRequest>";
        }

    }
}
