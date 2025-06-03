using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController1 : MonoBehaviour
{
    public TMP_Text victoryText;
    
    // Start is called before the first frame update
    void Start()
    {
     victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowVictoryMessage(); // スペースキーで表示
        }
    }
        public void ShowVictoryMessage()
        {
            victoryText.text = "Player 2 WIN";
            victoryText.gameObject.SetActive(true);
        }
}
