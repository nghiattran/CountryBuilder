﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public abstract class AgricultureResource : Resource {
		protected AgricultureResource(string name): base(name) {

		}
	}
}