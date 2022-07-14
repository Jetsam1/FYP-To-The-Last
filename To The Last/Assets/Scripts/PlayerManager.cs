using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] checkpoint;
    PlayerStats stats;
    newMove ms;
    bool isDead;
    float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        if (stats.pc == PlayerStats.playerClass.None)
        {
            stats.hp = 100;
        }
        else if(stats.pc ==PlayerStats.playerClass.Dreadnought)
        {
            stats.hp = 200;
        }
        else if(stats.pc ==PlayerStats.playerClass.Ghost)
        {
            stats.hp = 50;
        }
        else if(stats.pc == PlayerStats.playerClass.Trickster)
        {
            stats.hp = 100;
        }
    }

    private void regen()
    {
        if (currentHP<stats.hp)
        {
            for (float i = currentHP; currentHP < stats.hp; i++)
            {
                Invoke("addHP", 0.5f);
            }
        }
    }
    private void addHP()
    {
        currentHP += stats.regenRate;
    }
    // Update is called once per frame
    void Update()
    {
        stats.speed = ms.moveSpeed;

        if(currentHP <stats.hp)
        {
            Invoke("regen",3);
        }

    }
}


public class PlayerStats
{
    public enum playerClass { None,Trickster, Dreadnought, Ghost };
    public float hp;
    public float speed;
    public float baseDamage;
    public float regenRate;
    public playerClass pc;


}