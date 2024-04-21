using MultiShop.Discount.DTOs.CouponDTOs;

namespace MultiShop.Discount.Services;

public interface ICouponService
{
    Task<List<ResultCouponDTO>> GetCoupons();
    Task CreateCoupon(CreateCouponDTO couponDTO);
    Task UpdateCoupon(UpdateCouponDTO couponDTO);
    Task DeleteCoupon(int couponId);
    Task<GetByIdCouponDTO> GetByIdCoupon(int couponId);
}
