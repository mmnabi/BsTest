using BsTest.BLL.Abstruct;
using BsTest.BLL.DTOs;
using BsTest.BLL.Models.ViewModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BsTest.Web.Controllers.ApiControllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;

        public int PageSize = 3;

        public PostsController(IPostService repo)
        {
            _postService = repo;
        }

        [ResponseType(typeof(DynamicPagedListViewModel<PostDTO>))]
        [Route("api/Posts/Page{page}/Size{size}")]
        [HttpGet]
        public HttpResponseMessage GetPostsPaginated(int page = 1, int size = 5)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _postService.GetDynamicPagedPostList(page, size));
        }

        [ResponseType(typeof(DynamicPagedListViewModel<PostDTO>))]
        [Route("api/Posts/Page{page}/Size{size}/{searchQuery}")]
        [HttpGet]
        public HttpResponseMessage GetFilteredPagedPostsList(int page = 1, int size = 5, string searchQuery = null)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Search input invalid");
            }
            return Request.CreateResponse(HttpStatusCode.OK, _postService.GetDynamicFilteredPagedPostsList(page, size, searchQuery));
        }
    }
}
