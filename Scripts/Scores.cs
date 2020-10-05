using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        displayScores(5);
    }

    //This function displays the top highscores
    public void displayScores(int topSize)
    {
        //Will store the string to output
        string final_text = "High Scores:";

        //The unprocessed lines containing score from the file
        string[] unprocessed_lines  = Functions.readFile("Assets/Assets/Scripts/HighScores.txt", 1);
        int   [] scores             = new int[unprocessed_lines.Length]; //Will store the processed scores

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
}