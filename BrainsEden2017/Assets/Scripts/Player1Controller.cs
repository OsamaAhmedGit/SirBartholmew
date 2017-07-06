using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public float movementSpeed;

    private Rigidbody2D rbPlayer;

    private Animator animator;

    public GameObject[] bulletColor;

    public GameObject[] pickUpColor;

    public float bulletVelocity;

    private Vector3 target;

    private Vector3 directionVector;

    private int pickUpC, bulletC;

    private bool pickUpBool = false;

    public GameObject pickUp;

    public GameObject Aimer;

    private Vector3 AimVec;

    float nextFire;

    // Use this for initialization
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

		bulletC = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX1 = Input.GetAxis("Horizontal1");
        float moveY1 = Input.GetAxis("Vertical1");

        Vector2 direction = new Vector2(moveX1, moveY1);

        rbPlayer.velocity = new Vector2(moveX1 * movementSpeed, moveY1 * movementSpeed);

        if (Input.GetAxis("Horizontal1") < 0)
        {
            animator.Play("Player2Left");
            }
        else if (Input.GetAxis("Horizontal1") > 0)
        {
            animator.Play("Player2Right");
        }
        else if (Input.GetAxis("Vertical1") > 0)
        {
            animator.Play("Player2Up");
        }
        else if (Input.GetAxis("Vertical1") < 0)
        {
            animator.Play("Player2Down");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("AimX");
        float moveY = Input.GetAxis("AimY");
        Vector2 direction = new Vector2(moveX, moveY);

        if (Input.GetButtonDown("pickUp") && pickUpBool == true)
        {
			pickUp = (GameObject)Instantiate(pickUpColor[pickUpC], transform.position, Quaternion.identity);
            pickUp.transform.parent = transform;
        }

        if (Input.GetButtonDown("Throw"))
        {
            //target = AimVec;
            //target.z = 0;
            //directionVector = (target - transform.position).normalized;
            pickUp.transform.parent = null;

            //pickUp.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }
     


        //Aimer.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * 20, moveY * 20);

        //float Shoot = Input.GetAxis("Shoot");

        float fireRate = 0.1f;

        if (moveX > 0 || moveY > 0 || moveX < 0 || moveY < 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                //target = AimVec;
                //target.z = 0;
                //directionVector = (target - transform.position).normalized;
                GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

                DestroyObject(bullet, 2.0f);
            }

            //if (pickUp.transform.position.x < target.x)
            //{
            //    Destroy(pickUp.GetComponent<Rigidbody2D>());
            //}
        }

        

    }

    void OnTriggerEnter2D(Collider2D pickUps)
    {
        if (pickUps.tag == "yelBucket")
        {
            pickUpC = 0;
            pickUpBool = true;
        }
        else if (pickUps.tag == "blueBucket")
        {
            pickUpC = 1;
            pickUpBool = true;
        }

		if (pickUps.tag == "GreenPickUp") {
			bulletC = 0;
			Destroy (pickUps.gameObject);
		} else if (pickUps.tag == "RedPickUp") {
			bulletC = 1;
			Destroy (pickUps.gameObject);
		}

        if (pickUps.tag == "RedGhost" || pickUps.tag == "GreenGhost")
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<Animator>().Play("Player2Death");
        }
    }

    void OnTriggerExit2D(Collider2D pickUps)
    {
        if (pickUps.tag == "YellowPickUp")
        {
            pickUpC = 0;
            pickUpBool = false;
        }
        else if (pickUps.tag == "BluePickUp")
        {
            pickUpC = 1;
            pickUpBool = false;
        }
    }

}
