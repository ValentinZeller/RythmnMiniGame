using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    public GameObject playerInput;
    public GameObject gameManager;
    public Camera mainCamera;
    public Text startCountdown;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count < 5)
        {

            // display something...
            startCountdown.text = count.ToString();
            yield return new WaitForSeconds(0.5f);
            count++;
        }

        // count down is finished...
        startCountdown.enabled = false;
        gameObject.SetActive(false);
    }

    public void StartGame()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<StartTutorial>().enabled = false;
        startCountdown.enabled = true;
        StartCoroutine(Countdown(1));
        mainCamera.GetComponent<AudioSource>().Play();
        gameManager.SetActive(true);
        playerInput.SetActive(true);
    }
}
