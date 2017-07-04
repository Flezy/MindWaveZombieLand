using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthBar;
    public Slider healthBar2;
    public AudioSource panting;
    private float startingHealth = 100f;
    public float currentHealth;
    
    CameraController cr;
    bool damaged;
    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        healthBar.value = startingHealth;
        healthBar2.value = startingHealth;
        cr = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged && false)
        {
            DealDamage();
        }
        damaged = false;
    }

    public void DealDamage()
    {
        panting.Play();
        damaged = true;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            currentHealth -= 0.1f;
            healthBar.value = currentHealth/100;
            healthBar2.value = currentHealth / 100;
        }
    }

    void Die()
    {
        cr.enabled = false;
        Debug.Log("meghaltam");
    }
}
