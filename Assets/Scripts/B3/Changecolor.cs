﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour
{
	public Material[]materials;
	public Renderer rend;
	private int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer> ();
		rend.enabled = true;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		
		if(materials.Length == 0)
		{
			return;
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			index+=1;
			if(index == materials.Length + 1)
			{
				index = 1;	
				
			}
			rend.sharedMaterial = materials[index-1];				
			
			if(rend.tag == "red")
			{
				rend.tag = "green";
			}
			
			else if(rend.tag == "green")
			{
				rend.tag = "red";
			}
		}
		
    }
}
