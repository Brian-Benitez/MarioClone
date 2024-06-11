using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform PlayerTransform;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutOfBounds")
        {
            Debug.Log("out of bounds");
            PlayerTransform.transform.position = SpawnPoint.transform.position;
        }
    }
}
