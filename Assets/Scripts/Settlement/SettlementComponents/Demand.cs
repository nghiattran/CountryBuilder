using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Demand : SettlementComponent {
		Population population;

		public void Start(SettlementComponents settlementComponents) {
			base.Start(settlementComponents);

			population = settlementComponents.population;
		}

		override public void Update () {
			
		}
	}
}