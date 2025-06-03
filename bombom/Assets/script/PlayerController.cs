using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.GridLayoutGroup;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Tooltip("移動速度")]
    public float Speed;

    GameObject stage;

    [Header("爆弾の設定")]
    [SerializeField,Range(1,5)]
    public int bombcount;
    int power = 2;//damege
    public GameObject Bomb;

    public  int ID;
    GameObject createBomb;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        stage = GameObject.Find("Stage");
    }

    // Update is called once per frame
    void Update()
    {
        float sx = 0;
        float sz = 0;
        

        //if (ID == 1)//player 1 controll
        //{
        //    sx = Input.GetAxis("Horizontal");  //加速度+横方向の入力値（-1.0～1.0）
        //    sz = Input.GetAxis("Vertical");    //加速度+縦方向の入力値（-1.0～1.0）
        //}
        //else //player 2 controll
        //{
        //    sx = Input.GetAxis("Horizontal2");  //加速度+横方向の入力値（-1.0～1.0）
        //    sz = Input.GetAxis("Vertical2");    //加速度+縦方向の入力値（-1.0～1.0）
        //}


        if (ID == 1)//player 1 controll
        {
            sx = Input.GetAxisRaw("Horizontal");  //横方向の入力値（-1.0～1.0）
            sz = Input.GetAxisRaw("Vertical");    //縦方向の入力値（-1.0～1.0）
        }
        else //player 2 controll
        {
            sx = Input.GetAxisRaw("Horizontal2");  //横方向の入力値（-1.0～1.0）
            sz = Input.GetAxisRaw("Vertical2");    //縦方向の入力値（-1.0～1.0）
        }


        Vector3 move = new Vector3(sx, 0, sz);

        move = move.normalized;

       if( move.magnitude > 0.2f)
       {
        animator.SetBool("isWalking", true);
       }
       else
       {
        animator.SetBool("isWalking", false);
       }

        animator.SetFloat("anisp",Speed * 0.5f);



        this.GetComponent<CharacterController>().SimpleMove(move*Speed);

        if (sx != 0 || sz != 0)
        {
            transform.rotation = Quaternion.LookRotation(move);//キャラの向きを固定
        }

        int x = (int)(this.transform.position.x + 0.5f);
        int z = (int)(this.transform.position.z + 0.5f);

        stage.GetComponent<StageController>().GetMap(x, z);

        Bomb.GetComponent<BombController>().power = power;
        

        if (ID == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && stage.GetComponent<StageController>().map[x, z] == 0 && bombcount > 0)
            {
                GameObject createBomb = Instantiate(Bomb);

                createBomb.GetComponent<BombController>().owner = this.gameObject;

                Vector3 bombp = this.transform.position + new Vector3(0f, -0.5f, 0f);

                bombp.x = (int)(bombp.x + 0.5f);
                bombp.z = (int)(bombp.z + 0.5f);

                createBomb.transform.position = bombp;

                bombcount -= 1;

                stage.GetComponent<StageController>().setMap(x, z, 4);



            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && stage.GetComponent<StageController>().map[x, z] == 0 && bombcount > 0)
            {
                GameObject createBomb = Instantiate(Bomb);

                createBomb.GetComponent<BombController>().owner = this.gameObject;

                Vector3 bombp = this.transform.position + new Vector3(0f, -0.5f, 0f);

                bombp.x = (int)(bombp.x + 0.5f);
                bombp.z = (int)(bombp.z + 0.5f);

                createBomb.transform.position = bombp;

                bombcount -= 1;

                stage.GetComponent<StageController>().setMap(x, z, 4);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
          
            Destroy(gameObject);//何かと衝突！！
            if (ID == 1)
            { SceneManager.LoadScene("GameOver1"); }
            else
            { SceneManager.LoadScene("GameOver2"); }

            Debug.Log("sinu");
        }

        if (other.gameObject.tag == "itemSpeed")
        {
            Destroy(other.gameObject);
            Speed *= 1.2f;
        }

        if (other.gameObject.tag == "itemBomb")
        {
            Destroy(other.gameObject);
            bombcount+=1;          
        }

        if (other.gameObject.tag == "itemFire")
        {
            Destroy(other.gameObject);
            power++;
        }

    }

    void GameOver()
    {
     
    }


}
