using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveLoadManager : SingletonMonoBehaviour<SaveLoadManager> {
    public List<ISaveable> iSaveableObjectList;

    protected override void Awake() {
        base.Awake();
        iSaveableObjectList = new List<ISaveable>();
    }

    public void StoreCurrentSceneData() {
        foreach (ISaveable obj in iSaveableObjectList) {
            obj.ISaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSaveData() {
        foreach (ISaveable obj in iSaveableObjectList) {
            obj.ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnEnable() {
        EventHandler.BeforeSceneUnloadEvent += StoreCurrentSceneData;
        EventHandler.AfterSceneLoadEvent += RestoreCurrentSaveData;
    }

    private void OnDisable() {
        EventHandler.BeforeSceneUnloadEvent -= StoreCurrentSceneData;
        EventHandler.AfterSceneLoadEvent -= RestoreCurrentSaveData;
    }
}
