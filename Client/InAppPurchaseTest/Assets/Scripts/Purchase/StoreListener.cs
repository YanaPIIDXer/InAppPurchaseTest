using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// 課金系のイベントリスナ
/// </summary>
public class StoreListener : IStoreListener
{
    /// <summary>
    /// 商品購入インタフェース
    /// </summary>
    private IProductPurchase ProductPurchase = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="ProductPurchase">商品購入インタフェース</param>
    public StoreListener(IProductPurchase ProductPurchase)
    {
        this.ProductPurchase = ProductPurchase;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Store Initialize Success.");
        ProductPurchase.StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        SimpleDialog.Show("ストアの初期化に失敗しました。\nReasion:" + error.ToString());
        Debug.LogError("Store Initialize Failed.");
        Debug.LogError("Reason:" + error.ToString());
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase Failed. ID:" + product.definition.id);
        Debug.LogError("Reason:" + failureReason.ToString());
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        Debug.Log("Purchase ID:" + purchaseEvent.purchasedProduct.definition.id);
        ProductPurchase.OnPurchaseProduct(purchaseEvent);
        return purchaseEvent.purchasedProduct.definition.type != ProductType.Consumable ? PurchaseProcessingResult.Complete : PurchaseProcessingResult.Pending;
    }
}
