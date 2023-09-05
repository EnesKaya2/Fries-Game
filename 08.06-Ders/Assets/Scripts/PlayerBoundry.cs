using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float leftBoundry;
    [SerializeField] float rightBoundry;
    float move;


    void Update()
    {
        move = Mathf.Clamp(transform.position.x, leftBoundry, rightBoundry);
        transform.position = new Vector3(move, transform.position.y, transform.position.z);
    }
}
