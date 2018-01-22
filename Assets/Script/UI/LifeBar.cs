using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {
    RectTransform lifeLeftBar;
    float originalWidth;
	// Use this for initialization
	void Start () {
        lifeLeftBar = transform.GetChild(0).transform.GetComponent<RectTransform>();
        originalWidth = lifeLeftBar.rect.width;
	}

    public bool UpdateLifeBar(float t_pourcentage)
    {
        float life;
        life = originalWidth * t_pourcentage;
        if(lifeLeftBar.rect.width - life < 1)
        {
            lifeLeftBar.sizeDelta = new Vector2(0, lifeLeftBar.rect.height);
            return false;
        }
        lifeLeftBar.sizeDelta = new Vector2(lifeLeftBar.rect.width - life, lifeLeftBar.rect.height);
        lifeLeftBar.localPosition = new Vector2((originalWidth - lifeLeftBar.rect.width) / 2, 0);
        return true;
    }
}
