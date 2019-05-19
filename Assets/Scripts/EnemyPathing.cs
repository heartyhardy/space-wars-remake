using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints = new List<Transform>();

    private int waypointIndex = 0;

    // Use this for initialization
    void Start () {
        waypoints = waveConfig.getWaypoints();
	}
	
	// Update is called once per frame
	void Update () {
        FollowWaypoints();
	}

    public void setWaveConfig(WaveConfig wave)
    {
        this.waveConfig = wave;
    }

    private void FollowWaypoints()
    {
        if(waypointIndex <= waypoints.Count - 1)
        {
            var nextWaypoint = waypoints[waypointIndex].transform.position;
            float deltaSpeed = waveConfig.getMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(
                    transform.position,
                    nextWaypoint,
                    deltaSpeed
                );

            if(transform.position == nextWaypoint)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
