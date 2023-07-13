using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float leftBoundry;
    [SerializeField] float rightBoundry;
    void Update()
    {
        if (transform.position.x < leftBoundry)
        {
            transform.position = new Vector3(leftBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightBoundry)
        {
            transform.position = new Vector3(rightBoundry, transform.position.y, transform.position.z);
        }
    }
}
