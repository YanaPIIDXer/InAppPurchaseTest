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
    /// イベントリスナ
    /// </summary>
    private StoreListener Listener = new StoreListener();

    void Awake()
    {
        var PurchaseModule = StandardPurchasingModule.Instance();
        PurchaseModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
        var Builder = ConfigurationBuilder.Instance(PurchaseModule);
        Builder.AddProducts(Products.StoreProducts);
        UnityPurchasing.Initialize(Listener, Builder);
    }
}
