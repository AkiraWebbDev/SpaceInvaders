using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public Transform explosionPrefab;

    // Points the alien is worth
    public int points = 300;

    public int hitPoints = 3;

    public int speed = 2;

    public float rotationSpeed = 2;
    public float rotationModifier = 180;

    public int waitSeconds = 2;
    public float moveSeconds;

    bool targetting = false;
    bool dashing = false;

    public Transform player;

    Vector3 targetDirection;

    private void Start()
    {
        targetDirection = player.position - transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSeconds = Random.Range(1, 3);
        StartCoroutine("MovingTimer");
    }

    void Update()
    {
        if (targetting == false)
        {
            transform.Translate(new Vector3(Time.deltaTime * -1 * speed, 0, 0));
        }
        else if (dashing == false)
        {
            /*
             * Code taken from a good person on youtube! 
             * youtube.com/watch?v=RNPetUa8_PQ
             */
            targetDirection = player.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
        else
        {   
            transform.position += targetDirection.normalized * (speed*5) * Time.deltaTime;
        }
    }

    IEnumerator MovingTimer()
    {
        yield return new WaitForSeconds(moveSeconds);
        targetting = true;
        StartCoroutine("WaitTimer");
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(waitSeconds);
        dashing = true;
    }

}
