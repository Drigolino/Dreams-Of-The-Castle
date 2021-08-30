using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private float timeBtwShots;
    public float starTimeBtwShots;
    public GameObject proyectile;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starTimeBtwShots;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position,player.position)>stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if(timeBtwShots<=0)
        {
            Instantiate(proyectile, transform.position, Quaternion.identity);
            timeBtwShots = starTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Animacion de Muerte

        if(currentHealth<=0)
        {
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Murio el Enemigo");
    }

    
}
