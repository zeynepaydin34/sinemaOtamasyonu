using sinemaOtamasyonu.Data.Base;
using sinemaOtamasyonu.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace sinemaOtamasyonu.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage ="Film adını giriniz!")]
        public string Name { get; set; }

        [Display(Name = "Film İçeriği")]
        [Required(ErrorMessage = "Film içeriği giriniz!")]
        public string Description { get; set; }

        [Display(Name = "Film Ücreti")]
        [Required(ErrorMessage = "Fiyat giriniz!")]
        public double Price { get; set; }

        [Display(Name = "Film Görseli")]
        [Required(ErrorMessage = "Film görseli giriniz!")]
        public string ImageURL { get; set; }

        [Display(Name = "Film Kategorisi Seçiniz")]
        [Required(ErrorMessage = "Film kategorisi seçiniz!")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships

        [Display(Name = "Aktör Seçiniz")]
        [Required(ErrorMessage = "Aktör seçiniz!")]
        public List<int> ActorIds{ get; set; }

        [Display(Name = "Sinema Seçiniz")]
        [Required(ErrorMessage = "Sinema seçiniz!")]
        public int CinemaId { get; set; }

        [Display(Name = "Yönetmen Seçiniz")]
        [Required(ErrorMessage = "Yönetmen seçiniz!")]
        public int ProducerId { get; set; }
       
    }
}
