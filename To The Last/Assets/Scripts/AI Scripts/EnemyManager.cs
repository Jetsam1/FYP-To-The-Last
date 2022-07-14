using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyManager :MonoBehaviour
{
    static public GameObject game;
    public Rigidbody body;
    EnemyStats stats;


    
   void setType()
    {
       string identifier = game.tag;
        switch(identifier)
        {
            case "melee":
                stats.type = EnemyStats.enemyType.MELEE;
                stats.speed = 4.0f;
                stats.FOV = 110;
                stats.visionRange = 10.0f;
                stats.attackSpeed = 0.6f;
                stats.hp = 35.0f;
                 break;
            case "sranged":
                stats.type = EnemyStats.enemyType.SRANGED; //slow ranged
                stats.speed = 4.0f;
                stats.damage = 5.0f;
                stats.FOV = 110;
                stats.visionRange = 10.0f;
                stats.attackSpeed = 0.6f; //7 attacks per 10 seconds 
                stats.reloadTimer = 3.0f; //reload time after 10 number of bullets
                stats.clipSize = 10;
                stats.hp = 10.0f;
                break;
            case "mranged":
                stats.type = EnemyStats.enemyType.MRANGED; //medium speed ranged
                stats.speed = 5.5f;
                stats.damage = 7.0f;
                stats.FOV = 110;
                stats.visionRange = 12.5f;
                stats.attackSpeed = 0.4f;
                stats.reloadTimer = 5.0f;
                stats.clipSize = 15;
                stats.hp = 20.0f;
                break;
            case "franged"://fast ranged
                stats.type = EnemyStats.enemyType.FRANGED;
                stats.speed = 3.5f;
                stats.damage = 4.0f;
                stats.FOV = 110;
                stats.visionRange = 17.5f;
                stats.attackSpeed = 0.2f; //5 shots a second
                stats.reloadTimer = 8.0f;
                stats.clipSize = 40; //continuous fire for 8 seconds before reloading for 8 secomnds
                stats.hp = 20.0f;
                break;
            case "shield":
               stats.type = EnemyStats.enemyType.SHIELD;
               stats.speed = 1.0f;
               stats.hp = 1.0f;
                break;
            case "aoe":
                stats.type = EnemyStats.enemyType.AOE;
                stats.speed = 2.5f;
                stats.damage = 15.0f;
                stats.FOV = 110;
                stats.visionRange = 12.5f;
                stats.attackSpeed = 0.8f;
                stats.reloadTimer = 1.5f;
                stats.clipSize = 4;
                stats.hp = 35.0f;
                break;
            case "sniper":
                stats.type = EnemyStats.enemyType.SNIPER;
                stats.speed = 1.0f;
                stats.damage = 70.0f;
                stats.FOV = 110;
                stats.visionRange = 40.5f;
                stats.attackSpeed = 1.5f;
                stats.reloadTimer = 7.5f;
                stats.clipSize = 3;
                stats.hp = 3.0f;
                break;
            case "guardian":
                stats.type = EnemyStats.enemyType.GUARDIAN;
                stats.speed = 1.5f;
                stats.FOV = 110;
                stats.visionRange = 15.0f;
                stats.attackSpeed = 1.25f;
                stats.hp = 45.0f;
                break;
            case "boss":
                stats.type = EnemyStats.enemyType.BOSS;
                break;
            default:
               stats.type = EnemyStats.enemyType.SRANGED;
               stats.speed = 4.0f;
               stats.damage = 5.0f;
               stats.FOV = 110;
               stats.visionRange = 10.0f;
               stats.attackSpeed = 0.6f; //7 attacks per 10 seconds 
               stats.reloadTimer = 3.0f; //reload time after 10 number of bullets
               stats.clipSize = 10;
               stats.hp = 10.0f;
                break;

        }
    }


    public float getSpeed()
    {
        return stats.speed;
    }
    public void start()
    {
        setType();
    }
    public void update()
    {

    }


}

public class EnemyStats
{
    public enum enemyType { MELEE, SRANGED, MRANGED, FRANGED, SHIELD, AOE, SNIPER, GUARDIAN, BOSS };
    public float speed = 0;
    public float damage = 0;
    public float FOV = 0;
    public float visionRange = 0;
    public float attackSpeed = 1.0f;
    public float reloadTimer = 0.0f;
    public int clipSize = 0;
    public float hp = 10.0f;
    public enemyType type;
}

