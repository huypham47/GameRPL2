using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public EnemyCode enemyCode = EnemyCode.NoItem;
    public List<ItemDropRate> dropList;
    public List<EnemyInform> upgradeLevels;
}
