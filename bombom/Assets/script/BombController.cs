using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject Fire;
    public float FireDestroy;
    int i;
    GameObject stage;
    public GameObject player;
    public GameObject owner;
    bool isDead=false;
    public GameObject Model;
    public int power;



    // Start is called before the first frame update
    void Start()//start method
    {
        Application.targetFrameRate = 60;

        // Destroy(this.gameObject,3);　//()の,3は三秒後に消すって意味

        Invoke("Explosion", 3); //3秒後にこのmethodを実行して！！！

        stage = GameObject.Find("Stage");

    }

    // Update is called once per frame
    void Update()//update method
    {
    }

    void Explosion()//Explosion method
    {
        if(isDead == true)
        {
            return;//強制終了
        }

        isDead = true;

        int x = (int)(this.transform.position.x);
        int z = (int)(this.transform.position.z);
        stage.GetComponent<StageController>().setMap(x, z, 0);

        Model.SetActive(false);

        Destroy(gameObject,0.6f);


        booom();
    }

       void booom()
    {
        owner.GetComponent<PlayerController>().bombcount++;

     
      
        //右
        for (i= 0; i < power; i++)
        {　
            //火を出す位置
            int x = (int)(this.transform.position.x + i + 0.5f);   //int型にキャスト
            int z = (int)(this.transform.position.z + 0.5f);
            //その位置のステータス
            int status = stage.GetComponent<StageController>().GetMap(x, z);

           
            //1or2だったら
            if (status ==1||status==2)    //1 or 2
            {
                break;
            }


            //何もなければ火を出す
            GameObject FireP;
            FireP = Instantiate(Fire);       //Fireを呼ぶ
            FireP.transform.position = new Vector3(x, 0, z);    //BombのポジションにFireを出現//+ new Vector3(0,0,0)も同じ
            Destroy(FireP, FireDestroy);      //〇秒後にFire消える
           


            if (status==3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }


        }

        //左
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + -i + 0.5f);
            int z = (int)(this.transform.position.z + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0　0じゃなかったら
            {
             break;
            }

            GameObject FireP;
            FireP = Instantiate(Fire);       //Fireを呼ぶ
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //〇秒後にFire消える

            if (status == 3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }
        }

        //上
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + 0.5f);
            int z = (int)(this.transform.position.z + i + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0　0じゃなかったら
            {
                break;
            }

            GameObject FireP; 
            FireP = Instantiate(Fire);       //Fireを呼ぶ
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //〇秒後にFire消える

            if (status == 3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }
        }

        //下
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + 0.5f);
            int z = (int)(this.transform.position.z + -i + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0　0じゃなかったら
            {
                break;
            }

            GameObject FireP;
            FireP = Instantiate(Fire);       //Fireを呼ぶ
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //〇秒後にFire消える


            if (status == 3) 
            {
                //stage.GetComponent<StageController>().setMap(x, z,0);
                StartCoroutine(StageZero(x, z));
                break;
            }

        }
    }

    void re()
    {
      
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire" )
        {
            Debug.Log("触れた！");
            Explosion();

        }
    }

    IEnumerator StageZero(int x, int z)
    {
        //いーるど
        Debug.Log("爆発");
        yield return new WaitForSeconds(0.5f);
        stage.GetComponent<StageController>().setMap(x, z, 0);
    }

}
