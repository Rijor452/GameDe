using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform[] spawnPositions;
    public Transform endPosition;

    public int moveVel = 5;
    Transform startPosition;
    

    public Transform[] ObjectSpawnPositions;
    public GameObject coinPrefab;
    GameObject spawnedCoin;
    GameObject spawnedHazard;
    public GameObject HazardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != endPosition.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(endPosition.position.x, transform.position.y, transform.position.z), Time.deltaTime * moveVel);
        }
        else
        {
            if (spawnedCoin != null)
            {
                Destroy(spawnedCoin);
            }
            startPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
            transform.position = startPosition.position;

            int coin = Random.Range(0, 3);
            switch (coin)
            {
                case 0:
                case 1:
                    spawnedCoin = Instantiate(coinPrefab, ObjectSpawnPositions[coin].position, Quaternion.identity, transform);
                    break;
                case 2:
                default:
                    break;
            }
            int staticHazard = Random.Range(0, 3);
            int chances = Random.Range(0, 3);

            if(chances > 0)
            {
                spawnedHazard = Instantiate(HazardPrefab,new Vector3(ObjectSpawnPositions[staticHazard].position.x, ObjectSpawnPositions[staticHazard].position.y +1.07f, ObjectSpawnPositions[staticHazard].position.z), Quaternion.identity, transform);
            }


        }
    }
}
