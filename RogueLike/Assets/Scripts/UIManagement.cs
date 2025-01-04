using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Slider hpSlider;
    private PlayerHp playerHp;
    void Start()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();

        if (playerHp != null)
        {
            hpSlider.maxValue = 100;
            hpSlider.value = playerHp.Hp;
        }
    }

    void Update()
    {
        if (playerHp != null)
        {
            hpSlider.value = playerHp.Hp;
        }
    }
}
