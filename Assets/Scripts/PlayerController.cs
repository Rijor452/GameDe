using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Animator anim;
    public Rigidbody2D rb;

    public int jumpForce;
    public bool grounded;
    public Transform groundPoint;
    public LayerMask groundLayer;

    // Start is called before the first frame update

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapPoint(groundPoint.position,groundLayer);
    }
    void Start(){
     
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
        Destroy(gameObject);
    }
}
