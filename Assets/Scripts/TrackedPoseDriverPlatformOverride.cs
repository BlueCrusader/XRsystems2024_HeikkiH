using UnityEngine;
using UnityEngine.InputSystem;
 
public class TrackedPoseDriverPlatformOverride
    : MonoBehaviour
{
    public UnityEngine.InputSystem.XR.TrackedPoseDriver trackedPose;
 
    public bool android;
    public bool standalone;
    public bool editor;
 
    public bool dontOverrideInEditor;
 
    [Header("Position")]
    public InputAction inputPosition;
 
    [Header("Rotation")]
    public InputAction inputRotation;
 
    private void Awake()
    {
#if UNITY_EDITOR
        if (dontOverrideInEditor)
            return;
#endif
 
#if UNITY_STANDALONE
        if (standalone)
        {
            trackedPose.positionAction.Disable();
            trackedPose.positionAction = inputPosition;
            trackedPose.positionAction.Enable();
 
            trackedPose.rotationAction.Disable();
            trackedPose.rotationAction = inputRotation;
            trackedPose.rotationAction.Enable();
        }
#endif
 
#if UNITY_ANDROID
        if (android)
        {
            trackedPose.positionAction.Disable();
            trackedPose.positionAction = inputPosition;
            trackedPose.positionAction.Enable();
 
            trackedPose.rotationAction.Disable();
            trackedPose.rotationAction = inputRotation;
            trackedPose.rotationAction.Enable();
        }
#endif
 
#if UNITY_EDITOR
        if (editor)
        {
            trackedPose.positionAction.Disable();
            trackedPose.positionAction = inputPosition;
            trackedPose.positionAction.Enable();
 
            trackedPose.rotationAction.Disable();
            trackedPose.rotationAction = inputRotation;
            trackedPose.rotationAction.Enable();
        }
#endif
    }
}
 