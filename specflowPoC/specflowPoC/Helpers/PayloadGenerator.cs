using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using specflowPoC.TestDataObjects;
using Newtonsoft.Json;

namespace specflowPoC.Helpers
{
    class PayloadGenerator
    {
        public static String getFIERequestPayload(Table dataTable)
        {
            var payload = new FIERequestPayloadObject();
            payload.input = dataTable.CreateInstance<FIEInput>();
            return JsonConvert.SerializeObject(payload);
        }

        public static String getFITRequestPayload(Table dataTable)
        {
            var payload = new FITRequestPayloadObject();
            payload.input = dataTable.CreateInstance<FITInput>();
            return JsonConvert.SerializeObject(payload);
        }

    }
}
