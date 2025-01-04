using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public const int MAX_HEALTH = 100;
    public GameObject player;
    public GameObject bar;
    public GameObject heart;

    void Start()
    {
        player = GameObject.Find("Player");
        heart = GameObject.Find("Heart");
    }

    void Update()
    {
        if (player != null)
        {
            bar.transform.localScale = new Vector3((float)player.GetComponent<PlayerHp>().Hp / MAX_HEALTH, bar.transform.localScale.y, bar.transform.localScale.z);
        }
        else
        {
            bar.transform.localScale = new Vector3(0, bar.transform.localScale.y, bar.transform.localScale.z);
            heart.SetActive(false);
        }
    }
}
