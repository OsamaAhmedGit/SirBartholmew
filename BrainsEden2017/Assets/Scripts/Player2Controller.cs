using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
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

    float nextFire;

    void Start()
    {

        rbPlayer = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

		bulletC = 0;
    }

    void FixedUpdate()
    {
            float moveX = Input.GetAxis("Horizontal2");
            float moveY = Input.GetAxis("Vertical2");

            rbPlayer.velocity = new Vector2(moveX * movementSpeed, moveY * movementSpeed);

            if (Input.GetAxis("Horizontal2") < 0)
                animator.Play("Player1Left");
            else if (Input.GetAxis("Horizontal2") > 0)
                animator.Play("Player1Right");
            else if (Input.GetAxis("Vertical2") > 0)
                animator.Play("Player1Up");
            else if (Input.GetAxis("Vertical2") < 0)
                animator.Play("Player1Down");
        

    }

    void Update()
    {
        float moveX = Input.GetAxis("AimX2");
        float moveY = Input.GetAxis("AimY2");
        Vector2 direction = new Vector2(moveX, moveY);

		if (Input.GetMouseButtonDown(0) && pickUpBool == true)
        {
            pickUp = (GameObject)Instantiate(pickUpColor[pickUpC], transform.position, Quaternion.identity);
            pickUp.transform.parent = transform;
        }

        if (Input.GetButtonDown("Throw2"))
        {
            //target = AimVec;
            //target.z = 0;
            //directionVector = (target - transform.position).normalized;
            pickUp.transform.parent = null;

            //pickUp.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }



        //Aimer.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * 20, moveY * 20);

        //float Shoot = Input.GetAxis("Shoot");

//        float fireRate = 0.1f;
//
//        if (moveX > 0 || moveY > 0 || moveX < 0 || moveY < 0)
//        {
//            if (Time.time > nextFire)
//            {
//                nextFire = Time.time + fireRate;
//                //target = AimVec;
//                //target.z = 0;
//                //directionVector = (target - transform.position).normalized;
//                GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], transform.position, Quaternion.identity);
//                bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);
//
//                DestroyObject(bullet, 2.0f);
//            }
//
//            if (pickUp.transform.position.x < target.x)
//            {
//                Destroy(pickUp.GetComponent<Rigidbody2D>());
//            }
//        }

		if (Input.GetMouseButtonDown(0))
		{
			target = AimVec;
			target.z = 0;
			directionVector = (target - transform.position).normalized;
			GameObject bullet = (GameObject)Instantiate(bulletColor[bulletC], transform.position, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

			DestroyObject(bullet, 2.0f);
		}

		if (pickUp.transform.position.x < target.x)
		{
			Destroy(pickUp.GetComponent<Rigidbody2D>());
		}



    }

    void OnTriggerEnter2D(Collider2D pickUps)
    {
        if (pickUps.tag == "BluePickUp")
        {
            //currentBulletChoice = 1;
        }
        else if (pickUps.tag == "greenBucket")
        {
            pickUpC = 0;
            pickUpBool = true;
        }
        else if (pickUps.tag == "redBucket")
        {
            pickUpC = 1;
            pickUpBool = true;
        }

		if (pickUps.tag == "YellowPickUp") {
			bulletC = 0;
			Destroy (pickUps.gameObject);
		} else if (pickUps.tag == "BluePickUp") {
			bulletC = 1;
			Destroy (pickUps.gameObject);
		}

        if(pickUps.tag == "BlueGhost" || pickUps.tag == "YellowGhost")
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<Animator>().Play("Player1Death");
        }
			
    }

    void OnTriggerExit2D(Collider2D pickUps)
    {
        if (pickUps.tag == "GreenPickUp")
        {
            pickUpC = 0;
            pickUpBool = false;
        }
        else if (pickUps.tag == "RedPickUp")
        {
            pickUpC = 1;
            pickUpBool = false;
        }
    }

    //void StopBullet()
    //{

    //    directionVector = (target - transform.position).normalized;

    //    for (int i = 0; i < pickUps.Count; i++)
    //    {
    //        GameObject goBullet = pickUps[i];

    //        if (goBullet != null)
    //        {
    //                if (goBullet.transform.position.x < target.x)
    //                {
    //                    goBullet.transform.Translate(directionVector * bulletVelocity * Time.deltaTime);
    //            }
    //        }
    //    }
    //}

    //void ShootNormalBullet()
    //{
    //    directionVector = (target - transform.position).normalized;

    //    for (int i = 0; i < bullets.Count; i++)
    //    {
    //        GameObject goBullet = bullets[i];

    //        if (goBullet != null)
    //        {

    //            goBullet.transform.Translate(directionVector * bulletVelocity * Time.deltaTime);

    //        }

    //        Vector2 bulletPosition = Camera.main.WorldToScreenPoint(goBullet.transform.position);

    //        if (bulletPosition.y >= Screen.height || bulletPosition.y < 0 || bulletPosition.x >= Screen.width || bulletPosition.x < 0)
    //        {
    //            DestroyObject(goBullet);
    //            bullets.Remove(goBullet);
    //        }
    //    }


    //}
}
