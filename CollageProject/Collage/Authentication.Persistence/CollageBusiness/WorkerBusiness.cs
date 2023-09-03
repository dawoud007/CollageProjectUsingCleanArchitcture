using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class WorkerBusiness : BaseBusiness<Worker>, IWorkerBusiness
    {
        public WorkerBusiness(IWorkerRepository WorkerRepository) : base(WorkerRepository)
        {
        }
    }
}
