using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverIntro : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool genderSelected = false;

    [SerializeField] AnimatorController myAnim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        myAnim.SetAnimParameter("isSelected", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myAnim.SetAnimParameter("isSelected", false);
    }
}
