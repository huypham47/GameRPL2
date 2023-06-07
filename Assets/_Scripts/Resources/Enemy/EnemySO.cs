using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public int hpMax;
    public int damage;
    public List<DropRate> dropList;
}
