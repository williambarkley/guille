using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Scores : MonoBehaviour
{
    const string SCORE_FILE = "HighScores.txt";

    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(SCORE_FILE))
            Functions.createFile(SCORE_FILE, "Scores: #Try not to touch this file :)");
    }

    //This function displays the top highscores
    public void displayScores(int topSize)
    {
        //Will store the string to output
        string final_text = "High Scores:";

        //The unprocessed lines containing score from the file
        string[] unprocessed_lines = Functions.readFile(SCORE_FILE, 1);
        int[] scores = new int[unprocessed_lines.Length]; //Will store the processed scores

        //We store the processed scores
        for (int i = 0; i < unprocessed_lines.Length; i++)
            scores[i] = int.Parse(unprocessed_lines[i]);

        //We order the results
        Functions.orderGTL(ref scores);

        //We make the final string
        for (int i = 0; i < scores.Length && i < topSize; i++)
            final_text += "\n" + (i + 1) + " - " + scores[i];

        ScoreText.text = final_text;
    }

    //This function adds a highscore to the list
    public void newScore(int score)
    {
        Functions.writeFileLine(SCORE_FILE, score.ToString());
    }
}