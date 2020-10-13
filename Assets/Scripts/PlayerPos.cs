using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    public Transform spawnPosDoor, spawnPosDoor2, spawnPosDoor3, spawnPosDoor4, spawnPosDoor5;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (!gameMaster.doorOpened && !gameMaster.door2Opened && !gameMaster.door3Opened && !gameMaster.door4Opened && !gameMaster.door5Opened)
        {
            transform.position = gameMaster.lastCheckPointPos;
        }
        else if (gameMaster.doorOpened && !gameMaster.door2Opened && !gameMaster.door3Opened && !gameMaster.door4Opened && !gameMaster.door5Opened)
        {
            transform.position = spawnPosDoor.position;
        }
        else if (!gameMaster.doorOpened && gameMaster.door2Opened && !gameMaster.door3Opened && !gameMaster.door4Opened && !gameMaster.door5Opened)
        {
            transform.position = spawnPosDoor2.position;
        }
        else if (!gameMaster.doorOpened && !gameMaster.door2Opened && gameMaster.door3Opened && !gameMaster.door4Opened && !gameMaster.door5Opened)
        {
            transform.position = spawnPosDoor3.position;
        }
        else if (!gameMaster.doorOpened && !gameMaster.door2Opened && !gameMaster.door3Opened && gameMaster.door4Opened && !gameMaster.door5Opened)
        {
            transform.position = spawnPosDoor4.position;
        }
        else if (!gameMaster.doorOpened && !gameMaster.door2Opened && !gameMaster.door3Opened && !gameMaster.door4Opened && gameMaster.door5Opened)
        {
            transform.position = spawnPosDoor5.position;
        }
    }
}
