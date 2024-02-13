using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;
    bool twoGrabbing = false;
    
    private Transform prevObjPos;
    private Quaternion prevObjRot;
    private Transform prevHandPos;
    private Quaternion prevHandRot;
    private Transform prevOtherHandPos;
    private Quaternion prevOtherHandRot;

    private Transform originPos;

    public Vector3 lastPosition1;
    public Vector3 lastPosition2;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach(CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();
        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                grabbedObject.GetComponent<Rigidbody>().useGravity = false;

                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here

                //Testing
                twoGrabbing = otherHand.action.action.IsPressed();
                if (!twoGrabbing) {
                //originPos = grabbedObject;
                originPos = prevObjPos;
                }

                if (twoGrabbing == true) {
                    //Average position between two controllers
                    //grabbedObject.position = 0.5f*(transform.position + otherHand.transform.position);
                    
                    //Controller position change added to original position
                    //grabbedObject.position = originPos + (transform.position - originPos) + (otherHand.transform.position - originPos);
                    //grabbedObject.position = transform.position + (otherHand.transform.position - prevObjPos.position);
                    
                    //Combined position of two controllers
                    //grabbedObject.position = 1f*(transform.position + otherHand.transform.position);
                    
                    //var delta1 = transform.position - originPos.position;
                    //var delta2 = otherHand.transform.position - originPos.position;
                    //grabbedObject.transform.position += originPos.position + delta1 + delta2;
                    //grabbedObject.transform.position += originPos.position + delta2;
                    //grabbedObject.transform.position += delta1 + delta2;
                    
                    //grabbedObject.position = originPos.position + delta1 + delta2;
                    
                    
                   

                    

                    
                    // 
                    /*
                   
                    //Combined Rotation of both controllers
                    grabbedObject.rotation = otherHand.transform.rotation * transform.rotation;
                    //+90 x rotation needed
                    grabbedObject.rotation *= Quaternion.Euler(90, 0, 0);

                    //
                    //grabbedObject.position = transform.rotation * otherHand.transform.position + transform.position;

                    //
                    //var delta1 = transform.position - originPos.position;
                    //var delta2 = otherHand.transform.position - originPos.position;
                    //var delta1 = (transform.position - prevHandPos.position) * Time.deltaTime;
                    //var delta2 = (otherHand.transform.position - prevOtherHandPos.position) * Time.deltaTime;
                    Vector3 delta1 = (prevHandPos.position - transform.position) * Time.deltaTime;
                    Vector3 delta2 = (prevOtherHandPos.position - otherHand.transform.position) * Time.deltaTime;
                    //grabbedObject.position += originPos.position + delta1 + delta2;
                    //grabbedObject.position += delta1 + delta2;
                    //grabbedObject.position += prevObjPos.position + delta1 + delta2;
                    //grabbedObject.position += delta1 + delta2;
                    grabbedObject.position = prevObjPos.position + delta1 + delta2;
                    // */

                    //Vector3 delta1 = (prevHandPos.position - transform.position) * Time.deltaTime;
                    //Vector3 delta2 = (prevOtherHandPos.position - otherHand.transform.position) * Time.deltaTime;
                    //grabbedObject.position += delta1 + delta2;

                    Vector3 currentPosition1 = transform.position;
                    Vector3 positionChange1 = currentPosition1 - lastPosition1;
                    lastPosition1 = currentPosition1;
                    grabbedObject.position += positionChange1;

                    Vector3 currentPosition2 = otherHand.transform.position;
                    Vector3 positionChange2 = currentPosition1 - lastPosition1;
                    lastPosition2 = currentPosition2;
                    grabbedObject.position += positionChange2;


                    Quaternion combinedRotation = Quaternion.Lerp(transform.rotation, otherHand.transform.rotation, 0.5f);
                    grabbedObject.rotation = combinedRotation * Quaternion.Euler(0, 0, 0);

                    
                    
                    // */
                } else {
                    grabbedObject.position = transform.position;
                    grabbedObject.rotation = transform.rotation;
                }

                prevObjPos = grabbedObject;
                prevObjRot = grabbedObject.rotation;
                prevHandPos = transform;
                prevOtherHandPos = otherHand.transform;

                

                
                //
            }
            //Restore gravity
            //grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }
        // If let go of button, release object
        else if (grabbedObject)
            grabbedObject = null;

        // Should save the current position and rotation here
            //prevObjPos = grabbedObject;
            //prevObjRot = grabbedObject.rotation;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}


//Vector3 curObjPos = transform.position - prevObjPos.position;
//Quaternion curObjRot = Quaternion.Inverse(prevObjRot) * transform.rotation;
//grabbedObject.position += curObjPos;
//grabbedObject.rotation = grabbedObject.rotation * curObjRot;
// 


/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;
    bool twoGrabbing = false;
    
    private Transform prevObjPos;
    private Quaternion prevObjRot;
    private Transform prevHandPos;
    private Transform prevOtherHandPos;

    void Start()
    {
        action.action.Enable();

        foreach(CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();
        if (grabbing)
        {
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                grabbedObject.GetComponent<Rigidbody>().useGravity = false;

                twoGrabbing = otherHand.action.action.IsPressed();

                if (!twoGrabbing) {
                    grabbedObject.position = transform.position;
                    grabbedObject.rotation = transform.rotation;
                }
                else {
                    Vector3 delta1 = (prevHandPos.position - transform.position) * Time.deltaTime;
                    Vector3 delta2 = (prevOtherHandPos.position - otherHand.transform.position) * Time.deltaTime;
                    grabbedObject.position += delta1 + delta2;

                    Quaternion combinedRotation = Quaternion.Lerp(transform.rotation, otherHand.transform.rotation, 0.5f);
                    grabbedObject.rotation = combinedRotation * Quaternion.Euler(90, 0, 0);
                }

                prevObjPos = grabbedObject.transform;
                prevHandPos = transform;
                prevOtherHandPos = otherHand.transform;
            }
        }
        else if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject = null;
        }
    }
}


*/