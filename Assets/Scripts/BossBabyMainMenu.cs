using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBabyMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject main;
    [SerializeField]
    private GameObject selectScreen;
    [SerializeField]
    private GameObject pauseScreen;
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
        main.SetActive(false);
        if(pauseScreen != null){
            pauseScreen.SetActive(false);
        }
        selectScreen.SetActive(true);
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
    public void Pause(){
        Debug.Log("New Game");
        main.SetActive(false);
        selectScreen.SetActive(false);
        pauseScreen.SetActive(true);
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
    public void continueGame(){
        Debug.Log("Continue Game");
        pauseScreen.SetActive(false);
        selectScreen.SetActive(false);
        main.SetActive(true);
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }
    public void exitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
        //UnityEngine.SceneManagement.SceneManager.LoadScene('Name');
    }

    public void gobackMainMenu(){
        main.SetActive(true);
        selectScreen.SetActive(false);
        if(pauseScreen != null){
            pauseScreen.SetActive(false);
        }
    }

    public void loadLevel(int name){
        SceneManager.LoadScene(name);
    }
}
