using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitySystem : MonoBehaviour
{
    public float adder;
    public Movement mv;
    public float WaveCount,CurrentWaves,TotalWaves;
    public Transform[] SpawnAll;
    public Transform[] SpawnProb;
    public Transform[] Bow;
    public Transform[] Pulse;
    public List<GameObject> enemies = new List<GameObject>();
    public Spawn[] prefab;
    public Spawn[] All;
    public Spawn[] BowPrefab;
    public Spawn[] PulsePrefab;
    public int EnemyCount;
   public  EnemyBehaviour[] g;
    bool before;

    private void Start()
    {
        mv = GameObject.Find("Player").GetComponent<Movement>();
        SpawnEnemy();
        EnemyCount = enemies.Count;
    }
    private void Update()
    {
        if (CurrentWaves == TotalWaves && enemies.Count<=0)
        {
            Debug.Log("Wave Finished");

          mv.controlPackage = true;
            Color tmp = mv.door.GetComponentInChildren<SpriteRenderer>().color;
            tmp.a += Time.deltaTime * 0.3f;
            mv.door.GetComponentInChildren<SpriteRenderer>().color = tmp;


        }
        if (enemies.Count<=0)
        {
            WaveCount += 1*Time.deltaTime;
        }
        if (WaveCount >= 1+adder && CurrentWaves<TotalWaves)
        {
            SpawnEnemy();
        }

        if (WaveCount >= 1  && CurrentWaves < TotalWaves && before==false)
        {
            foreach (Transform Spawn in SpawnAll)
            {
                Spawn.GetComponentInChildren<ParticleSystem>().Clear();
                Spawn.GetComponentInChildren<ParticleSystem>().Play();
            }

            foreach (Transform Spawn in SpawnProb)
            {
                Spawn.GetComponentInChildren<ParticleSystem>().Clear();
                Spawn.GetComponentInChildren<ParticleSystem>().Play();
            }

            foreach (Transform Spawn in Bow)
            {
                Spawn.GetComponentInChildren<ParticleSystem>().Clear();
                Spawn.GetComponentInChildren<ParticleSystem>().Play();
            }

            foreach (Transform Spawn in Pulse)
            {
                Spawn.GetComponentInChildren<ParticleSystem>().Clear();
                Spawn.GetComponentInChildren<ParticleSystem>().Play();
            }
            before = true;
        }
        if (WaveCount < TotalWaves)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                    enemies.Remove(enemy);
            }
        }

      
        
            Debug.Log("Count List "+g.Length);
        
    }

    void SpawnEnemy()
    {
        WaveCount = 0;
        CurrentWaves += 1;
        foreach (Transform Spawn in SpawnAll)
        {
           
            int i = (int)Random.Range(0, 100);
            for (int j = 0; j < prefab.Length; j++)
            {
               
                if (i >= prefab[j].minProbabilityRange && i <= prefab[j].maxProbabilityRange && Spawn.gameObject.activeInHierarchy)
                {
                    
                    GameObject carGo = Instantiate(prefab[j].spawnObject, Spawn.position, Spawn.rotation);
                    
                    
                }
            }
           
        }
        foreach (Transform Spawn in SpawnProb)
        {
            
            int i = (int)Random.Range(0, 80);
            for (int j = 0; j < All.Length; j++)
            {
                

                if (i >= All[j].minProbabilityRange && i <= All[j].maxProbabilityRange && Spawn.gameObject.activeInHierarchy)
                {
                    
                    GameObject carGo = Instantiate(All[j].spawnObject, Spawn.position, Spawn.rotation);


                }
            }
           
        }
        foreach (Transform Spawn in Bow)
        {
            
            int i = (int)Random.Range(0, 100);
            for (int j = 0; j < BowPrefab.Length; j++)
            {

                if (i >= BowPrefab[j].minProbabilityRange && i <= BowPrefab[j].maxProbabilityRange && Spawn.gameObject.activeInHierarchy)
                {
                  
                    GameObject carGo = Instantiate(BowPrefab[j].spawnObject, Spawn.position, Spawn.rotation);


                }
            }
           
        }
        foreach (Transform Spawn in Pulse)
        {
           
            int i = (int)Random.Range(0, 100);
            for (int j = 0; j < PulsePrefab.Length; j++)
            {

                if (i >= PulsePrefab[j].minProbabilityRange && i <= PulsePrefab[j].maxProbabilityRange && Spawn.gameObject.activeInHierarchy)
                {
                    
                    GameObject carGo = Instantiate(PulsePrefab[j].spawnObject, Spawn.position, Spawn.rotation);


                }
            }
           
        }
        g = GameObject.FindObjectsOfType<EnemyBehaviour>();
        foreach (EnemyBehaviour badguy in g){
            
            enemies.Add(badguy.gameObject);
            badguy.Index = enemies.IndexOf(badguy.gameObject);
             

        }

        before = false;
    }
}
   
[System.Serializable]
public class Spawn
    {
        public GameObject spawnObject;
        public int minProbabilityRange = 0;
        public int maxProbabilityRange = 0;
    }

