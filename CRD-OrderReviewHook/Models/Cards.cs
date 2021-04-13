using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDSHooks.Models
{

    public class Indicator
    {
        public static Indicator Success
        {
            get { return new Indicator("success"); }
        }

        public static Indicator Info
        {
            get { return new Indicator("info"); }
        }

        public static Indicator Warning
        {
            get { return new Indicator("warning"); }
        }

        public static Indicator HardStop
        {
            get { return new Indicator("hard-stop"); }
        }
        private Indicator(string value)
        {
            Value = value;
        }

        public string Value { get; internal set; }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Link
    {
        public Link(string label, string url = "",string appContext = "sample")
        {
            Label = label;
            Url = url;
            AppContext = appContext;
            Type = "smart";
        }


        public string Label { get; internal set; }

        public string Url { get; internal set; }

        public string AppContext { get; set; }

        public string Type { get; set; }
    }

    public class CardsDertails
    {
        public List<Card> Cards { get; set; }
    }

    public class Card
    {
        public Card()
        {
            Source = new Source();

        }
        public Card(string summary, Source source, Indicator indicator, string detail)
        {
            Summary = summary;
            Source = source;
            Indicator = indicator.ToString();
            Detail = detail;
            Links = new List<Link>();
            Suggestions = new List<Suggestion>();
        }

        public string Summary { get; set; }
        public Source Source { get; set; }
        public string Indicator { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        public List<Link> Links { get; set; }
        public string Detail { get; set; }

    }
    public class Source
    {
        public string label { get; set; }
    }

    public class Suggestion
    {
        public string label { get; set; }
        public string uuid { get; set; }
        public List<Action> actions { get; set; }
    }

    public class Action
    {
        public string type { get; set; }
        public string description { get; set; }
        public Resource resource { get; set; }
    }

    public class Resource
    {
        public string resourceType { get; set; }
        public string dateWritten { get; set; }
        public string status { get; set; }
        public JObject Infomarion { get; set; }
    }
}
