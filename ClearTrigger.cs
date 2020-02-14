using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    GameObject m_objGameController = null;

    void Start()
    {
        m_objGameController = GameObject.FindWithTag("GameController");
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        m_objGameController.SendMessage("IncreaseScore");
    }
}
