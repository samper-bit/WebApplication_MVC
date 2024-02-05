using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		[Display(Name = "Product Code")]
		public int ProductCode { get; set; }

		[Required]
		[MaxLength(80)]
		public string? Title { get; set; }

		[Required]
		[MaxLength(40)]
		public string? Producer { get; set; }

		[Required]
		[MaxLength(1000)]
		public string? Description { get; set; }

		[Required]
		[Display(Name = "List Price")]
		[Range(1, 10000000)]
		public double ListPrice { get; set; }

		[Required]
		[Display(Name = "Price for 1-4")]
		[Range(1, 10000000)]
		public double Price { get; set; }

		[Required]
		[Display(Name = "Price for 5+")]
		[Range(1, 10000000)]
		public double Price5 { get; set; }

		[Required]
		[Display(Name = "Price for 20+")]
		[Range(1, 10000000)]
		public double Price20 { get; set; }

		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public Category Category{ get; set; }

		public string ImageUrl { get; set; }

	}
}
