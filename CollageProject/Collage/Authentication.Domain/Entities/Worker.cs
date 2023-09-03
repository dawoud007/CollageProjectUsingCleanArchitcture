using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{
    public class Worker : BaseEntity
    {

        public string? Name { get; set; }
        public string? JobTitle { get; set; }

        [NotMapped]
        public Guid? FacultyId { get; set; }
        [NotMapped]
        public Faculty? Faculty { get; set; }
    }


}
