using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame

    public InputActionReference gripInput;
    public InputActionReference triggerInput;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
        
    void Update()
    {
        if (!animator) return;
        float grip = gripInput.action.ReadValue<float>();
        float trigger = triggerInput.action.ReadValue<float>();

        animator.SetFloat("Grip", grip);
        animator.SetFloat("Trigger", trigger);

    }
}
