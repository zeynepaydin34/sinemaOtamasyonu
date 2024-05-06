using Microsoft.AspNetCore.Identity;
using sinemaOtamasyonu.Data.Enums;
using sinemaOtamasyonu.Data.Static;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Sinemalar
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Paribu Cineverse Akasya",
                            Logo = "https://pbs.twimg.com/profile_images/1658731825483640832/ic5o9flE_400x400.jpg",
                            Description = "Acıbadem Mahallesi Çeçen Sokak No:25 Üsküdar/İstanbul"
                        },
                        new Cinema()
                        {
                            Name = "Paribu Cineverse Zorlu Center",
                            Logo = "https://pbs.twimg.com/profile_images/1658731825483640832/ic5o9flE_400x400.jpg",
                            Description = "Zorlu Center AVM Beşiktaş/İstanbul"
                        },
                        new Cinema()
                        {
                            Name = "AKM Yeşilçam Sineması",
                            Logo = "https://www.turizminsesi.com/d/news/53372.jpg",
                            Description = "Atatürk Kültür Merkezi, 34435 Beyoğlu/İstanbul"
                        },
                        new Cinema()
                        {
                            Name = "Kadıköy Sineması",
                            Logo = "https://www.kadikoysinemasi.com/wp-content/uploads/2019/08/LOGOKS.png",
                            Description = "Osmanağa, Bahariye Cad. Kadıköy Pasajı No:25, 34714 Kadıköy/İstanbul"
                        },
                        new Cinema()
                        {
                            Name = "Paribu Cineverse Kocaeli",
                            Logo = "https://pbs.twimg.com/profile_images/1658731825483640832/ic5o9flE_400x400.jpg",
                            Description = "Sanayi Mah. Ömer Türkçakal Bulvarı No: 7, 41040 İzmit/Kocaeli"
                        },
                    });
                    context.SaveChanges();
                }
                //Oyuncular
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Ahmet Mümtaz Taylan",
                            Bio = "Bio",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/ae83d60d4e794cfaa9e529b34de205fe.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Zeynep Çamcı",
                            Bio = "Bio",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/zeynep-camci-2019122721493.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Necip Memili",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/45ec8046d8704d5681f1dd36e8d48f7b.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Aras Bulut İynemli",
                            Bio = "Bio",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/80040411bb3846bf8175652994878efa.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Esra Bilgiç",
                            Bio = "Bio",
                            ProfilePictureURL = "https://www.cumhuriyet.com.tr/thumbs/1520x900/Archive/2024/2/20/2177663/kapak_173948.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Yönetmenler
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Mehmet Ada Öztekin",
                            Bio = "Bio",
                            ProfilePictureURL = "https://admin.biyografya.com/_docs/photos/1c971da6a668ee39dbb24cd388d319a9.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Tolga Örnek",
                            Bio = " Bio",
                            ProfilePictureURL = "https://img05.imgsinemalar.com/images/afis_buyuk/t/tolga-ornek-1708966709.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Yorgos Lanthimos",
                            Bio = "Bio",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/e3a76cd4-a94a-4791-b0d1-553b3495739a_indir%20(1).jpg"
                        },
                        new Producer()
                        {
                            FullName = "İlker Çatak",
                            Bio = "Bio",
                            ProfilePictureURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/People/9ee1da86d86d4a74abb72bd1a4b7e5bb.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Erman Bostan",
                            Bio = "Bio",
                            ProfilePictureURL = "https://tr.web.img4.acsta.net/pictures/24/02/27/09/33/0385925.png"
                        }
                    });
                    context.SaveChanges();
                }
                //Filmler
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Arap Kadri",
                            Description = "Arap kadri film içeriği",
                            Price = 99.50,
                            ImageURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/Films/arap-kadri-20244812303976e92b90ad8546fc91c577dac0c7b180.jpg",

                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Komedi
                        },
                        new Movie()
                        {
                            Name = "Atatürk 2",
                            Description = "Atatürk 2 film içeriği",
                            Price = 119.50,
                            ImageURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/Films/ataturk-1881-1919-2-film-2023121913854c6b0e5668ef34f4aa573a01225a4beb8.jpg",

                            ProducerId = 1,
                            MovieCategory = MovieCategory.Belgesel
                        },
                        new Movie()
                        {
                            Name = "Mucize Aynalar",
                            Description = "Mucize aynalar film içeriği",
                            Price = 139.50,
                            ImageURL = "https://tr.web.img4.acsta.net/pictures/24/02/26/09/27/4719597.jpg",

                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Komedi
                        },
                        new Movie()
                        {
                            Name = "Cadı",
                            Description = "Cadı film içeriği",
                            Price = 119.50,
                            ImageURL = "https://tr.web.img3.acsta.net/img/1a/e0/1ae081c69c6f3a471daf2abd5d19d88c.jpg",

                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Dram
                        },
                        new Movie()
                        {
                            Name = "Zavallılar",
                            Description = "Zavallılar film içeriği",
                            Price = 89.50,
                            ImageURL = "https://tr.web.img4.acsta.net/c_310_420/pictures/23/09/29/13/54/3977793.jpg",

                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Bilimkurgu
                        },
                        new Movie()
                        {
                            Name = "Öğretmenler Odası",
                            Description = "Öğretmenler odası film içeriği",
                            Price = 99.50,
                            ImageURL = "https://b6s54eznn8xq.merlincdn.net/Uploads/Films/ogretmenler-odasi-2024131732280efebc6d18924a2a82028acb747623de.JPG",

                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Dram
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //kullanıcı rol belirleme işlemihttps://www.youtube.com/watch?v=6QevlnaSDRw
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //kullanıcılar
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@sinema.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed= true
                    };
                    await userManager.CreateAsync(newAdminUser,"Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@sinema.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "App Kullanıcısı",
                        UserName = "app-kullanıcı",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

