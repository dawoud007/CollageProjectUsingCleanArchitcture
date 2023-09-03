using Collage.Domain.Commons;
using Collage.Domain.Entities;

namespace Collage.Application.Models.Faculties
{

    public class FacultyViewModel : BaseDto
    {

        public string Name { get; set; }

        public Guid? CollageId { get; set; }

        public Collages? Collage { get; set; }

        /*   public List<Student>? Students { get; set; }
           [NotMapped]
           public List<Professor>? Professors { get; set; }
           [NotMapped]
           public List<Worker>? Workers { get; set; }
           // Other relationships and attributes related to Faculty*/
    }

}
