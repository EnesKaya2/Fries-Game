using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    CircleCollider2D collider;

    private Gun gun;
    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();

        gun = GameObject.Find("Gun").GetComponent<Gun>();

        float test = collider.radius;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            gun.isClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gun.isClose = false;
        }
    }
}
