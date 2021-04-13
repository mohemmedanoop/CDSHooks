using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CDSHooks.Models
{
    public class Service
    {
        public Service()
        {
            Prefetch = new Dictionary<string, string>();
        }
        public Service(string id, string hook, string name)
        {
            ID = id;
            Hook = hook;
            Title = name;
            Prefetch = new Dictionary<string, string>();
        }

        public string Hook { get; internal set; }

        public string Title { get; internal set; }

        public string Description { get; internal set; }

        public string ID { get; internal set; }
     
        public IDictionary<string, string> Prefetch { get; internal set; }
    }
    public class ServicesBase
    {
        public ServicesBase()
        {
            Services = new List<Service>();
        }
        public List<Service> Services { get; set; }
    }
}
