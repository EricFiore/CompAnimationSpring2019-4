using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider p1;
    public Collider HeroOne;
    public Collider HeroTwo;
    public Collider enemy;
    int counter = 0;
    public Collider piece4;
    public Collider piece5;
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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("grow"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.tag = "dead";
            other.name = "selectedEnemy";
            transform.localScale = new Vector3(transform.localScale.x * 3, transform.localScale.y * 3, transform.localScale.z * 3);
        }

        if (other.gameObject.CompareTag("shrink"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.tag = "dead";
            other.name = "selectedEnemy";
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        }

        if ((other.name == "p1" || other.name == "chosen") && piece5.gameObject.tag == "dead" && piece5.name == "selectedEnemy")
        {

            HeroOne.gameObject.SetActive(false);
            HeroOne.gameObject.tag = "dead";
            transform.localScale = new Vector3(x, y, z);
        }

        if ((other.name == "p2" || other.name == "chosen") && piece5.gameObject.tag == "dead" && piece5.name == "selectedEnemy")
        {
            HeroTwo.gameObject.SetActive(false);
            HeroTwo.gameObject.tag = "dead";
            transform.localScale = new Vector3(x, y, z);
        }

        if ((other.name == "p1" || other.name == "chosen" || other.name == "p2") && piece5.gameObject.tag == "dead" && piece5.name == "selectedEnemy")
        {

            p1.gameObject.SetActive(false);
            p1.gameObject.tag = "dead";
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
