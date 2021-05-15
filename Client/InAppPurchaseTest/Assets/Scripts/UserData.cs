using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/// <summary>
/// ユーザデータ
/// </summary>
public class UserData
{
    /// <summary>
    /// 金のReactiveProperty
    /// </summary>
    private ReactiveProperty<int> GoldProp = new ReactiveProperty<int>();

    /// <summary>
    /// 金が更新された
    /// </summary>
    public IObservable<int> OnUpdateGold { get { return GoldProp; } }

    /// <summary>
    /// 金
    /// </summary>
    public int Gold
    {
        get { return GoldProp.Value; }
        set { GoldProp.Value = value; }
    }

    /// <summary>
    /// SPモードのReactiveProperty
    /// </summary>
    private ReactiveProperty<bool> SPModeProp = new ReactiveProperty<bool>();

    /// <summary>
    /// SPモードが更新された
    /// </summary>
    public IObservable<bool> OnUpdateSPMode { get { return SPModeProp; } }

    /// <summary>
    /// SPモードか？
    /// </summary>
    public bool SPMode
    {
        get { return SPModeProp.Value; }
        set { SPModeProp.Value = value; }
    }

    #region Singleton
    public static UserData Instance { get { return _Instance; } }
    private static UserData _Instance = new UserData();
    #endregion
}
