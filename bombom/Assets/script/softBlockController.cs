using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class softBlockController : MonoBehaviour
{
    public int item = 0;
    public GameObject itemS;
    public GameObject itemB;
    public GameObject itemF;
    public GameObject BurnBlockPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Fire")
        {
            Destroy(gameObject);
            GameObject BurnBlock = Instantiate(BurnBlockPrefab);
            BurnBlock.transform.position = this.transform.position;
            Destroy(BurnBlock, 1.0f);
        }

        if (item == 1)
        {
            GameObject ITEM=Instantiate(itemS);
            Vector3 Position = this.transform.position;
            ITEM.transform.position = Position;
        }

        if (item == 2)
        {
            GameObject ITEM = Instantiate(itemB);
            Vector3 Position = this.transform.position;
            ITEM.transform.position = Position;
        }

        if (item == 3)
        {
            GameObject ITEM = Instantiate(itemF);
            Vector3 Position = this.transform.position;
            ITEM.transform.position = Position;
        }

    }

 }
