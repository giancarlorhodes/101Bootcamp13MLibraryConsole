using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    public class AuthorDTO
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string BirthLocation { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
