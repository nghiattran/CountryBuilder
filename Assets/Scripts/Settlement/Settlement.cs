using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Settlement : MonoBehaviour {
		Resources resources;
		[SerializeField] SettlementComponents components;

		protected Settlement() {

		}

		void Start() {
			GameManager.instance.Register(this);

			components.Start();
		}

		void Update() {
			
		}

		public void GameUpdate() {
			components.Update();
		}

		[ContextMenu("Init")]
	    public void Init() {
	        resources = ResourceFactory.GetInstance().CloneResources();
	        components = new SettlementComponents(ref resources);
	    }
	}
}