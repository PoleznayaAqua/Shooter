using System.Collections.Generic;
using UnityEngine;


public class SLAgent : MonoBehaviour
{
    [HideInInspector]
    static public int loadedplcount;
    public struct TopTab
    {
        public string name;
        public int score;
    }

    public List<TopTab> LoadTop()
    {
        List<TopTab> list = new List<TopTab>();
        for (int i = 0;i< Global.maxplayers; i++)
        {
            if (PlayerPrefs.HasKey("PlayerName" + i))
            {
                list.Add(new TopTab{ name = PlayerPrefs.GetString("PlayerName" + i), score = PlayerPrefs.GetInt("PlayerScore" + i) });
            }
            else continue;
        }
        return list;
    }

    public void SavePlayer(string plname, int plscore)
    {
        int pos = -1;
        List<TopTab> list = LoadTop();
        int counter = 0;
        foreach (TopTab pl in list)
            if (plscore >= pl.score)
            {
                pos = counter;
                continue;
            }
            else counter++;
        list.Insert(0, new TopTab { name = plname, score = plscore });
        list.Sort((y,x)=>x.score.CompareTo(y.score));
        if (list.Count >= Global.maxplayers)
        {
            for (int i = list.Count - 1; i >= Global.maxplayers; i--) list.Remove(list[i]);
        }

        for (int i = 0; i < list.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, list[i].name);
            PlayerPrefs.SetInt("PlayerScore" + i, list[i].score);
        }
        PlayerPrefs.Save();
    }

    public static void SaveName(string plname)
    {
        if (PlayerPrefs.HasKey("plname"))
        {
            PlayerPrefs.DeleteKey("plname");
        }
        PlayerPrefs.SetString("plname", plname);
        PlayerPrefs.Save();
    }

    public static string LoadName()
    {
        if (PlayerPrefs.HasKey("plname")) return PlayerPrefs.GetString("plname");
        else return Global.stplname;
    }
}
