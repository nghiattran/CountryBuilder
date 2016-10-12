using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public class Farm {
		[SerializeField] float arce;
		[SerializeField] [Range(0.0F, 1F)]
		float multiplier;
	}
}