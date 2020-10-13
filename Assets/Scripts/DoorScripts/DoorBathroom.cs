using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBathroom : MonoBehaviour
{
    private bool isOpen;
    public Transform doorSpawn;
    private bool inTrigger;
    public Transform player;

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                isOpen = true;
            }
        }

        if (isOpen == true)
        {
            player.position = doorSpawn.position;
            isOpen = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

}
