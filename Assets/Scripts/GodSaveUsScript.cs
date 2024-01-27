using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GodSaveUsScript : MonoBehaviour
{
    [SerializeField]
    private int[] levelStates;
    // Start is called before the first frame update
    void Start()
    {
        
        if(!saveFileExists()){
            /*string data = "";
            foreach(int num in levelStates){
                data = data + num.ToString() + '\n';
            }
            writeToFile(data, "saveData.wad");*/
            saveCurrentData();
        }else{
            readFileData();
        }
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
        foreach(int num in levelStates){
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
        levelStates = new int[l];
        for(int i=0; i< l; i++){
            int.TryParse(sdata[i], out levelStates[i]);
        }
    }
}
