using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder.Buildings;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Structure : SettlementComponent {
		[Header("School")]
		[SerializeField] ElementarySchool elementarySchool;
		[SerializeField] HighSchool highSchool;
		[SerializeField] University university;
		[Space(10)]

		[Header("Agriculture")]
		[SerializeField] AppleOrchard appleOrchard;
		[SerializeField] Bakery bakery;
		[SerializeField] ChickenFarm chickenFarm;
		[SerializeField] DairyFarm dairyFarm;
		[SerializeField] WheatField wheatField;

		override public void Update () {
			UpdateEducation();
		}

		void UpdateEducation() {
			university.CalculateEnrollment(settlementComponents.population);
			highSchool.CalculateEnrollment(settlementComponents.population);
			elementarySchool.CalculateEnrollment(settlementComponents.population);
		}
	}
}