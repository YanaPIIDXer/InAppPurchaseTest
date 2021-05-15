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
        var Prod = StoreController.products.WithID(ProductIDs.AddMoneyItem);
        Debug.Log(Prod.metadata.localizedPriceString);
    }
}
