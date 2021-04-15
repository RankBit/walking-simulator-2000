using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("OpenDoor");
            }
        }
    }
}
