using UnityEngine;
using System.Collections;

public class UpgradeScene : Scene<TransitionData> {

    private Upgrade _upgrade;

    internal override void OnEnter(TransitionData data) {
        // set menu active
        //
    }

    internal override void OnExit() {
        // set menu deactive   
    }


    public void BackBtnOnClick() {
       
        Service.Scenes.Swap<MenuScene>(new TransitionData());
    }

    public void OKBtnOnClick() {
    
        Service.Scenes.Swap<MenuScene>(new TransitionData(_upgrade));
    }

    public void Upgrade1() {
        _upgrade = new HealthUpgrade();

    }
    public void Upgrade2() {
        _upgrade = new SpeedUpgrade();
    }
    public void Upgrade3() {
        _upgrade = new NewSpriteUpgrade();
    }
}
