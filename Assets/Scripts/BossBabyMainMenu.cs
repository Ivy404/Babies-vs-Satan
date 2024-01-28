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
    private string[] names_c;
    private string[] initials;
    // Start is called before the first frame update
    void Start()
    {
        names_c = new string[8];
        initials = new string[8];

        string sts = Resources.Load("names_list").ToString();

        string[] names = sts.Split(",");

        sts = Resources.Load("surnames_list").ToString();

        string[] surnames = sts.Split(",");

        sts = Resources.Load("surnames_list").ToString();

        string[] modifiers = sts.Split(",");

        int nChoose;
        string nameBuilder, temp;
        for (int i = 0; i < 8; i++) {
            nameBuilder = "";
            // choose name
            nChoose = Random.Range(0, names.Length - 1);
            nameBuilder += names[nChoose];
            // save initial 1
            initials[i] = names[nChoose][0] + ". ";
            nameBuilder += chooseWithProbability(0.2f, names) + " ";

            // choose surname
            nChoose = Random.Range(0, surnames.Length - 1);
            nameBuilder += surnames[nChoose];
            // save initial 2
            initials[i] = surnames[nChoose][0] + ".";

            for (int j = 0; j < 4; j++)
            {
                temp = chooseWithProbability(0.8f / (float)j, surnames);
                if (!temp.Equals(""))
                {
                    nameBuilder += " " + temp;
                }
            }
            // save name
            names_c[i] = nameBuilder;
        }

        for (int i = 0;i < 8; i++) { Debug.Log(names_c[i]); }

    }

    string chooseWithProbability(float probability, string[] surnames)
    {
        float p = Random.value;
        if (p < probability)
        {
            return surnames[Random.Range(0, surnames.Length - 1)];
        }
        return "";
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

        // select name
        //Read the text from directly from the test.txt file
        // end

        todobautizado = true;
        main.SetActive(false);
        selectScreen.SetActive(false);
        victoryScreen.SetActive(true);
        AudioManager.audioManagerRef.PlaySound("roulette");
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
