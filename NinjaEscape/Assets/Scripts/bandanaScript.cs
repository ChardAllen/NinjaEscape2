using UnityEngine;
using System.Collections;

public class bandanaScript : MonoBehaviour
{
    public UnityEngine.UI.Text ThisText;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ThisText.text = "Bandanas: " + Player2.bandanas;
    }
}
