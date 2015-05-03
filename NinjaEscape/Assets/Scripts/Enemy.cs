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
    public bool isGoingLeft;

    public void Start ()
    {
        start = gameObject.transform.position;
    }

    void FixedUpdate()
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
        if (otherCollider.gameObject.tag == "Weapons")
        {
            weaponThrown weapon = otherCollider.gameObject.GetComponent<weaponThrown>();

            weapon.hitEnemy = true;

            Destroy(gameObject);
        }

        else if (otherCollider.gameObject.tag == "Exit")
        {
            
            Physics2D.IgnoreCollision(otherCollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
       

    }

}
