﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs.CouponDTOs;
using MultiShop.Discount.Entities;

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
        string query = $@"insert into Coupons (Code,Rate,isActive,ValidDate) values 
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
    public async Task DeleteCoupon(int couponId)
    {
        string query = "Delete from Coupons where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId", couponId);
        using (var connection= _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdCouponDTO> GetByIdCoupon(int couponId)
    {
        string query = "select * from Coupons WHERE CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);
        using (var connections = _dapperContext.CreateConnection())
        {
            var values = await connections.QueryFirstOrDefaultAsync<GetByIdCouponDTO>(query, parameters);
            return values;
        }
    }

    public async Task<List<ResultCouponDTO>> GetCoupons()
    {
        string query = "select * from coupons";
        using var connection = _dapperContext.CreateConnection();
        var values = await connection.QueryAsync<ResultCouponDTO>(query);
        return values.ToList();
    }

    public async Task UpdateCoupon(UpdateCouponDTO couponDTO)
    {
        string query = @$"Update Coupons set Code = @code ,Rate = @rate , isActive = @isActive,ValidDate = @validDate 
                          WHERE CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code", couponDTO.Code);
        parameters.Add("@rate", couponDTO.Rate);
        parameters.Add("@isActive", couponDTO.isActive);
        parameters.Add("@validDate", couponDTO.ValidDate);
        parameters.Add("couponId", couponDTO.CouponId);
        using (var connection = _dapperContext.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }
}
