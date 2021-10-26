namespace OzonEdu.MerchandiseService.HttpModels
{
    public class MerchRetrieveModel
    {
        public MerchRetrieveModel(MerchItem[] merchItems)
        {
            MerchItems = merchItems;
        }
        
        public MerchItem[] MerchItems { get; }
    }
}