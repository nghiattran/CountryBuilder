using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class HighSchool : School {
		public HighSchool(): base(1000) {

		}

		public override void CalculateEnrollment(Population population) {
			Education education = population.GetTeensEducation();
			enrollment = Math.Min(education.GetEducated(), GetTotalCapacity());
			education.AddWellEducated((int)(enrollment * ratio));
		}
	}
}