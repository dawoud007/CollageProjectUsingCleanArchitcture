using Collage.Domain.Commons;
using Collage.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Application.Models.Subjects
{

    public class SubjectViewModel : BaseDto
    {
        public string? Code { get; set; }


        public Guid? ProfessorId { get; set; }
        [NotMapped]

        public Professor? Professor { get; set; }
        /* [NotMapped]

         public List<Student>? Students { get; set; }*/
    }
}
