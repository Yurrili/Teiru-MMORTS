﻿using UnityEngine;
using System.Collections;

public class CharacterStats {


	private int PTS;
	private int STR;
	private int DEX;
	private int CON;
	private int INT;
	private int WIS;
	private int CHA;

	public CharacterStats(){
		PTS = 32;
		STR = 8;
		DEX = 8;
		CON = 8;
		INT = 8;
		WIS = 8;
		CHA = 8;

	}

	public string getDescription(){
		string a = "";
		if (STR != 0)
			a += "Strenght : +" + STR + "\n";

		if (DEX != 0)
			a += "Dexterity : +"  + DEX + "\n" ;

		if (CON != 0)
			a += "Condition : +"  + CON + "\n" ;

		if (INT != 0)
			a += "Inteligent : +" + INT + "\n" ;

		if (WIS != 0)
			a += "Wisdom : +"     + WIS + "\n" ;

		if (CHA != 0)
			a += "Charisma : +"   + CHA + "\n" ;
					
		return a;
	}

	public int getPTS(){
		return PTS;
	}

	public int getSTR(){
		return STR;
	}
	public int getDEX(){
		return DEX;
	}
	public int getCON(){
		return CON;
	}
	public int getINT(){
		return INT;
	}
	public int getWIS(){
		return WIS;
	}
	public int getCHA(){
		return CHA;
	}

	public void setSTR(int s){
		STR = s;
	}
	public void setDEX(int a){
		DEX = a;
	}
	public void setCON(int a){
		CON = a;
	}
	public void setINT(int a){
		INT = a;
	}
	public void setWIS(int a){
		WIS = a;
	}
	public void setCHA(int a){
		CHA = a; 
	}

	public int increase(int actualPoints){

		if (PTS > 0) {

			if (actualPoints == 17 && PTS >= 4) {
				PTS = PTS - 4;
				actualPoints++;
			}

			if (actualPoints >= 13 && actualPoints < 17 && PTS >= 3) {
				PTS = PTS - 3;
				actualPoints++;
			}

			if (actualPoints >= 8 && actualPoints < 13 && PTS >= 1) {
				actualPoints++;
				PTS--;
			}


		}
		return actualPoints;
	}

	public int increaseSTR(){
		return STR = increase(STR);
	}

	public int increaseDEX(){
		return DEX = increase(DEX);
	}

	public int increaseCON(){
		return CON = increase(CON);
	}

	public int increaseINT(){
		return INT = increase(INT);
	}

	public int increaseWIS(){
		return WIS = increase(WIS);
	}

	public int increaseCHA(){
		return CHA = increase(CHA);
	}

	public int decrease(int actualPoints){

		if (PTS < 32) {
		
			if (actualPoints > 8 && actualPoints <= 13) {
				actualPoints--;
				PTS++;
			}

			if (actualPoints > 13 && actualPoints <= 17) {
				PTS = PTS + 3;
				actualPoints--;
			}

			if (actualPoints == 18) {
				PTS = PTS + 4;
				actualPoints--;
			}


		}

		return actualPoints;
	}

	public int decreaseSTR(){

		return STR = decrease(STR);
	}

	public int decreaseDEX(){
		
		return DEX = decrease(DEX);
	}

	public int decreaseCON(){
		
		return CON = decrease(CON);
	}

	public int decreaseINT(){
		
		return INT = decrease(INT);
	}

	public int decreaseWIS(){
		
		return WIS = decrease(WIS);
	}

	public int decreaseCHA(){
		
		return CHA = decrease(CHA);
	}


}
