using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour {

	public int selectedPlayer;
	public CharacterSelector characterSel;
	private GameObject characterSelector;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	void Start () 
	{
		characterSel = characterSelector.GetComponent<CharacterSelector> ();
		selectedPlayer = characterSel.selectedChar;
		DisableAll ();
		SpawnChar ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnChar()
	{
		if (selectedPlayer == 0) 
		{
			player1.SetActive (true);
		} 
		if (selectedPlayer == 1) 
		{
			player2.SetActive(true);
		}
		if (selectedPlayer == 2) 
		{
			player3.SetActive(true);
		}
		else
			return;
	}

	void DisableAll()
	{
		player1.SetActive (false);
		player2.SetActive(false);
		player3.SetActive (false);
	}
}
