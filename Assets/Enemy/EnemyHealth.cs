using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] //it ensures that the required component we specified (Enemy) also gets attached to the gameObject this script (EnemyHealth) is attached
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable() // OnEnable because each time the gameObject is activated again, it restarts fresh (from the startPos, full health, etc)
    {
        currentHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        KillEnemy();
    }

    private void KillEnemy() {
        currentHitPoints--;
        if(currentHitPoints < 1) {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp; // each time it dies and is activated again, it gains +1 of health
            enemy.RewardGold();
        }
    }
}
