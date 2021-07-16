using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmCheck : MonoBehaviour
{
    private Animation animation;
    private bool firstStep;
    private bool turn;
    // Start is called before the first frame update
    void Start()
    {
        // init
        animation = this.GetComponent<Animation>();
        firstStep = true;
        turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (firstStep) {
                animation.Play("leg-step-start");
                firstStep = false;
            }
            else
            {
                if (turn) {
                    animation.Play("leg-step-left");
                    turn = false;
                }
                else {
                    animation.Play("leg-step-right");
                    turn = true;
                }
            }
        }
    }
}
