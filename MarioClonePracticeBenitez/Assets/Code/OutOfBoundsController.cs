using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    //This is scalable now
    public System.Action OutOfBoundEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "OutOfBounds")
            return;

        OutOfBoundEvent?.Invoke();
    }
}
