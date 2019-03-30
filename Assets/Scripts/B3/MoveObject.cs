using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

	public Camera cam;
	public float force = 5;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rb;

                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {                     
                        Debug.Log(hit.transform.gameObject.tag);
                    }
                }
            }		
        }
    }


}
