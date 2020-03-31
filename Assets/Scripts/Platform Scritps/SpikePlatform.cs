using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatform : Platform
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable obj;

        if (collision.gameObject.TryGetComponent<IDamagable>(out obj) == true)
        {
            obj.TakeDamage(1);
        }
    }
}
