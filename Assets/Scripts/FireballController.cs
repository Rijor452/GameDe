using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public int moveVel = 5;
     Transform StartPosition;
    //public Transform EndPos;
    public Transform[] SpawnLocations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != GameManager.instance.endFire.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameManager.instance.endFire.position.x, transform.position.y, transform.position.z), Time.deltaTime * moveVel);
        }
        else
        {
            StartPosition = SpawnLocations[Random.Range(0, SpawnLocations.Length)];
            transform.position = StartPosition.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().GameOver();
        }
    }
}
