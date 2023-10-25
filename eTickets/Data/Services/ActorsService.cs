
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
