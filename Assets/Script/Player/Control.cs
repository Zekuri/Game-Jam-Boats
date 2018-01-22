using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Control : MovingObject {
    Image Bar;
    LifeBar lifeBar;
    int life;
    bool m_isdead;
    public float speed;
    Rigidbody rg;
    Transform trans;
    GameObject mainCam;
	// Use this for initialization
	protected override void Start () {
        m_isdead = false;
        rg = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        mainCam = transform.GetChild(3).gameObject;
        Bar = GameObject.Find("CurrentLife").transform.GetComponent<Image>();
        lifeBar = GameObject.Find("LifeBar").transform.GetComponent<LifeBar>();
        life = 10;
        if (!isLocalPlayer)
        {
            mainCam.SetActive(false);
            return;
        }
        for (int i = 0; i < GameManager.Instance.m_spawnPoints.Length; i++)
        {
            if (!GameManager.Instance.m_spawnPoints[i].GetComponent<Spawn>().GetSetIsTaken)
            {
                transform.position = GameManager.Instance.m_spawnPoints[i].transform.position;
                GameManager.Instance.m_spawnPoints[i].GetComponent<Spawn>().GetSetIsTaken = true;
                break;
            }
        }
    }
    public override void OnStartLocalPlayer()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update () {
        if (m_isdead)
            return;
        if (!isLocalPlayer)
        {
            mainCam.SetActive(false);
            return;
        }
        if (Input.GetKey("w") && !Input.GetKey("s"))
        {
            rg.velocity = transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey("s") && !Input.GetKey("w"))
        {
            rg.velocity = transform.right * -speed * Time.deltaTime;
        }
        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            trans.Rotate(0f, -speed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            trans.Rotate(0f, speed * Time.deltaTime, 0f);
        }
	}
    protected override void LoseLife(float pourcentage)
    {
        if (!isLocalPlayer)
            return;
        if (!lifeBar.UpdateLifeBar(pourcentage))
        {
            m_isdead = true;
            Drown();
        }
    }
}
