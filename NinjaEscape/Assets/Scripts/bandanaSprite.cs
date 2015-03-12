using UnityEngine;
using System.Collections;

public class bandanaSprite : MonoBehaviour {

    public bool collected = false;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(collected)
        {
            Destroy(gameObject);
        }
	}
}
