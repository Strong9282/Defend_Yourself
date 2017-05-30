using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager 
{
	public Button Player1Button;
	public Button Player2Button;
	public Button Player3Button;
	public Button Player4Button;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void playerListeners()
	{
		Player1Button.onClick.AddListener (delegate {AvatarPicker (Player1Button.name);});
		Player2Button.onClick.AddListener (delegate {AvatarPicker (Player2Button.name);});
		Player3Button.onClick.AddListener (delegate {AvatarPicker (Player3Button.name);});
		Player4Button.onClick.AddListener (delegate {AvatarPicker (Player4Button.name);});

	}

	void AvatarPicker(string buttonName)
	{
		
	}
}
