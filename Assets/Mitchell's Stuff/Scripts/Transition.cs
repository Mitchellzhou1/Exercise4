using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Transition : MonoBehaviour
{
    Image transition;
    bool loading=false;
    bool unloading=false;
    float timer=0;
    float speed=0.3f;
    public string nextScene;

    void OnEnable()
    {
        SceneManager.sceneLoaded+=onsceneload;  //subscribe to scene loaded
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded-=onsceneload;  //unsubscribe to scene loaded
    }


    private void onsceneload(Scene arg0, LoadSceneMode arg1)
    {
        timer=0;
        loading=true;
        transition=GameObject.FindGameObjectWithTag("Finish").GetComponent<Image>();  //get the image with tag Finish     

    }
    

    // Update is called once per frame
    void Update()
    {
        if(loading && timer<1)
        {
            timer+=Time.deltaTime*speed; 
            float alpha=Mathf.Lerp(1,0,timer);
            Color color=transition.color;
            color.a=alpha;
            transition.color=color;
            if(timer>0.95)
            {
                loading =false;
                timer=0;
            }
        }
        if(unloading && timer<1)
        {
            timer+=Time.deltaTime*speed; 
            float alpha=Mathf.Lerp(0,1,timer);
            Color color=transition.color;
            color.a=alpha;
            transition.color=color;
            if(timer>0.95)
            {
                unloading =false;

            }
        }
        
        
    }
}