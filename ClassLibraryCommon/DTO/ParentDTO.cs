using System;

namespace ClassLibraryCommon.DTO
{
    public class ParentDTO
    {

        public string Comment { get; set; }

        public DateTime DateModified { get; set; }

        public int ModifiedByUserId { get; set; }

        public ParentDTO()
        {
        }

        public ParentDTO(RoleDTO inDTO)
        {
            this.Comment = inDTO.Comment;
            this.DateModified = inDTO.DateModified;
            this.ModifiedByUserId = inDTO.ModifiedByUserId;
        }

    }
}