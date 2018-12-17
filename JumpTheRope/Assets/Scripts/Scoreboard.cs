using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public Text score;
    public Text highscore;
    public Text highscoreMText;

	void Start () {
        highscore.text = "Highscore\n" + PlayerPrefs.GetInt("Score").ToString();
    }

    private void Update()
    {
        highscoreMText.text = "Highscore\n" + PlayerPrefs.GetInt("Score").ToString();
    }

    public void Save()
    {
        GameManager g;
        g = FindObjectOfType<GameManager>();

        if (g.jumpsDone > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", g.jumpsDone);
            highscore.text = "Highscore\n" + g.jumpsDone.ToString();
        }
    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
