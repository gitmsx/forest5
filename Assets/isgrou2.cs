using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isgrou2 : MonoBehaviour
{


    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        var controller = GetComponent<CharacterController>();
    }



     
 

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            print("CharacterController is grounded");
        }

    }
}
