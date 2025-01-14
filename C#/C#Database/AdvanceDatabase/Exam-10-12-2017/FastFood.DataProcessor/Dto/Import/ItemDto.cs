﻿using System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ItemDto
    {
	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
		public string Name { get; set; }

	    [Required]
	    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
		public decimal Price { get; set; }

	    [Required]
	    [MinLength(3)]
	    [MaxLength(30)]
		public string Category { get; set; }
    }
}
