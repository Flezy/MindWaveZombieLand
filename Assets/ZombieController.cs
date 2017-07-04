using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public Animator zombieAnim;
    public GameObject player;
    public AudioSource audioShort;
    public AudioSource audioLong;
    public float rotateSpeed;
    public float speed;
    public enum state { idle, walk };
    state actState;
    private PlayerHealth ph;
    private GameObject playerObject;
    private bool canMove;
    // Use this for initialization
    void Start () {
        actState = state.walk;
        zombieAnim = GetComponent<Animator>();
        int randomShout = Random.Range(0, 4);
        if (randomShout == 1)
        {
            audioLong.Play();
        }
        ph = player.GetComponent<PlayerHealth>();
        canMove = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (canMove)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            targetDir = new Vector3(targetDir.x, 0, targetDir.z);
            if (Mathf.Sqrt(targetDir.x * targetDir.x + targetDir.z * targetDir.z) > 3)
            {
                if (actState == state.idle)
                {
                    zombieAnim.SetBool("CanAttack", false);
                }
                float step = rotateSpeed * Time.deltaTime * 10;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                Debug.DrawRay(transform.position, newDir, Color.red);
                transform.rotation = Quaternion.LookRotation(newDir);
                Vector3 vec3 = new Vector3(player.transform.position.x, 2.5f, player.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, vec3, speed);
                actState = state.walk;

            }
            else
            {

                zombieAnim.SetBool("CanAttack", true);
                actState = state.idle;
                ph.DealDamage();
                
                actState = state.idle;
                //GetComponent<Animator>().speed = 0;

            }
            int randomShout = Random.Range(0, 10);
            if (randomShout == 1)
            {
                audioShort.Play();
            }
        }
        
    }
    public void forbidMove()
    {
        canMove = false;
    }
    public void die()
    {
        if (canMove)
        {
            zombieAnim.SetTrigger("Die");
            canMove = false;
        }
    }

}
