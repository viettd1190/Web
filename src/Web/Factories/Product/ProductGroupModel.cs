using Web.Framework.Models;

namespace Web.Factories.Product
{
    public class ProductGroupModel : BaseModel
    {
        public ProductGroupModel()
        {
            if(PageSize < 1)
            {
                PageSize = 5;
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PageSize { get; set; }

        public string PageSizeOptions { get; set; }
    }
}
