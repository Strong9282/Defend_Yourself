using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{

    public GameObject player;

    public Collider2D playerCollider;
    public Collider2D firstDoor;
    public GameObject door2;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TeleportDoor();
	}

    void TeleportDoor()
    {
        if (playerCollider.IsTouching(firstDoor))
        {
            player.transform.position = door2.transform.position;
        }
    }

}
