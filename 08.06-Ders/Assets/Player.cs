using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float age;
    [SerializeField] private float weight;
    [SerializeField] private bool isStudy;

    // Start is called before the first frame update
    private void Start()
    {
        if (!isStudy)
        {
            if (age == 18 && weight < 100)
            {
                Debug.Log("Askerlik Görevi Ýçin Cagrýldýgýnýz");
            }
            else if (age > 18 && weight < 100)
            {
                float delay = age - 18;
                Debug.Log("Askerlik Görevi Ýcin" + delay + "Yýl Gec Kaldýnýz.Lütfen Birlige Teslim Olun");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Trigger'a Dokundu");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Trigger'ýn Ýçinde");
         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Triggerdan Çýktý");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Carpýsma'a Baþladý");
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Carpýsma Devam Ediyor");
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Debug.Log("Carpýsma Bitti");
        }

    }
}
