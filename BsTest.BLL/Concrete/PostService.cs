using BsTest.BLL.Abstruct;
using BsTest.BLL.DTOs;
using BsTest.BLL.Models;
using BsTest.BLL.Models.ViewModels;
using BsTest.DAL.Concrete;
using BsTest.DAL.Database;
using System;
using System.Linq;

namespace BsTest.BLL.Concrete
{
    public class PostService : IPostService
    {
        public DynamicPagedListViewModel<PostDTO> GetDynamicFilteredPagedPostsList(int pageIndex, int pageSize, string searchQuery)
        {
            using (var _unitOfWork = new UnitOfWork(new BsTestDbEntities()))
            {
                var count = 0;
                var items = _unitOfWork.Posts.GetFilteredPosts(pageIndex, pageSize, searchQuery, out count)
                        .Select(BindDbToDto).ToList();

                DynamicPagedListViewModel<PostDTO> model = new DynamicPagedListViewModel<PostDTO>
                {
                    ItemList = items,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageIndex,
                        ItemsPerPage = pageSize,
                        TotalItems = count
                    }
                };
                return model;
            }
        }

        private PostDTO BindDbToDto(Post post)
        {
            return new PostDTO
            {
                PostId = post.PostId,
                UserName = post.User.UserName,
                PostContent = post.PostContent,
                CreatedAtLocal = post.CreatedAtUtc,
                CommentCount = post.Comments.Count,
                Comments = post.Comments.Select(c => new CommentDTO
                {
                    Comment = c.Comment1,
                    UserName = c.User.UserName,
                    CreatedAtLocal = c.CreatedAtUtc,
                    Likes = c.Likes,
                    Dislikes = c.Dislikes
                })
            };
        }

        public DynamicPagedListViewModel<PostDTO> GetDynamicPagedPostList(int pageIndex, int pageSize)
        {
            using (var _unitOfWork = new UnitOfWork(new BsTestDbEntities()))
            {
                var items = _unitOfWork.Posts.GetPosts(pageIndex, pageSize)
                        .Select(BindDbToDto).ToList();

                DynamicPagedListViewModel<PostDTO> model = new DynamicPagedListViewModel<PostDTO>
                {
                    ItemList = items,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageIndex,
                        ItemsPerPage = pageSize,
                        TotalItems = _unitOfWork.Posts.Count()
                    }
                };
                return model;
            }
        }
    }
}
