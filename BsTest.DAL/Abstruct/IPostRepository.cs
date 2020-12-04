using BsTest.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTest.DAL.Abstruct
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPosts(int pageIndex, int pageSize);
        IEnumerable<Post> GetFilteredPosts(int pageIndex, int pageSize, string searchQuery, out int count);
    }
}
