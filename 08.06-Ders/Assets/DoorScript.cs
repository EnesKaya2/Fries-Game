using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.instance.PlaySound(13);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            collision.gameObject.GetComponent<Movement>().enabled = false;
            collision.gameObject.GetComponent<Jump>().enabled = false;
        }
    }
}
