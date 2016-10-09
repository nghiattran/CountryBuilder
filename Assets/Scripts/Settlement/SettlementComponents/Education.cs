using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {

	[System.Serializable]
	public class Education : SettlementComponent {
		[SerializeField] float uneducated;
		[SerializeField] float educated;
		[SerializeField] float wellEducated;
		[SerializeField] float highlyEducated;
		PopulationStruct populationStruct;
		int total;
		int[] amounts;
		float[] ratios = new float[4];

		public Education(PopulationStruct _populationStruct) {
			populationStruct = _populationStruct;
		}

		override public void Update () {
			ratios[0] = uneducated;
			ratios[1] = educated;
			ratios[2] = wellEducated;
			ratios[3] = highlyEducated;
		}

		public void AddPeople(int[] diffAmounts) {
			AddPeople(diffAmounts, 1);
		}

		public void AddPeople(int[] diffAmounts, int sign) {
			AssignRatios();
			int[] amounts = new int[4];
			amounts = CalculateRatio(populationStruct.quantity, ratios).ToArray();
			float sum = (float) amounts.Sum() + diffAmounts.Sum();
			if (sum <= 0) {
				return;
			}
			
			for (int i = 0; i < amounts.Length; i++) {
				amounts[i] += diffAmounts[i] * Math.Sign(sign);
			}

			uneducated = amounts[0] / sum;
			educated = amounts[1] / sum;
			wellEducated = amounts[2] / sum;
			highlyEducated = amounts[3] / sum;
		}

		public int GetUneducated() {
			return (int) (uneducated * populationStruct.quantity);
		}

		public void AddUneducated(int amount) {
			AddPeople(new int[] {amount, 0, 0, 0});
		}

		public int GetEducated() {
			return (int) (educated * populationStruct.quantity);
		}

		public void AddEducated(int amount) {
			AddPeople(new int[] {-amount, amount, 0, 0});
		}

		public int GetWellEducated() {
			return (int) (wellEducated * populationStruct.quantity);
		}

		public void AddWellEducated(int amount) {
			AddPeople(new int[] {0, -amount, amount, 0});
		}

		public int GetHighlyEducated() {
			return (int) (highlyEducated * populationStruct.quantity);
		}

		public void AddHighlyEducated(int amount) {
			AddPeople(new int[] {0, 0, -amount, amount});
		}

		public int[] AgeUp(int amount) {
			AssignRatios();

			int[] diffAmounts = new int[4];
			diffAmounts = CalculateRatio(amount, ratios).ToArray();

			AddPeople(diffAmounts, -1);

			return diffAmounts;
		}

		public void AgeUp(int amount, Education nextGen) {
			int[] diffAmounts = AgeUp(amount);
			nextGen.AddPeople(diffAmounts);
		}

		void AssignRatios() {
			ratios[0] = uneducated;
			ratios[1] = educated;
			ratios[2] = wellEducated;
			ratios[3] = highlyEducated;
		}

		static public List<int> CalculateRatio(int wholeNumer, float[] ratios) {
			List<int> results = new List<int>();
			int sum = 0;
			string debug = "";
			string ratio = "";
			for (int i = 0; i < ratios.Length; i++) {
				results.Add((int) (wholeNumer * ratios[i]));
				sum += results[i];
				debug += results[i] + " ";
				ratio += ratios[i] + " ";
			}
			// Debug.Log(debug);
			// Debug.Log(ratio);
			return results;
		}
	}
}