using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

public float delta = 1.5f;  
public float speed = 2.0f;
private Vector3 startPos;
public UnityEngine.Camera cam;
public Transform checkedObject;
public Material normalColor;
bool isvisible;
bool red;

void Start()
{
    cam = UnityEngine.Camera.main;
    isvisible = true;
}

void Update()
{
    Vector3 viewPos = cam.WorldToViewportPoint(checkedObject.position);
    if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
    {
        // Your object is in the range of the camera, you can apply your behaviour
		if(checkedObject.tag == "red")
		{
			red = true;
		}
		
		else if(checkedObject.tag == "green")
		{
			red = false;
		}
		
        isvisible = true;
    }
    else
        isvisible = false;
		red = true;
	
	Debug.Log(red);
}


}
