using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    public GameObject targetParent;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadGameData();
        Debug.Log("자식의 길이" + targetParent.transform.childCount);
        for (int i = 0; i < targetParent.transform.childCount-3; i++)
        {
            Debug.Log(targetParent.transform.GetChild(i).name);
        }
        //Default();
        DataManager.Instance.data.SceneState = 0;
        StageLocked();
    }
    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Default()
    {
        DataManager.Instance.data.stageLock[0] = true;
        DataManager.Instance.SaveGameData();
    }
    void StageLocked()
    {
        for (int i = 0; i < targetParent.transform.childCount-3; i++)
        {
            if (DataManager.Instance.data.stageLock[i] == false)
            {
                targetParent.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    public Button Unlock, Cancel;
    public void UnLock()
    {
        GameObject clickobject = EventSystem.current.currentSelectedGameObject;
        if (clickobject != null)
        {
            for (int i = 0; i < targetParent.transform.childCount - 3; i++)
            {
                if (targetParent.transform.GetChild(i) == clickobject.transform.parent)
                {
                    if (i == 3 || i == 5)
                        return;
                    Debug.Log($"{i} 버튼 클릭");
                    targetParent.transform.GetChild(targetParent.transform.childCount-1).gameObject.SetActive(true);
                    int index = i;
                    Unlock.onClick.AddListener(() => UnLockAccept(index));
                    Cancel.onClick.AddListener(UnLockCancel);
                }
            }
        }
    }
    public Button NotEnoughCoinCheck;
    void UnLockCancel()
    {
        targetParent.transform.GetChild(targetParent.transform.childCount-1).gameObject.SetActive(false);
    }
    void UnLockAccept(int i)
    {
        if (DataManager.Instance.data.coin >= 500)
        {
            DataManager.Instance.data.stageLock[i] = true;
            if (DataManager.Instance.data.stageLock[i] == true)
                targetParent.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
            targetParent.transform.GetChild(targetParent.transform.childCount - 1).gameObject.SetActive(false);
            DataManager.Instance.data.coin -= 500;
            DataManager.Instance.SaveGameData();
            TotalSound.instance.LobbyBuyGame();
        }
        else
        {
            targetParent.transform.GetChild(targetParent.transform.childCount - 1).GetChild(1).gameObject.SetActive(true);
            NotEnoughCoinCheck.onClick.AddListener(NotEoughCoinCancel);
        }
    }
    void NotEoughCoinCancel()
    {
        targetParent.transform.GetChild(targetParent.transform.childCount - 1).GetChild(1).gameObject.SetActive(false);
        targetParent.transform.GetChild(targetParent.transform.childCount - 1).gameObject.SetActive(false);
    }
    public void DataReset()
    {
        DataManager.Instance.LoadGameData();
        DataManager.Instance.data.coin = 500;
        DataManager.Instance.data.SceneState = 0;
        for (int i = 0; i < DataManager.Instance.data.highScore.Length; i++)
        {
            DataManager.Instance.data.highScore[i] = 0;
            DataManager.Instance.data.stageLock[i] = false;
        }
        DataManager.Instance.SaveGameData();
    }
    public void CoinCheat()
    {
        DataManager.Instance.LoadGameData();
        DataManager.Instance.data.coin += 1000;
        DataManager.Instance.data.SceneState = 0;
        DataManager.Instance.SaveGameData();
    }
}
