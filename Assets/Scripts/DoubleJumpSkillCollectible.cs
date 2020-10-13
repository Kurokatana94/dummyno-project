﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpSkillCollectible : MonoBehaviour
{
    private GameMaster gameMaster;
    public PlayerController player;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.aquiredDoubleJump = true;
            gameMaster.unlockDoubleJump = true;
            Destroy(gameObject);
        }
    }

}
