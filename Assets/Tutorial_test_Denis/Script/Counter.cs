using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    GameObject[] skill;
    public Text counter;
   
  

    // Start is called before the first frame update
    void Start()
    {
   //     count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        skill = GameObject.FindGameObjectsWithTag("Skill");
    counter.text = "Skill :" + skill.Length.ToString();
        //counter.text = "Counter :" + Score;
       
    }
    

}



