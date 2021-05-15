using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static UIManager Instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
}
