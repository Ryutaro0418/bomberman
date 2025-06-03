using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeOnClick : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 左クリックを検出
        {
            FadeManager.Instance.LoadScene("SampleScene", 1.5f);
        }
    }
}