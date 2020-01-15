using System.Collections.Generic;
using Newtonsoft.Json;

namespace Web.Framework.Models
{
    /// <summary>
    ///     Represents the base paged list model (implementation for DataTables grids)
    /// </summary>
    public abstract class BasePagedListModel<T> : BaseModel,
                                                  IPagedModel<T>
            where T : BaseModel
    {
        /// <summary>
        ///     Gets or sets data records
        /// </summary>
        [JsonProperty("Data")]
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        ///     Gets or sets draw
        /// </summary>
        [JsonProperty("Draw")]
        public string Draw { get; set; }

        /// <summary>
        ///     Gets or sets a number of filtered data records
        /// </summary>
        [JsonProperty("RecordsFiltered")]
        public int RecordsFiltered { get; set; }

        /// <summary>
        ///     Gets or sets a number of total data records
        /// </summary>
        [JsonProperty("RecordsTotal")]
        public int RecordsTotal { get; set; }

        //TODO: remove after moving to DataTables grids
        [JsonProperty("Total")]
        public int Total { get; set; }
    }
}
