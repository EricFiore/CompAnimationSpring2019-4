using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscam : MonoBehaviour
{

 
     public Camera cameraRot;
     private Vector3 objRot;
 
 
     // Use this for initialization
     void Start()
     {
         //Only take the x axis rotation
         //Bone only uses Z for up and down, camera oddly is using the X for up and down
         Vector3 tmp = cameraRot.transform.localEulerAngles;
         tmp = cameraRot.transform.localEulerAngles;
         tmp.x = 0f;
         tmp.y = 0f;
         tmp.z = -cameraRot.transform.localEulerAngles.x + 10.0f;
         objRot = tmp;
 
         transform.localEulerAngles = objRot;
     }
 
     // Update is called once per frame
     void Update()
     {
 
     }
     void LateUpdate()
     {
         //Only take the x axis rotation
         //Bone only uses Z for up and down, camera oddly is using the X for up and down
         Vector3 tmp = cameraRot.transform.localEulerAngles;
         tmp = cameraRot.transform.localEulerAngles;
         tmp.x = 0f;
         tmp.y = 0f;
         tmp.z = -cameraRot.transform.localEulerAngles.x + 10.0f;
         objRot = tmp;
 
         transform.localEulerAngles = objRot;
     }
 
}
