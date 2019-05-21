using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [Header("Load")]
    [SerializeField] [Range(2f,5f)] float loadDelay = 3f;

    public void LoadStartMenu()
    {
        StartCoroutine(StartMenu());
    }

    public void LoadGame()
    {
        StartCoroutine(GameOn());        
    }

    public void LoadGameOverMenu()
    {
        StartCoroutine(GameOver());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator StartMenu()
    {
        yield return StartCoroutine(FadeTrackVolume());
        SceneManager.LoadScene("StartMenu");
    }

    private IEnumerator FadeTrackVolume()
    {
        AudioSource audioSource = FindObjectOfType<MusicSource>().GetAudioSource();

        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.15f;
            yield return new WaitForSeconds(.25f);
        }
    }

    private IEnumerator GameOn()
    {
        yield return StartCoroutine(FadeTrackVolume());
        SceneManager.LoadScene("Game");
    }

    private IEnumerator GameOver()
    {
        yield return StartCoroutine(FadeTrackVolume());
        SceneManager.LoadScene("GameOver");
    }
}
