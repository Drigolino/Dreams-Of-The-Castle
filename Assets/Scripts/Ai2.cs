using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Accessibility;


public class Ai2 : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float stopingDistance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,target.position)>stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }
    }
}
