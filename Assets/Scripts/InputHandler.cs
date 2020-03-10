using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    
    float time = 0;
    public Text timeValue;
    public Text scoreValue;
    float score;
    float[] timingLow = { 2.1f , 2.6f};
    float[] timingHigh = { 2.5f, 3.0f };
    int index = 0;
    bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(clicked);
        if ((index < timingLow.Length) &&(time <= timingHigh[index])&&( time >= timingLow[index])&&(clicked == false))
        {
            if (Input.anyKeyDown&&!clicked)
            {
                score++;
                index++;
                clicked = true;
            }
        }

        if ((index < timingLow.Length)&&(time > timingHigh[index])&&!clicked)
        {
            index++;
        } else if ((index < timingLow.Length)&&(time > timingHigh[index])&&clicked)
        {
            clicked = false;
        }
        timeValue.text = (Mathf.Round(time*100)/100).ToString();
        scoreValue.text = score.ToString();
        
    }
}
