using Collage.Domain.Commons;
using Collage.Domain.Entities;
using Collage.Domain.Entities.ApplicationUser;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Application.Models.Department
{

    public class CollageDepartmentViewModel : BaseDto
    {
        public string Name { get; set; }


        public Guid? ManagerId { get; set; }
        [NotMapped]

        public Professor? Manager { get; set; }
        [NotMapped]

        public List<CollageUser>? CollageUsers { get; set; }


    }
}
