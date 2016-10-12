using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	public abstract class SettlementComponent : MonoBehaviour {
		protected SettlementComponents settlementComponents;

		void Start() {
			
		}

		public void ComponentStart(SettlementComponents _settlementComponents) {
			settlementComponents = _settlementComponents;
		}

		virtual public void Init() {}

		abstract public void GameUpdate();
	}
}