using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyHealth = 3;
  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        EnemyHealth--;
        KillEnemy();
    }

    public void KillEnemy()
    {
        Debug.Log("Enemy Heath is " + EnemyHealth);
        if(EnemyHealth <= 0)
            this.gameObject.SetActive(false);
    }
}
