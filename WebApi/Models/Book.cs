namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int BookId { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        public int? PublishingYear { get; set; }
    }
}
