using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    private int score = 0;

    // Use this for initialization
    private void Awake()
    {
        InitSingleton();
    }

    public int getScore()
    {
        return score;
    }

    public void addToScore(int addition)
    {
        score += addition;
    }

    private void InitSingleton()
    {
        int noOfInstances = FindObjectsOfType<GameSession>().Length;

        if (noOfInstances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
