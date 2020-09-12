using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : SingletonMonoBehaviour<NPCManager> {
    private Dictionary<int, NPCDetails> npcDetailsDictionary;
    private Dictionary<int, SocialLinkDetails> socialLinks;
    private Dictionary<int, NPCSaveData> npcDataDictionary;

    [SerializeField]
    private SO_NPCList npcList = null;
    [SerializeField]
    private SO_SocialLinkList socialLinkList = null;
    public NPC NPCPrefab;

    private Transform instancesParent;
    private Transform spawnsParent;

    protected override void Awake() {
        base.Awake();
        CreateDictionaries();
    }

    protected void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            DebugPrintSocialLinks();
        }
    }

    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += OnNPCSceneLoad;
    }

    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= OnNPCSceneLoad;
    }

    public NPCDetails GetNPCDetails(int npcCode) {
        NPCDetails res;
        return npcDetailsDictionary.TryGetValue(npcCode, out res) ? res : null;
    }
    
    private void CreateDictionaries() {
        npcDetailsDictionary = new Dictionary<int, NPCDetails>();
        npcDataDictionary = new Dictionary<int, NPCSaveData>();
        socialLinks = new Dictionary<int, SocialLinkDetails>();

        foreach (NPCDetails detail in npcList.npcDetails) {
            npcDetailsDictionary.Add(detail.npcCode, detail);

            NPCSaveData saveData = new NPCSaveData();
            saveData.npcCode = detail.npcCode;
            saveData.currentSchedule = detail.startingSchedule;
            npcDataDictionary.Add(detail.npcCode, saveData);
        }
        foreach(SocialLinkDetails sl in socialLinkList.socialLinks) {
            if (!socialLinks.ContainsKey(sl.npcCode)) {
                socialLinks.Add(sl.npcCode, sl);
            }
        }
    }

    private void OnNPCSceneLoad() {
        instancesParent = GameObject.FindGameObjectWithTag(Tags.InstancesParent).transform;
        spawnsParent = GameObject.FindGameObjectWithTag(Tags.SpawnPointParent).transform;

        WeekDay day = TimeManager.Instance.currentWeekDay;
        TimeSlot slot = TimeManager.Instance.currentTimeslot;
        SceneName sceneName;
        if (!Enum.TryParse<SceneName>(SceneController.Instance.CurrentScene, out sceneName)) {
            return;
        }

        foreach (NPCSaveData data in npcDataDictionary.Values) {
            ScheduleUnit unit = data.currentSchedule.GetScheduleUnit(day, slot);
            if (unit.sceneName == sceneName) {
                Vector3 pos = spawnsParent.Find(unit.spawnName).position;
                Instantiate<NPC>(NPCPrefab, pos, Quaternion.identity, instancesParent);
            }
        }
    }

    // Debug Methods
    public void DebugPrintSocialLinks() {
        Debug.Log("******************************** Social Links ************************");
        foreach(SocialLinkDetails sl in socialLinks.Values) {
            sl.DebugPrint();
        }
        Debug.Log("**********************************************************************");
    }
}