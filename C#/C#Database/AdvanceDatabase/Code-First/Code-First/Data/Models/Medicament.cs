﻿using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
	    public Medicament()
	    {
		    Prescriptions = new List<PatientMedicament>();
	    }

		public int MedicamentId { get; set; }
	    public string Name { get; set; }

	    public  ICollection<PatientMedicament> Prescriptions { get; set; }
	}
}
