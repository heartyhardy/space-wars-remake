using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject path;
    [SerializeField] float spawnCooldown = 2f;
    [SerializeField] float spawnCooldownRandomness = .5f;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] int spawnCount = 10;

    public GameObject getEnemeyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> getWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform waypoint in path.transform)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

    public float getSpawnCD()
    {
        return spawnCooldown;
    }

    public float getSpawnRandomness()
    {
        return spawnCooldownRandomness;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getSpawnCount()
    {
        return spawnCount;
    }
}
