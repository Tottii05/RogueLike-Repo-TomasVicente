using System.Collections;
using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public int TotalEnemies = 0;
    public int KilledEnemies = 0;
    public GameObject finalStairs;
    public GameObject finalUI;
    public Animator fadeOutImage;
    public GameObject postProcessing;
    public GameObject player;
    public TextMeshProUGUI killCountText;
    public GameObject audioManager;
    public AudioClip victorySound;

    public void Start()
    {
        StartCoroutine(AsyncStairLoad());
        player = GameObject.Find("Player");
        audioManager = GameObject.Find("AudioManager");
    }

    private void OnEnable()
    {
        HPSystem.OnEnemyKilled += IncrementKillCount;
        EndGameScript.OnFinalDoorPassed += OnFinalDoorPassed;
    }

    private void OnDisable()
    {
        HPSystem.OnEnemyKilled -= IncrementKillCount;
        EndGameScript.OnFinalDoorPassed -= OnFinalDoorPassed;
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

    private void OnFinalDoorPassed()
    {
        postProcessing.SetActive(false);
        fadeOutImage.SetTrigger("FadeOut");
        StartCoroutine(EndGameCanvasLoad());
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

    public IEnumerator EndGameCanvasLoad()
    {
        audioManager.GetComponent<AudioManager>().StopMusic();
        audioManager.GetComponent<AudioManager>().PlaySFX(victorySound);
        yield return new WaitForSeconds(1.2f);
        killCountText.text = KilledEnemies.ToString();
        finalUI.SetActive(true);
        Destroy(player);
    }
}
