using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningInteraction : MonoBehaviour
{
    public KeysStatus key;
    private bool isOpen;
    private bool inTrigger;
    private GameMaster gameMaster;
    public SpriteRenderer doorOpened;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update()
    {
        if (inTrigger == true)
        {
            if(Input.GetButtonDown("Interaction") && key.haveKey == true)
            {
                isOpen = true;
            }
        }

        if (isOpen == true || gameMaster.isDoor1Opened == true)
        {
            gameMaster.isDoor1Opened = true;
            doorOpened.enabled = true;
            Destroy(gameObject);
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
