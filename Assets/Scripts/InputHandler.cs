﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    
    float time = 0;
    public Text timeValue;
    public Text scoreValue;
    float score;
    public float[] timing = {0};
    float interval = 0.4f;
    float intervalLong = 3.2f;
    int index = 0;
    bool clicked = false;

    int indexLong = 29;
    int indexLong2 = 83; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //Timing où le joueur doit mainteir appuyer
        if ((index < timing.Length) && (time <= timing[index] + intervalLong) && (time >= timing[index] - interval) && ((index == indexLong)||(index == indexLong2))) {
            if (Input.anyKey)
            {
                score++;
            }
        }
        //Timing où le joueur doit appuyer
        else if ((index < timing.Length) && (time <= timing[index] + interval) && (time >= timing[index] - 0.2) && !clicked)
        {
            //S'il appuie, il gagne des points
            if (Input.anyKeyDown && !clicked)
            {
                score++;
                clicked = true;
            }
        }

        //Lorsque le timing est passé, on augmente l'index pour passer au prochain timing
        if ((index < timing.Length)&&(time > timing[index]+interval)&&(!clicked))
        {
            index++;
        } else if ((index < timing.Length)&&(time > timing[index]+interval)&&(clicked))
        {
            clicked = false;
            index++;
        }


        
        displayValue();
        
    }

    //Affichage du score et du temps
    public void displayValue()
    {
        timeValue.text = (Mathf.Round(time * 100) / 100).ToString();
        scoreValue.text = score.ToString();
    }
}
