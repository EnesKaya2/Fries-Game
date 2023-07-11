using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip ground;
    [SerializeField] private AudioClip dead;
    [SerializeField] private AudioClip attackEnemy;
    [SerializeField] private AudioClip playerEnemy;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void JumpSound()
    {
        audioSource.PlayOneShot(jump);
    }
    public void GroundSound()
    {
        audioSource.PlayOneShot(ground);
    }
    public void DeadSound()
    {
        audioSource.PlayOneShot(dead);
    }
    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemy);
    }
    public void PlayerEnemySound()
    {
        audioSource.PlayOneShot(playerEnemy);
    }
   
}
