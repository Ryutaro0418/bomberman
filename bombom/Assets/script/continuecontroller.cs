using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeOnClick : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���N���b�N�����o
        {
            FadeManager.Instance.LoadScene("SampleScene", 1.5f);
        }
    }
}