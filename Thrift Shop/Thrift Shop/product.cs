namespace Thrift_Shop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thriftshop.product")]
    public partial class product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public decimal? price { get; set; }

        [StringLength(100)]
        public string category { get; set; }

        public int? brand_id { get; set; }

        public virtual brand brand { get; set; }
    }
}
