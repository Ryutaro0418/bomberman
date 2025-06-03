using DG.Tweening;
using UnityEngine;

public class BlackBercontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOScale(new Vector3(36f, 3f, 2f), 0.2f).SetDelay(0.6f);
        transform.DOScale(new Vector3(0f, 1f, 0f), 0.2f).SetDelay(4.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
