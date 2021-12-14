using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy1;
        public Transform enemy2;
        public Transform enemy3;
        public Transform enemy4;
        public Transform boss;
        public int count1;
        public int count2;
        public int count3;
        public int count4;
        public int BossCount;
        public float rate;
    }
    public GameObject WallSet1;
    public GameObject WallSet2;


    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING  
    };

    public Wave[] waves;
    public Transform[] SpawnPoints;
    public float timeBetweenWaves = 5f;
    public float WaveCountdown;
    private SpawnState state = SpawnState.COUNTING;
    public int nextWave = 0;
    private float SearchCountDown = 1f;

    // sound code
    public AudioSource SoundSource1;
    public AudioClip DeepSoundTrack;
    public AudioSource SoundSource2;
    public AudioClip SoftSoundTrack;

    // Start is called before the first frame update
    void Start()
    {
        WaveCountdown = timeBetweenWaves;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (nextWave == 2)
        {
            WallSet1.SetActive(true);
        }
        if (nextWave == 3)
        {
            WallSet1.SetActive(false);
            WallSet2.SetActive(true);
        }
        if (nextWave == 4)
        {
            WallSet1.SetActive(true);
            WallSet2.SetActive(true);
        }
        PlaySound();
        if (state == SpawnState.WAITING)
        {
            //Check if their are active enemies
            if (!EnemyIsAlive())
            {
                //Begin new Round
                
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (WaveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //Start Spawning Wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            
        }
        else
        {
            WaveCountdown -= Time.deltaTime;
        }
        
    }
    void WaveCompleted()
    {
       // Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        WaveCountdown = timeBetweenWaves;

        if(nextWave+1> waves.Length - 1)
        {
            nextWave = 0;

            //end game
           // Debug.Log("All waves Have been Completed, now looping....");
            // can add end state, or you can add a stack multiplier;
        }
        else
        {
            nextWave++;
        }
        
    }
    bool EnemyIsAlive()
    {
        SearchCountDown -= Time.deltaTime;
        if (SearchCountDown <= 0)
        {
            SearchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;

    }
    IEnumerator SpawnWave( Wave _wave)
    {
       // Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;
        //spawn all enemy 1 units
        for(int i=0; i< _wave.count1; i++)
        {
            SpawnEnemy(_wave.enemy1);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //Spawn All enemy 2 units
        for (int i = 0; i < _wave.count2; i++)
        {
            SpawnEnemy(_wave.enemy2);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //Spawn All enemy 3 units
        for (int i = 0; i < _wave.count3; i++)
        {
            SpawnEnemy(_wave.enemy3);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //Spawn All enemy 4 units
        for (int i = 0; i < _wave.count4; i++)
        {
            SpawnEnemy(_wave.enemy4);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //Spawn All boss units
        for (int i = 0; i < _wave.BossCount; i++)
        {
            SpawnEnemy(_wave.boss);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy( Transform _enemy)
    {
        //Spawn enemy
        //Debug.Log("Spawning Enemy " + _enemy.name);
        Transform _SP = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _SP.position, _SP.rotation);
        

    }
    void PlaySound()
    {

        if (nextWave == 4)
        {
            SoundSource1.volume = 1;
        }
        
       
            return;

    }
}
