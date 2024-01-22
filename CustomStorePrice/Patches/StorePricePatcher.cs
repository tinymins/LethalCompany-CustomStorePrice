using HarmonyLib;
using System.Linq;

namespace CustomStorePrice.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class PricePatches
    {
        [HarmonyPatch("SetItemSales")]
        [HarmonyPostfix]
        private static void StorePrices(ref Item[] ___buyableItemsList)
        {
            var customStorePrices = CustomStorePrice.StoreItemPrices.Value.Split(',')
                .Select(i => i.Trim().Split(':'))
                .ToList();
            for (int i = 0; i < ___buyableItemsList.Length; i++)
            {
                var buyItem = ___buyableItemsList[i];

                for (int j = 0; j < customStorePrices.Count; j++)
                {
                    var customStorePrice = customStorePrices[j];
                    if (customStorePrice[0] == buyItem.itemName && customStorePrice.Length > 1)
                    {
                        try
                        {
                            var price = int.Parse(customStorePrice[1]);
                            buyItem.creditsWorth = price;
                        }
                        catch { }
                        break;
                    }
                }
                CustomStorePrice.Log.LogInfo($"{buyItem.itemName} is now ${buyItem.creditsWorth}.");
            }
        }
    }
}
