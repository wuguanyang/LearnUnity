/*
CreateBy:     wgy
CreateTime:   2020/08/04 18:17:31
Description:  
*/

using System.Collections.Generic;
using UnityEngine;

public class LoadScriptObject : MonoBehaviour
{
    
    void Start()
    {
        var personData=Resources.Load<PersonData>("PersonData");
        this.Log(personData.name);


        
    }
}



