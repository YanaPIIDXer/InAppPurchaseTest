using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIの重ね順
/// </summary>
public enum EUIStack
{
    Front,
    Back,
}

/// <summary>
/// UI管理
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// 後ろのキャンバス
    /// </summary>
    [SerializeField]
    private Transform BackCanvasTransform = null;

    /// <summary>
    /// 前のキャンバス
    /// </summary>
    [SerializeField]
    private Transform FrontCanvasTransform = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    /// <summary>
    /// 追加
    /// </summary>
    /// <param name="UITransform">UIのTransform</param>
    /// <param name="Stack">重ね順</param>
    /// <returns>UIハンドラ</returns>
    public UIHandler Add(Transform UITransform, EUIStack Stack)
    {
        Transform Target = Stack == EUIStack.Front ? FrontCanvasTransform : BackCanvasTransform;
        return new UIHandler(UITransform, Target);
    }
}

/// <summary>
/// UIハンドラ
/// </summary>
public class UIHandler
{
    /// <summary>
    /// UIのTransform
    /// </summary>
    private Transform UITransform = null;

    /// <summary>
    /// 親Transform
    /// </summary>
    private Transform ParentTransform = null;

    /// <summary>
    /// 生存しているか？
    /// </summary>
    public bool IsAlive { get { return (UITransform != null); } }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="UITransform">UIのTransform</param>
    /// <param name="ParentTransform">親のTransform</param>
    public UIHandler(Transform UITransform, Transform ParentTransform)
    {
        this.UITransform = UITransform;
        this.ParentTransform = ParentTransform;
        this.UITransform.SetParent(ParentTransform);
    }

    /// <summary>
    /// 消去
    /// </summary>
    public void Delete()
    {
        if (!IsAlive) { return; }
        GameObject.Destroy(UITransform.gameObject);
    }
}
