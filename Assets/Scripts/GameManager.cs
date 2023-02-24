using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int life = 3;
    string levelName;

    public TMPro.TextMeshProUGUI scoreUI;
    public TMPro.TextMeshProUGUI lifeUI;
    private void Awake()
    {   
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;

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

// Stuff Mitchell Added
    public int getScore(){
        return score;
    }

    public void GGz(){
        life -= 3;
        if (life < 0)
            life = 0;
        lifeUI.text = "LIFE: " + life;
        swapToEnd(3);
    }

//

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
    if (levelName == "Level 3")
        {
        if (score >= 30)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Victory");
        }
        }
    }
    IEnumerator swapToEnd (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("GameOver");
    }
}
