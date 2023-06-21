using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public float diePower, dieTorque, timeMultiplier;
    private Rigidbody rb;
    [SerializeField]
    private GameObject Die;
    private float tempTimer;
    public int diceToThrow;
    public bool canThrow;

    void ThrowDice(float charge)
    {
        GameObject die = Instantiate(Die, transform.position, new Quaternion(Random.Range(0,359), Random.Range(0, 359), Random.Range(0, 359), 1));
        die.GetComponent<Rigidbody>().AddForce(this.transform.forward * (charge * diePower), ForceMode.Impulse);
        die.GetComponent<Rigidbody>().AddTorque(Random.Range(0,dieTorque), Random.Range(0, dieTorque), Random.Range(0, dieTorque), ForceMode.VelocityChange);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canThrow)
        {
            tempTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.Space) && canThrow)
        {
            tempTimer += Time.deltaTime * timeMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && canThrow)
        {
            canThrow = false;
            for (int i = 0; i < diceToThrow; i++)
            {
                ThrowDice(Mathf.Clamp01(tempTimer));
            }
        }
        
        tempTimer = Mathf.Clamp01(tempTimer);

    }
}
