using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class CollageBusinesses : BaseBusiness<Collages>, ICollageBusiness
    {
        public CollageBusinesses(ICollageRepository cartRepository) : base(cartRepository)
        {
        }
    }
}
