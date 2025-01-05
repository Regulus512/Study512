using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabPurchase : MonoBehaviour
{
    public void PurchaseItem()
    {
        var request = new PurchaseItemRequest()
        {
            CatalogVersion = "Main",
            ItemId = "test",
            Price = 100,
            VirtualCurrency = "KW"
        };
        PlayFabClientAPI.PurchaseItem(request, (result) => print($"{request.CharacterId} 구입 성공"), (error) => print(error.GenerateErrorReport()));
    }

    void GetInventory()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), LogSuccess, LogFailure);
    }

    private void LogSuccess(GetUserInventoryResult result)
    {
        Debug.Log("[V2]" + result);
    }

    private void LogSuccess(PurchaseItemResult result)
    {
        Debug.Log("[V2]" + result);
    }

    private void LogFailure(PlayFabError error)
    {
        Debug.LogWarning("[V2]Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}
