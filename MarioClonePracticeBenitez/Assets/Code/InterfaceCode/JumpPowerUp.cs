using DG.Tweening;
using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour, IPowerUp
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        PowerUp();
    }

    public void PowerUp()
    {
        PlayerController PlayerRef = GetComponent<PlayerController>();
        Debug.Log("Players jump has increased!");
        PlayerRef.jumpingPower = 32;
    }
}
