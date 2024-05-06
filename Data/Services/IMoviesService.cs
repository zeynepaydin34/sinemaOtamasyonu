using sinemaOtamasyonu.Data.Base;
using sinemaOtamasyonu.Data.ViewModels;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
