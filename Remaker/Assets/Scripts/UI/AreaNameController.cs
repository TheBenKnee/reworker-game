using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaNameController : MonoBehaviour
{
    [SerializeField] private GameObject nameText;
    private StringValue roomNameValue;
    private TextMeshProUGUI text;
    private bool fade = false;
    private Color originalColor;
    private Color mutatedColor;

    void FixedUpdate()
    {
        if(fade)
        {
            mutatedColor.a -= (float)0.01;
            text.color = mutatedColor;
        }
    }

    public void ActivateText()
    {
        StartCoroutine(NameCo());
    }

    public IEnumerator NameCo()
    {
        mutatedColor = text.color;
        SetText(roomNameValue.value);
        nameText.SetActive(true);
        yield return new WaitForSeconds(2);
        fade = true;
        yield return new WaitForSeconds(2);
        fade = false;
        text.color = originalColor;
        nameText.SetActive(false);
    }

    public void Inialize()
    {
        originalColor = text.color;
    }

    public void SetStringValue(StringValue newText)
    {
        roomNameValue = newText;
        text = nameText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    void SetText(string newText)
    {
        TextMeshProUGUI myText = nameText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        myText.text = newText;
    }

}