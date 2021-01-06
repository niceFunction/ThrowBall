using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreEntry
{
    public GameObject Score { get; set; }
    public float PlayerName { get; set; }
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public List<HighScoreEntry> highscoreList = new List<HighScoreEntry>();

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        for (int i = 0; i < highscoreList.Count; i++)
        {
            highscoreList[i].PlayerName -= Time.deltaTime;
            if (highscoreList[i].PlayerName <= 0)
            {
                highscoreList[i].Score.SetActive(true);
                highscoreList.Remove(highscoreList[i]);
            }
        }
    }

    public void AddToList(GameObject goalObject, float spawnInterval)
    {
        AddHighScore(goalObject, spawnInterval);
    }


    public void AddHighScore(GameObject newScore, float newPlayerName)
    {
        HighScoreEntry newScoreObject = new HighScoreEntry();
        
        newScoreObject.Score = newScore;
        newScoreObject.PlayerName = newPlayerName;


        highscoreList.Add(newScoreObject);

    }

}
