using UnityEngine;
using DG.Tweening;	//DOTween���g���Ƃ��͂���using���g��
using TMPro; // TextMeshPro�p

public class movetest : MonoBehaviour
{

        
  
        [SerializeField]
        private TextMeshProUGUI _target; 
        void Start()
        {
            // 2.8�b��Ƀ��[�J�����W(0,0,0)��0.2�b�����Ĉړ�

            transform.DOLocalMove(new Vector3(0f, 0f, 0f), 0.2f).SetDelay(3.3f);

            // 3.5�b���0.2�b�����Ċg��

            transform.DOScale(new Vector3(5f, 5f, 5f), 0.2f).SetDelay(3.8f);

            // 3.5�b���1.5�b�����ē����x��0.2��
            if (_target != null)
            {

                _target.DOFade(0f, 0.2f).SetDelay(3.8f);

            }
        }
    
}
