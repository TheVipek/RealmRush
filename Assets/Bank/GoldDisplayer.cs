using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldDisplayer : MonoBehaviour
{
    [SerializeField] TMP_Text TMP_Text; 

    public void ChangeText(string str)
    {
        TMP_Text.text = str;
    }
}
