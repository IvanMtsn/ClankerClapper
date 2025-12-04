using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyArray;
    float _timeTillSpawn = 3f;
    float _currentTimerProgress = 0;
    public bool CanSpawnEnemies;
    float _maxEnemyCountOfSpawner = 4;
    float _enemyCountOfSpawner = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (!CanSpawnEnemies || _enemyCountOfSpawner >= _maxEnemyCountOfSpawner) { return; }

        if(_currentTimerProgress >= _timeTillSpawn)
        {
            _currentTimerProgress = 0;
            SpawnEnemy();
        }
        else
        {
            _currentTimerProgress += Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        int enemyToSpawnIndex = Random.Range(0, _enemyArray.Length-1);
        GameObject enemyOfThis = Instantiate(_enemyArray[enemyToSpawnIndex], transform.position, Quaternion.identity);
        enemyOfThis.GetComponent<EnemyDroid>().SetSpawner(GetComponent<EnemySpawner>());
        _enemyCountOfSpawner++;
    }
    public void ReduceEnemyCount()
    {
        _enemyCountOfSpawner--;
    }
}
