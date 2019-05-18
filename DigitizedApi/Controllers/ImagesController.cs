using System.Collections.Generic;
using DigitizedApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using DigitizedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Linq;

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
        private readonly ICommentRepository _commentRepository;

        public ImagesController(IImageRepository imageRepository, IVisitorRepository visitorRepository, ICommentRepository commentRepository) {
            _imageRepository = imageRepository;
            _visitorRepository = visitorRepository;
            _commentRepository = commentRepository;
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
        /// <returns>Returns the requested image or a NotFound</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<MyImage> GetImage(int id) {
            MyImage img = _imageRepository.GetById(id);
            if (img == null) {
                return NotFound();
            } else {
                return img;
            }
        }

        /// <summary>
        /// Gets the comments of the image with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of comments</returns>
        [HttpGet("{id}/comments")]
        [AllowAnonymous]
        public IEnumerable<Comment> GetCommentsFromImage(int id) {
            return _imageRepository.GetComments(id);
        }

        /// <summary>
        /// Gets the comment with the given id from the image with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentId"></param>
        /// <returns>The requested comment or NotFound</returns>
        [HttpGet("{id}/comments/{commentId}")]
        public ActionResult<Comment> GetComment(int id, int commentId) {
            MyImage image = _imageRepository.GetById(id);
            if (image == null) {
                return NotFound();
            }
            Comment comment = image.GetComment(commentId);
            if (comment == null) {
                return NotFound();
            }
            return comment;
        }

        /// <summary>
        /// Adds a comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns>The added comment</returns>
        [HttpPost("{id}/comments")]
        public ActionResult<Comment> PostComment(int id, Comment comment) {
            MyImage image = _imageRepository.GetById(id);
            if (image == null) {
                return NotFound();
            }
            Visitor visitor = _visitorRepository.GetById(User.Identity.Name);
            if (visitor == null) {
                return NotFound();
            }
            visitor.AddComment(comment);
            image.AddComment(comment);
            _imageRepository.SaveChanges();
            return CreatedAtAction(nameof(GetComment), new { id = id, commentId = comment.Id }, comment);
        }

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentId"></param>
        /// <param name="comment"></param>
        /// <returns>The updated comment or BadRequest</returns>
        [HttpPut("{id}/comments/{commentId}")]
        public IActionResult PutComment(int id, int commentId, Comment comment) {
            MyImage image = _imageRepository.GetByIdNoTracking(id);
            if (comment.Id != commentId) {
                return BadRequest();
            }
            if (image == null) {
                return BadRequest();
            }
            _commentRepository.Update(comment);
            _commentRepository.SaveChanges();
            return CreatedAtAction(nameof(GetComment), new { id = id, commentId = comment.Id }, comment);
        }

        /// <summary>
        /// Deletes the comment with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentId"></param>
        /// <returns>The deleted commen or NotFound</returns>
        [HttpDelete("{id}/comments/{commentId}")]
        public ActionResult<Comment> DeleteComment(int id, int commentId) {
            Comment comment = _commentRepository.GetById(commentId);
            MyImage image = _imageRepository.GetById(id);
            if (comment == null || image == null) {
                return NotFound();
            }
            Visitor visitor = _visitorRepository.GetById(User.Identity.Name);
            if (visitor == null) {
                return NotFound();
            }
            image.Comments.Remove(comment);
            visitor.Comments.Remove(comment);
            _commentRepository.Delete(comment);
            _commentRepository.SaveChanges();
            return comment;
        }
    }
}

///// <summary>
///// Adds an image
///// </summary>
///// <param name="img"></param>
///// <returns>The added image</returns>
//[HttpPost]
//public ActionResult<MyImage> PostImage(MyImage img) {
//    _imageRepository.Add(img);
//    _imageRepository.SaveChanges();
//    return CreatedAtAction(nameof(GetImage), new { id = img.Id }, img);
//}

///// <summary>
///// Modifies an image
///// </summary>
///// <param name="id"></param>
///// <param name="img"></param>
///// <returns>The modified image</returns>
//[HttpPut("{id}")]
//public IActionResult PutImage(int id, MyImage img) {
//    if (id != img.Id) {
//        return BadRequest();
//    }
//    _imageRepository.Update(img);
//    _imageRepository.SaveChanges();
//    return CreatedAtAction(nameof(GetImage), new { id = img.Id }, img);
//}

///// <summary>
///// Deletes an image
///// </summary>
///// <param name="id"></param>
///// <returns>The deleted image</returns>
//[HttpDelete("{id}")]
//public ActionResult<MyImage> DeleteImage(int id) {
//    MyImage image = _imageRepository.GetById(id);
//    if (image == null) {
//        return NotFound();
//    }
//    _imageRepository.Delete(image);
//    _imageRepository.SaveChanges();
//    return image;
//}

///// <summary>
///// Gets the liked images from the logged in visitor
///// </summary>
///// <returns></returns>
//[HttpGet("Liked")]
//public IEnumerable<MyImage> GetLiked() {
//    Visitor visitor = _visitorRepository.GetBy(User.Identity.Name);
//    return visitor.LikedImages;
//}