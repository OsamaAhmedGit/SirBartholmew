using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (gameObject.tag == "RedBullet" && col.gameObject.tag == "RedGhost") {
            col.GetComponent<Animator>().Play("RedGhostDeath");
            col.GetComponent<EnemyController2>().moveSpeed = 0;
			Destroy (gameObject);
			Destroy (col.gameObject, 1);
		}
		else if (gameObject.tag == "YellowBullet" && col.gameObject.tag == "YellowGhost") {
            col.GetComponent<Animator>().Play("YellowGhostDeath");
            col.GetComponent<EnemyController>().moveSpeed = 0;
            Destroy (gameObject);
			Destroy (col.gameObject, 1);
		}
		else if (gameObject.tag == "GreenBullet" && col.gameObject.tag == "GreenGhost") {
            col.GetComponent<Animator>().Play("GreenGhostDeath");
            col.GetComponent<EnemyController2>().moveSpeed = 0;
            Destroy (gameObject);
			Destroy (col.gameObject, 1);
		}
		else if (gameObject.tag == "BlueBullet" && col.gameObject.tag == "BlueGhost") {
            col.GetComponent<Animator>().Play("BlueGhostDeath");
            col.GetComponent<EnemyController>().moveSpeed = 0;
            Destroy (gameObject);
			Destroy (col.gameObject, 1);
		}
	}

}
