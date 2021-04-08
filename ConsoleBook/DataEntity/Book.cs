﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary.DataEntity
{
    class Book
    {
        // data
        // represents a row of data in a table
        public int BookID { get; set; } // primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string IsPaperback { get; set; }
        public DateTime PublishDate { get; set; }
        public int Author_FK { get; set; }
        public int Genre_FK { get; set; }
        public int Publisher_FK { get; set; } 
    }

}
