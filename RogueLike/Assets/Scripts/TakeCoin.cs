using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    public AudioClip takeCoinAudio;
    public GameObject audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<MoneyManager>().coinCount++;
            audioManager.GetComponent<AudioManager>().PlaySFX(takeCoinAudio);
            Destroy(gameObject);
        }
    }
}
