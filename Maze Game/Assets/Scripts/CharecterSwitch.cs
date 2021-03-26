using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharecterSwitch : MonoBehaviour
{	public GameObject Char1;
    public GameObject Char2;
    //public GameObject Canvas1;
    //public GameObject Canvas2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Char1.SetActive(true);
            Char2.SetActive(false);
            //Canvas1.SetActive(true);
            //Canvas2.SetActive(false);
        }
        if(Input.GetKey(KeyCode.O))
        {
        	Char1.SetActive(false);
            Char2.SetActive(true);
            //Canvas1.SetActive(false);
            //Canvas2.SetActive(true);
        }

    }
}
