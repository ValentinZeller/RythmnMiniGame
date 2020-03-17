using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int NbMoutons = 10;
    [SerializeField]
    public GameObject[] tMoutons;
    public GameObject echecMouton;
    public InputHandler input;
    float start = 1.2f;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("MoutMoutMout", start, 0.8f);
        InvokeRepeating("MoutMout", start, 0.2f);
    }

   public void MoutMout()
   {
        if (echecMouton.GetComponent<SpriteRenderer>().color == Color.black)
        {
            echecMouton.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (tMoutons[NbMoutons - 1].GetComponent<SpriteRenderer>().color == Color.black)
        {
            tMoutons[NbMoutons - 1].GetComponent<SpriteRenderer>().color = Color.white;
        }

        for (int nI=1; nI< NbMoutons; nI++)
        {
            if (tMoutons[nI - 1].GetComponent<SpriteRenderer>().color == Color.black)
            {
                tMoutons[nI - 1].GetComponent<SpriteRenderer>().color = Color.white;
                if ((nI == 4)&&(!input.clicked))
                {
                    echecMouton.GetComponent<SpriteRenderer>().color = Color.green;
                } else
                {
                    tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.green;
                    
                }
            }
        }

        for (int nI = 0; nI < NbMoutons; nI++)
        {
            if (tMoutons[nI].GetComponent<SpriteRenderer>().color == Color.green)
            {
                tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
        if (echecMouton.GetComponent<SpriteRenderer>().color == Color.green)
        {
            echecMouton.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    public void MoutMoutMout()
    {
        tMoutons[0].GetComponent<SpriteRenderer>().color = Color.green;
    }
}
