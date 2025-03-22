using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Ink.Runtime;
using UnityEngine.UI;

public class BranchingController : MonoBehaviour
{
    // [SerializeField] private GameObject branchingCanvas;
    // [SerializeField] private GameObject dialogPrefab;
    // [SerializeField] private GameObject choicePrefab;
    // [SerializeField] private TextAssetValue dialogValue;
    // [SerializeField] private Story myStory;
    // [SerializeField] private GameObject dialogHolder;
    // [SerializeField] private GameObject choiceHolder;
    // [SerializeField] private ScrollRect dialogScroll;
    // [SerializeField] private FloatValue gameSpeed;

    // public void EnableBranchingCanvas()
    // {
    //     Time.timeScale = 0f;
    //     Debug.Log("Setting timescale to 0");
    //     branchingCanvas.SetActive(true);
    //     SetStory();
    //     RefreshView();
    // }

    // public void SetStory()
    // {
    //     if(dialogValue.value)
    //     {
    //         DeleteOldDialogs();
    //         myStory = new Story(dialogValue.value.text);
    //     }
    //     else
    //     {
    //         Debug.Log("Error with story.");
    //     }
    // }

    // public void DeleteOldDialogs()
    // {
    //     for(int i = 0; i < dialogHolder.transform.childCount; i++)
    //     {
    //         Destroy(dialogHolder.transform.GetChild(i).gameObject);
    //     }
    // }

    // public void RefreshView()
    // {
    //     while(myStory.canContinue)
    //     {
    //         MakeNewDialog(myStory.Continue());
    //     }
    //     if(myStory.currentChoices.Count > 0)
    //     {
    //         MakeNewChoices();
    //     }
    //     else
    //     {
    //         JumpOutOfDialog();
    //     }
    //     StartCoroutine(ScrollCo());
    // }

    // IEnumerator ScrollCo()
    // {
    //     yield return null;
    //     dialogScroll.verticalNormalizedPosition = 0f;
    // }

    // public void MakeNewDialog(string newDialog)
    // {
    //     DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DialogObject>();
    //     newDialogObject.Setup(newDialog);
    // }

    // public void MakeNewResponse(string newDialog, int choiceValue)
    // {
    //     ResponseObject newResponseObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ResponseObject>();
    //     newResponseObject.Setup(newDialog, choiceValue);
    //     Button responseButton = newResponseObject.gameObject.GetComponent<Button>();
    //     if(responseButton)
    //     {
    //         responseButton.onClick.AddListener(delegate{ ChooseChoice(choiceValue); });
    //     }
    // }

    // public void MakeNewChoices()
    // {
    //     for(int i = 0; i < choiceHolder.transform.childCount; i++)
    //     {
    //         Destroy(choiceHolder.transform.GetChild(i).gameObject);
    //     }
    //     for(int i = 0; i < myStory.currentChoices.Count; i++)
    //     {
    //         MakeNewResponse(myStory.currentChoices[i].text, i);
    //     }
    // }

    // public void ChooseChoice(int choice)
    // {
    //     myStory.ChooseChoiceIndex(choice);
    //     RefreshView();
    // }

    // public void JumpOutOfDialog()
    // {
    //     Time.timeScale = gameSpeed.value;
    //     branchingCanvas.SetActive(false);
    // }
}
