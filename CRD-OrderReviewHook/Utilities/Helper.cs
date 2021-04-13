using CDSHooks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CDSHooks.Utilities
{
    public static class Helper
    {
        public static string GetJsonFromFile(string fileName)
        {
            string description = string.Empty;
            string fileLocation = Path.Combine("Resource", fileName);
            FileStream fileStream = new FileStream(fileLocation, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                description = reader.ReadToEnd();
            }
            return description;
        }

        public static List<Card> GetResultCardDetails(string cardLabel, string cardSummary, Indicator indicator, string detail, 
            string url= null, string urlLabel = null)
        {

            List<Card> cardsDetails = new List<Card>();
            var card = Create(cardSummary, indicator, detail);

            Source source = new Source();
            source.label = string.IsNullOrEmpty(cardLabel) ? "Humana" : cardLabel;
            card.Source = source;

            
            if (!string.IsNullOrEmpty(url))
            {
                card.Links = new List<Link>()
                {
                    new Link(label:urlLabel , url:url)
                    {

                    }
                };
            }

            cardsDetails.Add(card);
            return cardsDetails;

        }

        private static Card Create(string summary, Indicator indicator, string detail)
        {
            var source = new Source();
            source.label = "Checking Pateint Details";
            Card card = new Card(summary, source, indicator, detail);
            return card;
        }
    }


}
