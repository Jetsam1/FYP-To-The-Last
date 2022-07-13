using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{

    private enum HazardType { OOB,SPIKES,FLOOR,ROTATE,FIRE,SLIME,SLOW}
    public Rigidbody RB;
    private GameObject obj;
    [SerializeField]
    HazardType type;
    [SerializeField]
    float length;
    [SerializeField]
    float width;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float height;


    // Start is called before the first frame update
    void Start()
    {
        if(type==HazardType.OOB)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (type== HazardType.OOB)
        {
            if (collision.gameObject.tag == "Player")
            {
                
            }
        }
    }
}
