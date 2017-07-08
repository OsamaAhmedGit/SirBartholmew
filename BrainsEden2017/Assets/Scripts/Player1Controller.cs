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

    public GameObject[] currentGunArray;

    public float bulletVelocity;

    private Vector3 target;

    private Vector3 directionVector;

    private int pickUpC, bulletC;

    private bool pickUpBool = false;

    public GameObject pickUp;

    public GameObject Aimer;

    private Vector3 AimVec;

    float nextFire;

    private GameObject currentGun;

    // Use this for initialization
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

		bulletC = 0;

        currentGun = Instantiate(currentGunArray[0], transform.position, Quaternion.identity);
        currentGun.transform.parent = transform;
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
        float moveX = Input.GetAxis("Horizontal1");
        float moveY = Input.GetAxis("Vertical1");
        Vector2 direction = new Vector2(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.Space) && pickUpBool == true)
        {
			pickUp = (GameObject)Instantiate(pickUpColor[pickUpC], transform.position, Quaternion.identity);
            pickUp.transform.parent = transform;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            //target = AimVec;
            //target.z = 0;
            //directionVector = (target - transform.position).normalized;
            pickUp.transform.parent = null;

            //pickUp.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }
     


        //Aimer.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * 20, moveY * 20);

        //float Shoot = Input.GetAxis("Shoot");

        //float fireRate = 0.1f;

        //if (moveX > 0 || moveY > 0 || moveX < 0 || moveY < 0)
        //{
        //    if (Time.time > nextFire)
        //    {
        //        nextFire = Time.time + fireRate;
        //        //target = AimVec;
        //        //target.z = 0;
        //        //directionVector = (target - transform.position).normalized;
        //        GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], transform.position, Quaternion.identity);
        //        bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

        //        DestroyObject(bullet, 2.0f);
        //    }

        //    //if (pickUp.transform.position.x < target.x)
        //    //{
        //    //    Destroy(pickUp.GetComponent<Rigidbody2D>());
        //    //}
        //}

        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            directionVector = (target - currentGun.transform.position).normalized;
            GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], currentGun.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = directionVector * bulletVelocity;
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(currentGun.transform.position);

        mousePos.x = mousePos.x - objectPosition.x;
        mousePos.y = mousePos.y - objectPosition.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        float rx = Input.GetAxis("Right_Horizontal");
        float ry = Input.GetAxis("Right_Vertical");

        float angle = Mathf.Atan2(ry, rx) * Mathf.Rad2Deg;

        Vector3 shotDirection = new Vector3(rx, ry, 0);

        currentGun.transform.localRotation = Quaternion.Euler(0,0,angle);

        if(Input.GetAxis("Right_Trigger") == 1)
        {
            GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], currentGun.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shotDirection * bulletVelocity;
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
            currentGun = Instantiate(currentGunArray[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            currentGun.transform.parent = transform;
        } else if (pickUps.tag == "RedPickUp") {
			bulletC = 1;
			Destroy (pickUps.gameObject);
            currentGun = Instantiate(currentGunArray[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            currentGun.transform.parent = transform;
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
