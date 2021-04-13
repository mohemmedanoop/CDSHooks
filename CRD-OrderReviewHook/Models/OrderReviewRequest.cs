using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRD_OrderReviewHook.Models
{
    public class FhirAuthorization
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string access_token { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string token_type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int expires_in { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string scope { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string subject { get; set; }
    }

    public class Coding
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string system { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }
    }

    public class CodeCodeableConcept
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Coding> coding { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string text { get; set; }
    }

    public class Subject
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Insurance
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Performer
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Resource
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string resourceType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CodeCodeableConcept codeCodeableConcept { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Subject subject { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string authoredOn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Insurance> insurance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Performer performer { get; set; }
    }

    public class Entry
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Resource resource { get; set; }
    }

    public class Orders
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string resourceType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Entry> entry { get; set; }
    }

    public class Context
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string patientId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string encounterId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Orders orders { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string userId { get; set; }
    }

    public class Coding2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string system { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }
    }

    public class CodeCodeableConcept2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Coding2> coding { get; set; }
    }

    public class Subject2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Insurance2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Address
    {
        [JsonProperty("use", NullValueHandling = NullValueHandling.Ignore)]
        public string use { get; set; }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string state { get; set; }
    }

    public class Performer2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Type
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string system { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }
    }

    public class Class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Type type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; }
    }

    public class Payor
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Practitioner
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Location
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string reference { get; set; }
    }

    public class Identifier
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string system { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; }
    }

    public class Resource2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string resourceType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CodeCodeableConcept2 codeCodeableConcept { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Subject2 subject { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string authoredOn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Insurance2> insurance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Performer2 performer { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string gender { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string birthDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Class> @class { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Payor> payor { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Practitioner practitioner { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Location> location { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Identifier> identifier { get; set; }
    }

    public class Entry2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Resource2 resource { get; set; }
    }

    public class DeviceRequestBundle
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string resourceType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Entry2> entry { get; set; }
    }

    public class Prefetch
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DeviceRequestBundle deviceRequestBundle { get; set; }
    }

    public class OrderReviewRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string hookInstance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string fhirServer { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string hook { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public FhirAuthorization fhirAuthorization { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Context context { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Prefetch prefetch { get; set; }
    }
}
