using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensCamDirection : MonoBehaviour
{
    public Transform cameraTransform;
    //public Transform MagGlassPosition;
    public Transform target;
    //public int rotationX = 0;
    //public int rotationY = 0;
    //public int rotationZ = 90;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        //Vector3 tempTargetPos = target.position;
        //Transform tempTarget = target;
        //Vector3 resultRotation = cameraTransform.rotation;
        //var lookPos = cameraTransform.position - target.position;
        


        //Mostly Works, fails when magnifying glass is rolled 
        // /*
        Vector3 lookPos = target.position - cameraTransform.position;
        Quaternion camRotation = Quaternion.LookRotation(lookPos, Vector3.up);
        //target.SetPositionAndRotation(target.position, camRotation);
        target.rotation = camRotation;
        // */
        
        // 
        /*
        Vector3 lookAway = target.position - cameraTransform.position;
        Quaternion awayRotation = Quaternion.LookRotation(lookAway);
        target.rotation = awayRotation;
        // */
        
        // Test c
        /*
        //Vector3 cameraPosition = cameraTransform.TransformPoint(cameraTransform.position);
        //Vector3 targetPosition = target.TransformPoint(target.position);
        Vector3 cameraPosition = cameraTransform.position;
        Vector3 targetPosition = target.position;
        Vector3 cameraToTarget = targetPosition - cameraPosition;

        Quaternion cameraDirection = Quaternion.LookRotation(cameraToTarget, Vector3.up);
        target.SetPositionAndRotation(target.position, cameraDirection);
        // */


        //Testing other methods
        // 
        /*
        //Vector3 targetPos = target.InverseTransformPoint(cameraTransform.position);
        //Vector3 targetPos = target.InverseTransformPoint(target.position);
        Vector3 targetPos = target.position;
        //transform.position = target.TransformPoint(new Vector3(targetPos.x, targetPos.y, targetPos.z));
        //transform.position = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        //Vector3 targetDirection = target.TransformPoint(new Vector3(-targetPos.x, -targetPos.y, -targetPos.z));
        //Vector3 targetDirection = new Vector3(-targetPos.x, -targetPos.y, -targetPos.z);
        Vector3 targetDirection = target.position;
        Vector3 cameraDirection = cameraTransform.position;
        //cameraDirection = new Vector3(cameraDirection.x, cameraDirection.y, cameraDirection.z);
        //transform.LookAt(targetDirection, target.up);
        //transform.LookAt(targetDirection, target.forward);
        //transform.LookAt(cameraDirection, cameraTransform.up);

        Vector3 cameraToTargetDirection = targetDirection - cameraDirection;
        //transform.LookAt(cameraToTargetDirection, cameraTransform.up);
        //transform.LookAt(cameraToTargetDirection, target.up);
        transform.LookAt(cameraToTargetDirection, target.forward);
        // */




        //lookPos.z = 0;
        //lookPos.y = 0;
        //lookPos.x = 0;
        
        //Vector3 newPostition = new Vector3( lookPos.x, lookPos.y, lookPos.z );
        
        //Vector3 newPostition = new Vector3( this.transform.rotation.x, lookPos.y, lookPos.z );
        //Vector3 newPostition = new Vector3( lookPos.x, 0, lookPos.z );
        //Vector3 newPostition = new Vector3( lookPos.x, lookPos.y, -90 );

        //var camRotation = Quaternion.LookRotation(-lookPos);
        //var camRotation = Quaternion.LookRotation(-newPostition);
        //var camRotation = Quaternion.LookRotation(newPostition, Vector3.up);
        //target.rotation = camRotation;

        //var camRotation = Quaternion.LookRotation(lookPos, Vector3.up);
        //target.SetPositionAndRotation(target.position, camRotation);
        




        //Quaternion originalQuat = Quaternion.Euler(tempTargetPos.x, tempTargetPos.y, tempTargetPos.z);
        
        //Vector3 v = target.rotation.eulerAngles;
        //Vector3 v2 = tempTarget.rotation.eulerAngles;

        //transform.rotation = Quaternion.Euler (v.x, v.y, v2.z);
        //transform.rotation = Quaternion.Euler (v.x, v2.y, v.z);
        //transform.rotation = Quaternion.Euler (v2.x, v.y, v.z);




        //target.position = new Vector3(target.position.x, 1, transform.position.z);
        //Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.forward);
        //Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.up);
        //Quaternion zQuaternion = Quaternion.AngleAxis(rotationZ, Vector3.right);
        //transform.localRotation = orginalRotation * zQuaternion;
        //transform.localRotation = xQuaternion;
        //transform.localRotation = yQuaternion;
        //transform.localRotation = zQuaternion;
        
       
    }
}
