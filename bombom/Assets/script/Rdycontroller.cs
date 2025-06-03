using UnityEngine;
using DG.Tweening;
using TMPro;
public class Rdycontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ÉçÅ[ÉJÉãç¿ïWÇÃ(0,0,0)Ç÷1ïbÇ≈à⁄ìÆÇ∑ÇÈ
        this.transform.DOLocalMove(new Vector3(50f, 0f, 0f), 0.5f).SetDelay(0.7f);
        this.transform.DOLocalMove(new Vector3(-1353f, 0f, 0f), 0.2f).SetDelay(2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
