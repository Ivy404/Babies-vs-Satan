using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBabyMainMenu : MonoBehaviour
{
    [SerializeField]
    private bool testmode;
    [SerializeField]
    private GameObject main;
    [SerializeField]
    private GameObject selectScreen;
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject victoryScreen;
    [SerializeField]
    private GameObject roulete;
    [SerializeField]
    private GameObject namemsg;
    [SerializeField]
    private int nextLevel;
    [SerializeField]
    private bool inmainmenu = false;
    private bool todobautizado = false;
    private bool pausado = false;
    [SerializeField]
    private float waitUntil = 4.0f;
    private float timewon = 0f;
    private RectTransform spinO;
    private float fRotations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && testmode){
            Debug.Log("Victory");
            bautizadoOle();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && !inmainmenu && !todobautizado){
            if(pausado){
                continueGame();
                pausado = !pausado;
            }else{
                Pause();
                pausado = !pausado;
            }
        }

        if(todobautizado){
            if(timewon < waitUntil)
            {
                makeRotations();
                timewon += Time.deltaTime;
            }else{
                namemsg.SetActive(true);
            }
        }
    }

    void makeRotations()
    {
        float rot = Mathf.Lerp(0f, 360f*fRotations, 1f - Mathf.Pow(1f - timewon / waitUntil, 4));
        //rot = (rot % 360f) - 180f;
        Vector3 angles = spinO.eulerAngles;
        angles.z = rot; // + rotationSpeed for right button
        spinO.eulerAngles = angles;
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
        if(todobautizado){
            loadLevel(0);
        }
        else{
            main.SetActive(true);
            selectScreen.SetActive(false);
            if(pauseScreen != null){
                pauseScreen.SetActive(false);
            }
        }
    }

    public void loadLevel(int name){
        SceneManager.LoadScene(name);
    }

    public void bautizadoOle(){
        todobautizado = true;
        main.SetActive(false);
        selectScreen.SetActive(false);
        victoryScreen.SetActive(true);
        spinO = roulete.GetComponent<RectTransform>();
        fRotations = 3.0f + Random.value;
        if (pauseScreen != null){
            pauseScreen.SetActive(false);
        }
    }

    public void loadNextLevel(){
        loadLevel(nextLevel);
    }
}
