using BsTest.DAL.Abstruct;
using BsTest.DAL.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BsTest.DAL.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }

        public BsTestDbEntities Entities => Context as BsTestDbEntities;

        public IEnumerable<Post> GetFilteredPosts(int pageIndex, int pageSize, string searchQuery, out int count)
        {
            var filteredCustomers = Entities.Posts
                        .Where(e => e.PostContent.ToLower().Contains(searchQuery.ToLower()));
            count = filteredCustomers.Count();
            return filteredCustomers
                .Include(c => c.Comments.Select(cu => cu.User))
                .OrderBy(c => c.PostId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Post> GetPosts(int pageIndex, int pageSize)
        {
            return Entities.Posts
                .Include(c => c.Comments.Select(cu => cu.User))
                .OrderBy(c => c.PostId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
