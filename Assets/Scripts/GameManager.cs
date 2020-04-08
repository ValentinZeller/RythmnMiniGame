using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTableauMouton", start, 0.2f);
        InvokeRepeating("InitMouton", start, 2.0f);
    }

    void Update()
    {
        displayValueTimer();
        switch (timer)
        {
            case float fX when (fX >= 2.1f && fX<3.8f):
                InvokeMouton();
                break;
            case float fX when (fX >= 3.8 && fX < 5.7):
                RevokeMouton();
                break;
            case float fX when (fX >= 5.8f && fX < 7.6f):
                if (!IsInvoking("InitMouton"))
                {
                    InvokeRepeating("InitMouton", start, fTempo);
                }
                break;
            //case float fX when (fX >= 7.6f && fX <12.8f)



            /*case default:
                break;*/
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
}
