using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerEnemy : EnemyScript
{
   

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // assign target to the player object transformation
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, targetPos.position) < 15f){ // if the distance between the object and the target objecct less than 15 then transform the position of this object to move towards the target gameobject
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }
}
