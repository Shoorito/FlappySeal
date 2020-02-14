using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum E_STATE
    {
        E_READY,
        E_PLAY,
        E_GAMEOVER,
        E_MAX
    };

    private int     m_nScore = 0;
    private E_STATE m_eState = E_STATE.E_READY;

    public Text m_textScoreLabel  = null;
    public Text m_textStateLabel  = null;
    public SealController m_seal  = null;
    public GameObject m_objBlocks = null;

    void Start()
    {
        Ready();
    }

    void Ready()
    {
        m_eState = E_STATE.E_READY;

        m_seal.SetSteerActive(false);
        m_objBlocks.SetActive(false);

        m_textScoreLabel.text = "Score : " + 0;

        m_textStateLabel.gameObject.SetActive(true);
        m_textStateLabel.text = "Ready";
    }

    void GameStart()
    {
        m_eState = E_STATE.E_PLAY;

        m_seal.SetSteerActive(true);
        m_objBlocks.SetActive(true);

        m_seal.Flap();

        m_textStateLabel.gameObject.SetActive(false);
        m_textStateLabel.text = "";
    }

    void GameOver()
    {
        ScrollObject[] arrayScrollObject = { }; 

        m_eState = E_STATE.E_GAMEOVER;

        arrayScrollObject = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject so in arrayScrollObject) so.enabled = false;

        m_textStateLabel.gameObject.SetActive(true);
        m_textStateLabel.text = "GameOver";
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LateUpdate()
    {
        switch (m_eState)
        {
            case E_STATE.E_READY:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case E_STATE.E_PLAY:
                if (m_seal.IsDead()) GameOver();
                break;
            case E_STATE.E_GAMEOVER:
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
    }

    public void IncreaseScore()
    {
        m_nScore++;
        m_textScoreLabel.text = "Score : " + m_nScore;
    }
}
