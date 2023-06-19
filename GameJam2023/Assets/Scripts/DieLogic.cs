using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLogic : MonoBehaviour
{
    [SerializeField]
    private List<Transform> faceCheck;
    private Rigidbody rb;
    private bool landed;
    private float lifetime;
    [SerializeField]
    private float maxLifetime;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        landed = false;
    }

    void Update()
    {
        lifetime += Time.deltaTime;
        if (!landed)
        {
            if (rb.IsSleeping() || (rb.velocity.magnitude < 0.005f && lifetime > 1f))
            {
                Debug.Log(FindDieValue());
                landed = true;
                Destroy(rb);
            }
        }
        if (lifetime > maxLifetime && rb != null)
        {
            rb.drag += 0.1f;
            rb.angularDrag += 0.1f;
        }
    }

    int FindDieValue()
    {
        float highestPos = -Mathf.Infinity;
        int highestVal = 0;

        for (int i = 0; i < faceCheck.Count; i++)
        {
            if (faceCheck[i].position.y > highestPos)
            {
                highestVal = i;
                highestPos = faceCheck[i].position.y;
            }
        }

        return highestVal + 1;
    }
}
