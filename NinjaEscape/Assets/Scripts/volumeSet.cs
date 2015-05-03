using UnityEngine;
using System.Collections;

public class volumeSet : MonoBehaviour 
{
    public static float _masterVolume = 1.0f;
    public AudioSource thisSound;

    public void Awake()
    {
        GameObject temp = GameObject.Find("gameMusic");
        thisSound = temp.GetComponent<AudioSource>();        
        DontDestroyOnLoad(thisSound);        
    }

	// Update is called once per frame
	void Update () 
    {
        GameObject temp = GameObject.Find("gameMusic");
        thisSound = temp.GetComponent<AudioSource>();
        thisSound.volume = _masterVolume;
	}
}
