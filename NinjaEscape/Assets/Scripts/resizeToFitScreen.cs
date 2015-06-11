using UnityEngine;
using System.Collections;

public class resizeToFitScreen : MonoBehaviour 
{

    // Use this for initialization
    void Awake()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Debug.Log("1");
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);
        Debug.Log("2");

        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;
        Debug.Log("3");

        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight / (Screen.height * Screen.width);
        Debug.Log("4");

        Vector3 xWidth = transform.localScale;
        xWidth.x = screenWidth / spriteWidth;
        transform.localScale = xWidth;
        Debug.Log("5");

        Vector3 yHeight = transform.localScale;
        yHeight.y = screenHeight / spriteHeight;
        transform.localScale = yHeight;

        Debug.Log("Well it ran :)");
    }
	
	// Update is called once per frame
	void Update () 
    {
     
	}
}
