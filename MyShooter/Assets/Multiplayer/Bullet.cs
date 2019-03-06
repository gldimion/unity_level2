using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 20;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ph = collision.collider.GetComponent<PlayerHealth>();
        ph?.GetDamage(Damage);

        Destroy(gameObject);
    }
}
