namespace MultiShop.Basket.WebAPI.DTOs
{
    public class BasketDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }//say
        public decimal Price { get; set; }

    }
}
