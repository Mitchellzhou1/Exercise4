using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int life = 3;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI lifeUI;
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
        scoreUI.text = " " + score;
        lifeUI.text = " " + life;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreUI.text = " " + score;
    }

    public void MinusLife()
    {
        if (life > 0)
        {
            life -= 1;
            lifeUI.text = " " + life;
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
            SceneManager.LoadScene("levelName");
        }

    }
}
