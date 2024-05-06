using sinemaOtamasyonu.Models;
using Microsoft.EntityFrameworkCore;
using sinemaOtamasyonu.Data.Base;

namespace sinemaOtamasyonu.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
        
    }
}
