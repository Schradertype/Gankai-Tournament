using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSampleScene()
    {
        // "SampleScene" adl� sahneyi y�kle
        SceneManager.LoadScene("SampleScene");
    }
}
