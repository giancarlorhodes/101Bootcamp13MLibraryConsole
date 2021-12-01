using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    class PublisherDTO
    {
        public int PublisherID { get; set; } // Primary Key Property

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string state { get; set; }

        public int Zip { get; set; }  

    }
}
