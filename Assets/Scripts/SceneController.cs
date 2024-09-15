using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Play(int scene)
    {
        // "SampleScene" adlý sahneyi yükle
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        // Unity Editor'de çalýþýrken oyun kapanmaz, bu yüzden mesaj görüntülenir.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Derlenmiþ oyunda (Build) oyunu kapatýr.
        Application.Quit();
#endif
    }
}
