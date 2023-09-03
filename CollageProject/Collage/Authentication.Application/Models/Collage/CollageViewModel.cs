using Collage.Domain.Commons;
using Collage.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collage.Application.Models.Collage
{

    public class CollageViewModel : BaseDto
    {
        public string? Name { get; set; }
        public string? Boss { get; set; }

        [NotMapped]

        public List<Faculty>? Faculties { get; set; }
    }
}
