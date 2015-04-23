using UnityEngine;
using System.Collections;

public class Dice {//kostki

	private string Answer;
	
		public int[] Roll(int numberOfDice, int numberOfSides)
		{
			Answer = "";

			int[] roll = new int[numberOfDice];
			
			for (int i = 0; i < numberOfDice; i++)
			{
				
				roll[i] = Random.Range(1, numberOfSides);
				
			}
			
			int total = 0;

			// opis rzutów można wyświetlać dalej w oknie informacji

			for (int i = 0; i < roll.Length; i++)
			{
				
				total += roll[i];
				Answer += " Dice k" + numberOfSides + " - " + (i + 1) + " : " + roll[i] + "\n" ;
				
			}
			
				Answer += "Summary : " + total + "\n";

			
			return roll;
			
		}

	public string getAnswer(){
		return Answer;
	}

}
