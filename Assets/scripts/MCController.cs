using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCController : MonoBehaviour
{
    private Animation anim;
    private bool firstStep;
    private bool turn;
    // Start is called before the first frame update
    void Start()
    {
        // init
        anim = this.GetComponent<Animation>();
        firstStep = true;
        turn = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.anyKeyDown)
        {
            if (firstStep) {
                anim.Play("leg-step-start");
                firstStep = false;
            }
            else
            {
                if (turn) {
                    anim.Play("leg-step-left");
                    turn = false;
                }
                else {
                    anim.Play("leg-step-right");
                    turn = true;
                }
            }
        }
    }
}
