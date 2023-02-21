using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int life = 3;
    public TMPro.TextMeshProUGUI scoreUI;
    public TMPro.TextMeshProUGUI lifeUI;
    private void Awake()
    {
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
        DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreUI.text = "SCORE: " + score;
        lifeUI.text = "LIFE: " + life;
    }

    public void AddScore()
    {
        score += 1;
        scoreUI.text = "SCORE: " + score;
    }

    public void MinusLife()
    {
        if (life > 0)
        {
            life -= 1;
            lifeUI.text = "LIFE: " + life;
        }
    }

    public void AddLife()
    {
        if (life > 0)
        {
            life += 1;
            lifeUI.text = "LIFE: " + life;
        }
    }

    void Update()
    {
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

    if (life == 0)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("StartGame");
        }

    }
}
