using UnityEngine;
using TMPro;

public class AutoText : MonoBehaviour
{
    //A script purely to set the score valuable in gameover
    public TextMeshProUGUI scoreTextBox;
    void Start()
    {
        scoreTextBox.text = "Score: " + PlayerPrefs.GetInt("Score", 0);
    }
}
