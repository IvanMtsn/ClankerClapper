using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputAction triggerAction;
    [SerializeField] private InputAction grabAction;

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = triggerAction.ReadValue<float>();
        float grabValue = grabAction.ReadValue<float>();

        _animator.SetFloat("Trigger", triggerValue);
        _animator.SetFloat("Grip", grabValue);

    }
}
