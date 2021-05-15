using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;

/// <summary>
/// 商品購入インタフェース
/// </summary>
public interface IProductPurchase
{
    /// <summary>
    /// ストアコントローラ
    /// </summary>
    IStoreController StoreController { set; }

    /// <summary>
    /// 商品を購入した
    /// </summary>
    /// <param name="PurchaseEvent">購入イベント情報</param>
    void OnPurchaseProduct(PurchaseEventArgs PurchaseEvent);
}

/// <summary>
/// IProductPurchaseのMonoBehaviour版
/// interfaceはSerializeFieldでインスペクタから渡せないようなので
/// </summary>
public abstract class ProductPurchaseBehaviour : MonoBehaviour, IProductPurchase
{
    /// <summary>
    /// ストアコントローラ
    /// </summary>
    public IStoreController StoreController { set; protected get; }

    /// <summary>
    /// 商品を購入した
    /// </summary>
    /// <param name="PurchaseEvent">購入イベント情報</param>
    virtual public void OnPurchaseProduct(PurchaseEventArgs PurchaseEvent) { throw new NotImplementedException(); }
}
