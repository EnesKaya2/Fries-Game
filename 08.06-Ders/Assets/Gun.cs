using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 target;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPos;
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform.position;
            direction = target - (Vector2)transform.position;
            transform.right = -direction;

        }
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, bulletSpawnPos.transform.position, bulletSpawnPos.rotation);
        }
    }
}
