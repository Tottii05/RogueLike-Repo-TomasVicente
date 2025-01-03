using System.Collections;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public int TotalEnemies = 0;
    public int KilledEnemies = 0;
    public GameObject finalStairs;

    public void Start()
    {
        StartCoroutine(AsyncStairLoad());
    }

    private void OnEnable()
    {
        HPSystem.OnEnemyKilled += IncrementKillCount;
    }

    private void OnDisable()
    {
        HPSystem.OnEnemyKilled -= IncrementKillCount;
    }

    private void IncrementKillCount()
    {
        KilledEnemies++;
        CheckForVictory();
    }

    private void CheckForVictory()
    {
        if (KilledEnemies >= TotalEnemies)
        {
            ActivateFinalStairs();
        }
    }

    private void ActivateFinalStairs()
    {
        if (finalStairs != null)
        {
            finalStairs.SetActive(true);
        }
    }

    public IEnumerator AsyncStairLoad()
    {
        yield return new WaitForSeconds(0.25f);
        finalStairs = GameObject.Find("ExitDoor");
        if (finalStairs != null)
        {
            finalStairs.SetActive(false);
        }
    }
}
