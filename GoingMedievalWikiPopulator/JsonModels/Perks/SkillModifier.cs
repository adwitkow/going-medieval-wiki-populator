﻿using Newtonsoft.Json;

namespace GoingMedievalWikiPopulator.JsonModels.Perks
{
    public class SkillModifier
    {
        [JsonConstructor]
        public SkillModifier(
            [JsonProperty("key")] int? key,
            [JsonProperty("value")] int? value
        )
        {
            this.Key = key;
            this.Value = value;
        }

        [JsonProperty("key")]
        public int? Key { get; }

        [JsonProperty("value")]
        public int? Value { get; }
    }
}
