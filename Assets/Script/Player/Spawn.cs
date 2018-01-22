using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    bool m_isTaken;

    public bool GetSetIsTaken { get { return m_isTaken; } set { m_isTaken = value; } }
	// Use this for initialization
	void Start () {
        m_isTaken = false;
	}
}
