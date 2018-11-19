using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Enemy : battleState
{

    private float maxHP;
    private float currentHP;
    private float strength;
    private Image healthBar;
    public GameObject player;

    messageSelectEnemy selector;

    // this is added by the extents to always have a 
    // clear distance above the enemies top
    private float distanceAboveEnemy = 0.5f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selector = player.GetComponent<messageSelectEnemy>();

        GameObject canvas = Instantiate(Resources.Load("CalledPrefabs/EnemyCanvas"), gameObject.transform) as GameObject;
        SetUpHealthCanvas(ref canvas);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int dmg)
    {
        currentHP -= (float)dmg;
        DebugMobileManager.Log("HP: " + currentHP.ToString());

        healthBar.fillAmount = (currentHP / maxHP);
        if (currentHP <= 0.0f)
        {
            selector.SetSelected(null);
            SendToFactory();
        }
        else
        {
            NextState();
        }
    }

    public abstract void SendToFactory();

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

    protected void SetHealth(float _health)
    {
        maxHP = _health;
        currentHP = _health;
    }

    protected void SetStrength(float _strength)
    {
        strength = _strength;
    }

    protected virtual void UpdateState()
    {

    }

    protected void Attack(float _dmg)
    {
        player.GetComponent<playerState>().Damage(_dmg);
    }

    public override IEnumerator Action()
    {
        while (inFirst)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Attack(strength);
        BattleController.FinishTurn();
    }

    protected IEnumerator WaitToChangeStates()
    {
        yield return new WaitForSecondsRealtime(2);
        player.GetComponent<playerState>().NextState();
        NextState();
    }

}
