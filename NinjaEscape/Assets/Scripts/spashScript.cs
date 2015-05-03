using UnityEngine;
using System.Collections;

public class spashScript : MonoBehaviour {

    public float timer = 3.0f;

	public void Awake()
    {
        StartCoroutine("DisplaySplash");

    }

    IEnumerator DisplaySplash()
    {
        yield return new WaitForSeconds( timer );
        Application.LoadLevel("Menu");
    }
}
