using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsTest.BLL.Models.ViewModels
{
    public class DynamicPagedListViewModel<T> where T : class
    {
        public IEnumerable<T> ItemList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
