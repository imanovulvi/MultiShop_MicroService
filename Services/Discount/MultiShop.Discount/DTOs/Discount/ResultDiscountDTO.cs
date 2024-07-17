namespace MultiShop.Discount.DTOs.Discount
{
    public class ResultDiscountDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
