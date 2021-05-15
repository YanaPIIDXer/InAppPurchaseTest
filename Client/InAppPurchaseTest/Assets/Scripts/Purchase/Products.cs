using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// 商品ＩＤの定数定義
/// </summary>
public static class ProductIDs
{
    /// <summary>
    /// 金を増やすアイテム
    /// </summary>
    public const string AddMoneyItem = "item1";

    /// <summary>
    /// SPモードフラグアイテム
    /// </summary>
    public const string SPModeItem = "item2";

    /// <summary>
    /// ログボ権解禁アイテム
    /// </summary>
    public const string LoginBonusItem = "item3";

    /// <summary>
    /// 消耗型アイテムによる金増加量UPアイテム
    /// </summary>
    public const string AddMoneyBoostItem = "item4";
}

/// <summary>
/// 商品情報
/// </summary>
public class Products
{
    /// <summary>
    /// 商品リスト
    /// </summary>
    private List<ProductDefinition> ProductList = new List<ProductDefinition>();

    /// <summary>
    /// 商品リスト
    /// </summary>
    public static ProductDefinition[] StoreProducts { get { return _Instance.ProductList.ToArray(); } }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        ProductList.Add(new ProductDefinition(ProductIDs.AddMoneyItem, ProductType.Consumable));
        ProductList.Add(new ProductDefinition(ProductIDs.SPModeItem, ProductType.NonConsumable));
        ProductList.Add(new ProductDefinition(ProductIDs.LoginBonusItem, ProductType.Subscription));
        ProductList.Add(new ProductDefinition(ProductIDs.AddMoneyBoostItem, ProductType.Subscription));
    }

    #region Singleton
    private static Products _Instance = new Products();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private Products()
    {
        Initialize();
    }
    #endregion
}
