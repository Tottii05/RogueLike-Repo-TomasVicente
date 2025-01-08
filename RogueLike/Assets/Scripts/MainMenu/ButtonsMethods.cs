using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMethods : MonoBehaviour
{
    public GameObject moveKeys;
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BasementMain");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowTutorial()
    {
        moveKeys.GetComponent<Animator>().SetBool("Move", true);
    }
}
