using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        // if (other.gameObject.tag == "dead-zone")
        // {
        //     other.gameObject.SetActive(true);
        // }    
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
