using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Collections.Generic;
public class ReadJson : MonoBehaviour
{
    [SerializeField]
    private int level = 1;
    public int ChangeLevel
    {
        get { return level; }
        set { if (level < 4) { level = value; } else { level = 1; Awake(); } }
    }
    private JsonData items;
    [SerializeField]
    List <string> componentsLevel1;
    public List <string> Level1
    {
        get { return componentsLevel1; }
        set { componentsLevel1 = value; }
    }

    [SerializeField]
    List<string> componentsLevel2;
    public List<string> Level2
    {
        get { return componentsLevel2; }
        set { componentsLevel2 = value; }
    }

    [SerializeField]
    List<string> componentsLevel3;
    public List<string> Level3
    {
        get { return componentsLevel3; }
        set { componentsLevel3 = value; }
    }

    [SerializeField]
    List<string> componentsLevel4;
    public List<string> Level4
    {
        get { return componentsLevel4; }
        set { componentsLevel4 = value; }
    }


    [SerializeField]
    List<string> actualTags;

    public List<string> MyTags
    {
        get { return actualTags; }
        set { actualTags = value; }
    }


    /// <summary>
    ///
    /// </summary>
    void Awake()
    {
       
        Processjson(File.ReadAllText(Application.dataPath + "/Resources/frutimix.json"));
    }


    /// <summary>
    /// Read frutimix.json file 
    /// </summary>
    /// <param name="json"></param>
    void Processjson(string json)
    {
        items = JsonMapper.ToObject(json);
        //string aux;
        componentsLevel1.Clear();
        componentsLevel2.Clear();
        componentsLevel3.Clear();
        componentsLevel4.Clear();
        if (items["frutimix"].Count > 0)
        {
           
            /*Debug.Log("total " + items["frutimix"].Count);
            Debug.Log("random "+ran);
            Debug.Log("hay" + items["frutimix"][0]["level1"][0].Count);*/
           
            for (int i = 0; i < items["frutimix"].Count; i++)
            {
                int ran = Random.Range(0, 3);

                
                for (int j = 0; j < items["frutimix"][i]["level"+(i+1)][ran].Count; j++)
                {
                    if (i == 0)
                    {
                        componentsLevel1.Add(items["frutimix"][i]["level"+(i+1)][ran]["content"+j].ToString());
                    }
                    else if (i == 1)
                    {
                        componentsLevel2.Add(items["frutimix"][i]["level" + (i + 1)][ran]["content" + j].ToString());
                    }
                    else if (i == 2)
                    {
                        componentsLevel3.Add(items["frutimix"][i]["level" + (i + 1)][ran]["content" + j].ToString());
                    }
                    else 
                    {
                        componentsLevel4.Add(items["frutimix"][i]["level" + (i + 1)][ran]["content" + j].ToString());
                    }

                }

               
                // content.SendData(i,num, items["frutimix"][0]["s" + i].ToString());// I send the square position, the num varible with zeros(exa:103006780)

            }
            FillActualTags(level);
        }
    }

    public void FillActualTags(int actualLevel)
    {
        int a;
        string _tag = "";
        string aux=" ";
        actualTags.Clear();
        if (actualLevel == 1) {
             a = componentsLevel1[3].Length;
            aux = componentsLevel1[3];
        }
        else if(actualLevel == 2)
        {
            a = componentsLevel2[3].Length;
            aux = componentsLevel2[3];
        }
        else if (actualLevel == 3)
        {
            a = componentsLevel3[3].Length;
            aux = componentsLevel3[3];
        }
        else 
        {
            a = componentsLevel4[3].Length;
            aux = componentsLevel4[3];
        }

        for (int o = 0; o < a; o++)
        {
            if ("-" == aux[o].ToString() || a-o==1)
            {
                
                actualTags.Add(_tag);
                _tag = "";
                continue;
            }
           
            _tag += aux[o];
        }



    }

    public List<string> MyList() {
        if (level == 1)
        {
            return Level1;

        }else if(level == 2)
        {
            return Level2;
        }
        else if (level == 3)
        {
            return Level3;
        }
        else 
        {
            return Level4;
        }

    }

    public List<string> TheTagsAre()
    {
        FillActualTags(level);
        return MyTags;
    }



}
