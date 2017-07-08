using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightStickShooting : MonoBehaviour {

    public float shootDelay = 0.1f;

    public GameObject bullet;

    private Rigidbody2D rbPlayer;

    private bool canShoot = true;
    // Use this for initialization
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }


    void ResetShoot () {
        canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * 3, y * Time.deltaTime * 3, 0, Space.World);

        float rx = Input.GetAxis("Right_Horizontal");
        float ry = Input.GetAxis("Right_Vertical");

        float angle = Mathf.Atan2(rx, ry);

        transform.rotation = Quaternion.Euler(0, 0, 1);
    }
}
