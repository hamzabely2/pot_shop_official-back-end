﻿using Entity.Model;
using Model.DetailsItem;

namespace Repository.Interface.Item
{
    public interface ItemIRepository : IGenericRepository<Entity.Model.Item>
    {
        Task<Entity.Model.Item> GetItemByName(string name);
        Task<Entity.Model.Item> GetItemDetailsByIdAsync(int itemId);
        Task<Entity.Model.Item> GetItemByIdWithDetails(int itemId);
        Task<List<Image>> GetAllImagesForItem(int itemId);
        Task<List<Color>> GetAllColorsForItem(int itemId);
    }
}
