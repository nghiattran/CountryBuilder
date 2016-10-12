using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class Building {
		[SerializeField] protected int quantity;
		[SerializeField] protected BuildPrice buildPrice;
		[SerializeField] [Range(0f, 1f)]
		protected float multiplier;
	}
}