using sinemaOtamasyonu.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace sinemaOtamasyonu.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Profil Fotoğrafı")]
        [Required(ErrorMessage = "Profil fotoğrafını giriniz!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad giriniz!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ad soyad 3 ile 50 karakter arasında olmalıdır!")]

        public string FullName { get; set; }

        [Display(Name = "Biyografi")]
        [Required(ErrorMessage ="Biyografi giriniz!")]
        public string Bio { get; set; }

        //ilişkiler
        public List<Movie>? Movies { get; set; }
    }
}
