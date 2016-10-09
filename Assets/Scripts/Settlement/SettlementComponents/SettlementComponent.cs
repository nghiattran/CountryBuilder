using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
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
		[SerializeField] public Demand demand;
		[SerializeField] public Consumption comsumption;
		[SerializeField] public Storage storage;
		[SerializeField] public Building building;
		[SerializeField] public Production production;
		public Resources resources;

		public SettlementComponents (Population _population, Demand _demand, 
			Consumption _comsumption, Storage _storage, Building _building, 
			Production _production, Resources _resources)
		{
			resources = _resources;
			population = _population;
			demand = _demand;
			comsumption = _comsumption;
			storage = _storage;
			building = _building;
			production = _production;
		}

		public SettlementComponents (Resources _resources) {
			resources = _resources;
			population = new Population();
			demand = new Demand();
			comsumption = new Consumption();
			storage = new Storage();
			building = new Building();
			production = new Production();
		}

		public void Start() {
			population.Start(this);
			demand.Start(this);
			comsumption.Start(this);
			storage.Start(this);
			building.Start(this);
			production.Start(this);
		}

		public void Update() {
			population.Update();
			demand.Update();
			comsumption.Update();
			storage.Update();
			building.Update();
			production.Update();
		}
	}
}