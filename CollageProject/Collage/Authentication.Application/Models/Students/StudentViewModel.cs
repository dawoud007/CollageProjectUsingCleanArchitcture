using Collage.Domain.Commons;
using Collage.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Application.Models.Students
{

    public class StudentViewModel : BaseDto
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }

        // Other attributes related to Student

        public Guid? FacultyId { get; set; }
        [NotMapped]

        public Faculty? Faculty { get; set; }
        /*  [NotMapped]

          public List<Subject>? Subjects { get; set; }*/
    }
}
