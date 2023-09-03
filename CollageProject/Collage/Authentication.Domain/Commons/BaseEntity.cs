using System.ComponentModel.DataAnnotations;

namespace Collage.Domain.Commons
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }



    }

    public class BaseDto
    {
        public Guid Id { get; set; }
    }
}