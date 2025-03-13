
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputField usernameInput;
    public GameObject loginPanel;
    public GameObject gamePanel;
    public GameObject missionPanel;
    public Text tokenText;
    public Button bitcoinButton;
    public Text usernameDisplay;
    public Animator coinAnimator;
    public ParticleSystem coinEffect;
    public Text missionText;
    public Button claimRewardButton;
    public Text rankText;

    private int tokens = 0;
    private string username;
    private int missionProgress = 0;
    private int missionGoal = 10;

    private string[] ranks = { "Bronze", "Silver", "Gold", "Platinum", "Diamond", "Heroic", "Master", "Elite Master" };
    private int currentRankIndex = 0;

    void Start()
    {
        gamePanel.SetActive(false);
        loginPanel.SetActive(true);
        missionPanel.SetActive(false);
        UpdateMissionText();
    }

    public void Login()
    {
        if (!string.IsNullOrEmpty(usernameInput.text))
        {
            username = usernameInput.text;
            usernameDisplay.text = "Welcome, " + username;
            loginPanel.SetActive(false);
            gamePanel.SetActive(true);
        }
    }

    public void EarnToken()
    {
        tokens++;
        tokenText.text = "Tokens: " + tokens;
        coinAnimator.SetTrigger("Click");
        coinEffect.Play();
        
        missionProgress++;
        UpdateMissionText();
        
        if (missionProgress >= missionGoal)
        {
            claimRewardButton.interactable = true;
        }

        UpdateRank();
    }

    void UpdateMissionText()
    {
        missionText.text = "Mission: Click " + missionGoal + " times (" + missionProgress + "/" + missionGoal + ")";
    }

    public void ClaimMissionReward()
    {
        if (missionProgress >= missionGoal)
        {
            tokens += 50;
            tokenText.text = "Tokens: " + tokens;
            missionProgress = 0;
            claimRewardButton.interactable = false;
            UpdateMissionText();
            UpdateRank();
        }
    }

    public void OpenMissionPanel()
    {
        missionPanel.SetActive(true);
    }

    public void CloseMissionPanel()
    {
        missionPanel.SetActive(false);
    }

    void UpdateRank()
    {
        if (tokens >= 500 && currentRankIndex < ranks.Length - 1)
        {
            currentRankIndex++;
            rankText.text = "Rank: " + ranks[currentRankIndex];
        }
    }
}
