using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waves;
    [SerializeField] bool spawnLooping = false;
    int startingWave = 0;

	// Use this for initialization
	IEnumerator Start () {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (spawnLooping);
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waves.Count; waveIndex++)
        {
            var currentWave = waves[waveIndex];
            yield return StartCoroutine(SpawnAllInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllInWave(WaveConfig currentWave)
    {
        for(int enemyCount = 0; enemyCount < currentWave.getSpawnCount(); enemyCount++)
        {
            var spawnRandomness = UnityEngine.Random.Range(
                    currentWave.getSpawnCD() - currentWave.getSpawnRandomness(),
                    currentWave.getSpawnCD() + currentWave.getSpawnRandomness()
                );

            var enemy = Instantiate(
                    currentWave.getEnemeyPrefab(),
                    currentWave.getWaypoints()[0].transform.position,
                    Quaternion.identity
                    );

            enemy.GetComponent<EnemyPathing>().setWaveConfig(currentWave);

            yield return new WaitForSeconds(spawnRandomness);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
