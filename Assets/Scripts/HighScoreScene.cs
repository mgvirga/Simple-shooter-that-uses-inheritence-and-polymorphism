using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class HighScoreScene : MonoBehaviour {
    public GameObject scoreText;
    public List<Score> scores;

    StreamWriter writer;
    StreamReader reader;

    string[] details;
	void Start () {
       
        scores = new List<Score>();
        scoreText = GameObject.FindGameObjectWithTag("Scores");
        scoreChecker("HighScores.txt");
        Score z = new Score(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("YourScore"));            // for saving scores
        scores.Add(z);
        hscore("HighScores.txt");
        display();
        PlayerPrefs.DeleteKey("name");                  //deletes the player pref entries
        PlayerPrefs.DeleteKey("YourScore");
        
    }

  
    void scoreChecker(string name)
    {
        try
        {
           
            reader = new StreamReader(Application.dataPath + "/" + name);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                details = line.Split(',');
                Score d = new Score(details[0], int.Parse(details[1]));
                scores.Add(d);
            }
            reader.Close();
        }
        catch(IOException e)
        {
            Debug.Log(e.Message);
        }


      
       
        
        
    }
    public void hscore(string name)
    {
        try
        {
            scores.Sort();
            scores.Reverse();
            PlayerPrefs.SetInt("last", scores[4].score);
            
            if (scores.Count >= 6)
                scores.RemoveAt(5);
            writer = new StreamWriter(Application.dataPath + "/" + name);
            for (int i = 0; i < scores.Count; i++)
            {
                writer.WriteLine(scores[i].name + "," + scores[i].score);
            }
        }
        catch(IOException e)
        {
            Debug.Log(e.Message);
        }
        writer.Close();
    }
    public void display()
    {
        
        foreach (Score x in scores)
        {
            scoreText.GetComponent<Text>().text += x + "\n";
        }
        
    }





}

public class Score : IComparable<Score>
{
    public string name;
    public int score;
    public Score(string n, int s)
    {
        name = n;
        score = s;
    }
    public override string ToString()
    {
        return string.Format(name + ' ' + score);
    }
    public int CompareTo(Score s)
    {
        return score.CompareTo(s.score);

    }
   

    }


