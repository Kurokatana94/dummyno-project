using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysStatus : MonoBehaviour
{
    public bool haveKey, haveKey2, haveKey3, haveKey4, haveKey5;
    private GameMaster gameMaster;
    public GameObject key, key2, key3, key4, key5;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        if (gameMaster.keyCollected == true)
        {
            haveKey = true;
            Destroy(key);
        }
        if(gameMaster.key2Collected == true)
        {
            haveKey2 = true;
            Destroy(key2);
        }
        if (gameMaster.key3Collected == true)
        {
            haveKey3 = true;
            Destroy(key3);
        }
        if (gameMaster.key4Collected == true)
        {
            haveKey4 = true;
            Destroy(key4);
        }
        if (gameMaster.key5Collected == true)
        {
            haveKey5 = true;
            Destroy(key5);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            haveKey = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Key2"))
        {
            haveKey2 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Key3"))
        {
            haveKey3 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Key4"))
        {
            haveKey4 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Key5"))
        {
            haveKey5 = true;
            Destroy(other.gameObject);
        }

    }

    private void OnDestroy()
    {
        if (haveKey == true)
        {
            gameMaster.keyCollected = true;
        }
        if (haveKey2 == true)
        {
            gameMaster.key2Collected = true;
        }
        if (haveKey3 == true)
        {
            gameMaster.key3Collected = true;
        }
        if (haveKey4 == true)
        {
            gameMaster.key4Collected = true;
        }
        if (haveKey5 == true)
        {
            gameMaster.key5Collected = true;
        }

    }

}
