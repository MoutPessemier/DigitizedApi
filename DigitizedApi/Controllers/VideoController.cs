using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitizedApi.Controllers {
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    public class VideoController : ControllerBase {
        private readonly IVideoRepository _videoRepository;

        public VideoController(IVideoRepository videoRepository) {
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Gets all the videos
        /// </summary>
        /// <returns>A list of all the Videos</returns>
        [HttpGet]
        public IEnumerable<MyVideo> GetVideos() {
            return _videoRepository.GetAll();
        }

        /// <summary>
        /// Gets a video with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the requested video or a NotFound</returns>
        [HttpGet("{id}")]
        public ActionResult<MyVideo> GetVideoById(int id) {
            MyVideo video = _videoRepository.GetById(id);
            if(video == null) {
                return NotFound();
            } else {
                return video;
            }
        }
    }
}