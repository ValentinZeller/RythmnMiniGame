using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int NbMoutons = 10;
    public GameObject[] tMoutons;
    public GameObject echecMouton;
    public InputHandler input;
    float start = 0.0f;
    public int[] TabMouton;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("AfficheMouton", start, 0.5f); L'afficheMouton a été déplacé dans l'incrementtableaumouton
        InvokeRepeating("IncrementTableauMouton", start, 0.5f);
        InvokeRepeating("InitMouton", start, 2.0f);
    }

    public void IncrementTableauMouton()
    //BUT : Gérer le tableau des moutons.
    //ENTREE : Le tableau à incrémenter.
    //SORTIE : Le tableau incrémenté.
    {
        if (echecMouton.GetComponent<SpriteRenderer>().color == Color.black)
        {
            echecMouton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        for (int nI = 1; nI < NbMoutons; nI++)
        {
            if (TabMouton[nI-1]==1)
            {
                TabMouton[nI-1] = 0;
                if ((nI == 4) && (!input.clicked))
                {
                    echecMouton.GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    TabMouton[nI] = 2; //2 est une valeur temporaire pour ne pas pousser au bout du tableau la valeur.
                }
            }
        }

        for (int nI = 0; nI < NbMoutons; nI++)
        {
            if (TabMouton[nI]==2)
            {
                TabMouton[nI] = 1;
            }
        }

        AfficheMouton();

        TabMouton[NbMoutons - 1] = 0;
    }

    public void AfficheMouton()
    //BUT : Gérer l'affichage des moutons.
    //ENTREE : Le tableau des moutons et le tableau d'incrémentation.
    //SORTIE : L'affichage des moutons actualisé.
    {
        for (int nI = 0; nI < NbMoutons; nI++)
        {
            if (TabMouton[nI] == 1)
            {
                tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                tMoutons[nI].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void InitMouton()
    //BUT : Meilleure fonction du monde.
    //ENTREE : Une seule ligne mais elle est appelée 4 tic avant l'impact demandé au joueur.
    //SORTIE : Ca colore les moutons en noir.
    {
        TabMouton[0] = 2;
    }
}
