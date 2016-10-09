using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public abstract class IndustrialResource : Resource {

		protected IndustrialResource(string name) : base(name) {}

		abstract public void CalculateDemand();
	}
}