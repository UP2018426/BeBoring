using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public float diePower, timeMultiplier;
    private Rigidbody rb;
    [SerializeField]
    private GameObject Die;
    public float tempTimer;

    void Reset()
    {

    }

    void ThrowDice(float charge)
    {
        GameObject die = Instantiate(Die, transform.position, new Quaternion(Random.Range(0,359), Random.Range(0, 359), Random.Range(0, 359), 1));
        die.GetComponent<Rigidbody>().AddForce(this.transform.forward * (charge * diePower), ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            tempTimer += Time.deltaTime * timeMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ThrowDice(Mathf.Clamp01(tempTimer));
        }
        
        tempTimer = Mathf.Clamp01(tempTimer);

    }
}
