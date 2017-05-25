/* Michael Witters Started on 5/4/17 Character Selection Script Cycle through Characters Available */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour 

{ 
	public List<GameObject> characters;
	public int charSelect = 1; // default character selection
	private int namSelect = 1; // default name selection
	public GameObject prevBttn;
	public GameObject nexBttn;
	public List<GameObject> names;
	public int selectedChar;

	// Use this for initialization
	void Start () 
	{
		
		CharacterList ();// Generate list of Characters
        

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//selectedChar = charSelect; // Update the Character the player is on as the selected character, change evertime the player changes their selection.
		Debug.Log(""+PlayerPrefs.GetInt("Selected Character"));
		disableButton ();// Disable Next or Previous button if it's at the last selection in the list
		disableNames ();// Disable names of players that aren't currently being viewed
	}

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Next ()
	{
		// check if the current character select is 1 or less and allow next selection
		if (charSelect >= 1) {
			characters [charSelect].SetActive (false);// set previous character selection as disabled
			charSelect--;// decrease character select number
			characters [charSelect].SetActive (true);// set previous character selection as enabled
		} else
			return;
	}

	public void Previous ()
	{
		// check if the current character select is 1 or less and allow previous selection
		if (charSelect <= 1) {
			characters [charSelect].SetActive (false); // set previous character selection as disabled
			charSelect++; // increase character select number
			characters [charSelect].SetActive (true);// set previous character selection as enabled
		} else
			return;
	}

	public void disableButton()
	{
		if (Application.loadedLevel == 0) { // Only use this block of code if in the Character Select Screeen (Avoid Errors)
			if (charSelect == 2) {	//When the last value is reached, disable the previous button.
				prevBttn.SetActive (false);
			} else // otherwise enable the previous button
				prevBttn.SetActive (true); 

			if (charSelect == 0) {  //When the last value is reached, disable the next button.
				nexBttn.SetActive (false);
			} else // otherwise enable the next button
				nexBttn.SetActive (true);
		}
		return;
	}

	public void disableNames() // Disable/Enable names based off of the character being viewed or selected.
	{
		if (Application.loadedLevel == 0) { // Only use this block of code if in the Character Select Screeen (Avoid Errors)
			names [0].SetActive (false);
			names [2].SetActive (false);
			if (charSelect == 0) {
				names [namSelect].SetActive (false);
				namSelect = 2;
				names [namSelect].SetActive (true);
			}
			if (charSelect == 1) {
				names [namSelect].SetActive (false);
				namSelect = 1;
				names [namSelect].SetActive (true);
			}
			if (charSelect == 2) {
				names [namSelect].SetActive (false);
				namSelect = 0;
				names [namSelect].SetActive (true);
			} else
				return;
		}
		return;
	}

	public void CharacterList()
	{
		characters = new List<GameObject> ();
		foreach (Transform t in transform) //Grab all object transforms from the parent (all characters transforms in the character container) 
		{
			characters.Add (t.gameObject); // add all the objects transforms from into the list.
			t.gameObject.SetActive(false);
		}
		characters [charSelect].SetActive (true);
	}

	public void Select()
	{
		PlayerPrefs.SetInt ("Selected Charcter", selectedChar); // Store the selected character into Playerprefs
		selectedChar = PlayerPrefs.GetInt("Selected Character");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Application.LoadLevel (1); // Load the Tutorial Level after character has been selected.
    }
		
}
