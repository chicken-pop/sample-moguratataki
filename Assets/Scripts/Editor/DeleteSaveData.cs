using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Utility;

public class DeleteSaveData
{
    [MenuItem("Data/Delete")]
    static void DeleteSaveDataMethod()
    {
        PlayerPrefs.DeleteKey(SaveDataRepository.C_GAME_STORAGE_DATA_SAVE_KEY_NAME);
        PlayerPrefs.Save(); // 確実に変更を適用
        DebugUtility.Log("Save data deleted.");
    }
}
