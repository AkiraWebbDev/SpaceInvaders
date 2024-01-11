using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public Transform explosionPrefab;

    // Points the alien is worth
    public int points = 30;

    public int hitPoints = 3;

    public int speed = 2;

    public float rotationSpeed = 2;
    public float rotationModifier = 180;

    public int waitSeconds = 2;
    public float moveSeconds;

    bool targetting = false;
    bool dashing = false;

    public GameObject player;

    Vector3 targetDirection;

    private void Start()
    {
        player = GameObject.Find("Player");
        targetDirection = player.transform.position - transform.position;
        moveSeconds = Random.Range(0.5f, 2.5f);
        StartCoroutine("MovingTimer");
    }

    void Update()
    {
        if (targetting == false)
        {
            transform.Translate(new Vector3(Time.deltaTime * -1 * speed, 0, 0));
        }
        else if (targetting == true && dashing == false)
        {
            /*
             * Code taken from a good person on youtube! 
             * youtube.com/watch?v=RNPetUa8_PQ
             */
            targetDirection = player.transform.position - transform.position;
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
        StartCoroutine("DespawnTimer");
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    // When enemy collides with an object with a
    // collider that is a trigger...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Collision with something that is not a wall
        // Check if collided with a projectile
        // A projectile has a Projectile script component,
        // so try to get a reference to that component
        Projectile projectile = other.GetComponent<Projectile>();

        //If that reference is not null, then check if it's an enemyProjectile      
        if (projectile != null && !projectile.enemyProjectile)
        {
            // Collided with non enemy projectile (so a player projectile)

            // Destroy the projectile game object
            Destroy(other.gameObject);

            // Report enemy hit to the game master
            GameMaster.DartHit(this);

            hitPoints--;

            if (hitPoints <= 0)
            {
                // Destroy self
                Destroy(gameObject);
            }

        }
        

    }

    public void OnDestroy()
    {
        Transform explosion = Instantiate(explosionPrefab);
        explosion.parent = transform.parent.parent;
        explosion.position = transform.position;
    }

}
