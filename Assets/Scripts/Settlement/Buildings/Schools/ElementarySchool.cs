using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class ElementarySchool : School {

		public ElementarySchool():base(300) {
			ratio = 0.1f;
		}

		public override void CalculateEnrollment(Population population) {
			Education education = population.GetChildrenEducation();
			enrollment = Math.Min(education.GetUneducated(), GetTotalCapacity());
			education.AddEducated(GetGraduators(enrollment));
		}
	}
}