using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace sinemaOtamasyonu.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Ad Soyad")]
        public string FullName { get; set; }
    }
}
