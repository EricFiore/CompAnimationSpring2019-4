using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{

    Renderer m_Renderer;
    bool redColor = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_Renderer.isVisible)
        {
            if(m_Renderer.material.color == new Color(1.000f, 0.000f, 0.000f, 1.000f))
            {
                redColor = false;
            }
        }
        else if (!m_Renderer.isVisible)
        {
            redColor = true;
        }
    }

    public bool getColor()
    {
        return redColor;
    }
}
