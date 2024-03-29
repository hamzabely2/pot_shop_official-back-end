﻿using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;

namespace Repository.Item
{
    public class ItemRepository : GenericRepository<Entity.Model.Item>, ItemIRepository
    {
        public ItemRepository(PotShopIDbContext _idbcontext)
            : base(_idbcontext)
        {
            _table = _idbcontext.Set<Entity.Model.Item>();
        }

        private readonly DbSet<Entity.Model.Item> _table;

        /// get by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.Item> GetItemByName(string name)
        {
            Entity.Model.Item item = await _table
                .FirstOrDefaultAsync(x => x.Name == name)
                .ConfigureAwait(false);

            return item;
        }

        public async Task<Entity.Model.Item> GetItemDetailsByIdAsync(int itemId)
        {
            // Vous devriez implémenter le code pour récupérer les détails de l'Item à partir de votre base de données
            // Par exemple, si vous utilisez Entity Framework Core, cela pourrait ressembler à ceci :
            return await _table.FirstOrDefaultAsync(item => item.Id == itemId);
        }

        public async Task<Entity.Model.Item> GetItemByIdWithDetails(int itemId)
        {
            var item = await _table
                .Where(i => i.Id == itemId)
                .Include(i => i.Materials)
                .Include(i => i.Categories)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return item;
        }

        public async Task<List<Image>> GetAllImagesForItem(int itemId)
        {
            var images = await _idbcontext.Images
                .Where(img => img.ItemId == itemId)
                .ToListAsync()
                .ConfigureAwait(false);

            return images;
        }


        public async Task<List<Color>> GetAllColorsForItem(int itemId)
        {
            var colorItems = await _idbcontext.ColorsItems
                .Include(ci => ci.Color)
                .Where(ci => ci.ItemId == itemId)
                .ToListAsync()
                .ConfigureAwait(false);

            List<Color> colors = new List<Color>();

            foreach (var colorItem in colorItems)
            {
                // Vérifier si colorItem.Color n'est pas null avant d'essayer d'y accéder
                if (colorItem.Color != null)
                {
                    colors.Add(colorItem.Color);
                }
            }

            return colors;
        }
    }
}
