using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	
	[System.Serializable]
	public class IndustrialWrapper {
		[SerializeField] private string name;
		[SerializeField] private int quantity = 0;
		[SerializeField] IndustrialResource resource;

		public IndustrialWrapper(IndustrialResource _resource) {
			resource = _resource;
			name = resource.GetType().Name;
		}

		public string GetName() {
			return name;
		}

		public int GetQuantity() {
			return quantity;
		}

		public void AddQuantity(int amount) {
			quantity += amount;
		}
	}
}