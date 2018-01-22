using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager m_instance = null;
    public GameObject m_player;
    public GameObject[] m_spawnPoints;

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new GameManager();
            return m_instance;
        }
    }
    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
    }
}
