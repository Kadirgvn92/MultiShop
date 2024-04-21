using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs.CouponDTOs;

namespace MultiShop.Discount.Services;

public class CouponService : ICouponService
{
    private readonly DapperContext _dapperContext;

    public CouponService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task CreateCoupon(CreateCouponDTO couponDTO)
    {
        string query = $@"insert into Coupons (Code,Rate,IsActive,ValidDate) values 
                          (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", couponDTO.Code);
        parameters.Add("@rate",couponDTO.Rate);
        parameters.Add("@isActive", couponDTO.isActive);
        parameters.Add("@validDate", couponDTO.ValidDate);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        } 
    }

    public Task DeleteCoupon(int couponId)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCouponDTO> GetByIdCoupon(int couponId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultCouponDTO>> GetCoupons()
    {
        throw new NotImplementedException();
    }

    public Task UpdateCoupon(UpdateCouponDTO couponDTO)
    {
        throw new NotImplementedException();
    }
}
