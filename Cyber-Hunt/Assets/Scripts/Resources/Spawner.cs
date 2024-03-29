
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string Name;

    public GameObject prefab;
    [Range(0, 100f)] public float Chance = 100f;

    [HideInInspector] public double _weight;

}
public class Boss
{
    public string Name;

    public GameObject prefab;


}
public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameObject SpiderBoss;
    private bool spawnedSpider;
    [SerializeField] private GameObject DroneBoss;
    private bool spawnedDrone;
    [SerializeField] private GameObject BeeBoss;
    private bool spawnedBee;
    [SerializeField] private int _maxEnemies;

    private double accumulateWeights;
    private System.Random rand = new System.Random();
    private int EnemyAmount = 0;

    private void Awake()
    {
        CalculateWeights();
    }

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if(EnemyAmount <= _maxEnemies/10&& !globalVarables.Bossfight)
        {
            Spawn();
        }
        if(globalVarables.kills >= 100&&!spawnedSpider)
        {
            SpawnSpiderBoss();
        }
        if (globalVarables.kills >= 300 && !spawnedDrone)
        {
            SpawnDroneBoss();
        }
        if (globalVarables.kills >= 500 && !spawnedBee)
        {
            SpawnBeeBoss();
        }
    }

    private void SpawnRandomEnemy(Vector2 position)
    {
        Enemy randomEnemy = _enemies[GetRandomEnemyIndex()];

        Instantiate(randomEnemy.prefab, position, Quaternion.identity, transform);
    }
    // Start is called before the first frame update
   
    private void Spawn()
    {
        for(EnemyAmount = 0;EnemyAmount< _maxEnemies; EnemyAmount++)
        {
            SpawnRandomEnemy(new Vector2(Random.Range(-6f, 6f), Random.Range(-8f, 8f)));
        }
    }
    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulateWeights;
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i]._weight >= r)
            {
                return i;
            }
        }
        return 0;
    }

    private void CalculateWeights()
    {
        accumulateWeights = 0f;
        foreach(Enemy enemy in _enemies)
        {
            accumulateWeights += enemy.Chance;
            enemy._weight = accumulateWeights;
        }
    }
    
    public void ReduceEnemys(int Amount)
    {
        if (EnemyAmount >= Amount)
        {
            EnemyAmount -= Amount;
        }
        else
        {
            Debug.Log("Not enough enemys remaining");
        }
    }
    private void SpawnSpiderBoss()
    {
        Instantiate(SpiderBoss, Vector3.zero, Quaternion.identity, transform);
        spawnedSpider = true;
        globalVarables.Bossfight = true;
    }
    private void SpawnBeeBoss()
    {

        Instantiate(BeeBoss, Vector3.zero, Quaternion.identity, transform);
        spawnedBee = true;
        globalVarables.Bossfight = true;
    }
    private void SpawnDroneBoss()
    {

        Instantiate(DroneBoss, Vector3.zero, Quaternion.identity, transform);
        spawnedDrone = true;
        globalVarables.Bossfight = true;
    }



}
