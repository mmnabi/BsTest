using BsTest.BLL.DTOs;
using BsTest.BLL.Models.ViewModels;

namespace BsTest.BLL.Abstruct
{
    public interface IPostService
    {
        DynamicPagedListViewModel<PostDTO> GetDynamicPagedPostList(int pageIndex, int pageSize);
        DynamicPagedListViewModel<PostDTO> GetDynamicFilteredPagedPostsList(int pageIndex, int pageSize, string searchQuery);
    }
}
