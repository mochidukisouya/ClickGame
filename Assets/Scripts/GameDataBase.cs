using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//資料庫引擎
public class GameDataBase  {

    public static void Save(string key,object data) {

        string jsonStr = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, jsonStr);

    }

    //T  泛型 由對方決定型態
    public static T Load<T>(string key) {

        string JsonStr = PlayerPrefs.GetString(key, string.Empty);
        if (string.IsNullOrEmpty(JsonStr)) {
            return Activator.CreateInstance<T>();//如果沒有資料創建新物件
        }
        return JsonUtility.FromJson<T>(JsonStr);
    }
    public static void Clear() {
        PlayerPrefs.DeleteAll();

    }


}
