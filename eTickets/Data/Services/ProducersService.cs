using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducerService(AppDbContext context) : base(context)
        {

        }
    }
}
