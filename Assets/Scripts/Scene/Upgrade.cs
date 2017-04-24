using UnityEngine;
using System.Collections;

public class Upgrade {

    public string name;

    public Upgrade() {}

    public virtual void Effect() {}

}

public class HealthUpgrade : Upgrade {

    public HealthUpgrade() {
        name = "More health";   
    }

    public override void Effect() {
        GameObject.Find("Player").GetComponent<PlayerHealth>().health = 10; 
    }

}

public class SpeedUpgrade : Upgrade {

    public SpeedUpgrade() {
        name = "Increase speed";
    }

    public override void Effect() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 7f; 
    }
}

public class NewSpriteUpgrade : Upgrade {
    
    public Sprite newSprite = Resources.Load("newship", typeof(Sprite)) as Sprite;

    public NewSpriteUpgrade() {
        name = "Change Player Ship";
    }

    public override void Effect() {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = newSprite; 
    }

}
