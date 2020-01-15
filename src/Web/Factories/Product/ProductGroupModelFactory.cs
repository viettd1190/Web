using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Framework.Models.Extensions;
using Web.Models.Product;
using Web.Service.Product;

namespace Web.Factories.Product
{
    public interface IProductGroupModelFactory
    {
        /// <summary>
        ///     Prepare product group search model
        /// </summary>
        /// <param name="searchModel">ProductGroup search model</param>
        /// <returns>ProductGroup search model</returns>
        ProductGroupSearchModel PrepareProductGroupSearchModel(ProductGroupSearchModel searchModel);

        /// <summary>
        ///     Prepare paged productGroup list model
        /// </summary>
        /// <param name="searchModel">ProductGroup search model</param>
        /// <returns>ProductGroup list model</returns>
        ProductGroupListModel PrepareProductGroupListModel(ProductGroupSearchModel searchModel);
    }

    public class ProductGroupModelFactory : IProductGroupModelFactory
    {
        readonly IMapper _mapper;

        private readonly IProductGroupService _productGroupService;

        public ProductGroupModelFactory(IProductGroupService productGroupService,
                                        IMapper mapper)
        {
            _productGroupService = productGroupService;
            _mapper = mapper;
        }

        #region IProductGroupModelFactory Members

        /// <summary>
        ///     Prepare product group search model
        /// </summary>
        /// <param name="searchModel">ProductGroup search model</param>
        /// <returns>ProductGroup search model</returns>
        public virtual ProductGroupSearchModel PrepareProductGroupSearchModel(ProductGroupSearchModel searchModel)
        {
            if(searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        ///     Prepare paged productGroup list model
        /// </summary>
        /// <param name="searchModel">ProductGroup search model</param>
        /// <returns>ProductGroup list model</returns>
        public virtual ProductGroupListModel PrepareProductGroupListModel(ProductGroupSearchModel searchModel)
        {
            if(searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get categories
            var categories = _productGroupService.GetAll(searchModel.ProductGroupName,
                                                         searchModel.Page - 1,
                                                         searchModel.PageSize);

            //prepare grid model
            var model = new ProductGroupListModel().PrepareToGrid(searchModel,
                                                                  categories,
                                                                  () =>
                                                                  {
                                                                      return _mapper.Map<IList<ProductGroupModel>>(categories);
                                                                  });

            return model;
        }

        #endregion
    }
}
