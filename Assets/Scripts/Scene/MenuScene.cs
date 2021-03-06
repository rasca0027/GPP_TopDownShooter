﻿using UnityEngine;
using System.Collections;

public class MenuScene : Scene<TransitionData> {

    private Upgrade _upgrade; 
    
    internal override void OnEnter(TransitionData data) {
        _upgrade = data.upgrade;
    }

    internal override void OnExit() {
        // set menu deactive   
    }

    public void StartBtnOnClick() {
        Service.Scenes.PushScene<GameScene>(new TransitionData(_upgrade));
    }

    public void UpgradeBtnOnClick() {
        Service.Scenes.PushScene<UpgradeScene>(new TransitionData());
    }

}
