using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 単純なダイアログ
/// </summary>
public class SimpleDialog : MonoBehaviour
{
    /// <summary>
    /// Prefabのパス
    /// </summary>
    private static readonly string PrefabPath = "Prefabs/UI/SimpleDialog";

    /// <summary>
    /// Prefab
    /// </summary>
    private static GameObject Prefab = null;

    /// <summary>
    /// 表示
    /// </summary>
    /// <param name="DisplayText">表示文字列</param>
    public static void Show(string DisplayText)
    {
        if (Prefab == null)
        {
            Prefab = Resources.Load<GameObject>(PrefabPath);
            Debug.Assert(Prefab != null);
        }

        var Obj = Instantiate<GameObject>(Prefab);
        var Dialog = Obj.GetComponent<SimpleDialog>();
        Dialog.DisplayText.text = DisplayText;

        UIManager.Instance.Add(Obj.transform, EUIStack.Front);
    }

    /// <summary>
    /// 表示するテキスト
    /// </summary>
    [SerializeField]
    private Text DisplayText = null;

    /// <summary>
    /// OKボタンが押された
    /// </summary>
    public void OnPressedOKButton()
    {
        Destroy(gameObject);
    }
}
