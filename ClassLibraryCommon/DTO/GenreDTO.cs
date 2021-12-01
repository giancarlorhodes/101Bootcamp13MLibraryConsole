using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    class GenreDTO
    {
        public int GenreID { get; set; }
        public bool isFiction { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
