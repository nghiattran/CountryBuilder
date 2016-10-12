using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Resource {
		[SerializeField] private string name;
		[SerializeField] private float basePrice;
		[SerializeField] private int quantity;

		protected Resource(string _name) {
			name = _name;
		}

		public string GetName() {
			return name;
		}

		public int GetQuantity() {
			return quantity;
		}
	}
}