using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Button butn = startButton.GetComponent<Button>();
		butn.onClick.AddListener(TaskOnClick);
    }

    //Goes to the first real level, resets things back to the basics incase of using the reset button
    public void TaskOnClick(){
        if (CoinPoolManager.Instance != null){ CoinPoolManager.Instance.ResetAllCoins(); }
        SceneManager.LoadScene("Debug_FirstLevel");
        GameManager.Instance.playerHp = 100;
        GameManager.Instance.playerScore = 0;
	}
}
