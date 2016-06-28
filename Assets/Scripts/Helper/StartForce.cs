using UnityEngine;
using System.Collections;

public class StartForce : MonoBehaviour
{
    public Vector3 m_Force;
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody2D>())
            GetComponent<Rigidbody2D>().AddForce(m_Force, ForceMode2D.Impulse);
        else if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().AddForce(m_Force, ForceMode.Impulse);
    }
}