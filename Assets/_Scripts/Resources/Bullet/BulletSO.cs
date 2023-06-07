using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet")]
public class BulletSO : ScriptableObject
{
    public string bulletName;
    public int damage;
    public float speed;
}
