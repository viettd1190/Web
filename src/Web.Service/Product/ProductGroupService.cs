using System;
using System.Collections.Generic;
using System.Linq;
using Faker;
using Web.Core;
using Web.Models.Product;

namespace Web.Service.Product
{
    public interface IProductGroupService
    {
        IPagedList<ProductGroup> GetAll(string name,
                                        int page = 0,
                                        int pageSize = int.MaxValue);
    }

    public class ProductGroupService : IProductGroupService
    {
        readonly List<ProductGroup> _productGroups = new List<ProductGroup>();

        public ProductGroupService()
        {
            for (int i = 0; i < 100000; i++)
            {
                _productGroups.Add(new ProductGroup
                                   {
                                           Id = i + 1,
                                           Name = Internet.DomainName(),
                                           DateCreated = DateTime.Now,
                                           DateUpdated = DateTime.Now,
                                           UserCreated = 1,
                                           UserUpdated = 1
                                   });
            }
        }

        #region IProductGroupService Members

        public IPagedList<ProductGroup> GetAll(string name,
                                               int page = 0,
                                               int pageSize = int.MaxValue)
        {
            var productGroups = _productGroups.Where(c => string.IsNullOrEmpty(name) || c.Name.Contains(name))
                                              .OrderBy(c => c.Name)
                                              .ToList();
            return new PagedList<ProductGroup>(productGroups,
                                               page,
                                               pageSize);
        }

        #endregion
    }
}
