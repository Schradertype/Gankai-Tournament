using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 10; // Hasar miktarý
    public string enemyTag = "Enemy"; // Hangi tag'lere hasar vereceðimizi belirtiyoruz

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            // Düþmanýn saðlýðýný azaltýyoruz
            //other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("Düþman vuruldu! Hasar: " + damage);
        }
    }
}
