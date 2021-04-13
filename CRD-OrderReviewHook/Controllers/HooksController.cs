using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDSHooks.Models;
using CDSHooks.Utilities;
using CRD_OrderReviewHook.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CDSHooks.Controllers
{
    [Route("cds-services")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class HooksController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<ServicesBase> Get()
        {
            Service service = new Service()
            {
                ID = "OrderReview",
                Hook = "order-review",
                Description = "Get information regarding the coverage requirements for durable medical equipment",
                Title = "order-review : Coverage Requirements Discovery"
            };
            service.Prefetch.Add("patient", "Patient/{{context.patientId}}");
            service.Prefetch.Add("nutritionOrderBundle", "NutritionOrder?_id={{context.orders.NutritionOrder.id}}&_include=NutritionOrder:patient&_include=NutritionOrder:provider&_include=NutritionOrder:requester&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=NutritionOrder:encounter&_include=Encounter:location&_include=NutritionOrder:insurance:Coverage");
            service.Prefetch.Add("serviceRequestBundle", "ServiceRequest?_id={{context.orders.ServiceRequest.id}}&_include=ServiceRequest:patient&_include=ServiceRequest:performer&_include=ServiceRequest:requester&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=ServiceRequest:insurance:Coverage");
            service.Prefetch.Add("medicationRequestBundle", "MedicationRequest?_id={{context.medications.MedicationRequest.id}}&_include=MedicationRequest:patient&_include=MedicationRequest:intended-dispenser&_include=MedicationRequest:intended-performer&_include:recurse=PractitionerRole:location&_include=MedicationRequest:requester:PractitionerRole&_include=MedicationRequest:medication&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=MedicationRequest:insurance:Coverage");
            service.Prefetch.Add("deviceRequestBundle", "DeviceRequest?_id={{context.orders.DeviceRequest.id}}&_include=DeviceRequest:patient&_include=DeviceRequest:performer&_include=DeviceRequest:requester&_include=DeviceRequest:device&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include:recurse=PractitionerRole:location&_include:iterate=PractitionerRole:location&_include=DeviceRequest:insurance:Coverage");
            service.Prefetch.Add("supplyRequestBundle", "SupplyRequest?_id={{context.orders.SupplyRequest.id}}&_include=SupplyRequest:patient&_include=SupplyRequest:supplier:Organization&_include=SupplyRequest:requester:Practitioner&_include=SupplyRequest:requester:Organization&_include=SupplyRequest:Requester:PractitionerRole&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=SupplyRequest:insurance:Coverage");

            Service service1 = new Service()
            {
                ID = "OrderSign",
                Hook = "order-sign",
                Description = "Get information regarding the coverage requirements for durable medical equipment",
                Title = "order-review : Coverage Requirements Discovery"
            };
            service1.Prefetch.Add("patient", "Patient/{{context.patientId}}");
            service1.Prefetch.Add("nutritionOrderBundle", "NutritionOrder?_id={{context.orders.NutritionOrder.id}}&_include=NutritionOrder:patient&_include=NutritionOrder:provider&_include=NutritionOrder:requester&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=NutritionOrder:encounter&_include=Encounter:location&_include=NutritionOrder:insurance:Coverage");
            service1.Prefetch.Add("serviceRequestBundle", "ServiceRequest?_id={{context.orders.ServiceRequest.id}}&_include=ServiceRequest:patient&_include=ServiceRequest:performer&_include=ServiceRequest:requester&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=ServiceRequest:insurance:Coverage");
            service1.Prefetch.Add("medicationRequestBundle", "MedicationRequest?_id={{context.medications.MedicationRequest.id}}&_include=MedicationRequest:patient&_include=MedicationRequest:intended-dispenser&_include=MedicationRequest:intended-performer&_include:recurse=PractitionerRole:location&_include=MedicationRequest:requester:PractitionerRole&_include=MedicationRequest:medication&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=MedicationRequest:insurance:Coverage");
            service1.Prefetch.Add("deviceRequestBundle", "DeviceRequest?_id={{context.orders.DeviceRequest.id}}&_include=DeviceRequest:patient&_include=DeviceRequest:performer&_include=DeviceRequest:requester&_include=DeviceRequest:device&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include:recurse=PractitionerRole:location&_include:iterate=PractitionerRole:location&_include=DeviceRequest:insurance:Coverage");
            service1.Prefetch.Add("supplyRequestBundle", "SupplyRequest?_id={{context.orders.SupplyRequest.id}}&_include=SupplyRequest:patient&_include=SupplyRequest:supplier:Organization&_include=SupplyRequest:requester:Practitioner&_include=SupplyRequest:requester:Organization&_include=SupplyRequest:Requester:PractitionerRole&_include=PractitionerRole:organization&_include=PractitionerRole:practitioner&_include=SupplyRequest:insurance:Coverage");



            //Sample Just to check using CDS Hooks Sandbook as Order Review is not part of the implementation
            Service service2 = new Service()
            {
                ID = "PatientGreeting",
                Hook = "patient-view",
                Description = "Get information regarding the coverage requirements for durable medical equipment",
                Title = "order-review : Coverage Requirements Discovery"
            };
    
            service2.Prefetch.Add("patient", "Patient/{{context.Patient.id}}");

            ServicesBase serviceBase = new ServicesBase();
            serviceBase.Services.Add(service);
            serviceBase.Services.Add(service1);
            serviceBase.Services.Add(service2);
            
            return serviceBase;
        }

        [HttpPost("OrderReview")]
        public ActionResult<Dictionary<string, List<Card>>> OrderReview()
        {
            return OrderReviewHook();

        }

        [HttpPost("OrderSign")]
        public ActionResult<Dictionary<string, List<Card>>> OrderSign()
        {
            return OrderReviewHook();

        }

        //Sample Just to check using CDS Hooks Sandbook as Order Review is not part of the implementation
        [HttpPost("PatientGreeting")]
        public ActionResult<Dictionary<string, List<Card>>> PatientGreeting()
        {
            return OrderReviewHook();

        }


        private ActionResult<Dictionary<string, List<Card>>> OrderReviewHook()
        {
            string input;
            Dictionary<string, List<Card>> cards = new Dictionary<string, List<Card>>();
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    input = reader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(input))
                {
                    return StatusCode(422, "Empty Input Details");
                }
                OrderReviewRequest orderReviewRequest = JsonConvert.DeserializeObject<OrderReviewRequest>(input);
                GetPatientDetails(orderReviewRequest);         

                cards.Add("cards", Helper.GetResultCardDetails("Humana", "Complete DTR/ CQL Questionnaire", Indicator.Success,
                    "Pior Auth Required", url: "https://localhost:44347/Home/Launch", urlLabel: "SmartApplication"));
                return Ok(cards);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "System Internal Exception Not able to parse JSON");
            }
        }

        private void GetPatientDetails(OrderReviewRequest orderReviewRequest)
        {
            try
            {


                var humanaFhirEndPoint = new Uri("https://api.logicahealth.org/HumanaR4/open");
                FhirClient humanaFhir = new FhirClient(humanaFhirEndPoint)
                {
                    PreferredFormat = ResourceFormat.Json
                };

                Uri patientEhrEndPoint;
                FhirClient ehrfhirClient = new FhirClient(orderReviewRequest.fhirServer)
                {
                    PreferredFormat = ResourceFormat.Json
                };

                if (orderReviewRequest.fhirServer != null &&
                    orderReviewRequest.fhirServer[orderReviewRequest.fhirServer.Length - 1] == '/')
                {
                    patientEhrEndPoint = new Uri(orderReviewRequest.fhirServer + "Patient/" + orderReviewRequest.context.patientId);
                }
                else
                {
                    patientEhrEndPoint = new Uri(orderReviewRequest.fhirServer + "/Patient/" + orderReviewRequest.context.patientId);
                }

                if (orderReviewRequest.fhirAuthorization != null &&
                    !string.IsNullOrEmpty(orderReviewRequest.fhirAuthorization.access_token))
                {
                    ehrfhirClient.OnBeforeRequest += (object sender, BeforeRequestEventArgs e) =>
                    {
                        e.RawRequest.Headers.Add("Authorization", "Bearer " + orderReviewRequest.fhirAuthorization.access_token);
                    };
                }

                var reult1 = ehrfhirClient.Read<Patient>(patientEhrEndPoint.AbsoluteUri.ToString());
                var patient = humanaFhir.Update<Patient>(reult1);

            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
