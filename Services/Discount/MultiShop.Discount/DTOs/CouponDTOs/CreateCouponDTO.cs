﻿namespace MultiShop.Discount.DTOs.CouponDTOs;

public class CreateCouponDTO
{
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool isActive { get; set; }
    public DateTime ValidDate { get; set; }
}