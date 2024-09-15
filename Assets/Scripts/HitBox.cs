using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 10; // Hasar miktar�
    public string enemyTag = "Enemy"; // Hangi tag'lere hasar verece�imizi belirtiyoruz

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            // D��man�n sa�l���n� azalt�yoruz
            //other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("D��man vuruldu! Hasar: " + damage);
        }
    }
}
