using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public abstract class AgricultureBuilding: Building, IProductionBuilding {
		[SerializeField] protected int workers;
		[SerializeField] protected List<Resource> output;
		
		public abstract List<Resource> CalculateProduction(Population population);
	}
}