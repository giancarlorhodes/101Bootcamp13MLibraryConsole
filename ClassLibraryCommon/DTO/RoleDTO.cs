using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public string Comment { get; set; }

        public RoleDTO() { }

    }
}
