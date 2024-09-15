using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Play(int scene)
    {
        // "SampleScene" adl� sahneyi y�kle
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        // Unity Editor'de �al���rken oyun kapanmaz, bu y�zden mesaj g�r�nt�lenir.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Derlenmi� oyunda (Build) oyunu kapat�r.
        Application.Quit();
#endif
    }
}
