using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using specflowPoC.TestDataObjects;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public static String getNewProjectPayload(Table dataTable)
        {
            var payload = dataTable.CreateInstance<CreateProjectPlaceholder>();
            NewProject _newProject = new NewProject();
            _newProject.pvtDataId = payload.pvtDataId;
            _newProject.name = payload.name;
            _newProject.description = payload.description;
            _newProject.numberOfCases = payload.numberOfCases;
            _newProject.equipment  = new List<NewEquipment>();
            for (int i = 1; i <= payload.equipments; i++)
            {
                NewEquipment newEq = new NewEquipment();
                newEq.name = "equipment_" + i.ToString();
                newEq.subEquipment = new List<NewSubEquipment>();
                for (int j = 1; j <= payload.subEquipments; j++)
                {
                    NewSubEquipment newSubEq = new NewSubEquipment();
                    newSubEq.name = "subEquipment_" + j.ToString();
                    newEq.subEquipment.Add(newSubEq);
                }
                _newProject.equipment.Add(newEq);
            }

            CreateProjectRequestPayloadObject createNewProject = new CreateProjectRequestPayloadObject();
            createNewProject.project = _newProject;

            return JsonConvert.SerializeObject(createNewProject);
        }

        public static String getAspectsDetailsPayload(Table dataTable)
        {
            var payload = new AspectsDetailsObject();
            payload.aspects = dataTable.CreateInstance<Aspects>();
            return JsonConvert.SerializeObject(payload);
        }

        public static String getDeletePVTFilePayload(long pvtFileId)
        {
            PVTFileObject pvtFile = new PVTFileObject();
            pvtFile.pvtDataId = pvtFileId;
            return JsonConvert.SerializeObject(pvtFile);
        }

        public static String getPrecalcDetailsPayload(PrecalcDetailsObject _precalc)
        {
            PrecalcDetailsObject _precalcToReturn = _precalc;

            _precalcToReturn.data.standardGasDensity = Procedures.GetRandomNumber(0.00, 1000.00, 2);
            _precalcToReturn.data.standardOilDensity = Procedures.GetRandomNumber(0.00, 1000.00, 3);
            _precalcToReturn.data.standardWaterDensity = Procedures.GetRandomNumber(0.00, 1000.00, 2);

            for (int i = 0; i < _precalcToReturn.data.productionProfileData.Count; i++)
            {
                _precalcToReturn.data.productionProfileData[i].pressure = Procedures.GetRandomNumber(0.00, 1000.00, 2);
                _precalcToReturn.data.productionProfileData[i].temperature = Procedures.GetRandomNumber(0.00, 1000.00, 1);
                _precalcToReturn.data.productionProfileData[i].gasRateAtStandardConditions = Procedures.GetRandomNumber(0.00, 1000.00, 4);
                _precalcToReturn.data.productionProfileData[i].oilRateAtStandardConditions = Procedures.GetRandomNumber(0.00, 1000.00, 2);
                _precalcToReturn.data.productionProfileData[i].waterRateAtStandardConditions = Procedures.GetRandomNumber(0.00, 1000.00, 2);
            }

            return JsonConvert.SerializeObject(_precalcToReturn);
        }

    }
}
