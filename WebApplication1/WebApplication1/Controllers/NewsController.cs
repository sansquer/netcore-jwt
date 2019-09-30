using System;
using System.Collections.Generic;
using HNWrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly HNWrapperService hnWrapperService;
        private readonly IConfiguration configuration;

        public NewsController(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            hnWrapperService = new HNWrapperService(configuration["HN:Url"]);
        }

        /// <summary>
        /// Get top 10 new items
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("new")]
        public ActionResult<IEnumerable<string>> GetNewItems()
        {
            Items newItems = hnWrapperService.GetNewStories();

            return Ok(newItems);
        }

        /// <summary>
        /// Get top 10 top items
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("top")]
        public ActionResult<IEnumerable<string>> GetTopItems()
        {
            Items topItems = hnWrapperService.GetTopStories();

            return Ok(topItems);
        }

        /// <summary>
        /// Get top 10 best items
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("best")]
        public ActionResult<IEnumerable<string>> GetBestItems()
        {
            Items bestItems = hnWrapperService.GetBestStories();

            return Ok(bestItems);
        }
    }
}