using sinemaOtamasyonu.Data.Base;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
        
    }   
}
