using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Api.Core.Application.ViewModels
{
    public class PaginatedItemsViewModels<TEntity> where TEntity : class
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }
        
        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedItemsViewModels(int PageIndex, int PageSize, long count, IEnumarable<TEntity> data)
        {
            PageIndex = PageIndex;
            PageSize = PageSize;
            Count = count;
            Data = data;
        }
    }
}