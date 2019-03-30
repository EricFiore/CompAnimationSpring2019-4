using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    private bool atTop;
    public float speed;

    void Start()
    {
        atTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atTop)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= 10)
            {
                atTop = true;
            }
        }
        else if (atTop)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= 1)
            {
                atTop = false;
            }
        }
    }
}
