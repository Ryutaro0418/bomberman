using UnityEngine;
using DG.Tweening;	//DOTween‚ğg‚¤‚Æ‚«‚Í‚±‚Ìusing‚ğg‚¤
using TMPro; // TextMeshPro—p

public class movetest : MonoBehaviour
{

        
  
        [SerializeField]
        private TextMeshProUGUI _target; 
        void Start()
        {
            // 2.8•bŒã‚Éƒ[ƒJƒ‹À•W(0,0,0)‚Ö0.2•b‚©‚¯‚ÄˆÚ“®

            transform.DOLocalMove(new Vector3(0f, 0f, 0f), 0.2f).SetDelay(3.3f);

            // 3.5•bŒã‚É0.2•b‚©‚¯‚ÄŠg‘å

            transform.DOScale(new Vector3(5f, 5f, 5f), 0.2f).SetDelay(3.8f);

            // 3.5•bŒã‚É1.5•b‚©‚¯‚Ä“§–¾“x‚ğ0.2‚É
            if (_target != null)
            {

                _target.DOFade(0f, 0.2f).SetDelay(3.8f);

            }
        }
    
}
