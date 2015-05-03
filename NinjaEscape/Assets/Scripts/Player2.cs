using UnityEngine;
using System.Collections;

//Testing GitHub updates

public class Player2 : MonoBehaviour
{
    public bool facingRight = true;			// For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;				// Condition for whether the player should jump.

    public float moveForce = 20f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;				// The fastest the player can travel in the x axis..
    public float jumpForce = 500f;			// Amount of force added when the player jumps.

    private Transform platformCheck;			// A position marking where to check if the player is platform.
    private bool platform = false;			// Whether or not the player is platform.

    private bool shoot = false;
    public GameObject weaponPrefab;
    public static int ammo = 3;
    public static int bandanas = 0;

    public Vector2 location;

    [HideInInspector]
    public bool isPlayer;
    public float volumeSetting;
	
	[HideInInspector]
	public bool isCollectible;

    void Awake()
    {
        // Setting up references.
        platformCheck = transform.Find("platformCheck");
    }

    void Update()
    {
        // The player is platform if a linecast to the groundcheck position hits anything on the ground layer.
        platform = Physics2D.Linecast(transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform"));

        // If the jump button is pressed and the player is platform then the player should jump.
        if (Input.GetButtonDown("Jump") && platform)
            jump = true;

        if(Input.GetButtonDown("Fire1"))
            shoot = true;           
        
    }

    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        if (h * rigidbody2D.velocity.x < maxSpeed)
            // ... add a force to the player.
            rigidbody2D.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);


        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (jump)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));

            jump = false;
        }

        //Shooting

        if (shoot && ammo>0)
        {
            GameObject clone;

            if (facingRight)
            {
                clone = (Instantiate(weaponPrefab, transform.position, transform.rotation)) as GameObject;
                clone.rigidbody2D.AddForce(new Vector2(200, 0), 0);

            }
            else
            {
                clone = (Instantiate(weaponPrefab, transform.position, transform.rotation)) as GameObject;
                clone.rigidbody2D.AddForce(new Vector2(-200, 0), 0);
            }

            ammo--;
            shoot = !shoot;
        }

        location.x = this.transform.position.x;
        location.y = this.transform.position.y;

    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
	void OnTriggerEnter2D(Collider2D otherCollider)
    {
		if(otherCollider.gameObject.tag == "Collectible")
		{
        	bandanaSprite bandana = otherCollider.gameObject.GetComponent<bandanaSprite>();

	        bandana.collected = true;
		
			bandanas++;
		}

        else if (otherCollider.gameObject.tag == "Exit")
        {
            Application.LoadLevel("LevelComplete");
            menuScript.level++;
        }

        else if(otherCollider.gameObject.tag == "Weapons")
		{
			weaponThrown weapon = otherCollider.gameObject.GetComponent<weaponThrown>();
			Physics2D.IgnoreCollision(weapon.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if(otherCollider.gameObject.tag == "Enemy" )
        {
            Application.LoadLevel("Dead");
        }
    }

}
