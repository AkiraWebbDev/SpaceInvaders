using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // The speed of the projectile.
    public float speed;

    // Flag identifying whether the projectile
    // is sent by enemy or player.
    public bool enemyProjectile;

    // Update is called once per frame
    void Update()
    {
        // The projectile travels up (in the directon of positive y axis), but
        // the movement is multiplied by the speed (so negative speed will
        // move the projectile down.)
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
