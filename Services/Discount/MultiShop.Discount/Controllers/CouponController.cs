using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs.CouponDTOs;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }
    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        var values = await _couponService.GetCoupons();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        var values = await _couponService.GetByIdCoupon(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDTO createCouponDTO)
    {
        await _couponService.CreateCoupon(createCouponDTO);
        return Ok("Kupon başarıyla oluşturuldu");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _couponService.DeleteCoupon(id);
        return Ok("Kupon başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDTO updateCouponDTO)
    {
        await _couponService.UpdateCoupon(updateCouponDTO);
        return Ok("Kupon başarıyla güncellendi");
    }
}
