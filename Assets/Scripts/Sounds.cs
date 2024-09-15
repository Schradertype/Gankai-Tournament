using UnityEngine;

public class OyunSes : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource bileþeni

    void Start()
    {
        // Oyun baþladýðýnda sesi çal
        audioSource.Play();
    }
}
