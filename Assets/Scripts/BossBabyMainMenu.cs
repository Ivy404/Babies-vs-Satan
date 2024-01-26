using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBabyMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newGame(){
        Debug.Log("New Game");
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
    public void continueGame(){
        Debug.Log("Continue Game");
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
    public void exitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
}
