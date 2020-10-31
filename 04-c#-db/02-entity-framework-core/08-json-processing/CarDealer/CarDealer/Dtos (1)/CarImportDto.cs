using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarDealer.Dtos
{
    public class CarImportDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartCars { get; set; }
    }
}