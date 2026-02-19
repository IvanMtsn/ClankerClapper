using UnityEngine;

public class EnemyDroid : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    EnemySpawner _spawner;
    Transform _player;
    Rigidbody _rb;
    bool _isStunned = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _rb = GetComponent<Rigidbody>();
        SoundManager.instance.StartRobotMove(_audioSource);

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
       
        SoundManager.instance.StartRobotRambling(_audioSource);
        _isStunned =true;
        Invoke("ResetStun", 2);
        _audioSource.Stop();

        
    }
    void ResetStun()
    {
        _isStunned=false;
        _audioSource.Pause();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameModeManager.Instance.LoseHeart(1);
            SoundManager.instance.PlayPlayerHurtSound();   
        }
    }
}
