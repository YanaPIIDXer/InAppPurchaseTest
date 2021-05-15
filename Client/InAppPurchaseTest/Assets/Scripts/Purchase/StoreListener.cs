using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

/// <summary>
/// 課金系のイベントリスナ
/// </summary>
public class StoreListener : IStoreListener
{
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Store Initialize Success.");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
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
        return PurchaseProcessingResult.Complete;
    }
}
