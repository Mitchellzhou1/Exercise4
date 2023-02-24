using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
