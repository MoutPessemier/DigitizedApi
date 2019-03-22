using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitizedApi.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitizedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DigitizedApi.Controllers {
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ImagesController : ControllerBase {
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        private readonly IImageRepository _imageRepository;
        private readonly IVisitorRepository _visitorRepository;

        public ImagesController(IImageRepository imageRepository, IVisitorRepository visitorRepository) {
            _imageRepository = imageRepository;
            _visitorRepository = visitorRepository;
        }

        /// <summary>
        /// Gets all the images
        /// </summary>
        /// <returns>A list of all the images</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MyImage> GetImages() {
            return _imageRepository.GetAll();
        }

        /// <summary>
        /// Gets an image with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The image</returns>
        [HttpGet("{id}")]
        public ActionResult<MyImage> GetImage(int id) {
            MyImage img = _imageRepository.GetById(id);
            if (img == null) {
                return NotFound();
            } else {
                return img;
            }
        }

        /// <summary>
        /// Adds an image
        /// </summary>
        /// <param name="img"></param>
        /// <returns>The added image</returns>
        [HttpPost]
        public ActionResult<MyImage> PostImage(MyImage img) {
            _imageRepository.Add(img);
            _imageRepository.SaveChanges();
            return CreatedAtAction(nameof(GetImage), new { id = img.Id }, img);
        }

        /// <summary>
        /// Modifies an image
        /// </summary>
        /// <param name="id"></param>
        /// <param name="img"></param>
        /// <returns>The modified image</returns>
        [HttpPut("{id}")]
        public IActionResult PutImage(int id, MyImage img) {
            if (id != img.Id) {
                return BadRequest();
            }
            _imageRepository.Update(img);
            _imageRepository.SaveChanges();
            return CreatedAtAction(nameof(GetImage), new { id = img.Id }, img);
        }

        /// <summary>
        /// Deletes an image
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted image</returns>
        [HttpDelete("{id}")]
        public ActionResult<MyImage> DeleteImage(int id) {
            MyImage image = _imageRepository.GetById(id);
            if (image == null) {
                return NotFound();
            }
            _imageRepository.Delete(image);
            _imageRepository.SaveChanges();
            return image;
        }

        /// <summary>
        /// Gets the liked images from the logged in visitor
        /// </summary>
        /// <returns></returns>
        [HttpGet("Liked")]
        public IEnumerable<MyImage> GetLiked() {
            Visitor visitor = _visitorRepository.GetBy(User.Identity.Name);
            return visitor.LikedImages;
        }
    }
}