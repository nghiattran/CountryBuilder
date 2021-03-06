﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NghiaTTran.CountryBuilder;

namespace NghiaTTran.CountryBuilder.Buildings {
	[System.Serializable]
	public abstract class School : Building {
		[SerializeField] protected int capacity;
		[SerializeField] protected int enrollment;
		[SerializeField] protected float ratio;

		public School(int _capacity) {
			capacity = _capacity;
			multiplier = 1f;
		}

		public abstract void CalculateEnrollment(Population population);

		public int GetTotalCapacity() {
			return quantity * capacity;
		}

		protected int GetGraduators(int enrollment) {
			return (int) (enrollment * multiplier * ratio);
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