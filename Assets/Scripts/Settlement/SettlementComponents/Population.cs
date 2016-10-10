using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public class PopulationStruct {
		[SerializeField] public int quantity;
		[SerializeField] public Education education;
		// PopulationStruct nextGen;
		public readonly string name;

		public PopulationStruct(string _name) {
			name = _name;
			quantity = 0;
			education = new Education(this);
		}

		public void EducateChildren(int amount) {
			education.AddEducated(amount);
		}

		public void AgeUp(float ageFactor) {
			int marginal = (int) (quantity * ageFactor);
			quantity -= marginal;
			education.AgeUp(marginal);

			education.Update();
		}

		public void AgeUp(float ageFactor, PopulationStruct nextGen) {
			int marginal = (int) (quantity * ageFactor);
			quantity -= marginal;
			nextGen.quantity += marginal;

			education.AgeUp(marginal, nextGen.education);

			education.Update();
		}
	}

	[System.Serializable]
	public class Population : SettlementComponent {
		[SerializeField] float ageFactor = 0.05f;

		[SerializeField] int totalPopulation;
		[SerializeField] PopulationStruct children = new PopulationStruct("children");
		[SerializeField] PopulationStruct teens = new PopulationStruct("teens");
		[SerializeField] PopulationStruct youngAdults = new PopulationStruct("youngAdults");
		[SerializeField] PopulationStruct adults = new PopulationStruct("adults");
		[SerializeField] PopulationStruct seniors = new PopulationStruct("seniors");

		override public void Update () {
			AgeUp();

			Sum();
		}

		void Sum() {
			totalPopulation = children.quantity + teens.quantity +
				youngAdults.quantity + adults.quantity + seniors.quantity;
		}

		void AgeUp() {
			// seniors.AgeUp(ageFactor);
			// adults.AgeUp(ageFactor, seniors);
			// youngAdults.AgeUp(ageFactor, adults);
			// teens.AgeUp(ageFactor, youngAdults);
			children.AgeUp(ageFactor, teens);
		}

		public int GetChildren() {
			return children.quantity;
		}

		public Education GetChildrenEducation() {
			return children.education;
		}

		public int GetTeens() {
			return teens.quantity;
		}

		public Education GetTeensEducation() {
			return teens.education;
		}

		public int GetYoungAdults() {
			return youngAdults.quantity;
		}

		public Education GetYoungAdultsEducation() {
			return youngAdults.education;
		}

		public int GetAdults() {
			return adults.quantity;
		}

		public Education GetAdultsEducation() {
			return adults.education;
		}

		public int GetSeniors() {
			return seniors.quantity;
		}

		public Education GetSeniorEducation() {
			return seniors.education;
		}
	}
}