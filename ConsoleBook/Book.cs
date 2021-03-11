using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Book
    {

       public string Title { get; set; }
       public string Description { get; set; }
       public double Price { get; set; }
       public bool IsPaperback { get; set; }
       public DateTime PublishDate { get; set; }
       public int Author_FK { get; set; }
       public int Genre_FK { get; set; }
       public int Publisher_FK { get; set; } 
    }



}
