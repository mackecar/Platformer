using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxController : MonoBehaviour
{
    public GameObject Player;

    public Sprite OutOfAmmo;
    public Sprite AddedAmmo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowOutOfAmmo()
    {
        Player.GetComponent<MainTextController>().AddText(_outOfAmmoComments[Random.Range(0, _outOfAmmoComments.Count - 1)]);
        gameObject.GetComponent<SpriteRenderer>().sprite = OutOfAmmo;
        gameObject.SetActive(true);
        StartCoroutine(Hide());
    }

    public void ShowAddedAmmo()
    {
        Player.GetComponent<MainTextController>().AddText(_addAmmoComments[Random.Range(0,_addAmmoComments.Count-1)]);
        gameObject.GetComponent<SpriteRenderer>().sprite = AddedAmmo;
        gameObject.SetActive(true);
        StartCoroutine(Hide());
    }

    public void ShowKilledMessage(string message)
    {
        Player.GetComponent<MainTextController>().AddText(message);
        gameObject.SetActive(true);
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    private List<string> _outOfAmmoComments = new List<string>()
    {
        "Шта који курац?!",
        "Шта је бре ово?!",
        "НИЈЕ ФЕР!",
        "СТЕФАНЕ! Опрема!",
        "СТЕФАНЕ! ЧАМЦИ!"
    };

    private List<string> _addAmmoComments = new List<string>()
    {
        "Идемоо!!!",
        "Иде  гааас!!!",
        "Родило!",
        "Тооо!",
        "Маму вам јебем!",
        "Јебем вам матер!",
        "Бог те јебо!",
        "ААААА",
        "Nesto na madjarskom...",
        "Еssünk neki",
        "Nem tudom magyarul",
        "Аnyák"
    };
}
