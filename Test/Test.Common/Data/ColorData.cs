﻿
using Context.Interface;
using Entity.Model;

namespace Test.Common
{
    public static class ColorData
    {
        public static void CreateColors(this PotShopIDbContext idbContext)
        {
            var color1 = new Color
            {
                Id = 1,
                Hex = "#00010",
                Label = "red",
            };
            var color2 = new Color
            {
                Id = 2,
                Hex = "#00010",
                Label = "green"
            };
            idbContext.Colors.AddRange(color1, color2);
            idbContext.SaveChanges();
        }
        public static void CreateColor(this PotShopIDbContext idbContext)
        {
            var color1 = new Color
            {
                Id = 3,
                Hex = "red"
            };

            idbContext.Colors.AddRange(color1);
            idbContext.SaveChanges();
        }
    }
}
