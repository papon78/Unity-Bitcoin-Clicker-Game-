
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject gamePanel;
    public GameObject missionPanel;

    public void ShowGamePanel()
    {
        loginPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void ShowMissionPanel()
    {
        missionPanel.SetActive(true);
    }

    public void HideMissionPanel()
    {
        missionPanel.SetActive(false);
    }
}
