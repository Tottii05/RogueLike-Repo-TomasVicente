using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour, IDroppeable
{
    public GameObject itemPrefab;
    public int minAmount;
    public int maxAmount;

    public void Drop()
    {
        int amount = Random.Range(minAmount, maxAmount);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
