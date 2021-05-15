using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

/// <summary>
/// ユーザ情報表示
/// </summary>
public class UserInfoDisplay : MonoBehaviour
{
    /// <summary>
    /// 金表示
    /// </summary>
    [SerializeField]
    private Text GoldText = null;

    /// <summary>
    /// SPモード表示
    /// </summary>
    [SerializeField]
    private Text SPModeText = null;

    void Awake()
    {
        UserData.Instance.OnUpdateGold
            .Subscribe((Value) => GoldText.text = string.Format("Gold: {0}", Value))
            .AddTo(gameObject);

        UserData.Instance.OnUpdateSPMode
            .Subscribe((Value) => SPModeText.text = string.Format("SPMode: {0}", Value))
            .AddTo(gameObject);
    }
}
