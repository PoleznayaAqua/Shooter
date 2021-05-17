using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class DisplayWorker : MonoBehaviour
{
    public GameObject scoretable;
    public GameObject scope;
    public GameObject scoretext;
    TextMeshProUGUI score;
    public RectTransform pltoptabchild;
    public RectTransform pltoptabcont;
    SLAgent slagent = new SLAgent();

    void Start()
    {
        SetCursor(true);
        scoretext.TryGetComponent(out score);
    }

    public void AddCount(int count)
    {
        score.text = Convert.ToString(count);
    }

    void SetCursor(bool value)
    {
        if (value)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void EndDisplay(int score)
    {
        SetCursor(false);
        scope.SetActive(false);
        scoretable.SetActive(true);
        slagent.SavePlayer(SLAgent.LoadName(), score);
        List<SLAgent.TopTab> list = slagent.LoadTop();

        foreach(Transform child in pltoptabcont.transform)
        {
            Destroy(child.gameObject);
        }

        if(list.Count>0)
            for (int i = 0; i < list.Count; i++)
            {
                var inst = Instantiate(pltoptabchild);
                inst.transform.SetParent(pltoptabcont.transform, false);
                inst.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = list[i].name;
                inst.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Convert.ToString(list[i].score);
            }
    }
}
