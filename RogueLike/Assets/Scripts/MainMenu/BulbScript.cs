using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbScript : MonoBehaviour
{
    public GameObject bulbOff;
    public GameObject bulbOn;
    void Start()
    {
        bulbOff.SetActive(true);
        bulbOn.SetActive(false);
        StartCoroutine(TurnOn());
    }

    public IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(1.05f);
        bulbOff.SetActive(false);
        bulbOn.SetActive(true);
    }
}
