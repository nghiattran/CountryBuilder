using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Resource {
		[SerializeField] private float basePrice;
		public readonly string name;

		protected Resource(string _name) {
			name = _name;
		}

		public string GetName() {
			return name;
		}
	}
}