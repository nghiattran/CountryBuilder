using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Area : SettlementComponent {
		[SerializeField] int farmArea;
		[SerializeField] int woodArea;

		override public void Update () {
		}
	}
}