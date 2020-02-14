using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float m_fMinHeight    = 0.0f;
    public float m_fMaxHeight    = 0.0f;
    public GameObject m_objPivot = null;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }

    void ChangeHeight()
    {
        float fHeight    = 0.0f;
        Vector3 vecPivot = Vector3.zero; 

        fHeight    = Random.Range(m_fMinHeight, m_fMaxHeight);
        vecPivot.y = fHeight;

        m_objPivot.transform.localPosition = vecPivot;
    }

    void OnScrollEnd()
    {
        ChangeHeight();
    }
}
