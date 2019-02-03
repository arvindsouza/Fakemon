using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonInterface {

    void attack(int atkDamage);
    bool damage(int damage);

}
[System.Serializable]
public class stats
{
    public int attack;
    public int defense;
    public int speed;
}
