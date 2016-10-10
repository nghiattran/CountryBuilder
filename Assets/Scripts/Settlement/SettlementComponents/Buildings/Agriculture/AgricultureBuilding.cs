﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public abstract class AgricultureBuilding: Building {
		[SerializeField] protected int workers;
		
		public abstract void CalculateProduction(Population population);
	}
}