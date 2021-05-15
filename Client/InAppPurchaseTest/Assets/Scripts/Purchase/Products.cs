using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

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
        ProductList.Add(new ProductDefinition("item1", ProductType.Consumable));
        ProductList.Add(new ProductDefinition("item2", ProductType.NonConsumable));
        ProductList.Add(new ProductDefinition("item3", ProductType.Subscription));
        ProductList.Add(new ProductDefinition("item4", ProductType.Subscription));
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
