using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SubmitButton : MonoBehaviour
{
    public Button startButton;
    public TMP_InputField playerNameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Button butn = startButton.GetComponent<Button>();
		butn.onClick.AddListener(TaskOnClick);
    }

    //Goes to the first real level, resets things back to the basics incase of using the reset button
    public void TaskOnClick(){
        string playerName = playerNameInput.text;
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "???";
        }
        
        int finalScore = GameManager.Instance.playerScore;
        
        DatabaseManager.Instance.SaveHighScore(playerName, finalScore);
        SceneManager.LoadScene("HighScores");
	}
}
