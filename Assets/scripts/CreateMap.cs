using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject note, allNotes, rythmLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Instantiate(note, rythmLine.transform.position, new Quaternion(), allNotes.transform);
        }
    }
}