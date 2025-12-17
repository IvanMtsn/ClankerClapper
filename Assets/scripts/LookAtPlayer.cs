using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform _player;
    Vector3 _target;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        _target = new Vector3(-_player.position.x, transform.position.y, -_player.position.z);
        transform.LookAt(_target);
    }
}
