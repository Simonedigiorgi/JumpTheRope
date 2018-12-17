using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : Components {

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
        if (gm.jumpsDone > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", gm.jumpsDone);
            highscore.text = "Highscore\n" + gm.jumpsDone.ToString();
        }
    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
