﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
	    public Item()
	    {
		    this.OrderItems = new List<OrderItem>();
	    }

	    public int Id { get; set; }

	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
		public string Name { get; set; }

	    //Possible need for Required
		public int CategoryId { get; set; }
		[Required]
	    public Category Category { get; set; }

		[Required]
		[Range(typeof(decimal), "0", "79228162514264337593543950335")]
		public decimal Price { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
