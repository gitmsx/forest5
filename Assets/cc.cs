using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cc : MonoBehaviour
{
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            print("CharacterController is grounded");
        }
    }
}