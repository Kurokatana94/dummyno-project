using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public PlayerController player;
    private GameMaster gameMaster;
    public GameObject dash;
    public GameObject doubleJump;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gameMaster.unlockDash == true)
        {
            player.aquiredDash = true;
            Destroy(dash);
        }
        else
        {
            player.aquiredDash = false;
        }

        if (gameMaster.unlockDoubleJump == true)
        {
            player.aquiredDoubleJump = true;
            Destroy(doubleJump);
        }
        else
        {
            player.aquiredDoubleJump = false;
        }

    }
}
