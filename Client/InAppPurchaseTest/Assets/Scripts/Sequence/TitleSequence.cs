using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーケンス
/// </summary>
public class TitleSequence : MonoBehaviour
{
    /// <summary>
    /// ログイン
    /// </summary>
    public void Login()
    {
        // とりあえず面倒なので名前はダミーのものを突っ込む
        string DummyName = "Test";

        StartCoroutine(APICall.Login(DummyName, (Result) =>
        {
            if (!Result.result)
            {
                Debug.Log("Login Failed.");
                return;
            }

            UserData.Instance.Gold = Result.gold;
            UserData.Instance.SPMode = Result.sp_mode;

            SceneManager.LoadScene("Menu");
        }));
    }
}
