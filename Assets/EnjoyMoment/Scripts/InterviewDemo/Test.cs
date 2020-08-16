using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    void Start () {
        Exam.ItemData        ItemData_A = new Exam.ItemData () {
            id = 0,
            count = 3,
            costGold = 0,
            materialList = new List<Exam.MaterialData> (),
        };  
        Exam.ItemData  ItemData_B = new Exam.ItemData () {
            id = 1,
            count = 0,
            costGold = 5,
            materialList = new List<Exam.MaterialData> () {
            new Exam.MaterialData () { item = ItemData_A, count = 3 },
            }

        };   
        Exam  exam = new Exam ();
        Debug.Log (exam.Run (ItemData_B, 50));
    }

}