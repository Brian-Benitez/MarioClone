using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public Transform Target;

    [Header("Enemy Stats")]
    public int EnemyHealth = 3;
    public float EnemySpeed;


    private void Update()
    {
        EnemyMovement();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        EnemyHealth--;
        CheckEnemyHealth();
    }

    public void CheckEnemyHealth()
    {
        Debug.Log("Enemy Heath is " + EnemyHealth);
        if(EnemyHealth <= 0)
            this.gameObject.SetActive(false);
        return;
    }

    private void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, EnemySpeed * Time.deltaTime);
    }
}
