using UnityEngine;
using System.Collections;

public class CharacterStats {

	private int STR;
	private int DEX;
	private int CON;
	private int INT;
	private int WIS;
	private int CHA;

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

	public void increaseSTR(){
		STR++;
	}

	public void increaseDEX(){
		DEX++;
	}

	public void increaseCON(){
		CON++;
	}
	public void increaseINT(){
		INT++;
	}
	public void increaseWIS(){
		WIS++;
	}
	public void increaseCHA(){
		CHA++;
	}

	public void decreaseSTR(){

		if (STR > 0) {
			STR--;
		} else {
			STR = 0;
		}
	}

	public void decreaseDEX(){
		
		if (DEX > 0) {
			DEX--;
		} else {
			DEX = 0;
		}
	}

	public void decreaseCON(){
		
		if (CON > 0) {
			CON--;
		} else {
			CON = 0;
		}
	}

	public void decreaseINT(){
		
		if (INT > 0) {
			INT--;
		} else {
			INT = 0;
		}
	}

	public void decreaseWIS(){
		
		if (WIS > 0) {
			WIS--;
		} else {
			WIS = 0;
		}
	}

	public void decreaseCHA(){
		
		if (CHA > 0) {
			CHA--;
		} else {
			CHA = 0;
		}
	}


}
