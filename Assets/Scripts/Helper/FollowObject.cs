using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{
    public Transform m_FollowObject;
    public Vector3 m_FollowAxis = new Vector3(1, 1, 1);

    // Update is called once per frame
    void Update()
    {
        if (m_FollowObject == null)
            return;

        Vector3 pos = m_FollowObject.position;

        if (m_FollowAxis.x < 1)
            pos.x = transform.position.x;
        if (m_FollowAxis.y < 1)
            pos.y = transform.position.y;
        if (m_FollowAxis.z < 1)
            pos.z = transform.position.z;

        transform.position = pos;
    }
}