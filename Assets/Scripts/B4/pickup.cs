using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
	public Collider p1;
	public Collider enemy;
	int counter = 0;
	public Collider unlock;
	public Collider  piece1;
	public Collider  piece2;
	public Collider  piece3;
	public Collider  piece4;
	public Collider  piece5;
	public Collider  piece6;
    public GameObject wayPoint;
	float x = 0;
	float y = 0;
	float z = 0;
	
    void Start()
    {
        //p1 = GetComponent<Rigidbody>();
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (piece1.gameObject.tag == "dead" && piece2.gameObject.tag == "dead" && piece3.gameObject.tag == "dead")
		{
			counter = 3;
		}
		
		if(piece4.gameObject.tag == "dead" && piece4.name == "p1")
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
		
		if (other.gameObject.CompareTag ("grow"))
        {
            other.gameObject.SetActive (false);
			other.gameObject.tag = "dead";
            other.name = "p1";
            transform.localScale = new Vector3(transform.localScale.x * 3, transform.localScale.y * 3, transform.localScale.z * 3);		 
        }
		
		if (other.gameObject.CompareTag ("shrink"))
        {
            other.gameObject.SetActive (false);
			other.gameObject.tag = "dead";
            other.name = "p1";
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);		 
        }
				
		if(counter == 3 && other.gameObject.CompareTag ("unlock"))
		{

			unlock.gameObject.SetActive (false);
			unlock.gameObject.tag = "dead";
            wayPoint.name = "arrived";
		}
		
		if(counter == 3 && other.gameObject.CompareTag ("unlock") && piece4.gameObject.tag == "dead" && piece4.name == "p1")
		{

			unlock.gameObject.SetActive (false);
			unlock.gameObject.tag = "dead";
            wayPoint.name = "arrived";
			transform.localScale = new Vector3(x, y, z);
		}

        if (other.name == "EnemyOne" && piece5.gameObject.tag == "dead" && piece5.name == "p1")
        {

			enemy.gameObject.SetActive (false);
			enemy.gameObject.tag = "dead";
            enemy.name = "coward";
            wayPoint.name = "arrived";
			transform.localScale = new Vector3(x, y, z);
		}
		
		if(other.name == "EnemyOne" && piece6.gameObject.tag == "dead" && piece6.name == "p1")
		{

			p1.gameObject.SetActive (false);
			p1.gameObject.tag = "dead";
            wayPoint.name = "arrived";
			transform.localScale = new Vector3(x, y, z);
		}
        if (other.gameObject.CompareTag("sword"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.tag = "dead";
            other.name = "deadSword";
            enemy.name = "coward";
        }
    }
}
