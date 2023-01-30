using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    // Start is called before the first frame update
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
        }
    }
}
