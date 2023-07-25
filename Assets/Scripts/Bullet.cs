using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;
    public float speed = 30f;
    public float explosionRadius = 0f;

    public float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void HitTarget()
    { 
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); // BulletImpact
        Destroy(effectIns, 1f);
        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
        
    }
    public void Explode()
    {
        Collider[] colliders  = Physics.OverlapSphere(transform.position,explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }

        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow; 

        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
