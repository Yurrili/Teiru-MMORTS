using UnityEngine;
using System.Collections;

public class Dice {//kostki

	private string Answer;
	private string Simple;
	
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
			Answer += numberOfDice + "k" + numberOfSides;
			Simple += numberOfDice + "k" + numberOfSides;
			for (int i = 0; i < roll.Length; i++)
			{
				
				total += roll[i];
				Answer +=  " : " + roll[i] + " " ;
				Simple +=  " : " + roll[i] + " " ;
				
			}
			
				Answer += "\nSummary : " + total + "\n";

			
			return roll;
			
		}

	public string getAnswer(){
		return Answer;
	}

	public string getSimpleAnswer(){
		return Simple;
	}
}
