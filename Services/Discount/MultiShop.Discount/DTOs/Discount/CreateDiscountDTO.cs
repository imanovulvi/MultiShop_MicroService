namespace MultiShop.Discount.DTOs.Discount
{
    public class CreateDiscountDTO
    {

        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
