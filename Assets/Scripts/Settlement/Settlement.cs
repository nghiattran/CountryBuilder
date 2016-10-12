using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NghiaTTran.CountryBuilder {
	[RequireComponent(typeof(SettlementComponents))]
	public class Settlement : MonoBehaviour {
		SettlementComponents components;

		protected Settlement() {

		}

		void Start() {
			GameManager.instance.Register(this);

			components = GetComponent<SettlementComponents>();
		}

		void Update() {
			
		}

		public void GameUpdate() {
			components.GameUpdate();
		}
	}
}