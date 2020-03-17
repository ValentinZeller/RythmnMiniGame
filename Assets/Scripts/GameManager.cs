using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int NbMoutons = 10;
    [SerializeField]
    public GameObject[] tMoutons;
    public GameObject echecMouton;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoutMoutMout", 2.0f, 2f);
        InvokeRepeating("MoutMout", 2.0f, 0.5f);
    }

   void MoutMout()
   {
        if (tMoutons[NbMoutons - 1].GetComponent<SpriteRenderer>().color == Color.black)
        {
            tMoutons[NbMoutons - 1].GetComponent<SpriteRenderer>().color = Color.white;
        }

        for (int nI=1; nI< NbMoutons; nI++)
        {
            if (tMoutons[nI - 1].GetComponent<SpriteRenderer>().color == Color.black)
            {
                tMoutons[nI - 1].GetComponent<SpriteRenderer>().color = Color.white;
                tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

        for (int nI = 0; nI < NbMoutons; nI++)
        {
            if (tMoutons[nI].GetComponent<SpriteRenderer>().color == Color.green)
            {
                tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

    void MoutMoutMout()
    {
        tMoutons[0].GetComponent<SpriteRenderer>().color = Color.green;
    }
}
