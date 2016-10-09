using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class GameManager : MonoBehaviour {
		[SerializeField] List<Settlement> settlements;
		[SerializeField] float dayCycle;
		static public GameManager instance;

		// Use this for initialization
		void Awake () {
			if (instance == null)
                instance = this;
            else if (instance != this) 
            	Destroy(gameObject);

            InitGame();
		}

		void InitGame() {
			InvokeRepeating("GameUpdate", 0f, dayCycle);
		}

		public void Register(Settlement settlement) {
			bool found = settlements.IndexOf(settlement) > -1;

			if (!found) {
				settlements.Add(settlement);
			}
		}

		void GameUpdate() {
			for (int i = 0; i < settlements.Count; i++) {
				settlements[i].GameUpdate();
			}
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
