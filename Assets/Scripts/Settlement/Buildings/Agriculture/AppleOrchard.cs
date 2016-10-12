using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class AppleOrchard : AgricultureBuilding {
		[SerializeField] protected Farm farm;

		public AppleOrchard() {
			output = new List<Resource>();
			output.Add(new Apple());
		}

		public override List<Resource> CalculateProduction(Population population) {
			return output;
		}
	}
}