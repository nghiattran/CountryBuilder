using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class WheatField : AgricultureBuilding {
		[SerializeField] protected Farm farm;
		
		public override List<Resource> CalculateProduction(Population population) {
			return null;
		}
	}
}