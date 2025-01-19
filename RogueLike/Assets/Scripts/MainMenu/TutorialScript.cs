using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject moveKeys;

    public void ShowTutorial()
    {
        moveKeys.GetComponent<Animator>().SetTrigger("Show");
    }
}
