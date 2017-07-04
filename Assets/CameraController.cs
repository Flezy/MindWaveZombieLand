using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TrackPosition { start }

public class CameraController : MonoBehaviour {

    
    public Vector3 velocity;
    public TrackPosition trackpos;
    public GameObject path;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float moveSpeed;
    public Transform escapePlace;
    public AudioSource calmMusic;
    public AudioSource dangerMusic;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private int current = 0;
    private Vector3 offset;
    private bool stillWait = true;
    private bool weAreWaiting = false;
    private List<Transform> waypoints;
    private PlayerPosition pp;
    private bool isDanger;
    
    // Use this for initialization
    void Start () {
        velocity = new Vector3(0, 0, 0.0f);
        trackpos = TrackPosition.start;
        waypoints = new List<Transform>();
        isDanger = false;
        pp = GetComponent<PlayerPosition>();
        foreach (Transform child in path.transform)
        {
            waypoints.Add(child);
        }

    }

    void inDanger()
    {
        isDanger = true;
        calmMusic.Stop();
        dangerMusic.Play();
        PlayerPosition.setDanger(true);
    }

    internal void setMoveSpeed(int v)
    {
        moveSpeed = v;
    }

    // Update is called once per frame
    void Update () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        if (isDanger)
        {
            waypoints[1] = escapePlace;
            waypoints[0] = escapePlace;
        }
            
        if (current < waypoints.Count || current > 0)
        {
            if (current == waypoints.Count - 1)
            {
                inDanger();
            }
            if (current == 11)
            {
                if (!isDanger)
                {
                    PlayerPosition.state = PlayerPosition.positionState.DOORS;
                }
                else
                {
                    PlayerPosition.state = PlayerPosition.positionState.START;
                }
            }
            if (current == 21)
            {
                if (!isDanger)
                {
                    PlayerPosition.state = PlayerPosition.positionState.DOORS;
                }
                else
                {
                    PlayerPosition.state = PlayerPosition.positionState.BEND;
                }
            }
            if (current == 46)
            {
                if (!isDanger)
                {
                    PlayerPosition.state = PlayerPosition.positionState.BEND;
                }
                else
                {
                    PlayerPosition.state = PlayerPosition.positionState.OTHER_DOORS;
                }
            }

            if (transform.position != waypoints[current].position)
            {
                float tmpMS = moveSpeed;
                if (isDanger)
                {
                    tmpMS = moveSpeed * 1.8f;
                }
                Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current].position, tmpMS * Time.deltaTime);
                transform.position = pos;
            }
            else
            {
                if (!isDanger)
                {
                    current++;
                }
                else
                {
                    current--;
                }

            }
        }
      
        

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x + velocity.x, transform.position.y + velocity.y , transform.position.z + velocity.z + 0.02f * 4f);
        }
        else
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x + velocity.x, transform.position.y + velocity.y, transform.position.z + velocity.z - 0.02f * 4f);
            }
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x + velocity.x - 0.02f * 4f, transform.position.y + velocity.y, transform.position.z + velocity.z);
        }
        else {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + velocity.x + 0.02f * 4f, transform.position.y + velocity.y, transform.position.z + velocity.z);
            }
        }
        
        switch (trackpos)
        {
            case TrackPosition.start:
                break;
            
        }*/



    }
    IEnumerator Example()
    {
        weAreWaiting = true;
        print(Time.time);
        yield return new WaitForSecondsRealtime(2);
        print(Time.time);
        stillWait = false;
    }
}
