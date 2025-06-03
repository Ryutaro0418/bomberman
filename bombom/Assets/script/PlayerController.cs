using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.GridLayoutGroup;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Tooltip("�ړ����x")]
    public float Speed;

    GameObject stage;

    [Header("���e�̐ݒ�")]
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
        //    sx = Input.GetAxis("Horizontal");  //�����x+�������̓��͒l�i-1.0�`1.0�j
        //    sz = Input.GetAxis("Vertical");    //�����x+�c�����̓��͒l�i-1.0�`1.0�j
        //}
        //else //player 2 controll
        //{
        //    sx = Input.GetAxis("Horizontal2");  //�����x+�������̓��͒l�i-1.0�`1.0�j
        //    sz = Input.GetAxis("Vertical2");    //�����x+�c�����̓��͒l�i-1.0�`1.0�j
        //}


        if (ID == 1)//player 1 controll
        {
            sx = Input.GetAxisRaw("Horizontal");  //�������̓��͒l�i-1.0�`1.0�j
            sz = Input.GetAxisRaw("Vertical");    //�c�����̓��͒l�i-1.0�`1.0�j
        }
        else //player 2 controll
        {
            sx = Input.GetAxisRaw("Horizontal2");  //�������̓��͒l�i-1.0�`1.0�j
            sz = Input.GetAxisRaw("Vertical2");    //�c�����̓��͒l�i-1.0�`1.0�j
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
            transform.rotation = Quaternion.LookRotation(move);//�L�����̌������Œ�
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
          
            Destroy(gameObject);//�����ƏՓˁI�I
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
