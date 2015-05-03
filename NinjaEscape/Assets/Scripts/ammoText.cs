using UnityEngine;
using System.Collections;

public class ammoText : MonoBehaviour 
{
    public UnityEngine.UI.Text ThisText;

	// Use this for initialization
	void Awake ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

        ThisText.text = "Ammo: " + Player2.ammo;
	}
}
