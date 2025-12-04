using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyDroid : MonoBehaviour
{
    EnemySpawner _spawner;
    Transform _player;
    Rigidbody _rb;
    public bool IsStunned = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStunned)
        {
            transform.LookAt(_player);

        }
    }
    private void FixedUpdate()
    {
        if (!IsStunned)
        {
            _rb.linearVelocity = _player.position - transform.position;

        }
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
