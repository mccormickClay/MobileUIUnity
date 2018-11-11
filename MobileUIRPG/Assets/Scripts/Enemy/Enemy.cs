using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHP;
    public float currentHP;
    public Image healthBar;

    // this is added by the extents to always have a 
    // clear distance above the enemies top
    private float distanceAboveEnemy = 0.5f;

	// Use this for initialization
	void Start () {
        maxHP = 100.0f;

        currentHP = maxHP;
        GameObject canvas = Instantiate(Resources.Load("CalledPrefabs/EnemyCanvas"), gameObject.transform) as GameObject;
        SetUpHealthCanvas(ref canvas);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int dmg)
    {
        currentHP -= (float)dmg;
        DebugMobileManager.Log("HP: " + currentHP.ToString());

        healthBar.fillAmount = (currentHP / maxHP);
        if (currentHP <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void SetUpHealthCanvas(ref GameObject canvas)
    {
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;
        Transform child = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0);
        healthBar = child.gameObject.GetComponent<Image>();
        /* Remember Extents is the distance between the edge of the object to its center
         * by means of its bounding (collider) box*/
        Vector3 extentsWorld = transform.TransformPoint(GetComponent<Collider>().bounds.extents);
        extentsWorld = new Vector3(transform.position.x, (extentsWorld.y + distanceAboveEnemy), transform.position.z);

        canvas.transform.SetPositionAndRotation(extentsWorld, Quaternion.identity);
    }
}
