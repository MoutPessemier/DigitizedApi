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
        private readonly IVideoRepository _videoRepository;
        private readonly IVisitorRepository _visitorRepository;
        private readonly ICommentRepository _commentRepository;

        public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, IImageRepository imageRepository, IVideoRepository videoRepository, IVisitorRepository visitorRepository, ICommentRepository commentRepository) {
            _dbContext = context;
            _userManager = userManager;
            _imageRepository = imageRepository;
            _videoRepository = videoRepository;
            _visitorRepository = visitorRepository;
            _commentRepository = commentRepository;
        }

        public async Task InitializeDataAsync() {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {

                MyImage image1 = new MyImage("Header", "ISO-200", "1/80 sec", "f/5.6", "Belgium", "../../../assets/images/IMG_9157c.jpg");
                _imageRepository.Add(image1);

                MyImage image2 = new MyImage("DisplayPic1", "ISO-100", "1/200 sec", "f/10", "Italy", "../../../assets/images/DSC_2544c2.jpg");
                _imageRepository.Add(image2);

                MyImage image3 = new MyImage("DisplayPic2", "ISO-100", "1/320 sec", "f/5.6", "Italy", "../../../assets/images/DSC_2648c3.jpg");
                _imageRepository.Add(image3);

                MyImage image4 = new MyImage("DisplayPic3", "ISO-500", "6 sec", "f/4.5", "Italy", "../../../assets/images/DSC_3043c2.jpg");
                _imageRepository.Add(image4);

                MyImage image5 = new MyImage("DisplayPic4", "ISO-100", "1/1600 sec", "f/5.6", "Italy", "../../../assets/images/DSC_2639c.jpg");
                _imageRepository.Add(image5);
                
                MyImage image6 = new MyImage("DisplayPic5", "ISO-100", "1/125 sec", "f/9", "Italy", "../../../assets/images/DSC_2682c2.jpg");
                _imageRepository.Add(image6);

                MyImage image7 = new MyImage("DisplayPic6", "ISO-640", "1/800 sec", "f/4.5", "Belgium", "../../../assets/images/DSC_3698c3.jpg");
                _imageRepository.Add(image7);

                MyImage image8 = new MyImage("DisplayPic7", "ISO-1250", "1/500 sec", "f/16", "Netherlands", "../../../assets/images/DSC_5088c.jpg");
                _imageRepository.Add(image8);

                MyImage image9 = new MyImage("DisplayPic8", "ISO-2500", "1/40 sec", "f/4.5", "Belgium", "../../../assets/images/DSC_5340.jpg");
                _imageRepository.Add(image9);

                MyImage image10 = new MyImage("DisplayPic9", "ISO-6400", "1/1000 sec", "f/13", "France", "../../../assets/images/DSC_5471c2.jpg");
                _imageRepository.Add(image10);

                _imageRepository.SaveChanges();

                MyVideo video1 = new MyVideo("https://www.youtube.com/watch?v=t7pY-PffCTo");
                _videoRepository.Add(video1);

                MyVideo video2 = new MyVideo("https://www.youtube.com/watch?v=T-9ZP7eT7oQ");
                _videoRepository.Add(video2);

                MyVideo video3 = new MyVideo("https://www.youtube.com/watch?v=Yeq9vAr037U");
                _videoRepository.Add(video3);

                _videoRepository.SaveChanges();

                Visitor visitor1 = new Visitor("Mout", "Pessemier", "moutpessemier@hotmail.com", "0032479123378", "Belgium");
                await CreateUser(visitor1.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor1);

                Visitor visitor2 = new Visitor("Leerkracht", "HoGent", "web4@hogent.be", "0032479111234", "België");
                await CreateUser(visitor2.Email, "gelukkiggeennetbeans");
                _visitorRepository.AddVisitor(visitor2);

                Visitor visitor3 = new Visitor("Nante", "Vermeulen", "nante.vermeulen@student.hogent.be", "0032579845263", "Belgium");
                await CreateUser(visitor3.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor3);

                Visitor visitor4 = new Visitor("Tom", "Clarys", "tom.clarys@student.hogent.be", "0032479547896", "Belgium");
                await CreateUser(visitor4.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor4);

                Visitor visitor5 = new Visitor("Jef", "Malfliet", "jef.malfliet@student.hogent.be", "0032479542031", "Belgium");
                await CreateUser(visitor5.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor5);

                Visitor visitor6 = new Visitor("Bram", "Vanoverbeke", "bram.vanoverbeke@student.hogent.be", "0032479102356", "Belgium");
                await CreateUser(visitor6.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor6);

                Visitor visitor7 = new Visitor("Robbe", "Van de Vyver", "robbe.vandevyver@student.hogent.be", "0032479115588", "Belgium");
                await CreateUser(visitor7.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor7);

                Visitor visitor8 = new Visitor("Indy", "Van Canegem", "indy.vancanegem@student.hogent.be", "0032479654710", "Belgium");
                await CreateUser(visitor8.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor8);

                Visitor visitor9 = new Visitor("Willem", "Hendrickx", "willem.hendrickx@student.hogent.be", "0032479205376", "Belgium");
                await CreateUser(visitor9.Email, "P@ssword1");
                _visitorRepository.AddVisitor(visitor9);

                _visitorRepository.SaveChanges();

                Comment comment1 = new Comment() { Author = "Mout Pessemier", Content = "Damn son, nice work!", MyImageId = 2, VisitorId = 1 };
                Comment comment2 = new Comment() { Author = "Tom Clarys", Content = "It's a very nice", MyImageId = 2, VisitorId = 4 };
                Comment comment3 = new Comment() { Author = "Nante Vermeulen", Content = "Good job", MyImageId = 2, VisitorId = 3 };
                image2.AddComment(comment1);
                image2.AddComment(comment2);
                image2.AddComment(comment3);
                _commentRepository.Add(comment1);
                _commentRepository.Add(comment2);
                _commentRepository.Add(comment3);

                Comment comment4 = new Comment() { Author = "Jef Malfliet", Content = "Echt een beestig goeie foto!", MyImageId = 3, VisitorId = 5 };
                Comment comment5 = new Comment() { Author = "Bram Vanoverbeker", Content = "AYYY LMAO, LMFAO, LMBOA", MyImageId = 3, VisitorId = 6 };
                image3.AddComment(comment4);
                image3.AddComment(comment5);
                _commentRepository.Add(comment4);
                _commentRepository.Add(comment5);

                Comment comment6 = new Comment() { Author = "Robbe Van de Vyver", Content = "Ik kan niet goed programmeren", MyImageId = 4, VisitorId = 7 };
                image4.AddComment(comment6);
                _commentRepository.Add(comment6);

                Comment comment7 = new Comment() { Author = "Indy Van Canegem", Content = "CSS", MyImageId = 5, VisitorId = 8 };
                Comment comment8 = new Comment() { Author = "Willem Hendrickx", Content = "Ik werk niets af", MyImageId = 5, VisitorId = 9 };
                Comment comment9 = new Comment() { Author = "Tom Clarys", Content = "Ik begin zonder inspiratie te zitten", MyImageId = 5, VisitorId = 4 };
                image5.AddComment(comment7);
                image5.AddComment(comment8);
                image5.AddComment(comment9);
                _commentRepository.Add(comment7);
                _commentRepository.Add(comment8);
                _commentRepository.Add(comment9);

                Comment comment10 = new Comment() { Author = "Bram Vanoverbeke", Content = "Ik bEn eEn ToP sPoRtEr", MyImageId = 6, VisitorId = 6 };
                Comment comment11 = new Comment() { Author = "Mout Pessemier", Content = "Me Like", MyImageId = 6, VisitorId = 1 };
                image6.AddComment(comment10);
                image6.AddComment(comment11);
                _commentRepository.Add(comment10);
                _commentRepository.Add(comment11);

                Comment comment12 = new Comment() { Author = "Nante Vermeulen", Content = "WiSkUnDe iS lEuK", MyImageId = 7, VisitorId = 3 };
                Comment comment13 = new Comment() { Author = "Jef Malfliet", Content = "KLJ Rocks", MyImageId = 7, VisitorId = 5 };
                Comment comment14 = new Comment() { Author = "Robbe Van de Vyver", Content = "Netwerken is de beste richting", MyImageId = 7, VisitorId = 7 };
                Comment comment15 = new Comment() { Author = "Indy Van Canegem", Content = "Cars Website", MyImageId = 7, VisitorId = 8 };
                Comment comment16 = new Comment() { Author = "Willem Hendrickx", Content = "Wa is ne widows server?", MyImageId = 7, VisitorId = 9 };
                image7.AddComment(comment12);
                image7.AddComment(comment13);
                image7.AddComment(comment14);
                image7.AddComment(comment15);
                image7.AddComment(comment16);
                _commentRepository.Add(comment12);
                _commentRepository.Add(comment13);
                _commentRepository.Add(comment14);
                _commentRepository.Add(comment15);
                _commentRepository.Add(comment16);

                Comment comment17 = new Comment() { Author = "Tom Clarys", Content = "Nog is gaan snowboarden?", MyImageId = 8, VisitorId = 4 };
                Comment comment18 = new Comment() { Author = "Mout Pessemier", Content = "Zeker wel!", MyImageId = 8, VisitorId = 1 };
                image8.AddComment(comment17);
                image8.AddComment(comment18);
                _commentRepository.Add(comment17);
                _commentRepository.Add(comment18);

                Comment comment19 = new Comment() { Author = "Bram Vanoverbeke", Content = "Ik ga een jaartje pauze pakken", MyImageId = 9, VisitorId = 6 };
                Comment comment20 = new Comment() { Author = "Nante Vermeulen", Content = "Ik ben slim maar studeer niet graag", MyImageId = 9, VisitorId = 3 };
                Comment comment21 = new Comment() { Author = "Jef Malfliet", Content = "Mr Shmancy Pants", MyImageId = 9, VisitorId = 5 };
                image9.AddComment(comment19);
                image9.AddComment(comment20);
                image9.AddComment(comment21);
                _commentRepository.Add(comment19);
                _commentRepository.Add(comment20);
                _commentRepository.Add(comment21);

                Comment comment22 = new Comment() { Author = "Robbe Van de Vyver", Content = "Let it all loose", MyImageId = 10, VisitorId = 7 };
                Comment comment23 = new Comment() { Author = "Indy Van Canegem", Content = "I love it <3", MyImageId = 10, VisitorId = 8 };
                Comment comment24 = new Comment() { Author = "Jef Malfliet", Content = "Teach me please!", MyImageId = 10, VisitorId = 9 };
                Comment comment25 = new Comment() { Author = "Mout Pessemier", Content = "I'm rocking that", MyImageId = 10, VisitorId = 1 };
                Comment comment26 = new Comment() { Author = "Nante Vermeulen", Content = "Ik ski liever", MyImageId = 10, VisitorId = 3 };
                Comment comment27 = new Comment() { Author = "Tom Clarys", Content = "Ooouh, kill 'em", MyImageId = 10, VisitorId = 4 };
                Comment comment28 = new Comment() { Author = "Jef Malfliet", Content = "Bah, sneeuw", MyImageId = 10, VisitorId = 5 };
                image10.AddComment(comment22);
                image10.AddComment(comment23);
                image10.AddComment(comment24);
                image10.AddComment(comment25);
                image10.AddComment(comment26);
                image10.AddComment(comment27);
                image10.AddComment(comment28);
                _commentRepository.Add(comment22);
                _commentRepository.Add(comment23);
                _commentRepository.Add(comment24);
                _commentRepository.Add(comment25);
                _commentRepository.Add(comment26);
                _commentRepository.Add(comment27);
                _commentRepository.Add(comment28);

                _commentRepository.SaveChanges();

            }
        }

        private async Task CreateUser(string email, string password) {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}

