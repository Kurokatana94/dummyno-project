using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    public Transform playerFirstPos;
    public bool keyCollected, key2Collected, key3Collected, key4Collected, key5Collected;
    public bool doorOpened, door2Opened, door3Opened, door4Opened, door5Opened;
    public bool unlockDash;
    public bool unlockDoubleJump;
    public bool isDoor1Opened;

    private void Awake()
    {
        lastCheckPointPos = playerFirstPos.position;

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }


}
