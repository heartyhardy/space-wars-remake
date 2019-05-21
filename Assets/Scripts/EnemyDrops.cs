using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour {
    [Header("General")]
    [SerializeField] int scoreReward = 5;
    
    public int getScoreReward()
    {
        return scoreReward;
    }
}
