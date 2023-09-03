using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class Student : BaseEntity
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }

        // Other attributes related to Student
        [NotMapped]
        public Guid? FacultyId { get; set; }
        [NotMapped]

        public Faculty? Faculty { get; set; }
        [NotMapped]

        public List<Subject>? Subjects { get; set; }
        // Other relationships and attributes related to Student
    }


}
