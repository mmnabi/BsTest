using System;
using System.Threading.Tasks;

namespace BsTest.DAL.Abstruct
{
    public interface IUnitOfWork : IDisposable
    {
        //IProductRepository Products { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
