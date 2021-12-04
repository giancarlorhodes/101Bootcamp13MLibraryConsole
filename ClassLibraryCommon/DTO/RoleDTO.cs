using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    public class RoleDTO : ParentDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public RoleDTO() : base() 
        { 
        }

        public RoleDTO(RoleDTO inDTO) : base(inDTO)
        {

            this.RoleID = inDTO.RoleID;
            this.RoleName = inDTO.RoleName;
        }

    }
}
