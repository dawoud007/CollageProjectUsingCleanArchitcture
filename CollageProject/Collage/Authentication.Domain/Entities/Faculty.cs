using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class Faculty : BaseEntity
    {

        public string Name { get; set; }

        [NotMapped]
        public Guid? CollageId { get; set; }
        [NotMapped]
        public Collages? Collage { get; set; }
        [NotMapped]

        public List<Student>? Students { get; set; }
        [NotMapped]

        public List<Professor>? Professors { get; set; }
        [NotMapped]

        public List<Worker>? Workers { get; set; }
    }


}
