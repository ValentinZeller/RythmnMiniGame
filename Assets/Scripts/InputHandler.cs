using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{   
    float time = 0;
    public Text timeValue;
    public Text scoreValue;
    public Image pressButton;
    float score;
    float[] timing = new float[83];
    float interval = 0.4f;
    int index = 0;
    float start = 2.1f;
    [HideInInspector]public bool clicked = false;

    private void Awake()
    {
        /*for (int i = 0; i < 83; i++)
        {
            timing[i] = start + (i * interval);
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    void Update()
    {
        time += Time.deltaTime;
        //if (time > timing[index] - interval*1.5)
        pressedButton();
        clickTiming();
        displayValue();
        
    }

    //Affichage du score et du temps
    public void displayValue()
    {
        timeValue.text = (Mathf.Round(time * 100) / 100).ToString();
        scoreValue.text = score.ToString();
    }

    void pressedButton()
    {
        if (Input.anyKeyDown)
        {
            pressButton.color = new Color32(231, 97, 97, 255);
        }
        else
        {
            pressButton.color = new Color32(147, 60, 60, 255);
        }
    }

    public void clickTiming()
    {
       
        //Timing où le joueur doit mainteir appuyer
        /*if ((index < timing.Length) && (time <= timing[index] + intervalLong) && (time >= timing[index] - interval) && ((index == indexLong) || (index == indexLong2)))
        {
            if (Input.anyKey)
            {
                score++;
            }
        }
        //Timing où le joueur doit appuyer
        else*/
        if ((GameObject.Find("GameManager").GetComponent<GameManager>().tMoutons[3].GetComponent<SpriteRenderer>().color == Color.black) && (!clicked))
        {
            //S'il appuie, il gagne des points
            if (Input.anyKeyDown && !clicked)
            {
                score++;
                clicked = true;
            }
        }

        //Lorsque le timing est passé, on augmente l'index pour passer au prochain timing

        if ((GameObject.Find("GameManager").GetComponent<GameManager>().tMoutons[3].GetComponent<SpriteRenderer>().color == Color.white))
        {
            clicked = false;
        }


    }

}
