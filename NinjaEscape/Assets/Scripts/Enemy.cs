using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

    [HideInInspector]
    public bool isEnemy;
    [HideInInspector]
    public float distance = 1f;
    [HideInInspector]
    public float speed = 10f;
    Vector3 start;

    public void Start ()
    {
        start = gameObject.transform.position;
    }

    bool isGoingLeft = false;

    void Update()
    {
        float distFromStart = transform.position.x - start.x;

        if (isGoingLeft)
        {
            // If gone too far, switch direction
            if (distFromStart < -distance)
                Flip();
            rigidbody2D.AddForce(Vector2.right * -speed);
            
        }
        else
        {
            // If gone too far, switch direction
            if (distFromStart > distance)

                Flip();
            rigidbody2D.AddForce(Vector2.right * speed);
        }
    }


    void Flip()
    {
        isGoingLeft = !isGoingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        weaponThrown weapon = otherCollider.gameObject.GetComponent<weaponThrown>();

        weapon.hitEnemy = true;

        Destroy(gameObject);


    }

}
