using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{

    private bool paused = false;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.T))
        {
            paused = !paused;
        }

        if(paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}
}
