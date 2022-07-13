using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] checkpoint;
    PlayerStats stats;
    newMove ms;
    bool isDead;
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

    // Update is called once per frame
    void Update()
    {
        stats.speed = ms.moveSpeed;
    }
}


public class PlayerStats
{
    public enum playerClass { None,Trickster, Dreadnought, Ghost };
    public float hp;
    public float speed;
    public float baseDamage;
    public playerClass pc;


}