using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingMedievalWikiPopulator
{
    internal class GenerationResult
    {
        public GenerationResult(string fileName, string[] lines)
        {
            this.FileName = fileName;
            this.Lines = lines;
        }

        public string FileName { get; set; }

        public string[] Lines { get; set; }
    }
}
