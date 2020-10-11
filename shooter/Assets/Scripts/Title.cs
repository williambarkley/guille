using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Image TutorialI;

    public Button NewGameB;
    public Button TutorialB;
    public Button HighscoresB;
    public Button ExitB;

    Button[] MainButtons;

    public Button ScoreReturnB;
    public Button TutorialReturnB;

    Scores ScoreText;

    private void Start()
    {
        ScoreText = GetComponent<Scores>();

        MainButtons = new Button[]{ NewGameB, TutorialB, HighscoresB, ExitB };

        ScoreReturnB.gameObject.SetActive(false);
        TutorialReturnB.gameObject.SetActive(false);

        ScoreText.displayScores(5);
        ScoreText.ScoreText.gameObject.SetActive(false);
        TutorialI.gameObject.SetActive(false);
    }

    public void Play()
    {
        //We initialize the score
        Constant.actual_score = 0;

        SceneManager.LoadScene(Constant.GAME_SCENE);
    }

    public void Tutorial()
    {
        foreach (Button b in MainButtons)
            b.gameObject.SetActive(false);

        TutorialReturnB.gameObject.SetActive(true);
        TutorialI.gameObject.SetActive(true);
    }

    public void Scores()
    {
        foreach (Button b in MainButtons)
            b.gameObject.SetActive(false);

        ScoreReturnB.gameObject.SetActive(true);
        ScoreText.ScoreText.gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ScoreReturn()
    {
        foreach (Button b in MainButtons)
            b.gameObject.SetActive(true);

        ScoreReturnB.gameObject.SetActive(false);
        ScoreText.ScoreText.gameObject.SetActive(false);
    }

    public void TutorialReturn()
    {
        foreach (Button b in MainButtons)
            b.gameObject.SetActive(true);

        TutorialReturnB.gameObject.SetActive(false);
        TutorialI.gameObject.SetActive(false);
    }
}
