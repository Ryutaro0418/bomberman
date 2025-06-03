using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class StageController : MonoBehaviour

{
    //public int[] map = new int[5]; �ꎟ���z��@
    public int[,] map = new int[15,13];//�񎟌��z��

    //0:��(�Ȃɂ��Ȃ�)
    //1:��
    //2:�n�[�h�u���b�N
    //3:�\�t�g�u���b�N
    //4:���e
    public GameObject SoftBlockPrefab;
    public GameObject SoftBlockParent;
    public GameObject player;
    public GameObject bomb;
 



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        InitOutLine();
        InitHardBlock();
        InitSoftBlock();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void InitOutLine()  //�O���̐ݒ�
    {
        int x;
        int z;

        //X
        for ( x= 0; x < 15; x++)
        {
            map[x, 0] = 1;�@//��X�̕�(0,12)�`(14,12)
            map[x, 12] = 1; // ��X�̕�(0,0)�`(14,0)  
        }

        //Z          
        for (z = 0; z < 13; z++)
        {
            map[0, z] = 1; �@//��Z�̕�(0,0)�`(0,12)
            map[14, z] = 1; //�EZ�̕�(14,0)�`(14,12)
        }

    }

    void InitHardBlock()
    {
        for (int x = 2; x <= 12; x += 2)
        {
            for (int z = 2; z <= 10; z += 2)
            {
                map[x,z] = 2;
            }
        }
    }

    void InitSoftBlock()    //����u���b�N�ݒu
    {
        for (int x = 0; x < 30; x++)
        {
            //�u���ʒu�����߂�
            int Softx = Random.Range(1, 14);    //1����13�̊ԂɃ����_����
            int Softz = Random.Range(1, 12);    //1����11�̊ԂɃ����_����

            //�����ɉ����Ȃ�������
            if (map[Softx, Softz] != 0 
                || (Softx == 1 && Softz == 1) || (Softx == 2 && Softz == 1) || (Softx == 1 && Softz == 2)
                || (Softx == 13 && Softz == 11) || (Softx == 12 && Softz == 11) || (Softx == 13 && Softz == 10))
            {
                x--;
            }
            else
            {
                //�u��
                GameObject SoftBlock = Instantiate(SoftBlockPrefab);
                SoftBlock.transform.position = new Vector3(Softx, 0, Softz);
                map[Softx, Softz] = 3;

                SoftBlock.transform.parent = SoftBlockParent.transform;//instantiate���ꂽsoftblock��softcore�̎q���ɂ���

                if (x < 10)
                {
                    SoftBlock.GetComponent<softBlockController>().item = 1;
                  
                }

                else if (x < 20)
                {
                    SoftBlock.GetComponent<softBlockController>().item = 2;

                }

                else if (x < 30)
                {
                    SoftBlock.GetComponent<softBlockController>().item = 3;

                }

            }
        }

    }

 

   



    public int GetMap(int x, int z)  //�Q�b�^�[
    {
        return map[x, z];
    }

    public  void setMap(int x,int z, int status)//�߂�l����������void use //�Z�b�^�[
    {
        map[x,z]=status;
    }


}
