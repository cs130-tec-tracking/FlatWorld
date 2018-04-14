using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test1 : MonoBehaviour 
{
	private Transform m_Transform;

	// Use this for initialization
	IEnumerator Start ()
	{
		string sceneName = "LoadMeAdditive";
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		Debug.Log("Loading2 " + sceneName);
		while (!asyncLoad.isDone) { yield return null; }
	}
	
}
