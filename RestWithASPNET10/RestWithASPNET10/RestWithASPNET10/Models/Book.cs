using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10.Models
{
    public class Book
	{
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("title", TypeName = "varchar(max)")]
        public string Title { get; set; }

		[Column("author", TypeName = "varchar(max)")]
		public string Author { get; set; }

        [Required]
		[Column("price", TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		[Required]
		[Column("launch_date", TypeName = "datetime2(6)")]
        public DateTime LaunchDate { get; set; }
    }
}
