using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private UnityEngine.UI.Text textComponent;
    private System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

    private nn.account.Uid userId;
    private const string mountName = "MySave";
    private const string fileName = "MySaveData";
    private static readonly string filePath = string.Format("{0}:/{1}", mountName, fileName);
#pragma warning disable 0414
    private nn.fs.FileHandle fileHandle = new nn.fs.FileHandle();
#pragma warning restore 0414

    private const string versionKey = "Version";
    private const string counterKey = "Counter";

    private nn.hid.NpadState npadState;
    private nn.hid.NpadId[] npadIds = { nn.hid.NpadId.Handheld, nn.hid.NpadId.No1 };
    private const int saveDataVersion = 1;
    private int counter = 0;
    private int saveData = 0;
    private int loadData = 0;
    public bool passed1;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Save"); if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        //textComponent = GameObject.Find("/Canvas/Text").GetComponent<UnityEngine.UI.Text>();

        nn.account.Account.Initialize();
        nn.account.UserHandle userHandle = new nn.account.UserHandle();

        if (!nn.account.Account.TryOpenPreselectedUser(ref userHandle))
        {
            nn.Nn.Abort("Failed to open preselected user.");
        }
        nn.Result result = nn.account.Account.GetUserId(ref userId, userHandle);
        result.abortUnlessSuccess();
        result = nn.fs.SaveData.Mount(mountName, userId);
        result.abortUnlessSuccess();

        InitializeSaveData();
        Load();

        nn.hid.Npad.Initialize();
        nn.hid.Npad.SetSupportedStyleSet(nn.hid.NpadStyle.Handheld | nn.hid.NpadStyle.JoyDual);
        nn.hid.Npad.SetSupportedIdType(npadIds);
        npadState = new nn.hid.NpadState();
    }

    private void Update()
    {
        stringBuilder.Length = 0;
    /*    if (counter - loadData >= 300)
        {
            Load();
            loadData = counter;
        }
        else if (counter - saveData >= 100)
        {
            PlayerPrefs.SetInt(counterKey, counter);
            SavePlayerPrefs();
            saveData = counter;
        }
        for (int i = 0; i < npadIds.Length; i++)
        {
            nn.hid.Npad.GetState(ref npadState, npadIds[i], nn.hid.Npad.GetStyleSet(npadIds[i]));
            if ((npadState.buttons & nn.hid.NpadButton.Y) != 0)
            {
                ResetSaveData();
            }
            else if ((npadState.buttons & nn.hid.NpadButton.B) != 0)
            {
                Load();
                loadData = counter;
            }
            else if ((npadState.buttons & nn.hid.NpadButton.A) != 0)
            {
                PlayerPrefs.SetInt(counterKey, counter);
                SavePlayerPrefs();
                saveData = counter;
            }
        }*/

        stringBuilder.AppendFormat("A:Save, B:Load, Y:Reset\nCounter: {0}\nSave data: {1}\nLoad data {2}",
            counter, saveData, loadData);
        counter++;

       //textComponent.text = stringBuilder.ToString();
    }

    private void OnDestroy()
    {
        nn.fs.FileSystem.Unmount(mountName);
    }

    private void InitializeSaveData()
    {
#if !UNITY_SWITCH || UNITY_EDITOR
        if (PlayerPrefs.HasKey(versionKey))
        {
            return;
        }
        PlayerPrefs.SetInt(versionKey, saveDataVersion);
        PlayerPrefs.SetInt(counterKey, 0);
        PlayerPrefs.Save();
#else
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (result.IsSuccess())
        {
            return;
        }
        if (!nn.fs.FileSystem.ResultPathNotFound.Includes(result))
        {
            result.abortUnlessSuccess();
        }

        PlayerPrefs.SetInt(versionKey, saveDataVersion);
        PlayerPrefs.SetInt(counterKey, 0);
       
        byte[] data = ES3.LoadRawBytes();
        long saveDataSize = data.LongLength;

        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection();

        result = nn.fs.File.Create(filePath, saveDataSize);
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write);
        result.abortUnlessSuccess();

        const int offset = 0;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);
        result = nn.fs.FileSystem.Commit(mountName);
        result.abortUnlessSuccess();

        UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection();
#endif
    }

    public void SavePlayerPrefs()
    {
#if !UNITY_SWITCH || UNITY_EDITOR
        PlayerPrefs.Save();



#else
         byte[] data = ES3.LoadRawBytes();
         ES3.AppendRaw(data);
        long saveDataSize = data.LongLength;
        

        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection();

        nn.Result result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write);
        result.abortUnlessSuccess();

        const int offset = 0;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);
        result = nn.fs.FileSystem.Commit(mountName);
        result.abortUnlessSuccess();

        UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection();
#endif
    }

    private void Load()
    {
#if !(!UNITY_SWITCH || UNITY_EDITOR)
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (nn.fs.FileSystem.ResultPathNotFound.Includes(result)) { return; }
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Read);
        result.abortUnlessSuccess();

        long fileSize = 0;
        result = nn.fs.File.GetSize(ref fileSize, fileHandle);
        result.abortUnlessSuccess();

        byte[] data = new byte[fileSize];
        result = nn.fs.File.Read(fileHandle, 0, data, fileSize);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);

       ES3.SaveRaw(data);
#endif
        int version = PlayerPrefs.GetInt(versionKey);
        Debug.Assert(version == saveDataVersion); // Save data version up
        counter = PlayerPrefs.GetInt(counterKey);
        if(ES3.KeyExists("Passed Scene01"))
        {
            passed1 = ES3.Load<bool>("Passed Scene01");
        }
        else
        {
            passed1 = false;
        }
       
    }

    private void ResetSaveData()
    {
        counter = 0;
        SavePlayerPrefs();
        saveData = counter;
    }
}

