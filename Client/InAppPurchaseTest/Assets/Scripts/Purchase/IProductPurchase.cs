using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// 商品購入インタフェース
/// </summary>
public interface IProductPurchase
{
    /// <summary>
    /// ストアコントローラ
    /// </summary>
    IStoreController StoreController { set; }
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
}
