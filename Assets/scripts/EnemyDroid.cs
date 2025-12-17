using UnityEngine;

public class EnemyDroid : MonoBehaviour
{
    EnemySpawner _spawner;
    Transform _player;
    Rigidbody _rb;
    bool _isStunned = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStunned)
        {
            transform.LookAt(_player);

        }
    }
    private void FixedUpdate()
    {
        if (!_isStunned)
        {
            _rb.linearVelocity = _player.position - transform.position;

        }
    }
    public void StunEnemy()
    {
        _isStunned=true;
        Invoke("ResetStun", 2);
    }
    void ResetStun()
    {
        _isStunned=false;
    }
    public void SetSpawner(EnemySpawner spawner)
    {
        _spawner = spawner;
    }
    void Death()
    {
        Destroy(gameObject);
        _spawner.ReduceEnemyCount();
    }
}
