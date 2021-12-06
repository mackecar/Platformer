using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MainTextController : MonoBehaviour
{
    public TextMeshProUGUI MainText;
    private bool _canAddText = true;

    // Start is called before the first frame update
    void Start()
    {
        MainText.text = "Јебо те БОГ морам до Новог Бечеја!";
        StartCoroutine(Clear());
    }

    public void AddText(string text)
    {
        if (_canAddText)
        {
            _canAddText = false; 
            MainText.text = text.ToString(new CultureInfo("sr"));
            StartCoroutine(Clear()); 
        }
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(1.5f);
        MainText.text = "";
        _canAddText = true;
    }
}
