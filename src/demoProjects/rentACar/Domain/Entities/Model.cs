﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Model : Entity
{
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public int BrandId { get; set; }
    public virtual Brand? Brand { get; set; }

    public Model()
    {
    }

    public Model(int id, string name, decimal dailyPrice, string imageUrl, int brandId) : this()
    {
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
        Id = id;
        BrandId = brandId;
    }
}