using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    GoldDisplayer goldDisplayer;
    public int CurrentBalance{ get { return currentBalance; } }

    private void Awake() {
        currentBalance = startingBalance;
        goldDisplayer = FindObjectOfType<GoldDisplayer>();
        goldDisplayer.ChangeText(currentBalance.ToString());
    }
    public void Deposit(int amount)
    {
        currentBalance+=Mathf.Abs(amount);
        goldDisplayer.ChangeText(currentBalance.ToString());
        
    }
    public void Withdraw(int amount)
    {
        currentBalance-=Mathf.Abs(amount);
        goldDisplayer.ChangeText(currentBalance.ToString());

        if(currentBalance<0)
        {
            //lose game
        }
    }
    void  ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
