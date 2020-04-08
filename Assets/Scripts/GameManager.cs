using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static int NbMoutons = 10;
    public GameObject[] tMoutons;
    public GameObject echecMouton;
    public InputHandler input;
    float start = 0.0f;
    public int[] TabMouton;
    float timer = 0.0f;
    public Text timeValue;
    private float fTempo = 0.45f;

    struct salve
    {
        public float fFin;
        public float fDebut;
    };

    List<salve> Timing = new List<salve>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTableauMouton", start, fTempo/2);
        //InvokeRepeating("InitMouton", start, 2.0f);
        MappingNiveau1();

    }

    void Update()
    {
        displayValueTimer();
        if (Timing.Count != 0)
        {
            if (timer >= (Timing[0].fDebut-4 * (fTempo/2)))
            {
                InvokeMouton();
            }
            if(timer >= (Timing[0].fFin - 4 * (fTempo / 2)))
            {
                RevokeMouton();
                Timing.Remove(Timing[0]);
            }
        }
        else
        {
            Debug.Log("La Liste est vide.");
        }
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    public void displayValueTimer()
    //BUT : Afficher la valeur du timer
    //ENTREE : La valeur du timer.
    //SORTIE : Le timer affiché.
    {
        float fTemps = timer;
        int nDizaine =(int) Mathf.Floor(fTemps / 10);
        fTemps -= nDizaine*10;
        int nUnite = (int)Mathf.Floor(fTemps);
        fTemps -= nUnite;
        int nDizieme = (int)Mathf.Floor(fTemps * 10);
        string sResultat = nDizaine.ToString();
        sResultat += nUnite.ToString();
        sResultat += ",";
        sResultat += nDizieme.ToString();
        timeValue.text = sResultat;
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

    public void InvokeMouton()
    {
        if (!IsInvoking("InitMouton"))
        {
            InvokeRepeating("InitMouton", start, fTempo);
        }
    }

    public void RevokeMouton()
    {
        if (IsInvoking("InitMouton"))
        {
            CancelInvoke("InitMouton");
        }
    }

    void MappingNiveau1()
    {
        Timing.Add(CreateSalve(2.1f, 4.0f));
        Timing.Add(CreateSalve(5.8f, 7.8f));
        Timing.Add(CreateSalve(9.2f, 11.0f));
        Timing.Add(CreateSalve(12.9f, 14.5f));
        Timing.Add(CreateSalve(16.1f, 18.2f));
        Timing.Add(CreateSalve(19.9f, 21.9f));
        Timing.Add(CreateSalve(23.3f, 25.2f));
        Timing.Add(CreateSalve(30.4f, 33.3f));
        Timing.Add(CreateSalve(33.7f, 37.0f));
        Timing.Add(CreateSalve(37.3f, 40.1f));
        Timing.Add(CreateSalve(40.9f, 44.3f));
        Timing.Add(CreateSalve(44.5f, 46.1f));
        Timing.Add(CreateSalve(46.2f, 47.5f));
        Timing.Add(CreateSalve(47.9f, 51.1f));
        Timing.Add(CreateSalve(51.4f, 54.8f));
    }

    salve CreateSalve(float fDebut, float fFin)
    {
        salve Salve;
        Salve.fDebut = fDebut;
        Salve.fFin = fFin;
        return Salve;
    }
}
