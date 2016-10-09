using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public abstract class SettlementComponent {
		protected SettlementComponents settlementComponents;

		public void Start(SettlementComponents _settlementComponents) {
			settlementComponents = _settlementComponents;
		}

		abstract public void Update();
	}

	[System.Serializable]
	public class SettlementComponents {
		[SerializeField] public Population population;
		[HideInInspector] public Demand demand;
		[HideInInspector] public Consumption consumption;
		[HideInInspector] public Storage storage;
		[SerializeField] public Building building;
		[HideInInspector] public Production production;
		public Resources resources;

		public SettlementComponents (Population _population, Demand _demand, 
			Consumption _consumption, Storage _storage, Building _building, 
			Production _production, ref Resources _resources)
		{
			resources = _resources;
			population = _population;
			demand = _demand;
			consumption = _consumption;
			storage = _storage;
			building = _building;
			production = _production;
		}

		public SettlementComponents (ref Resources _resources) {
			resources = _resources;
			population = new Population();
			demand = new Demand();
			consumption = new Consumption();
			storage = new Storage();
			building = new Building();
			production = new Production();
		}

		public void Start() {
			population.Start(this);
			demand.Start(this);
			consumption.Start(this);
			storage.Start(this);
			building.Start(this);
			production.Start(this);

			resources.Start();
		}

		public void Update() {
			population.Update();
			demand.Update();
			consumption.Update();
			storage.Update();
			building.Update();
			production.Update();
		}
	}
}