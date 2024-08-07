using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs.Discount;

namespace MultiShop.Discount.Services.Discount
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperDBContext context;

        public DiscountService(DapperDBContext context)
        {
            this.context = context;
        }
        public async Task<int> DiscountCountAsync()
        {
            string query = "select count(*) from Discounts";
           
            return await context.CreateConnection().QuerySingleAsync<int>(query);
        }

        public async Task CreateAsync(CreateDiscountDTO createDiscount)
        {
            string query = "insert into Discounts (Code,Rate,IsDelete,ValidDate) values (@code,@rate,@isDelete,@validDate)" ;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@code", createDiscount.Code);
            dynamicParameters.Add("@rate", createDiscount.Rate);
            dynamicParameters.Add("@isDelete", createDiscount.IsDelete);
            dynamicParameters.Add("@validDate", createDiscount.ValidDate);
             await context.CreateConnection().ExecuteAsync(query,dynamicParameters);

        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from Discounts where Id=@id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            using var con = context.CreateConnection();

            await con.ExecuteAsync(query, dynamicParameters);
        }

        public async Task<List<ResultDiscountDTO>> GetAllAsync()
        {
            string query = "select * from Discounts";
         using var con = context.CreateConnection();
            var list=await con.QueryAsync<ResultDiscountDTO>(query);
            return list.ToList();
        }

        public async Task<GetByIdDiscountDTO> GetByIdAsync(int id)
        {
            string query = "select * from Discounts where Id=@id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);
            using var con = context.CreateConnection();
            return await con.QueryFirstOrDefaultAsync<GetByIdDiscountDTO>(query,dynamicParameters);
           
        }

        public async Task<ResultDiscountDTO> GetByCodeAsync(string code)
        {
            string query = "select * from Discounts where Code=@code";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@code", code);
            using var con = context.CreateConnection();
            return await con.QueryFirstOrDefaultAsync<ResultDiscountDTO>(query, dynamicParameters);

        }

        public async Task Update(UpdateDiscountDTO updateDiscount)
        {
            string query = "update Discounts set Code=@code,Rate=@rate,isDelete =@isDelete,ValidDate=@validDate where Id=@id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", updateDiscount.Id);

            dynamicParameters.Add("@code", updateDiscount.Code);
            dynamicParameters.Add("@rate", updateDiscount.Rate);
            dynamicParameters.Add("@isDelete", updateDiscount.IsDelete);
            dynamicParameters.Add("@validDate", updateDiscount.ValidDate);
            using var con = context.CreateConnection();
           await con.ExecuteAsync(query, dynamicParameters);
        }
    }
}
