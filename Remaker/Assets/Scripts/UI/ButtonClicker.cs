using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    [SerializeField] private Sprite originalImage;
    [SerializeField] private Sprite pressedImage;
    [SerializeField] private Button myButton;

    public void whenClicked()
    {
        StartCoroutine(changeImage());
    }

    public IEnumerator changeImage()
    {
        myButton.image.sprite = pressedImage;
        yield return new WaitForSeconds(0.5f);
        myButton.image.sprite = originalImage;
    }

}
