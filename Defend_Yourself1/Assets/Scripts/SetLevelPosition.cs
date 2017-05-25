using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevelPosition : MonoBehaviour
{
    public GameObject player;
    private Vector3 myStartPosition;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        myStartPosition = GameObject.Find("StartPosition").transform.position;
        //transform.position = myStartPosition;
        player.transform.position = myStartPosition;
    }
}
