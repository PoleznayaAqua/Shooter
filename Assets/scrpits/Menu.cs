using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inp;
    public GameObject difftext;
    public void SetName() => SLAgent.SaveName(inp.GetComponent<TMPro.TextMeshProUGUI>().text);
    public void Exit() => Application.Quit();
    public void LoadGame()=> UnityEngine.SceneManagement.SceneManager.LoadScene("game");
    public void ChangeDiff(GameObject diff)
    {
        switch(System.Convert.ToInt32(diff.GetComponent<UnityEngine.UI.Slider>().value))
        {
            case 0:
                difftext.GetComponent<TMPro.TextMeshProUGUI>().text = "Easy";
                    break;
            case 1:
                difftext.GetComponent<TMPro.TextMeshProUGUI>().text = "Normal";
                break;
            case 2:
                difftext.GetComponent<TMPro.TextMeshProUGUI>().text = "Hard";
                break;
        }
        Global.diff = System.Convert.ToInt32(diff.GetComponent<UnityEngine.UI.Slider>().value);
    }
}
