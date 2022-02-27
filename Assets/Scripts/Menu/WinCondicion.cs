using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinCondicion : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI textWin;


    private void OnEnable()
    {
        TotalShrimpsPlayer.renameScore += ReWriteScore;
    }

    private void OnDisable()
    {
        TotalShrimpsPlayer.renameScore -= ReWriteScore;
    }

    public void ReWriteScore()
    {
        textWin.text = "Score " + player.GetComponent<PlayerLevelController>().GetTotalShrimps();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        TriggerGoal.StageComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
