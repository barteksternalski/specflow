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
            _newProject.equipments  = new List<CreateEquipment>();
            for (int i = 1; i <= payload.equipments; i++)
            {
                CreateEquipment newEq = new CreateEquipment();
                newEq.name = "equipment_" + i.ToString();
                newEq.subEquipments = new List<CreateSubEquipment>();
                for (int j = 1; j <= payload.subEquipments; j++)
                {
                    CreateSubEquipment newSubEq = new CreateSubEquipment();
                    newSubEq.name = "subEquipment_" + j.ToString();
                    newEq.subEquipments.Add(newSubEq);
                }
                _newProject.equipments.Add(newEq);
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


    }
}
