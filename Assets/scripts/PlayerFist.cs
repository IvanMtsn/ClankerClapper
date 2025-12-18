using UnityEngine;

public class PlayerFist : MonoBehaviour
{
    [SerializeField] float _hitStrength = 20f;
    [SerializeField] float _hitCooldown = 0.3f;
    float _currentCooldownTimer = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(_currentCooldownTimer < _hitCooldown)
        {
            _currentCooldownTimer += Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(_currentCooldownTimer < _hitCooldown) { return; }
        if(collision.gameObject.layer == 3)
        {
            Vector3 enemyHitDirection = Vector3.Reflect(collision.rigidbody.linearVelocity.normalized, collision.GetContact(0).normal);
            collision.rigidbody.linearVelocity = enemyHitDirection * _hitStrength;
            collision.gameObject.GetComponent<EnemyDroid>().StunEnemy();
            _currentCooldownTimer = 0;
        }
    }
}
