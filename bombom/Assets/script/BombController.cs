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

        // Destroy(this.gameObject,3);�@//()��,3�͎O�b��ɏ������ĈӖ�

        Invoke("Explosion", 3); //3�b��ɂ���method�����s���āI�I�I

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
            return;//�����I��
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

     
      
        //�E
        for (i= 0; i < power; i++)
        {�@
            //�΂��o���ʒu
            int x = (int)(this.transform.position.x + i + 0.5f);   //int�^�ɃL���X�g
            int z = (int)(this.transform.position.z + 0.5f);
            //���̈ʒu�̃X�e�[�^�X
            int status = stage.GetComponent<StageController>().GetMap(x, z);

           
            //1or2��������
            if (status ==1||status==2)    //1 or 2
            {
                break;
            }


            //�����Ȃ���Ή΂��o��
            GameObject FireP;
            FireP = Instantiate(Fire);       //Fire���Ă�
            FireP.transform.position = new Vector3(x, 0, z);    //Bomb�̃|�W�V������Fire���o��//+ new Vector3(0,0,0)������
            Destroy(FireP, FireDestroy);      //�Z�b���Fire������
           


            if (status==3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }


        }

        //��
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + -i + 0.5f);
            int z = (int)(this.transform.position.z + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0�@0����Ȃ�������
            {
             break;
            }

            GameObject FireP;
            FireP = Instantiate(Fire);       //Fire���Ă�
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //�Z�b���Fire������

            if (status == 3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }
        }

        //��
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + 0.5f);
            int z = (int)(this.transform.position.z + i + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0�@0����Ȃ�������
            {
                break;
            }

            GameObject FireP; 
            FireP = Instantiate(Fire);       //Fire���Ă�
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //�Z�b���Fire������

            if (status == 3)    //
            {
                //stage.GetComponent<StageController>().setMap(x, z, 0);
                StartCoroutine(StageZero(x, z));
                break;
            }
        }

        //��
        for (i = 0; i < power; i++)
        {
            int x = (int)(this.transform.position.x + 0.5f);
            int z = (int)(this.transform.position.z + -i + 0.5f);
            int status = stage.GetComponent<StageController>().GetMap(x, z);

            if (status == 1 || status == 2)    //!=0�@0����Ȃ�������
            {
                break;
            }

            GameObject FireP;
            FireP = Instantiate(Fire);       //Fire���Ă�
            FireP.transform.position = new Vector3(x, 0, z);
            Destroy(FireP, FireDestroy);      //�Z�b���Fire������


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
            Debug.Log("�G�ꂽ�I");
            Explosion();

        }
    }

    IEnumerator StageZero(int x, int z)
    {
        //���[���
        Debug.Log("����");
        yield return new WaitForSeconds(0.5f);
        stage.GetComponent<StageController>().setMap(x, z, 0);
    }

}
