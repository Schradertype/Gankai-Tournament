using UnityEngine;

public class OyunSes : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource bile�eni

    void Start()
    {
        // Oyun ba�lad���nda sesi �al
        audioSource.Play();
    }
}
