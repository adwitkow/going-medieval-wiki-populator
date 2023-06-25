using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoingMedievalWikiPopulator.JsonModels.Moods;

namespace GoingMedievalWikiPopulator
{
    internal interface IGenerator
    {
        public string Directory { get; }

        public GenerationResult[] Generate();
    }
}
