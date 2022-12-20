using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [Tooltip("Adds amount to maxHealth when enemy dies")]
    [SerializeField] int difficultyRamp = 2;
    [SerializeField] public int currentHealth;
    Enemy enemy;
    private void OnEnable() 
    {
       
        currentHealth = maxHealth;
    }
    void OnDisable() 
    {
        maxHealth+=difficultyRamp;
    }
    void Start() {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other) {
            takeHit();
            
        }
    void takeHit()
    {
        currentHealth -= 1;
        if(currentHealth == 0){
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
