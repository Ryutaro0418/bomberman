using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class StageController : MonoBehaviour

{
    //public int[] map = new int[5]; 一次元配列　
    public int[,] map = new int[15,13];//二次元配列

    //0:床(なにもなし)
    //1:壁
    //2:ハードブロック
    //3:ソフトブロック
    //4:爆弾
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

    void InitOutLine()  //外周の設定
    {
        int x;
        int z;

        //X
        for ( x= 0; x < 15; x++)
        {
            map[x, 0] = 1;　//上Xの壁(0,12)～(14,12)
            map[x, 12] = 1; // 下Xの壁(0,0)～(14,0)  
        }

        //Z          
        for (z = 0; z < 13; z++)
        {
            map[0, z] = 1; 　//左Zの壁(0,0)～(0,12)
            map[14, z] = 1; //右Zの壁(14,0)～(14,12)
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

    void InitSoftBlock()    //壊れるブロック設置
    {
        for (int x = 0; x < 30; x++)
        {
            //置く位置を決める
            int Softx = Random.Range(1, 14);    //1から13の間にランダムに
            int Softz = Random.Range(1, 12);    //1から11の間にランダムに

            //そこに何もなかったら
            if (map[Softx, Softz] != 0 
                || (Softx == 1 && Softz == 1) || (Softx == 2 && Softz == 1) || (Softx == 1 && Softz == 2)
                || (Softx == 13 && Softz == 11) || (Softx == 12 && Softz == 11) || (Softx == 13 && Softz == 10))
            {
                x--;
            }
            else
            {
                //置く
                GameObject SoftBlock = Instantiate(SoftBlockPrefab);
                SoftBlock.transform.position = new Vector3(Softx, 0, Softz);
                map[Softx, Softz] = 3;

                SoftBlock.transform.parent = SoftBlockParent.transform;//instantiateされたsoftblockをsoftcoreの子供にする

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

 

   



    public int GetMap(int x, int z)  //ゲッター
    {
        return map[x, z];
    }

    public  void setMap(int x,int z, int status)//戻り値無しだからvoid use //セッター
    {
        map[x,z]=status;
    }


}
