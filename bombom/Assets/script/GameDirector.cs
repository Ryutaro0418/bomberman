using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public GameObject TimeText;
    float timecount = 180;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    private void Update()
    {
        timecount -= Time.deltaTime;

        Debug.Log(timecount);

        int minute = (int)timecount / 60;
        int second = (int)timecount % 60;

        TimeText.GetComponent<TextMeshProUGUI>().text = "" +minute+":"+second.ToString("00");
    }


}
