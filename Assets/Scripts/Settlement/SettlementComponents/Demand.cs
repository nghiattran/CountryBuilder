using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Demand : SettlementComponent {
		override public void Update () {
			AgricultureWrapper tmp = settlementComponents.resources
										.GetAgricultureResource("Food");

			if (tmp != null) {
				tmp.SetDemand(
					AgricultureResource.CalculateDemand(settlementComponents.population)
				);
			}
		}
	}
}