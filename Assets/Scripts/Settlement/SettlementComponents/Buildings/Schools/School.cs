using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public abstract class School {
		[SerializeField] protected int quantity;
		[SerializeField] protected int capacity;
		[SerializeField] protected int enrollment;
		[SerializeField] protected float ratio;

		public School(int _capacity) {
			capacity = _capacity;
		}

		public School() {}

		public abstract void CalculateEnrollment(Population population);

		public int GetTotalCapacity() {
			return quantity * capacity;
		}
	}

	[System.Serializable]
	public class SchoolWarpper {
		[SerializeField] public School school;

		public SchoolWarpper(School _school) {
			school = _school;
		}
	}
}