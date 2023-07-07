using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingMedievalWikiPopulator
{
    internal interface ISubGenerator
    {
        public IEnumerable<GenerationResult> Generate();
    }
}
