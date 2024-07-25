using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyHealth = 3;
  
    public void CheckEnemyHealth()
    {
        Debug.Log("Enemy Heath is " + EnemyHealth);
        if(EnemyHealth <= 0)
            this.gameObject.SetActive(false);
        return;
    }
}
