using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPosMover : MonoBehaviour
{
    public InputActionReference move_action;
    public int playerPosIndex = 0;
    public Vector3 vectorPos;
    public Quaternion quatRot;
    // Start is called before the first frame update
    void Start()
    {
        vectorPos = new Vector3(0.0f, 0.0f, 0.0f);
        quatRot = new Quaternion(0, 0, 0, 1);
        move_action.action.Enable();
        move_action.action.performed += (ctx) => 
        {
            if (playerPosIndex == 0) {
                vectorPos = new Vector3(0.0f, 1.5f, 25.0f);
                quatRot = new Quaternion(0, 0, 0, 1);
                transform.SetPositionAndRotation(vectorPos, quatRot);
                playerPosIndex = 1;
            } else {
                vectorPos = new Vector3(0.0f, 1.5f, 0.0f);
                quatRot = new Quaternion(0, 0, 0, 1);
                transform.SetPositionAndRotation(vectorPos, quatRot);
                playerPosIndex = 0;
            }
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
