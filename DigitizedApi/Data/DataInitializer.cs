using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Threading.Tasks;

namespace DigitizedApi.Data {
    public class DataInitializer {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageRepository _imageRepository;

        public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, IImageRepository imageRepository) {
            _dbContext = context;
            _userManager = userManager;
            _imageRepository = imageRepository;
        }

        //public async Task InitializeData() {
        //    _dbContext.Database.EnsureDeleted();
        //    if (_dbContext.Database.EnsureCreated()) {
        //    }
        //}

        public void InitializeData() {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                MyImage image1 = new MyImage("Parallax1","ISO-100","1/200 sec","f/10","Italy",Image.FromFile("DSC_2544c2.jpg"));
                _imageRepository.Add(image1);

                MyImage image2 = new MyImage("DisplayPic1", "ISO-100", "1/1600 sec", "f/5.6", "Italy", Image.FromFile("DSC_2639c.jpg"));
                _imageRepository.Add(image2);

                MyImage image3 = new MyImage("Parallax2", "ISO-100", "1/320 sec", "f/5.6", "Italy", Image.FromFile("DSC_2648c3.jpg"));
                _imageRepository.Add(image3);

                MyImage image4 = new MyImage("DisplayPic2", "ISO-100", "1/125 sec", "f/9", "Italy", Image.FromFile("DSC_2682c2.jpg"));
                _imageRepository.Add(image4);

                MyImage image5 = new MyImage("Parallax3", "ISO-500", "6 sec", "f/4.5", "Italy", Image.FromFile("DSC_3043c2.jpg"));
                _imageRepository.Add(image5);

                MyImage image6 = new MyImage("DisplayPic3", "ISO-640", "1/800 sec", "f/4.5", "Belgium", Image.FromFile("DSC_3698c3.jpg"));
                _imageRepository.Add(image6);

                MyImage image7 = new MyImage("DisplayPic4", "ISO-1250", "1/500 sec", "f/16", "Belgium", Image.FromFile("DSC_5088c.jpg"));
                _imageRepository.Add(image7);

                MyImage image8 = new MyImage("DisplayPic5", "ISO-2500", "1/40 sec", "f/4.5", "Belgium", Image.FromFile("DSC_5340.jpg"));
                _imageRepository.Add(image8);

                MyImage image9 = new MyImage("DisplayPic6", "ISO-6400", "1/1000 sec", "f/13", "France", Image.FromFile("DSC_5471.jpg"));
                _imageRepository.Add(image9);


                _imageRepository.SaveChanges();



            }
        }

        private async Task CreateUser(string email, string password) {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}

