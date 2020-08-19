﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    Animator anim;
    Rigidbody2D rb;

    public int jumpForce;

     bool grounded;

    public Transform groundPoint;

    public LayerMask groundLayer;

    public GameObject deathEffect;

    public Transform effectPosition;

    

    // Start is called before the first frame update

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapPoint(groundPoint.position,groundLayer);
    }
    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (grounded && Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce);
        }
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
    }
    public void GameOver()
    {
        //Instantiate a particle system as the death affect
        GameManager.instance.cam.followPlayer = false;
        Instantiate(deathEffect, effectPosition.position, Quaternion.identity);
        GameManager.instance.gameOver.SetActive(true);
        Destroy(gameObject);
    }
}
