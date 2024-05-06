using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sinemaOtamasyonu.Data;
using sinemaOtamasyonu.Data.Static;
using sinemaOtamasyonu.Data.ViewModels;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Controllers
{
    public class AccountController : Controller
    {

        //Kullanıcı giriş-çıkış ve kayıt oluşturma işlemlerihttps://www.youtube.com/watch?v=0wntO75pZUs

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager= userManager;
            _signInManager= signInManager;
            _context= context;
        }
        public async Task<IActionResult> Users()
        {
            var users= await _context.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result =await _signInManager.PasswordSignInAsync(user, loginVM.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Lütfen tekrar deneyin!";
                return View(loginVM);
            }
            TempData["Error"]="Lütfen tekrar deneyin!";
            return View(loginVM);
        }


        //register backendhttps://www.youtube.com/watch?v=Qq5cYYsnhpk&list=RDCMUCbkbOlw8snP93RJ2BhH44Qw&index=5
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Bu email zaten kullanılıyor!";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterSuccess");
        }

        //Hesaptan çıkış işlemihttps://www.youtube.com/watch?v=6UvkhJ9hdjA&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=87

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Movies");
        }

    }
}
