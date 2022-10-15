using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialMessages : MonoBehaviour
{
    [SerializeField] private GameObject placeText;
    [SerializeField] private GameObject dialogBox;
    private TextMeshProUGUI myText;
    private Color originalColor;
    private Color mutatedColor;
    private bool wasActive = false;
    private bool tutorialStarted = false;
    private bool tutorialHasEnded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        myText = placeText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        originalColor = myText.color;
        mutatedColor = originalColor;
        mutatedColor.a = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!tutorialHasEnded)
        {
            if(!tutorialStarted)
            {
                if(wasActive)
                {
                    if(!placeText.activeSelf)
                    {
                        tutorialStarted = true;
                        StartCoroutine(TutorialCo());
                    }
                }
                else
                {
                    if(placeText.activeSelf)
                    {
                        wasActive = true;
                    }
                }
            }
            if(dialogBox.activeSelf)
            {
                tutorialHasEnded = true;
                myText.autoSizeTextContainer = false;
                placeText.SetActive(false);
                myText.text = "The Glade";
                myText.color = originalColor;
            }
        }
    }

    public IEnumerator TutorialCo()
    {
        myText.text = "Press 'e' to interact";
        yield return new WaitForSeconds(1);
        myText.color = mutatedColor;
        myText.autoSizeTextContainer = true;
        placeText.SetActive(true);

        
        // mutatedColor = text.color;
        // SetText(roomNameValue.value);
        // nameText.SetActive(true);
        
        // fade = true;
        // yield return new WaitForSeconds(2);
        // fade = false;
        // text.color = originalColor;
        // nameText.SetActive(false);
    }
}
