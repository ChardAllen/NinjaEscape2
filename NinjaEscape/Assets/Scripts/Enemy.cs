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
    public bool canSeePlayer;
    private RaycastHit2D info;

    private Transform playerCheckLeft;
    private Transform playerCheckRight;

    public void Start ()
    {
        start = gameObject.transform.position;
        playerCheckLeft = transform.Find("playerCheckLeft");
        playerCheckRight = transform.Find("playerCheckRight");
    }

    void FixedUpdate()
    {
        float distFromStart = transform.position.x - start.x;
        playerCheck();

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

    void playerCheck()
    {
        if(isGoingLeft)
        {
            canSeePlayer = Physics2D.Linecast(transform.position, playerCheckLeft.position, 9 << LayerMask.NameToLayer("Player"));

            if (canSeePlayer && !Player2.isHidden)
            {
                //canSeePlayer = true;
                Debug.Log("Can See You");
            }
            else
            {
                //canSeePlayer = false;
                Debug.Log("Can Not See You");
            }
        }
        else
        {
            //info = Physics2D.Raycast(transform.position, Vector2.right, 100);
            canSeePlayer = Physics2D.Linecast(transform.position, playerCheckRight.position, 9 << LayerMask.NameToLayer("Player"));

            if (canSeePlayer && !Player2.isHidden)
            {
                //canSeePlayer = true;
                Debug.Log("Can See You");
            }
            else
            {
                canSeePlayer = false;
                Debug.Log("Can Not See You");
            }
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
