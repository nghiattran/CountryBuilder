using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class University : School {
		public University():base(5000) {
			multiplier = 0.1f;
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
			
			adultsEducation.AddHighlyEducated(GetGraduators(
				(int)(enrollment * adultRatio))
			);
			youngAdultsEducation.AddHighlyEducated(GetGraduators(
				(int)(enrollment * (1 - adultRatio)))
			);
		}
	}
}