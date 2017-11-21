namespace BookShop_CA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransID { get; set; }

        public int? BookID { get; set; }

        [StringLength(120)]
        public string BookTitle { get; set; }

        public decimal? Price { get; set; }

        [StringLength(64)]
        public string CustomerName { get; set; }

        public string Address { get; set; }

        [StringLength(10)]
        public string ContactNumber { get; set; }

        public DateTime? DateOfPurchase { get; set; }
    }
}
