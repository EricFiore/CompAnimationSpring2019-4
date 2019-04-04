using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("B3");
    }
	
	public void SC3()
    {
        SceneManager.LoadScene("ExtraCredit");
    }

	public void Quit()
	{
		Application.Quit();
	}
}
 