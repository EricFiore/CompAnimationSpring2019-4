using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
	private Rigidbody p1;
	int counter = 0;
	public Collider unlock;
	public Collider  piece1;
	public Collider  piece2;
	public Collider  piece3;
    public GameObject wayPoint;


    void Start()
    {
        p1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (piece1.gameObject.tag == "dead" && piece2.gameObject.tag == "dead" && piece3.gameObject.tag == "dead")
		{
			counter = 3;
		}
		
    }
	
	void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("pickup"))
        {
            other.gameObject.SetActive (false);
			other.gameObject.tag = "dead";
        }
		
		if(counter == 3 && other.gameObject.CompareTag ("unlock"))
		{

			unlock.gameObject.SetActive (false);
            wayPoint.name = "arrived";
		}
		
    }
}
