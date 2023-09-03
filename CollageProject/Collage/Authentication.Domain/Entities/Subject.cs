using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class Subject : BaseEntity
    {
        public string? Code { get; set; }

        [NotMapped]
        public Guid? ProfessorId { get; set; }
        [NotMapped]

        public Professor? Professor { get; set; }
        [NotMapped]

        public List<Student>? Students { get; set; }
    }


}
