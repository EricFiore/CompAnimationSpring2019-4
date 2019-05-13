using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
	private Rigidbody p1;
	int num;
    // Start is called before the first frame update
    void Start()
    {
		num = Random.Range(1,8);
        p1 = GetComponent<Rigidbody>();
		
		if(num <= 2)
		{
			p1.gameObject.SetActive (false);
		}
		
		else
		{
			p1.gameObject.SetActive (true);
		}
		
		Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
