using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    private bool randomBalance;
    private bool scared;
    // Use this for initialization
    void Start () {
        randomBalance = true;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        scared = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int begin = 0;
        int end = 0;
        switch (PlayerPosition.state)
        {
            case PlayerPosition.positionState.START:
                end = 3;
                break;
               
            case PlayerPosition.positionState.DOORS:
                begin = 3;
                end = 5;
                break;
            case PlayerPosition.positionState.BEND:
                begin = 6;
                end = 6;
                break;
            case PlayerPosition.positionState.OTHER_DOORS:
                begin = 7;
                end = 11;
                break;
        }
        int randomEndOnSpawn = PlayerPosition.getDanger() ? 2 : 5;
        int spawnRandom = UnityEngine.Random.Range(begin, randomEndOnSpawn);
        Debug.Log("state: " + PlayerPosition.state);
        if ((spawnRandom == begin + 1 && (randomBalance || PlayerPosition.getDanger())) || scared)
        {
            int spawnPointIndex = UnityEngine.Random.Range(begin, end);
            Debug.Log("spawnPointIndex: " + spawnPointIndex);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            randomBalance = false;
        }
        else
        {
            randomBalance = true;
            // Ez arra van hogy egymas utan 2szer nem johet zombi, kis balance hogy a jatek elejen ne legyen tul sok
        }

    }

    internal void sendAttention(int value)
    {
        if (value < 60)
        {
            scared = true;
        }
    }
}
