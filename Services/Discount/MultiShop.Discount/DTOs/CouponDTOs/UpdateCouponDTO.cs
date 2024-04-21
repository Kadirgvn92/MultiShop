namespace MultiShop.Discount.DTOs.CouponDTOs;

public class UpdateCouponDTO
{
    public int CouponId { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool isActive { get; set; }
    public DateTime ValidDate { get; set; }
}
