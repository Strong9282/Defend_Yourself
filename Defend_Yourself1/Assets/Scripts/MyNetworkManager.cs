using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager 
{
	public Button FrankButton;
	public Button JackButton;
	public Button AngelaButton;
	public Button ScarButton;
	public int playerIndex = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerListeners ();
	}

	void playerListeners() // button actions, when clicked execute function from PlayerPicker below
	{
		FrankButton.onClick.AddListener (delegate {PlayerPicker (FrankButton.name);});
		JackButton.onClick.AddListener (delegate {PlayerPicker (JackButton.name);});
		AngelaButton.onClick.AddListener (delegate {PlayerPicker(AngelaButton.name);});
		ScarButton.onClick.AddListener (delegate {PlayerPicker (ScarButton.name);});

	}

	void PlayerPicker(string buttonName) // Player Picker, when the player clicks on the button corresponding to the player, assign that player to the spawn
	{
		switch (buttonName) {
		case "FrankButton":    // If frank button is clicked assign frank's  player prefab
			playerIndex = 0;
			break;
		case "JackButton":
			playerIndex = 1;
			break;
		case "AngelaButton":
			playerIndex = 2;
			break;
		case "ScarButton":
			playerIndex = 3;
			break;
		}
		playerPrefab = spawnPrefabs [playerIndex]; // Assign the player index corresponding to the player that was slected from the character select screen
	}
}
