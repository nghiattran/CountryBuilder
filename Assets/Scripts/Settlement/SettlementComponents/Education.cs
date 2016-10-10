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

			// Amount of people grown up
			int diffSum = diffAmounts.Sum();

			// Calculate people education before grown up
			amounts = CalculateRatio(
						populationStruct.quantity - Math.Sign(sign) * diffSum, 
						ratios
					)
					.ToArray();

			// Recalculate education ratio after updated
			for (int i = 0; i < amounts.Length; i++) {
				amounts[i] += diffAmounts[i] * Math.Sign(sign);
			}

			uneducated = CalculateRatio(amounts[0], populationStruct.quantity);
			educated = CalculateRatio(amounts[1], populationStruct.quantity);
			wellEducated = CalculateRatio(amounts[2], populationStruct.quantity);
			highlyEducated = CalculateRatio(amounts[3], populationStruct.quantity);
		}

		float CalculateRatio(int amount, int total) {
			return (float) Math.Round((float) amount / total, 2);
		}

		string ToString(int[] array) {
			string line = "";
			for (int i = 0; i < array.Length; i++) {
				line += array[i] + " ";
			}
			return line;
		}

		public int GetUneducated() {
			return (int) (uneducated * populationStruct.quantity);
		}

		public void AddUneducated(int amount) {
			if (amount == 0 )
				return;

			AddPeople(new int[] {amount, 0, 0, 0});
		}

		public int GetEducated() {
			return (int) (educated * populationStruct.quantity);
		}

		public void AddEducated(int amount) {
			if (amount == 0 )
				return;

			AddPeople(new int[] {-amount, amount, 0, 0});
		}

		public int GetWellEducated() {
			return (int) (wellEducated * populationStruct.quantity);
		}

		public void AddWellEducated(int amount) {
			if (amount == 0 )
				return;

			AddPeople(new int[] {0, -amount, amount, 0});
		}

		public int GetHighlyEducated() {
			return (int) (highlyEducated * populationStruct.quantity);
		}

		public void AddHighlyEducated(int amount) {
			if (amount == 0 )
				return;

			AddPeople(new int[] {0, 0, -amount, amount});
		}

		public int[] AgeUp(int amount) {
			AssignRatios();
			int[] diffAmounts = new int[4];

			if (diffAmounts.All(x => x != 0))
				return null;

			diffAmounts = CalculateRatio(amount, ratios).ToArray();
			AddPeople(diffAmounts, -1);

			return diffAmounts;
		}

		public void AgeUp(int amount, Education nextGen) {
			int[] diffAmounts = AgeUp(amount);

			if (diffAmounts == null)
				return;

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
			for (int i = 0; i < ratios.Length; i++) {
				results.Add((int) (wholeNumer * ratios[i]));
				sum += results[i];
			}
			return results;
		}
	}
}