using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder.Buildings;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Structure : SettlementComponent {
		[Header("School buildings")]
		[SerializeField] ElementarySchool elementarySchool;
		[SerializeField] HighSchool highSchool;
		[SerializeField] University university;
		[Space(10)]

		[Header("Agriculture buildings")]
		[SerializeField] AppleOrchard appleOrchard;
		[SerializeField] Bakery bakery;
		[SerializeField] ChickenFarm chickenFarm;
		[SerializeField] DairyFarm dairyFarm;
		[SerializeField] WheatField wheatField;

		List<IProductionBuilding> productionBuildings = new List<IProductionBuilding>();

		public void ComponentStart(SettlementComponents settlementComponents) {
			base.ComponentStart(settlementComponents);

			productionBuildings.Add(appleOrchard);
			productionBuildings.Add(bakery);
			productionBuildings.Add(chickenFarm);
			productionBuildings.Add(dairyFarm);
			productionBuildings.Add(wheatField);
		}

		override public void GameUpdate () {
			UpdateEducation();

			UpdateProduction();
		}

		void UpdateEducation() {
			university.CalculateEnrollment(settlementComponents.population);
			highSchool.CalculateEnrollment(settlementComponents.population);
			elementarySchool.CalculateEnrollment(settlementComponents.population);
		}

		void UpdateProduction() {
			for (int i = 0; i < productionBuildings.Count; i++) {
				// Debug.Log();
				UpdateProduction(productionBuildings[i]);
			}
		}

		void UpdateProduction(IProductionBuilding production) {
			List<Resource> output = production.CalculateProduction(
										settlementComponents.population
									);
			
			if (output == null) return;

			for (int i = 0; i < output.Count; i++) {
				settlementComponents
					.resources
					.SetProduction(
						output[i].GetName(), 
						output[i].GetQuantity()
					);
			}
		}

		public List<IProductionBuilding> GetProductionBuildings() {
			return productionBuildings;
		}
	}
}