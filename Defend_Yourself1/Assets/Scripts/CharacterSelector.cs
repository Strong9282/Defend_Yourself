/* Michael Witters Started on 5/4/17 Character Selection Script Cycle through Characters Available */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour 

{ 
	public GameObject characterSelector;
	public GameObject theCamera;
	public GameObject MainCamera;

	void start ()
	{
		
	}
		
	void Update()
	{
		
	}

	public void Select()
	{
		characterSelector.SetActive (false);
		MainCamera.SetActive (false);
		theCamera.SetActive (true);	
	}
}
