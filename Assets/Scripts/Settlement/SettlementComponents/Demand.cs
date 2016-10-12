using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Demand : SettlementComponent {
		[Header("Food demand multiplier")]
		[SerializeField] float childrenMultiplier = 2;
		[SerializeField] float teensMultiplier = 4;
		[SerializeField] float youngAdultsMultiplier = 6;
		[SerializeField] float adultsMultiplier = 7;
		[SerializeField] float seniorsMultiplier = 5;
		[Space(10)]

		[Header("Demands")]
		[SerializeField] int foodDemand;

		override public void GameUpdate () {
			foodDemand = CalculateDemand(settlementComponents.population);
		}

		public int CalculateDemand(Population population) {
			return 	(int)(population.GetChildren() * childrenMultiplier +
						population.GetTeens() * teensMultiplier +
						population.GetYoungAdults() * youngAdultsMultiplier +
						population.GetAdults() * adultsMultiplier +
						population.GetSeniors() * seniorsMultiplier);

		}
	}
}