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

        public static String getNewProjectPayload(Table dataTable, long pvtFileId)
        {
            var payload = dataTable.CreateInstance<CreateProjectPlaceholder>();
            NewProject _newProject = new NewProject();
            _newProject.pvtDataId = pvtFileId;
            _newProject.pvtDataFileName = payload.fileName;
            _newProject.name = payload.name + DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss"); ;
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

            _precalcToReturn.data.standardGasDensity = Procedures.GetRandomNumber(0, 1000, 2);
            _precalcToReturn.data.standardOilDensity = Procedures.GetRandomNumber(0, 1000, 3);
            _precalcToReturn.data.standardWaterDensity = Procedures.GetRandomNumber(0, 1000, 2);

            for (int i = 0; i < _precalcToReturn.data.productionProfileData.Count; i++)
            {
                _precalcToReturn.data.productionProfileData[i].pressure = Procedures.GetRandomNumber(0, 1000, 2);
                _precalcToReturn.data.productionProfileData[i].temperature = Procedures.GetRandomNumber(0, 1000, 1);
                _precalcToReturn.data.productionProfileData[i].gasRateAtStandardConditions = Procedures.GetRandomNumber(0, 1000, 4);
                _precalcToReturn.data.productionProfileData[i].oilRateAtStandardConditions = Procedures.GetRandomNumber(0, 1000, 2);
                _precalcToReturn.data.productionProfileData[i].waterRateAtStandardConditions = Procedures.GetRandomNumber(0, 1000, 2);
            }

            return JsonConvert.SerializeObject(_precalcToReturn);
        }

        public static String getModule22UpdatePayload(GetModule22Object details, Table dataTable)
        {
            PutModule22Object _module22Data = new PutModule22Object();
            var helper = dataTable.CreateInstance<Module22Helper>();

            _module22Data.data = new Modul22PutData();
            _module22Data.data.mainPipeInsideDiameter = helper.mainPipeInsideDiameter;
            _module22Data.data.mainPipeOutsideDiameter = helper.mainPipeOutsideDiameter;
            _module22Data.data.mainPipeSpanLength = helper.mainPipeSpanLength;
            _module22Data.data.inputs = details.data.inputs;

            for (int i = 0; i < _module22Data.data.inputs.Count; i++)
            {
                _module22Data.data.inputs[i].gasFlowRate = Procedures.GetRandomNumber(0, 1, 3);
                _module22Data.data.inputs[i].oilFlowRate = Procedures.GetRandomNumber(0, 1, 3);
                _module22Data.data.inputs[i].waterFlowRate = Procedures.GetRandomNumber(0, 1, 3);
                _module22Data.data.inputs[i].gasDensity = Procedures.GetRandomNumber(100, 1000, 1);
                _module22Data.data.inputs[i].oilDensity = Procedures.GetRandomNumber(100, 1000, 1);
                _module22Data.data.inputs[i].waterDensity = Procedures.GetRandomNumber(100, 1000, 1);
                _module22Data.data.inputs[i].gasViscosity = Procedures.GetRandomNumber(0, 1, 5);
            }

            return JsonConvert.SerializeObject(_module22Data);
        }

    }
}
