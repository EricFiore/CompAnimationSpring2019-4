using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFiveMove : MonoBehaviour
{
    private bool rockIsSelected;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rockIsSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rockIsSelected)
        {
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 5.0f)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 17.8f)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }

    public void selectRock()
    {
        rockIsSelected = true;
    }

    public void deselectRock()
    {
        rockIsSelected = false;
    }
}
