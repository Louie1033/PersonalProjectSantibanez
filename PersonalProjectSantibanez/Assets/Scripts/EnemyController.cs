using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyrb;
    public float speed = 2;
    private float flipTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyMovement()
    {
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            speed = -speed;
        }
        if(Mathf.Sign(speed) == -1)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            speed = -speed;
        }
    }
}
