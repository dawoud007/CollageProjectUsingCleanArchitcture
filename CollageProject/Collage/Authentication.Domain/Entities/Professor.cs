using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class Professor : BaseEntity
    {
        public string Name { get; set; }

        [NotMapped]
        public Guid? FacultyId { get; set; }
        [NotMapped]

        public Faculty? Faculty { get; set; }
        [NotMapped]

        public List<Subject>? Subjects { get; set; }
    }


}
