using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int costToPlaceTower = 75;

    public bool CreateTower(Tower tower, Vector3 position) { // accepting a prefab tower and a vector3 position
        Bank bank = FindObjectOfType<Bank>();
        
        if(bank == null) { return false; }
        
        if(bank.CurrentBalance >= costToPlaceTower) {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(costToPlaceTower);
            return true;
        }
        
        return false; // if everything else fails, return false (it corrects our method error)
    }
}
