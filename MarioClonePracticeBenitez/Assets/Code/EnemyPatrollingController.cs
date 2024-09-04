using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyController;

public class EnemyPatrollingController : EnemyController
{
    public GameObject PointA;
    public GameObject PointB;
    private Transform _currentPoint;

    private void Start()
    {
        _currentPoint = PointB.transform;
    }

    private void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;
    }

    public void EnemeyPatrol()
    {
        if (EnemyMovementType == EnemyBehaviour.PatrolPath)
        {
            if (_currentPoint == PointB.transform)
                Rigidbody.velocity = new Vector2(EnemySpeed, 0);
            else
                Rigidbody.velocity = new Vector2(-EnemySpeed, 0);

            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f)
                _currentPoint = PointA.transform;

            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f)
                _currentPoint = PointB.transform;
        }
    }
}
