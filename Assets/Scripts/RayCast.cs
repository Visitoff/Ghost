using UnityEngine;

public class RayCast : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;
    public Transform barrelLocation;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Shoot()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(barrelLocation.transform.position, barrelLocation.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        
    }
}
