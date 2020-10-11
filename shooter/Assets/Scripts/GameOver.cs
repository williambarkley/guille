using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    Scores ScoreText;

    public TextMeshProUGUI scoreRank;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Scores>();

        ScoreText.newScore(Constant.actual_score);
        ScoreText.ScoreText.text = Constant.actual_score.ToString();

        scoreRank.text = "You achieved the #" + ScoreText.rank().ToString() + " highest local highscore";
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(Constant.MENU_SCENE);
    }
}
