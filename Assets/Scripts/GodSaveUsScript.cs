using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GodSaveUsScript : MonoBehaviour
{
    [SerializeField]
    private int[] levelId;
    [SerializeField]
    private string[] levelChildName;
    [SerializeField]
    private int[] levelState;
    void Start()
    {
        if(!PlayerPrefs.HasKey("levelnumber")){
            Debug.Log(PlayerPrefs.GetInt("levelnumber"));
            levelChildName = new string[levelId.Length];
            levelState = new int[levelId.Length];
            saveProgress();
        }
        loadProgress();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            saveProgress();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            loadProgress();
        }
        
    }

    public void saveProgress(){
        PlayerPrefs.SetInt("levelnumber", levelId.Length);
        for(int i = 0; i< levelId.Length; i++){
            PlayerPrefs.SetString("level"+levelId[i].ToString()+"childname", levelChildName[i]);
            PlayerPrefs.SetInt("level"+levelId[i].ToString()+"state", levelState[i]);
        }
        PlayerPrefs.Save();
    }

    public void loadProgress(){
        levelChildName = new string[levelId.Length];
        levelState = new int[levelId.Length];
        for(int i = 0; i< levelId.Length; i++){
            levelChildName[i] = PlayerPrefs.GetString("level"+levelId[i].ToString()+"childname");
            levelState[i] = PlayerPrefs.GetInt("level"+levelId[i].ToString()+"state");
        }
    }
    /*[SerializeField]
    private string[] levelStates;
    private bool[] levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        
        if(!saveFileExists()){
            saveCurrentData();
        }else{
            readFileData();
        }
        levelPassed = new bool[levelStates.Length];
        updatePassedLevels();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void simpleWriteString()
    {
       string path = Application.persistentDataPath + "/test.txt";
       //Write some text to the test.txt file
       StreamWriter writer = new StreamWriter(path, true);
       writer.WriteLine("Test");
        writer.Close();
       StreamReader reader = new StreamReader(path);
       //Print the text from the file
       reader.Close();
    }
   public static void simpleReadString()
    {
       string path = Application.persistentDataPath + "/test.txt";
       //Read the text from directly from the test.txt file
       StreamReader reader = new StreamReader(path);
       Debug.Log(reader.ReadToEnd());
       reader.Close();
    }
    public static void writeToFile(string data, string file){
        string path = Application.persistentDataPath + "/" + file;
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(data);
        writer.Close();
    }
   public static string readFromFile(string path)
    {
       //Read the text from directly from the test.txt file
       StreamReader reader = new StreamReader(path);
       path = reader.ReadToEnd();
       reader.Close();
       return path;
    }
    public static bool saveFileExists(){
        return File.Exists(Application.persistentDataPath + "/saveData.wad");
    }
    public void saveCurrentData(){
        string data = "";
        foreach(string num in levelStates){
            data = data + num.ToString() + '\n';
        }
        writeToFile(data, "saveData.wad");
    }
    public void readFileData(){
        //int.TryParse(sillyMeme, out memeValue)
        string path = Application.persistentDataPath+"/saveData.wad";
        //Debug.Log(path);
        string[] sdata = readFromFile(path).Split('\n');
        int l = sdata.Length -1;
        levelStates = new string[l];
        for(int i=0; i< l; i++){
            levelStates[i] = sdata[i];
        }
    }
    public void setLevelState(int level, string state){
        levelStates[level] = state;
    }
    public void updatePassedLevels(){
        for(int i=0;i<levelPassed.Length;i++){
            Debug.Log(levelStates[i].Split(';'));
            bool ls = (levelStates[i].Split(';')[1] != "");
            levelPassed[i] = ls;
        }
    }*/
}
