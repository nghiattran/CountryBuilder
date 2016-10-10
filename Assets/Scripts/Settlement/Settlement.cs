using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NghiaTTran.CountryBuilder {
	[RequireComponent(typeof(SettlementComponents))]
	public class Settlement : MonoBehaviour {
		Resources resources;
		SettlementComponents components;

		protected Settlement() {

		}

		void Start() {
			GameManager.instance.Register(this);

			components = GetComponent<SettlementComponents>();
			// components.Start();
		}

		void Update() {
			
		}

		public void GameUpdate() {
			components.GameUpdate();
		}

		// [ContextMenu("Init")]
	 //    public void Init() {
	 //        resources = ResourceFactory.GetInstance().CloneResources();
	 //        components = new SettlementComponents(ref resources);
	 //    }
	}
}