using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{

    private GameObject player;

    public float moveSpeed;

    private Vector3 movementVec;

    // Use this for initialization
    void Start()
    {
        movementVec.x = moveSpeed;
        player = GameObject.FindWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
