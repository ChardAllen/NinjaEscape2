using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stealthIconScript : MonoBehaviour {

    public Image stealthIndicator;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Player2.isHidden)
        {
            stealthIndicator.enabled = true;
        }
        if(!Player2.isHidden)  
        {
            stealthIndicator.enabled = false;
        }
	
	}
}
