using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightScript : MonoBehaviour
{
    public Light light;
    public Boolean lightState = true;
    public InputActionReference light_action;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();

        light_action.action.Enable();
        light_action.action.performed += (ctx) => 
        {
            if (lightState == true) {
                light.color = new Color(1, 1, 2);
                lightState = false;
            } else {
                light.color = new Color(1, 1, 1);
                lightState = true;
            }
            
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
