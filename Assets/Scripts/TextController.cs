using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, sheets_0, mirror, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, stairs_0, floor, 
						closet_door, corridor_1, stairs_1, in_closet, stairs_2, corridor_2, courtyard_0, corridor_3, courtyard_1};
	private States myState;

	void Start () {
		myState = States.cell;
	}
	
	void Update () {
		if (myState == States.cell)					cell ();
		else if (myState == States.sheets_0)		sheets_0 ();
		else if (myState == States.mirror)			mirror ();
		else if (myState == States.lock_0)			lock_0 ();
		else if (myState == States.sheets_1)		sheets_1 ();
		else if (myState == States.cell_mirror)		cell_mirror ();
		else if (myState == States.lock_1)			lock_1 ();
		else if (myState == States.corridor_0)		corridor_0 ();
		else if (myState == States.stairs_0)		stairs_0 ();
		else if (myState == States.floor)			floor ();
		else if (myState == States.closet_door)		closet_door ();
		else if (myState == States.corridor_1)		corridor_1 ();
		else if (myState == States.stairs_1)		stairs_1 ();
		else if (myState == States.in_closet)		in_closet ();
		else if (myState == States.stairs_2)		stairs_2 ();
		else if (myState == States.corridor_2)		corridor_2 ();
		else if (myState == States.courtyard_0)		courtyard_0 ();
		else if (myState == States.corridor_3)		corridor_3 ();
		else if (myState == States.courtyard_1)		courtyard_1 ();
	}

	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"[Press S to view Sheets..]\n[Press M to view Mirrior..]\n[Press L to view Lock..]";
		
		if (Input.GetKeyDown (KeyCode.S)) 			myState = States.sheets_0;
		else if (Input.GetKeyDown (KeyCode.M)) 		myState = States.mirror;
		else if (Input.GetKeyDown (KeyCode.L)) 		myState = States.lock_0;
	}

	void sheets_0 () {
		text.text = "Nothing but a messy sheets lying on the bed. Nothing interesting here.\n\n" +
					"[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.cell;
	}

	void mirror () {
		text.text = "Messy wall, a broken mirror is put on the wall. There is a broken piece that can be taken.\n\n" +
					"[Press T to take broken mirror piece..]\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.T))			myState = States.cell_mirror;
		else if (Input.GetKeyDown (KeyCode.R))		myState = States.cell;
	}

	void lock_0 () {
		text.text = "Old lock holding the door together. You have nothing to open the lock. It seems a bit broken.\n\n" +
					"[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.cell;
	}

	void sheets_1 () {
		text.text = "It will do no good to just tur the sheets apart. Only good thing to do here is to " +
					"sleep, but either then it is not comfortable.\n\n" +
					"[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R)) 			myState = States.cell_mirror;
	}

	void cell_mirror () {
		text.text = "What to do now?\n\n[Press S to view Sheets..]\n[Press L to view Lock..]";

		if (Input.GetKeyDown (KeyCode.S))			myState = States.sheets_1;
		else if (Input.GetKeyDown (KeyCode.L))		myState = States.lock_1;
	}

	void lock_1 () {
		text.text = "Maybe that broken mirror can open this old lock. Seems like it can be opened easily with it.\n\n" +
					"[Press R to Return..]\n[Press O to try Open the Lock..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.cell_mirror;
		else if (Input.GetKeyDown (KeyCode.O))		myState = States.corridor_0;
	}

	void corridor_0 () {
		text.text = "Out of the prison cell, now where to go? There are stairs and a closet door which who knows " +
					"where it leads to. It's visible there are stairs down which lead to courtyard and your freedom\n" +
					"\n[Press U to view Stairs UP..]\n[Press F to look at the floor..]\n[Press C to " +
					"view Closet..]\n[Press D to go Stairs DOWN..]";

		if (Input.GetKeyDown (KeyCode.U))			myState = States.stairs_0;
		else if (Input.GetKeyDown (KeyCode.F))		myState = States.floor;
		else if (Input.GetKeyDown (KeyCode.C))		myState = States.closet_door;
		else if (Input.GetKeyDown (KeyCode.D))		myState = States.courtyard_1;
	}

	void stairs_0 () {
		text.text = "Stairs leading up to prison, surely I don't want to go back there.\n\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.corridor_0;
	}

	void floor () {
		text.text = "There is a hairclip lying down on the floor. Someone must have dropped it, it doesn't look like " +
					"this floor has been cleaned anytime recently.\n\n[Press H to Pickup the Hairclip..]\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.H))			myState = States.corridor_1;
		else if (Input.GetKeyDown (KeyCode.R))		myState = States.corridor_0;
	}

	void closet_door () {
		text.text = "The door is locked and can't be opened without help. Need to try find something to open it. Wonder what is " +
					"behind that door.\n\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.corridor_0;
	}

	void corridor_1 () {
		text.text = "Where could that hairclip be used that. What to do now?\n\n[Press P to Pick the Lock..]\n[Press U to view Stairs UP..]" +
					"\n[Press D to go Stairs DOWN..]";

		if (Input.GetKeyDown (KeyCode.P))			myState = States.in_closet;
		else if (Input.GetKeyDown (KeyCode.U))		myState = States.stairs_1;
		else if (Input.GetKeyDown (KeyCode.D))		myState = States.courtyard_1;
	}

	void stairs_1 () {
		text.text = "Still don't feel like going back up to prison. Want to escape this awful place.\n\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.corridor_1;
	}

	void in_closet () {
		text.text = "The door opened! Seems like just a closet filled with clothes, good for disguise myself out of here.\n\n" +
					"[Press R to Return..]\n[Press D to Dress up..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.corridor_2;
		else if (Input.GetKeyDown (KeyCode.D))		myState = States.corridor_3;
	}

	void stairs_2 () {
		text.text = "The same stairs leading up to prison. Don't want to go there.\n\n[Press R to Return..]";

		if (Input.GetKeyDown (KeyCode.R))			myState = States.corridor_2;
	}

	void corridor_2 () {
		text.text = "Can see freedom in the courtyard. Couple options available, either dress up and leave or risk it " +
					"and make a run for it.\n\n[Press B to go in Closet..]\n[Press U to view Stairs UP..]\n[Press D to go Stairs DOWN..]";

		if (Input.GetKeyDown (KeyCode.B))			myState = States.in_closet;
		else if (Input.GetKeyDown (KeyCode.U))		myState = States.stairs_2;
		else if (Input.GetKeyDown (KeyCode.D))		myState = States.courtyard_1;
	}

	void courtyard_0 () {
		text.text = "You are FREE! Congratulations.\nThank you for playing.\n\n\n[Press P to Play Again..]";

		if (Input.GetKeyDown (KeyCode.P))			myState = States.cell;
	}

	void corridor_3 () {
		text.text = "All dressed up. Undress or go to courtyard with the stairs down?\n\n" +
					"[Press U to Undress..]\n[Press D to go Stairs DOWN..]";

		if (Input.GetKeyDown (KeyCode.U))			myState = States.in_closet;
		else if (Input.GetKeyDown (KeyCode.D)) 		myState = States.courtyard_0;
	}

	void courtyard_1(){
		text.text = "You been COUGHT! You lost the game, Try Again?\n\n[Press Y to Try Again..]";

		if (Input.GetKeyDown (KeyCode.Y))			myState = States.cell;
	}
}