using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    private Transform playerTransform;

    public float addStartPosValue;

    public float MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            transform.position = transform.position;
        }
        else
        {
            Vector3 temp = transform.position;

            temp.x = Mathf.Clamp(playerTransform.position.x + addStartPosValue, playerTransform.position.x, MaxValue);

            transform.position = temp;
        }
               
    }

}
