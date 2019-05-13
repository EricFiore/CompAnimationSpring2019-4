using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer1 : MonoBehaviour
{
	public Rigidbody p1;
	public Rigidbody p2;
	
	int num;
    // Start is called before the first frame update
    void Start()
    {
		num = Random.Range(1,8);
        p1 = GetComponent<Rigidbody>();
		
		if(num == 1 || num == 2)
		{
			p1.gameObject.SetActive (false);
			p2.gameObject.SetActive (false);
		}
		
		if(num <= 4 && num >2)
		{
			p1.gameObject.SetActive (true);
			p2.gameObject.SetActive (false);
		}
		
		if(num > 4)
		{
			p2.gameObject.SetActive (true);
			p1.gameObject.SetActive (false);
		}
		
		Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
