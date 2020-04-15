using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public Text scoreValue;
    public Image pressButton;
    float score;
    public GameObject successAnim;
    public GameObject failedAnim;
    [HideInInspector]public bool clicked = false;


    // Update is called once per frame
    void Update()
    {
        pressedButton();
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
        //Timing où le joueur doit appuyer
        if ((GameObject.Find("GameManager").GetComponent<GameManager>().tMoutons[3].GetComponent<SpriteRenderer>().color == Color.black) && (!clicked))
        {
            //S'il appuie, il gagne des points
            if (Input.anyKeyDown && !clicked)
            {
                score++;
                clicked = true;
                successAnim.SetActive(true);
            }
        }

        if ((GameObject.Find("GameManager").GetComponent<GameManager>().echecMouton.GetComponent<SpriteRenderer>().color == Color.black) && (!clicked))
        {
            failedAnim.SetActive(true);
        } else
        {
            failedAnim.SetActive(false);
        }
            //Lorsque le timing est passé, on augmente l'index pour passer au prochain timing

        if ((GameObject.Find("GameManager").GetComponent<GameManager>().tMoutons[3].GetComponent<SpriteRenderer>().color == Color.white))
        {
            clicked = false;
            
        }

        if ((GameObject.Find("GameManager").GetComponent<GameManager>().tMoutons[2].GetComponent<SpriteRenderer>().color == Color.black)) {
            successAnim.SetActive(false);
        }


    }

}
