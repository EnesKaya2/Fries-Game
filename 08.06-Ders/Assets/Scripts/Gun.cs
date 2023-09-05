using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 target;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunLight;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] ParticleSystem particle;
    public bool isClose;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireTimer;

    void Update()
    {
        fireRate += Time.deltaTime;

        if (fireRate > fireTimer && isClose)
        {
            fireRate = 0;
            FireBullet();
        }
        GunLight();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform.position;
            direction = target - (Vector2)transform.position;
            transform.right = -direction;
        }

    }
    public void FireBullet()
    {
        Instantiate(bullet, bulletSpawnPos.transform.position, bulletSpawnPos.rotation);
        Instantiate(particle, bulletSpawnPos.transform.position, bulletSpawnPos.rotation);
        SoundManager.instance.PlaySound(14);
    }
    public void GunLight()
    {
        if (isClose)
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.green;

        }
    }

}
