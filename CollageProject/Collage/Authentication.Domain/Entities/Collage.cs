using Collage.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Domain.Entities
{

    public class Collages : BaseEntity
    {
        public string? Name { get; set; }
        public string? Boss { get; set; }

        // Other attributes related to Collage
        [NotMapped]

        public List<Faculty>? Faculties { get; set; }
    }



}
