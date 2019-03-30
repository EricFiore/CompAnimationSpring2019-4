using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrel : MonoBehaviour
{
    private bool barrelIsSelected;
    private Renderer barrelRenderer;
    public Material normalColor;
    public Material highlightColor;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        barrelIsSelected = false;
        barrelRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (barrelIsSelected)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    public void selectBarrel()
    {
        barrelIsSelected = true;
        barrelRenderer.material = highlightColor;
    }

    public void deselectBarrel()
    {
        barrelIsSelected = false;
        barrelRenderer.material = normalColor;
    }
}
