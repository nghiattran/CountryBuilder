﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder.Buildings {
	public interface IProductionBuilding {
		List<Resource> CalculateProduction(Population population);
	}
}