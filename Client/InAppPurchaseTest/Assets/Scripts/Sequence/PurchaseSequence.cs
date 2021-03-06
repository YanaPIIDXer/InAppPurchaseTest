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
        YesNoDialog.Show("購入しますか？", (Result) =>
        {
            if (Result)
            {
                StoreController.InitiatePurchase(ProductIDs.AddMoneyItem);
            }
        });
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

        switch (PurchaseEvent.purchasedProduct.definition.id)
        {
            case ProductIDs.AddMoneyItem:

                StartCoroutine(APICall.VerifyAddGoldPurchase(Info, (Result) =>
                {
                    if (!Result.success)
                    {
                        Debug.LogError("Verify Error...");
                        SimpleDialog.Show("購入エラー");
                        return;
                    }
                    UserData.Instance.Gold = Result.gold;
                    StoreController.ConfirmPendingPurchase(StoreController.products.WithID(ProductIDs.AddMoneyItem));
                    SimpleDialog.Show("購入しました。");
                }));
                break;
        }
    }
}
