﻿using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Collections.Generic;
public class ReadJson : MonoBehaviour
{
    public int level = 1;
    private JsonData items;
    public List <string> componentsLevel1;
    public List <string> Level1
    {
        get { return componentsLevel1; }
        set { componentsLevel1 = value; }
    }


    public List<string> componentsLevel2;
    public List<string> Level2
    {
        get { return componentsLevel2; }
        set { componentsLevel2 = value; }
    }


    public List<string> componentsLevel3;
    public List<string> Level3
    {
        get { return componentsLevel3; }
        set { componentsLevel3 = value; }
    }



    public List<string> actualTags;

    public List<string> MyTags
    {
        get { return actualTags; }
        set { actualTags = value; }
    }


    /// <summary>
    ///
    /// </summary>
    void Start()
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
        string aux;

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
                    else
                    {
                        componentsLevel3.Add(items["frutimix"][i]["level" + (i + 1)][ran]["content" + j].ToString());
                    }
                        
                }

                // content.SendData(i,num, items["frutimix"][0]["s" + i].ToString());// I send the square position, the num varible with zeros(exa:103006780)

            }
        }
    }




}
