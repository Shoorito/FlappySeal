using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float m_fSpeed         = 1.0f;
    public float m_fStartPosition = 0.0f;
    public float m_fEndPosition   = 0.0f;

    void Update()
    {
        if(transform.position.x <= m_fEndPosition)
        {
            ScrollEnd();
        }

        transform.Translate(-1.0f * m_fSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void ScrollEnd()
    {
        transform.Translate(-1.0f * (m_fEndPosition - m_fStartPosition), 0.0f, 0.0f);

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
