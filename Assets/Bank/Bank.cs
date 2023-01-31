using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance {get { return currentBalance; }}

    private void Awake() {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance < 0) {
            // should call method or sceneManager to handle the end of the level if it was not a prototype
            ReloadScene();
        }
    }

    private void UpdateDisplay() { // this right here could be in its own class (bank is getting overwhelmed of function)
        displayBalance.text = "Gold: " + currentBalance;
    }

    private void ReloadScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
