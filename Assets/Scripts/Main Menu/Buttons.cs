using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Playground");
    }
	
	public void SC1()
    {
        SceneManager.LoadScene("Animation");
    }
	public void SC2()
    {
        SceneManager.LoadScene("AnimationPartTwo");
    }

	public void Quit()
	{
		Application.Quit();
	}
}
 