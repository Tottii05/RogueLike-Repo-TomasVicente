using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            coinText.text = player.GetComponent<MoneyManager>().coinCount.ToString();
        }
    }
}
