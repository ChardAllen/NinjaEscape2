using UnityEngine;
using System.Collections;

public class weaponThrown : MonoBehaviour {

    public bool hitEnemy = false;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(hitEnemy)
        {
            Destroy(gameObject);
        }
	}
}
