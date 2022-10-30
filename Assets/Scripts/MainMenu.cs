using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	public void QuitGame()
	{

		Debug.Log("Exiting game...");
		Application.Quit();
	}

	public void LoadLevel(string level)
	{

		SceneManager.LoadScene(level);
	}

	

}