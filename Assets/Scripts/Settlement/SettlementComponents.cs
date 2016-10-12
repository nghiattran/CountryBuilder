using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[RequireComponent(typeof(Population))]
	[RequireComponent(typeof(Demand))]
	[RequireComponent(typeof(Consumption))]
	[RequireComponent(typeof(Storage))]
	[RequireComponent(typeof(Structure))]
	[RequireComponent(typeof(Area))]
	[RequireComponent(typeof(Production))]
	public class SettlementComponents : MonoBehaviour {
		public Population population;
		public Demand demand;
		public Consumption consumption;
		public Storage storage;
		public Structure structure;
		public Area area;
		public Production production;
		public Resources resources;

		[ContextMenu("Init")]
	    public void InitContext() {
	        resources = ResourceFactory.GetInstance().CloneResources();
	    }

		public void Init() {
			population.Init();
			demand.Init();
			consumption.Init();
			storage.Init();
			structure.Init();
			production.Init();
		}

		public void Start() {
			population = GetComponent<Population>();
			demand = GetComponent<Demand>();
			consumption = GetComponent<Consumption>();
			storage = GetComponent<Storage>();
			structure = GetComponent<Structure>();
			area = GetComponent<Area>();
			production = GetComponent<Production>();

			population.ComponentStart(this);
			demand.ComponentStart(this);
			consumption.ComponentStart(this);
			storage.ComponentStart(this);
			structure.ComponentStart(this);
			production.ComponentStart(this);

			resources.Start();
		}

		public void GameUpdate() {
			population.GameUpdate();
			demand.GameUpdate();
			consumption.GameUpdate();
			storage.GameUpdate();
			structure.GameUpdate();
			production.GameUpdate();
		}
	}
}