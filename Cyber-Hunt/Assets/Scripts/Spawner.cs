using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string Name;

    public GameObject prefab;
    [Range(0, 100f)] public float Chance = 100f;

    [HideInInspector] public double _weight;

}
public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private int _maxEnemies;

    private double accumulateWeights;
    private System.Random rand = new System.Random();

    private void Awake()
    {
        CalculateWeights();
    }

    void Start()
    {
        Spawn();
    }

    private void SpawnRandomEnemy(Vector2 position)
    {
        Enemy randomEnemy = _enemies[GetRandomEnemyIndex()];

        Instantiate(randomEnemy.prefab, position, Quaternion.identity, transform);
    }
    // Start is called before the first frame update
   
    private void Spawn()
    {
        for(int i = 0;i< _maxEnemies; i++)
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
    
    
    
    
    
 
    
}
