using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour, IPowerUp
{
    public void PowerUp()
    {
        PlayerController Player = FindObjectOfType<PlayerController>();
        Player.jumpingPower = 32;
        Debug.Log("Players jump has increased!");
        //Maybe make this a duration thing? Not sure yet...
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
            return;
        PowerUp();
    }
}
