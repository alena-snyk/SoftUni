﻿using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class ProcedureAnimalAid
    {
		public int ProcedureId { get; set; }
		[Required]
		public Procedure Procedure { get; set; }

		public int AnimalAidId { get; set; }
		[Required]
		public AnimalAid AnimalAid { get; set; }
	}
}
