using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Text __score, __hitEffect, __perfectHitEffect, __perfectHitEffect2;
    public int status;
    
    private bool canBePressed;

    public void Init(Text score, Text hitEffect, Text perfectHitEffect, Text perfectHitEffect2, int stat)
    {
        __score = score;    __hitEffect = hitEffect;
        status = stat;   __perfectHitEffect = perfectHitEffect;
        __perfectHitEffect2 = perfectHitEffect2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "hit-line")
            canBePressed = true;
            
        if (other.gameObject.tag == "dead-zone")
            GetComponent<Image>().enabled = false;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "hit-line")
            canBePressed = false; 

        if (other.gameObject.tag == "dead-zone")
            GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.anyKeyDown && canBePressed)
            {
                int a = int.Parse(__score.text);

                if (status == 1)
                {
                    __hitEffect.GetComponent<Animation>().Play();
                    a += 100;
                    __score.text = a.ToString();
                    Destroy(this.gameObject);   
                }
                else
                {
                    __perfectHitEffect.GetComponent<Animation>().Play();
                    __perfectHitEffect2.GetComponent<Animation>().Play();
                    a += 250;
                    __score.text = a.ToString();
                    Destroy(this.gameObject.transform.parent.gameObject);   
                }
            }  
    }
}
