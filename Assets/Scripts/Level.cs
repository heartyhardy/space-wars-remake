using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [Header("Audio Related")]
    [SerializeField] [Range(.25f,1f)] float loadDelay = .25f;
    [SerializeField] [Range(.15f, .5f)] float volumeReduction = .15f;

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

    private IEnumerator GameOn()
    {
        yield return StartCoroutine(FadeTrackVolume());
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene("Game");
    }

    private IEnumerator GameOver()
    {
        yield return StartCoroutine(FadeTrackVolume());
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator FadeTrackVolume()
    {
        AudioSource audioSource = FindObjectOfType<MusicSource>().GetAudioSource();

        while (audioSource.volume > 0)
        {
            audioSource.volume -= volumeReduction;
            yield return new WaitForSeconds(loadDelay);
        }
    }
}
