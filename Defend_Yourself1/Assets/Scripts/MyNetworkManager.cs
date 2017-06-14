using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;

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
	/// Copied from Unity's original NetworkManager script except where noted
	public override void OnClientConnect(NetworkConnection conn)
	{
		/// ***
		/// This is added:
		/// First, turn off the canvas...
		//characterSelectionCanvas.enabled = false;
		/// Can't directly send an int variable to 'addPlayer()' so you have to use a message service...
		IntegerMessage msg = new IntegerMessage(playerIndex);
		/// ***

		if (!clientLoadedScene)
		{
			// Ready/AddPlayer is usually triggered by a scene load completing. if no scene was loaded, then Ready/AddPlayer it here instead.
			ClientScene.Ready(conn);
			if (autoCreatePlayer)
			{
				///***
				/// This is changed - the original calls a differnet version of addPlayer
				/// this calls a version that allows a message to be sent
				ClientScene.AddPlayer(conn, 0, msg);
			}
		}

	}

	/// Copied from Unity's original NetworkManager 'OnServerAddPlayerInternal' script except where noted
	/// Since OnServerAddPlayer calls OnServerAddPlayerInternal and needs to pass the message - just add it all into one.
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
	{
		/// *** additions
		/// I skipped all the debug messages...
		/// This is added to recieve the message from addPlayer()...
		int id = 0;

		if (extraMessageReader != null)
		{
			IntegerMessage i = extraMessageReader.ReadMessage<IntegerMessage>();
			id = i.value;
		}

		/// using the sent message - pick the correct prefab
		GameObject playerPrefab = spawnPrefabs[id];
		/// *** end of additions

		GameObject player;
		Transform startPos = GetStartPosition();
		if (startPos != null)
		{
			player = (GameObject)Instantiate(playerPrefab, startPos.position, startPos.rotation);
		}
		else
		{
			player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		}

		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
