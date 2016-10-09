using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class AgricultureWrapper {
		[SerializeField] string name;
		[SerializeField] int quantity = 0;
		[SerializeField] int production = 0;
		[SerializeField] int demand = 0;
		[SerializeField] int comsumption = 0;
		[SerializeField] int storage = 0;
		[SerializeField] AgricultureResource resource;
		[SerializeField] Resource baseResource;

		public AgricultureWrapper(AgricultureResource _resource) {
			resource = _resource;
			name = resource.GetType().Name;
			baseResource = _resource as Resource;
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

		public void SetDemand(int _demand) {
			demand = _demand;
		}

		public int GetDemand() {
			return demand;
		}

		public void SetProduction(int _production) {
			production = _production;
		}

		public int GetProduction() {
			return production;
		}

		public void SetComsumption(int _comsumption) {
			comsumption = _comsumption;
		}

		public int GetComsumption() {
			return comsumption;
		}

		public void SetStorage(int _storage) {
			storage = _storage;
		}

		public int GetStorage() {
			return storage;
		}
	}
}