using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class Bakery : AgricultureBuilding {
		public override List<Resource> CalculateProduction(Population population) {
			return null;
		}
	}
}