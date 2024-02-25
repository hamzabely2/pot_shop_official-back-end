﻿namespace Model.DetailsItem
{
    public class CategoryDto
    {
        public string Label { get; set; }
        public string Description { get; set; }

    }
    public class ColorDto
    {
        public string Label { get; set; }

        public string Hex { get; set; }
    }

    public class MaterialDto
    {
        public string Label { get; set; }
        public string Description { get; set; }

    }

    public class AddColorByItem
    {
        public int ColorId { get; set; }
        public int ItemId { get; set; }

    }

    public class AddImageByItem
    {
        public int ItemId { get; set; }
        public byte[]? ImageData { get; set; }

    }
}
