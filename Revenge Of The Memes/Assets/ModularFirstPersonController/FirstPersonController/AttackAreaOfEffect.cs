using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaOfEffect : MonoBehaviour
{
    List<GameObject> enemiesInRange;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy/Active") && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }


    public List<GameObject> GetEnemiesAffected()
    {
        return enemiesInRange;
    }

    public void ResetList()
    {
        enemiesInRange.Clear();
    }
}
