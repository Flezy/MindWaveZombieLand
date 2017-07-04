using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtTheEndController : MonoBehaviour {

    private ZombieController[] zombies;
	// Use this for initialization
	void Start () {
        zombies = GetComponentInChildren<ZombieController[]>();
        foreach (ZombieController z in zombies)
        {
            z.forbidMove();
            Debug.Log("anyad");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
