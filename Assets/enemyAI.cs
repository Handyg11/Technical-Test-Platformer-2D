﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAI : MonoBehaviour
{
    public Transform target;
    public float speed= 200f;
    public float nextWayPointDistance = 3f;
    public Transform enemyGFX;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);

    }
    void UpdatePath(){
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p ){
        if(!p.error){
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null) return;
        if(currentWayPoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance){
            currentWayPoint++;
        }

        if(force.x >= 0.01f){
            enemyGFX.localScale = new Vector3(-0.2f,0.2f,1f);
        }else if(force.x <= -0.01f){
            enemyGFX.localScale = new Vector3(0.2f,0.2f,1f);
        }
    }
}
