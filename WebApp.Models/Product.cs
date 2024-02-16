using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApp.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

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
		//[Range(0.01, 10000000.01)]
		public double Price5 { get; set; }

		[Required]
		[Display(Name = "Price for 20+")]
		[Range(1, 10000000)]
		public double Price20 { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		[ValidateNever]
		[ForeignKey("CategoryId")]
		public Category Category{ get; set; }

		[ValidateNever]
		[Display(Name = "Image")]
		public string? ImageUrl { get; set; }

	}
}
