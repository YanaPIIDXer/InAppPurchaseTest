using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// 商品購入シーケンス
/// </summary>
public class PurchaseSequence : ProductPurchaseBehaviour
{
    /// <summary>
    /// 金増加アイテムを買う
    /// </summary>
    public void BuyGoldItem()
    {
        StoreController.InitiatePurchase(ProductIDs.AddMoneyItem);
    }

    /// <summary>
    /// 購入情報
    /// </summary>
    [Serializable]
    private struct PurchaseInfo
    {
        /// <summary>
        /// ストア
        /// </summary>
        public string Store;

        /// <summary>
        /// ペイロード
        /// </summary>
        public string Payload;
    }

    /// <summary>
    /// 商品を購入した
    /// </summary>
    /// <param name="PurchaseEvent">購入イベント情報</param>
    public override void OnPurchaseProduct(PurchaseEventArgs PurchaseEvent)
    {
        PurchaseInfo Info = JsonUtility.FromJson<PurchaseInfo>(PurchaseEvent.purchasedProduct.receipt);
        Debug.Log("Store:" + Info.Store);
        Debug.Log("Payload:" + Info.Payload);
    }
}
