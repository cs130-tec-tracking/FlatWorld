using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Oculus.Platform;

public class Test1 : MonoBehaviour 
{
	private Transform m_Transform;

	// Use this for initialization
	IEnumerator Start ()
	{
		Debug.Log(" WILL INIT");
		yield return null;
		Oculus.Platform.Core.Initialize(  ); //"1408566292532197"
		Debug.Log( "DID INIT" );
		/*
		string sceneName = "LoadMeAdditive";
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		Debug.Log("Loading2 " + sceneName);
		while (!asyncLoad.isDone) { yield return null; }
		*/
	}
	
}
