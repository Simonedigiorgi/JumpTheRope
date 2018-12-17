﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Components {

    public GameObject startMenu, optionsMenu, confirmMenu, highscoreMenu, endMenu;

    public int jumpsDone;
    private bool musicToggle;
    private bool effectsToggle;

    public Text jumpsText;
    public Text countdownText;
    public Text musicText;
    public Text effectsText;
    public Text tutorialText;

    void Start () {
        startMenu.SetActive(true);
    }

    private void Update()
    {
        jumpsText.text = "" + jumpsDone;

        PlayerPrefs.GetInt("Music");
        if(PlayerPrefs.GetInt("Music") == 0)
            SetMusic(true, "MUSIC OFF", false);
        else if (PlayerPrefs.GetInt("Music") == 1)
            SetMusic(false, "MUSIC ON", true);

        PlayerPrefs.GetInt("Effects");
        if (PlayerPrefs.GetInt("Effects") == 0)
            SetEffects(true, "EFFECTS OFF", false);
        else if (PlayerPrefs.GetInt("Effects") == 1)
            SetEffects(false, "EFFECTS ON", true);
    }

    public void StartGame()
    {
        StartCoroutine(StartTheGame());
    }

    public void RestartGame()
    {
        endMenu.SetActive(false);
        StartCoroutine(Reset());
    }

    public void MainMenu()
    {
        endMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void OptionsMenu(bool active)
    {
        optionsMenu.SetActive(active);
    }

    public void ConfirmMenu(bool a)
    {
        confirmMenu.SetActive(a);
    }

    public void HighScoreMenu(bool active)
    {
        highscoreMenu.SetActive(active);
    }

    public void MusicToggle()
    {
        musicToggle = !musicToggle;
        if (musicToggle == false)
            PlayerPrefs.SetInt("Music", 0);
        else if (musicToggle)
            PlayerPrefs.SetInt("Music", 1);
    }

    public void EffectsToggle()
    {
        effectsToggle = !effectsToggle;
        if (effectsToggle == false)
            PlayerPrefs.SetInt("Effects", 0);
        else if (effectsToggle)
            PlayerPrefs.SetInt("Effects", 1);
    }

    private void SetMusic(bool mute, string text, bool toggle)
    {
        am.musicSource.mute = mute;
        musicText.text = text;
        musicToggle = toggle;
    }

    private void SetEffects(bool mute, string text, bool toggle)
    {
        am.source.mute = mute;
        effectsText.text = text;
        effectsToggle = toggle;
    }

    private IEnumerator Reset()
    {
        am.GetComponent<AudioSource>().pitch = 1;
        an.speed = 0.85f;
        jumpsDone = 0;

        jumpsText.enabled = false;

        countdownText.text = "";
        yield return new WaitForSeconds(2);

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "Start";
        pc.isActive = true;

        tutorialText.enabled = false;
        jumpsText.enabled = true;
        an.SetBool("Move", true);

        yield return new WaitForSeconds(2);
        countdownText.text = "";
    }

    public IEnumerator StartTheGame()
    {
        Button b;
        b = startMenu.transform.GetChild(1).GetComponent<Button>();

        b.interactable = false;
        yield return new WaitForSeconds(3);
        startMenu.SetActive(false);
        b.interactable = true;
        am.musicSource.Play();

        StartCoroutine(Reset());
    }
}