using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public abstract class IndustrialResource : Resource {

		protected IndustrialResource() : base() {}

		abstract public void CalculateDemand();
	}
}