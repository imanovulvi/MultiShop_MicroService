namespace MultiShop.DTOs.DTOs.Basket
{
    public class BasketTotalDTO
    {
        public string UserId { get; set; }
        public int DuscountCode { get; set; }
        public int Discount { get; set; }

        public List<BasketDTO> Baskets { get; set; }
        public decimal TotalPrice{get=> Baskets.Sum(x => x.Price * x.Quantity);}
    }
}
