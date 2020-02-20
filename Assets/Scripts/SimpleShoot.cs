using UnityEngine;


public class SimpleShoot : RayCast
{
    void Update()
    {
        if (Time.time >= nextTimeToFire)
            { 
            nextTimeToFire = Time.time + 15f / fireRate;
            Shoot();

            }
    }
}

