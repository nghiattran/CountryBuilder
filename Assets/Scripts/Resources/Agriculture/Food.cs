using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	public class Food {
		[SerializeField] static float childrenMultiplier = 2;
		[SerializeField] static float teensMultiplier = 4;
		[SerializeField] static float youngAdultsMultiplier = 6;
		[SerializeField] static float adultsMultiplier = 7;
		[SerializeField] static float seniorsMultiplier = 5;

		public Food() {

		}

		static public int CalculateDemand(Population population) {
			return 	(int)(population.GetChildren() * childrenMultiplier +
						population.GetTeens() * teensMultiplier +
						population.GetYoungAdults() * youngAdultsMultiplier +
						population.GetAdults() * adultsMultiplier +
						population.GetSeniors() * seniorsMultiplier);

		}
	}
}