using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class University : School {
		public University() {
			capacity = 5000;
		}

		public override void CalculateEnrollment(Population population) {
			Education adultsEducation = population.GetAdultsEducation();
			Education youngAdultsEducation = population.GetYoungAdultsEducation();

			int totalStudent = youngAdultsEducation.GetWellEducated() 
				+ adultsEducation.GetWellEducated();

			if (totalStudent == 0)
				return;

			enrollment = Math.Min(totalStudent, GetTotalCapacity());

			float adultRatio = adultsEducation.GetWellEducated() / totalStudent;

			adultsEducation.AddHighlyEducated((int)(enrollment * adultRatio * ratio));
			youngAdultsEducation.AddHighlyEducated((int)(enrollment * (1 - adultRatio) * ratio));
		}
	}
}