using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform spawnPoint;

    public float timeBetweenWaves;

    private float countdown = 3f;

    private int WaveIndex = 0;

    public Text Wavecountdowntext;

    public Wave[] waves;

    public GameManager gameManager;

    void Update()
    {

        if (WaveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        Wavecountdowntext.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
            
        PlayerStates.rounds++;
        Wave wave = waves[WaveIndex];

        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(4f / wave.rate);
        }

        PlayerStates.Money += 300; 
        WaveIndex++;
        
        
    }
   public void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position, spawnPoint.rotation);
    }
}
