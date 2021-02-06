using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf : MonoBehaviour
{
    


    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyImmediate(this.gameObject);


        }
    }
}
