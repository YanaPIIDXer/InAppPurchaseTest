using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// ストアクラス
/// </summary>
public class Store : MonoBehaviour
{
    /// <summary>
    /// 商品購入インタフェース
    /// </summary>
    [SerializeField]
    private ProductPurchaseBehaviour ProductPurchase = null;

    void Awake()
    {
        var PurchaseModule = StandardPurchasingModule.Instance();
        PurchaseModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
        var Builder = ConfigurationBuilder.Instance(PurchaseModule);
        Builder.AddProducts(Products.StoreProducts);
        UnityPurchasing.Initialize(new StoreListener(ProductPurchase), Builder);
    }
}
