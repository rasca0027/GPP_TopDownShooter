using UnityEngine;
using System.Collections;

public class Root : MonoBehaviour {

        void Awake() 
        {
            Service.Prefabs = Resources.Load<PrefabDB>("Prefabs/PrefabDB");
            Service.Scenes = new SceneManager<TransitionData>(this.gameObject, Service.Prefabs.Levels); 
            Service.Scenes.PushScene<MenuScene>(new TransitionData());
        }

    public void onClick() {
    Debug.Log("onclick");
    }

}
