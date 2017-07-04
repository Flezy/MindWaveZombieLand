using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {
    public enum positionState
    {
        START, DOORS, BEND, OTHER_DOORS,
    }
    public static positionState state;
    private static bool isDanger;
	// Use this for initialization
	void Start () {
        state = positionState.START;
        isDanger = false;
	}
	
	// Update is called once per frame
	void Update () {
		

    }
    public static bool getDanger()
    {
        return isDanger;
    }
    public static void setDanger(bool danger)
    {
        isDanger = danger;
    }

}
