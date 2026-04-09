using UnityEngine;
using UnityEngine.InputSystem;

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
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStunned)
        {
            transform.LookAt(_player);
            //NUR DEBUG
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                StunEnemy();
            }
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
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("hit");

    }
    void ResetStun()
    {
        _isStunned=false;
        _audioSource.Pause();
        GetComponent<Animator>().enabled = false;
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

    private async void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && GameModeManager.Instance.InvincTimer <= 0)
        {
            SoundManager.instance.PlayPlayerHurtSound();
            await GameModeManager.Instance.LoseHeart(1);
        }
    }
}
