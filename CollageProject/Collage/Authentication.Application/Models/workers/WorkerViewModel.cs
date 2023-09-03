using Collage.Domain.Commons;

namespace Collage.Application.Models.worker
{

    public class WorkerViewModel : BaseDto
    {

        public string Name { get; set; }
        public string JobTitle { get; set; }


        public Guid FacultyId { get; set; }

    }
}
