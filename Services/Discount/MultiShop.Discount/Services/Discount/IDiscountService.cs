﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs.Discount;

namespace MultiShop.Discount.Services.Discount
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDTO>> GetAllAsync();
        Task <GetByIdDiscountDTO> GetByIdAsync(int id);
        Task<ResultDiscountDTO> GetByCodeAsync(string code);
        Task Update(UpdateDiscountDTO updateDiscount);
        Task DeleteAsync(int id);
        Task CreateAsync(CreateDiscountDTO createDiscount);
        Task<int> DiscountCountAsync();
    }
}
