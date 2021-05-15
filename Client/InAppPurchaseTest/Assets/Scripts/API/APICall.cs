using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// APIの呼び出し
/// </summary>
public static class APICall
{
    /// <summary>
    /// ベースとなるURL
    /// </summary>
    private static string BaseURL
    {
        get
        {
#if UNITY_EDITOR
            return "http://localhost/";
#else
            return "http://inapp-purchase-test.yanap-apptest.tk/";
#endif
        }
    }

    /// <summary>
    /// ログインリクエストパラメータ
    /// </summary>
    [Serializable]
    private struct LoginRequestParam
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string name;
    }

    /// <summary>
    /// ログイン結果
    /// </summary>
    [Serializable]
    public struct LoginResult
    {
        /// <summary>
        /// 成功？
        /// </summary>
        public bool result;

        /// <summary>
        /// 金
        /// </summary>
        public int gold;

        /// <summary>
        /// SPモードか？
        /// </summary>
        public bool sp_mode;
    }

    /// <summary>
    /// ログイン
    /// </summary>
    /// <param name="Name">名前</param>
    /// <param name="Callback">コールバック</param>
    public static IEnumerator Login(string Name, Action<LoginResult> Callback)
    {
        string URL = BaseURL + "login";
        LoginRequestParam Param = new LoginRequestParam();
        Param.name = Name;
        using (var Req = MakePostRequest<LoginRequestParam>(URL, Param))
        {
            yield return Req.SendWebRequest();
            if (Req.responseCode != 200)
            {
                LoginResult FailResult = new LoginResult();
                FailResult.result = false;
                Callback?.Invoke(FailResult);
                yield break;
            }

            LoginResult Result = JsonUtility.FromJson<LoginResult>(Req.downloadHandler.text);
            Callback?.Invoke(Result);
        }
    }

    /// <summary>
    /// POSTリクエストを作成
    /// </summary>
    /// <param name="URL">URL</param>
    /// <param name="Param">パラメータ</param>
    /// <typeparam name="T">パラメータの型</typeparam>
    /// <returns>リクエストオブジェクト</returns>
    private static UnityWebRequest MakePostRequest<T>(string URL, T Param)
    {
        var Req = UnityWebRequest.Post(URL, "POST");

        string ParamJson = JsonUtility.ToJson(Param);
        byte[] ParamData = System.Text.Encoding.UTF8.GetBytes(ParamJson);
        Req.uploadHandler = (UploadHandler)new UploadHandlerRaw(ParamData);
        Req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        Req.SetRequestHeader("Content-Type", "application/json");
        return Req;
    }
}
