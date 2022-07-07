using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyType { MELEE, SRANGED, MRANGED, FRANGED, SHIELD, AOE, SNIPER, GUARDIAN, BOSS }

public class Enemies :MonoBehaviour
{
    static public GameObject game;
    public Rigidbody body;
    public enemyType type;
  static protected float speed = 0;
    protected float damage = 0;
    protected float FOV = 0;
    protected float visionRange = 0;
    protected float attackSpeed = 1.0f;
    protected float reloadTimer = 0.0f;
    protected int clipSize=0;
    protected float hp = 10.0f;

    
   void setType()
    {
       string identifier = game.tag;
        switch(identifier)
        {
            case "melee":
                type = enemyType.MELEE;
                speed = 4.0f;
                FOV = 110;
                visionRange = 10.0f;
                attackSpeed = 0.6f;
                hp = 35.0f;
                 break;
            case "sranged":
                 type = enemyType.SRANGED; //slow ranged
                speed = 4.0f;
                damage = 5.0f;
                FOV = 110;
                visionRange = 10.0f;
                attackSpeed = 0.6f; //7 attacks per 10 seconds 
                reloadTimer = 3.0f; //reload time after 10 number of bullets
                clipSize = 10;
                hp = 10.0f;
                break;
            case "mranged":
                type = enemyType.MRANGED; //medium speed ranged
                speed = 5.5f;
                damage = 7.0f;
                FOV = 110;
                visionRange = 12.5f;
                attackSpeed = 0.4f;
                reloadTimer = 5.0f;
                clipSize = 15;
                hp = 20.0f;
                break;
            case "franged"://fast ranged
                type = enemyType.FRANGED;
                speed = 3.5f;
                damage = 4.0f;
                FOV = 110;
                visionRange = 17.5f;
                attackSpeed = 0.2f; //5 shots a second
                reloadTimer = 8.0f;
                clipSize = 40; //continuous fire for 8 seconds before reloading for 8 secomnds
                hp = 20.0f;
                break;
            case "shield":
                type = enemyType.SHIELD;
                speed = 1.0f;
                hp = 1.0f;
                break;
            case "aoe":
                type = enemyType.AOE;
                speed = 2.5f;
                damage = 15.0f;
                FOV = 110;
                visionRange = 12.5f;
                attackSpeed = 0.8f;
                reloadTimer = 1.5f;
                clipSize = 4;
                hp = 35.0f;
                break;
            case "sniper":
                type = enemyType.SNIPER;
                speed = 1.0f;
                damage = 70.0f;
                FOV = 110;
                visionRange = 40.5f;
                attackSpeed = 1.5f;
                reloadTimer = 7.5f;
                clipSize = 3;
                hp = 3.0f;
                break;
            case "guardian":
                type = enemyType.GUARDIAN;
                speed = 1.5f;
                FOV = 110;
                visionRange = 15.0f;
                attackSpeed = 1.25f;
                hp = 45.0f;
                break;
            case "boss":
                type = enemyType.BOSS;
                break;
            default:
                type = enemyType.SRANGED;
                speed = 4.0f;
                damage = 5.0f;
                FOV = 110;
                visionRange = 10.0f;
                attackSpeed = 0.6f; //7 attacks per 10 seconds 
                reloadTimer = 3.0f; //reload time after 10 number of bullets
                clipSize = 10;
                hp = 10.0f;
                break;

        }
    }
    public enemyType returnType()
    {
        
        return type;
    }

    public float getSpeed()
    {
        return speed;
    }
    public void start()
    {
        setType();
    }
    public void update()
    {

    }
    class BossEnemy:Enemies
    {

    }


}

