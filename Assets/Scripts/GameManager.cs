using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int life = 3;
    string levelName;

    public TMPro.TextMeshProUGUI scoreUI;
    public TMPro.TextMeshProUGUI lifeUI;

    private bool defeatedBoss = false;
    private bool GameOver = false;

    private void Awake()
    {   
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;

        // we have game manager on every scene... so we don't need this code.s
        // if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        // {
        //     //print(GameObject.FindObjectsOfType<GameManager>());
        //     Destroy(gameObject);
        // }
        // else
        // {
        // DontDestroyOnLoad(gameObject);
        // }
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
            if (life == 0){
                GameOver = true;
            }
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

// Stuff Mitchell Added
    public int getScore(){
        return score;
    }

    public int getLife(){
        return life;
    }

    public void beatGame(){
        defeatedBoss = true;
    }

//

    void screenChecker()
    {
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

    if (levelName == "Level 1")
        {
        if (score >= 10)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Level 2");
        }
        }
    if (levelName == "Level 2")
        {
        if (score >= 20)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Level 3");
        }
        }
    }

    void Update(){
        if (levelName == "Level 3" && defeatedBoss)
        {
            StartCoroutine(swapToEnd(6));
            defeatedBoss = false;
        }
        if (GameOver){
            StartCoroutine(swapToLost(6));
            GameOver = false;
        }
        screenChecker();
    }

    IEnumerator swapToEnd (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Victory");
    }
    IEnumerator swapToLost (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        score = 0;
        life = 3;
        SceneManager.LoadScene("GameOver");
    }
}
