using UnityEngine;
using BehaviorTree;
using System.Collections;

public class Companion : MonoBehaviour {

    public GameObject bullet;
    private Tree<Companion> _tree;

    // Use this for initialization
    void Start () {

        _tree = new Tree<Companion>(
            new Selector<Companion>(
                // (highest priority)
                // help attack behavior
                new Sequence<Companion>(
                    new IsEnemyExist(),
                    new IsPlayerHealthy(),
                    new Attack()
                ),
                // middle priority
                // healing behavior
                new Sequence<Companion>(
                    new IsPlayerLowHealth(),
                    new Heal()
                ),
                // lowest priority
                new Idle()
            )
        );
    
    }
    
    // Update is called once per frame
    void Update () {
        _tree.Update(this);	
    }

    private void Shoot() {
        InvokeRepeating("ShootBullet", 0f, 1.5f);
    }

    void ShootBullet() {
        GameObject obj = Instantiate(bullet);
        obj.transform.position = transform.position + transform.right * 0.5f;
        obj.GetComponent<Rigidbody2D>().AddForce(transform.right * 400f);
        Destroy(obj, 3);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NODES
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////
    // Conditions
    ////////////////////

    private class IsEnemyExist : Node<Companion> {
        public override bool Update(Companion c) {
            return GameObject.Find("GameManager").GetComponent<EnemyManager>().enemyAlive() > 0;	    
        } 
    }
    
    private class IsPlayerHealthy : Node<Companion> {
        public override bool Update(Companion c) { 
            return GameObject.Find("Player").GetComponent<PlayerHealth>().health >= 5;
        } 
    }
    
    private class IsPlayerLowHealth : Node<Companion> {
        public override bool Update(Companion c) {   
            return GameObject.Find("Player").GetComponent<PlayerHealth>().health <= 3;
        } 
    }

    
    ///////////////////
    /// Actions
    ///////////////////

    private class Attack : Node<Companion> {
        bool start = false;
        public override bool Update(Companion c) {
            if (!start) {
                c.Shoot();
                start = true;
            }
            return true;
        } 
    }

    private class Heal : Node<Companion> {
        public override bool Update(Companion c) {
            GameObject.Find("Player").GetComponent<PlayerHealth>().health += 1;
            return true;	    	
        } 
    }

    private class Idle : Node<Companion> {
        public override bool Update(Companion c) {
            return true;    
        } 
    }
    

}
