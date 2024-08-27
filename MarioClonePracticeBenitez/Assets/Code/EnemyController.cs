using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int EnemyHealth = 3;
    public float EnemySpeed;

    public GameObject PointA;
    public GameObject PointB;
    private Transform _currentaPoint;

    public Rigidbody2D Rigidbody;
    //Add more enums if needed
    public enum EnemyBehaviour {RunLeft, RunRight, JumpUp, PatrolLeftAndRight};

    public EnemyBehaviour EnemyMovementType;

    private void Start()
    {
        _currentaPoint = PointB.transform;
    }

    private void Update()
    {
        Vector2 point = _currentaPoint.position - transform.position;
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
    //I wanna make this a bit more scable but can't think of it rn. Just wanna see if it would work.
    /// <summary>
    /// Determines what type of movement the enemy does.
    /// </summary>
    private void EnemyMovement()
    {
        if (EnemyMovementType == EnemyBehaviour.RunLeft)
        {
            Debug.Log("Make enemy move to the left.");
            Rigidbody.velocity = new Vector2(-EnemySpeed, 0);
        }
        else if (EnemyMovementType == EnemyBehaviour.RunRight)
        {
            Debug.Log("Make enemy run right.");
            Rigidbody.velocity = new Vector2(EnemySpeed, 0);
        }
        else if(EnemyMovementType == EnemyBehaviour.PatrolLeftAndRight)
        {
            if (_currentaPoint == PointB.transform)
                Rigidbody.velocity = new Vector2(EnemySpeed, 0);
            Rigidbody.velocity = new Vector2(-EnemySpeed, 0);

            if (Vector2.Distance(transform.position, _currentaPoint.position) < 0.5f && _currentaPoint == PointB.transform)
                _currentaPoint = PointA.transform;

            if (Vector2.Distance(transform.position, _currentaPoint.position) < 0.5f && _currentaPoint == PointA.transform)
                _currentaPoint = PointB.transform;
        }
        //Drawing some gizmos would be helpful for the points...
    }
}
