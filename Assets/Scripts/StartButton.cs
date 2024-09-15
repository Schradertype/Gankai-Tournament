using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSampleScene()
    {
        // "SampleScene" adlý sahneyi yükle
        SceneManager.LoadScene("SampleScene");
    }
}
