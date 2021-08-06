using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistName : MonoBehaviour
{
    // Start is called before the first frame update
    public static PersistName PersistentName;

    public string nameInput;
    public string tempName;
    public int score;


    private void Awake()
    {
        if(PersistentName != null)
        {
            Destroy(gameObject);
            return;
        }


        PersistentName = this;
        DontDestroyOnLoad(gameObject);
    }

    public void setName(string input)
    {
        tempName = input;
    }

    [System.Serializable]
    class SaveScore
    {
        public string nameInput;
        public int score;
    }

    public void SaveHighScore(int scoreInput)
    {
        SaveScore save = new SaveScore();
        save.nameInput = tempName;
        save.score = scoreInput;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore save = JsonUtility.FromJson<SaveScore>(json);

            nameInput = save.nameInput;
            score = save.score;
        }
    }

}
