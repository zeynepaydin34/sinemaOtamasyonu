using sinemaOtamasyonu.Data.Base;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemasService(AppDbContext context):base(context)
        {

        }
    }
}
