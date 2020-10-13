using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door2Interaction : MonoBehaviour
{
    public bool door2Open;
    private bool inTrigger;
    public Animator animator;
    public string scene;
    public KeysStatus keysStatus;
    public Image interactionKey;
    public TextMeshProUGUI text;
    private bool showText;
    private GameMaster gameMaster;
    public Transform spawnPos;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        door2Open = false;
    }
    void Update()
    {
        if (inTrigger == true)
        {
            interactionKey.enabled = true;
            if (Input.GetButton("Interaction") && keysStatus.haveKey2 == true)
            {
                door2Open = true;
                DoorLink(scene);
            }
            else if (Input.GetButton("Interaction") && keysStatus.haveKey2 == false)
            {
                showText = true;
            }


            if (showText == true)
            {
                text.enabled = true;
            }
        }
        else
        {
            interactionKey.enabled = false;
            text.enabled = false;
        }

        if (door2Open == true)
        {
            animator.SetBool("Open", true);
            gameMaster.door2Opened = true;
        }
        else
        {
            gameMaster.door2Opened = false;
        }
    }



    public void DoorLink(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = false;
            showText = false;
        }
    }

}
