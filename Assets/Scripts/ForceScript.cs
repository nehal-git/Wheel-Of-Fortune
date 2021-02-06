using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RandomTimemin;
    public float RandomTimemax;
    public bool isForceApplied=false;
    public float ForceVal;
    public float forceRad;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isForceApplied)
        {
            isForceApplied = true;
            rb.AddForce(Vector2.up*ForceVal);
            StartCoroutine(Resrt());
        
        }


        
    }

    IEnumerator Resrt()
    {
        yield return new WaitForSeconds(Random.Range(RandomTimemin,RandomTimemax));
        isForceApplied = false;
    
    
    }
}
