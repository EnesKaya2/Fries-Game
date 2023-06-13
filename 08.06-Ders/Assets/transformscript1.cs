using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformscript1 : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Delta Time Olmadan 
        transform.Rotate(transform.forward * speed);
    }
}
