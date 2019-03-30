using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{

    private float counter;
    public float speed;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        float x = Mathf.Cos(-counter) * width;
        float y = 0; 
        float z = Mathf.Sin(-counter) * height; ;

        transform.Translate(x, y, z);
    }
}
