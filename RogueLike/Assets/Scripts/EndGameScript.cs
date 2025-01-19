using System;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public static Action OnFinalDoorPassed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnFinalDoorPassed?.Invoke();
        }
    }
}
