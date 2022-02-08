﻿using Microsoft.EntityFrameworkCore;
using Series.Database.Interfaces;
using Series.DataBase;
using Series.Models;

namespace Series.Database.Repositories
{
    internal class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        public SerieRepository(SeriesContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            Serie? serie = _context.Series.Find(id);
            if (serie == null) return false;
            _context.Series.Remove(serie);
            return true;
        }

        public async Task<IEnumerable<Serie>> GetAll()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<IEnumerable<Serie>> GetSeriesByCategory(int categoryId)
        {
            return await _context.Series.Where(s => s.CategoryId == categoryId).ToListAsync();
        }


    }
}
