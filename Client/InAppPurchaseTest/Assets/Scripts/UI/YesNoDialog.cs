using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class YesNoDialog : MonoBehaviour
{
    /// <summary>
    /// Prefabのパス
    /// </summary>
    private static readonly string PrefabPath = "Prefabs/UI/YesNoDialog";

    /// <summary>
    /// Prefab
    /// </summary>
    private static GameObject Prefab = null;

    /// <summary>
    /// コールバック
    /// </summary>
    private Action<bool> Callback = null;

    /// <summary>
    /// 表示
    /// </summary>
    /// <param name="DisplayText">表示文字列</param>
    public static void Show(string DisplayText, Action<bool> Callback = null)
    {
        if (Prefab == null)
        {
            Prefab = Resources.Load<GameObject>(PrefabPath);
            Debug.Assert(Prefab != null);
        }

        var Obj = Instantiate<GameObject>(Prefab);
        var Dialog = Obj.GetComponent<YesNoDialog>();
        Dialog.DisplayText.text = DisplayText;
        Dialog.Callback = Callback;

        UIManager.Instance.Add(Obj.transform, EUIStack.Front);
    }

    /// <summary>
    /// 表示するテキスト
    /// </summary>
    [SerializeField]
    private Text DisplayText = null;

    /// <summary>
    /// Yesボタンが押された
    /// </summary>
    public void OnPressedYesButton()
    {
        Destroy(gameObject);
        Callback?.Invoke(true);
    }

    /// <summary>
    /// Yesボタンが押された
    /// </summary>
    public void OnPressedNoButton()
    {
        Destroy(gameObject);
        Callback?.Invoke(false);
    }
}
