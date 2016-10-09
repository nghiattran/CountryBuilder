using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class ElementarySchool : School {

		public override void CalculateEnrollment(Population population) {
			Education education = population.GetChildrenEducation();
			enrollment = Math.Min(education.GetUneducated(), GetTotalCapacity());
			education.AddEducated((int)(enrollment * ratio));
		}
	}
}