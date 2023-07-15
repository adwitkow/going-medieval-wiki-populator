using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.ProductionBuildings
{
    public class ProductionSpeedMultiplier
    {
        [JsonConstructor]
        public ProductionSpeedMultiplier(
            [JsonProperty("outside")] double? outside,
            [JsonProperty("inside")] double? inside,
            [JsonProperty("roofed")] int? roofed,
            [JsonProperty("outsideRain")] double? outsideRain,
            [JsonProperty("outsideSnow")] double? outsideSnow,
            [JsonProperty("outsideFog")] double? outsideFog
        )
        {
            this.Outside = outside;
            this.Inside = inside;
            this.Roofed = roofed;
            this.OutsideRain = outsideRain;
            this.OutsideSnow = outsideSnow;
            this.OutsideFog = outsideFog;
        }

        [JsonProperty("outside")]
        public double? Outside { get; }

        [JsonProperty("inside")]
        public double? Inside { get; }

        [JsonProperty("roofed")]
        public int? Roofed { get; }

        [JsonProperty("outsideRain")]
        public double? OutsideRain { get; }

        [JsonProperty("outsideSnow")]
        public double? OutsideSnow { get; }

        [JsonProperty("outsideFog")]
        public double? OutsideFog { get; }
    }
}
