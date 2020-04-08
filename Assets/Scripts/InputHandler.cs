using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
<<<<<<< HEAD
{   
    float time = 0;
    public Text timeValue;
=======
{
    //float time = 0;
>>>>>>> SCHLOTTER_Romain_unity_2019
    public Text scoreValue;
    public Image pressButton;
    float score;
    float[] timing = new float[83];
    float interval = 0.4f;
<<<<<<< HEAD
    int index = 0;
    float start = 2.1f;
    [HideInInspector]public bool clicked = false;

=======
    //float intervalLong = 3.2f;
    //int index = 0;
    float start = 2.1f;
    [HideInInspector]public bool clicked = false;

    //int indexLong = 29;
    //int indexLong2 = 83;

>>>>>>> SCHLOTTER_Romain_unity_2019
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
<<<<<<< HEAD
        time += Time.deltaTime;
        //if (time > timing[index] - interval*1.5)
        pressedButton();
=======
        //if (time > timing[index] - interval*1.5)
>>>>>>> SCHLOTTER_Romain_unity_2019
        clickTiming();
        displayValueScore();
        
    }


    //Affichage du score
    public void displayValueScore()
    {
        scoreValue.text = score.ToString();
    }

    void pressedButton()
    {
        if (Input.anyKeyDown || Input.anyKey)
        {
            pressButton.color = new Color32(231, 97, 97, 255);
        }
        else
        {
            pressButton.color = new Color32(0, 0, 0, 255);
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
