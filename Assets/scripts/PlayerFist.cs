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
        if(_currentCooldownTimer >= _hitCooldown)
        {
            Vector3 enemyHitDirection = Vector3.Reflect(collision.rigidbody.linearVelocity.normalized, collision.GetContact(0).normal);
            collision.rigidbody.linearVelocity = enemyHitDirection * _hitStrength;
            _currentCooldownTimer = 0;
        }
    }
}
