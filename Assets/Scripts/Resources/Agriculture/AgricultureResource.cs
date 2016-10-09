using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public abstract class AgricultureResource : Resource {
		protected AgricultureResource(): base() {

		}

		abstract public void CalculateDemand(Population population);
	}
}