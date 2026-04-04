using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoresButtonPress : MonoBehaviour
{
    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Button butn = startButton.GetComponent<Button>();
		butn.onClick.AddListener(TaskOnClick);
    }

    //Goes to the highscore screen
    public void TaskOnClick(){
        SceneManager.LoadScene("HighScores");
	}
}