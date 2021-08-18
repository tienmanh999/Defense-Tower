using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoundServived : MonoBehaviour
{
    public Text Roundtext;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    void Awake()
    {
        Roundtext.text = PlayerStart.Rounds.ToString();
    }
    IEnumerator AnimateText()
    {
        Roundtext.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);

        while(round < PlayerStart.Rounds)
        {
            round++;
            Roundtext.text = round.ToString();
            yield return new WaitForSeconds(.5f);
        }
    }
}
