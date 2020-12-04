using BsTest.DAL.Abstruct;
using BsTest.DAL.Database;
using System.Threading.Tasks;

namespace BsTest.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BsTestDbEntities _context;

        public UnitOfWork(BsTestDbEntities context)
        {
            _context = context;
            Posts = new PostRepository(_context);
        }
        public IPostRepository Posts { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
