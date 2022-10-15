using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Scriptable Objects/Object Saver", fileName = "New Object List")]
public class ObjectSaver : ScriptableObject
{
    public List<int> itemList = new List<int>();
    // [SerializeField] public bool resetValue;

    // private void OnEnable()
    // {
    //     value = resetValue;
    // }
}