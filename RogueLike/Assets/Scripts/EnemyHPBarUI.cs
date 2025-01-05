using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBarUI : MonoBehaviour
{
    public const int MAX_HEALTH = 100;
    public GameObject enemy;
    public GameObject bar;

    void Update()
    {
        if (enemy != null)
        {
            bar.transform.localScale = new Vector3((float)enemy.GetComponent<HPSystem>().Hp / MAX_HEALTH, bar.transform.localScale.y, bar.transform.localScale.z);
        }
        else
        {
            bar.transform.localScale = new Vector3(0, bar.transform.localScale.y, bar.transform.localScale.z);
        }
    }
}
