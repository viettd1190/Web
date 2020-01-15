using Newtonsoft.Json;
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

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("PageSize")]
        public int PageSize { get; set; }

        [JsonProperty("PageSizeOptions")]
        public string PageSizeOptions { get; set; }
    }
}
