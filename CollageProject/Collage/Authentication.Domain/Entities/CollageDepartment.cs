using Collage.Domain.Commons;
using Collage.Domain.Entities.ApplicationUser;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class CollageDepartment : BaseEntity
    {
        public string Name { get; set; }

        // Other attributes related to Department
        [NotMapped]
        public Guid? ManagerId { get; set; }
        [NotMapped]

        public Professor? Manager { get; set; }
        [NotMapped]

        public List<CollageUser>? CollageUsers { get; set; }


    }

}
