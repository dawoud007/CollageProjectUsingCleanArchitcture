using Collage.Domain.Commons;
using Collage.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Application.Models.Professors
{

    public class ProfessorViewModel : BaseDto
    {
        public string Name { get; set; }

        // Other attributes related to Professor

        public Guid? FacultyId { get; set; }
        [NotMapped]

        public Faculty? Faculty { get; set; }
        /* [NotMapped]

         public List<Subject>? Subjects { get; set; }*/
        // Other relationships and attributes related to Professor
    }
}
