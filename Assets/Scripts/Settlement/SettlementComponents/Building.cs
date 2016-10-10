using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Building : SettlementComponent {

		[SerializeField] ElementarySchool elementarySchool;
		[SerializeField] HighSchool highSchool;
		[SerializeField] University university;

		override public void Update () {
			UpdateEducation();
		}

		void UpdateEducation() {
			// university.CalculateEnrollment(settlementComponents.population);
			// highSchool.CalculateEnrollment(settlementComponents.population);
			elementarySchool.CalculateEnrollment(settlementComponents.population);
		}
	}
}