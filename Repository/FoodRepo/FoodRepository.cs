using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FoodRepo
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationContext _context;

        public FoodRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Food> GetAll()
        {
            return _context.Foods.ToList();
        }

        public Food Get(int id)
        {
            return _context.Foods.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Food Food)
        {
            _context.Foods.Add(Food);
        }

        public void Update(Food Food)
        {
            _context.Foods.Update(Food);
        }

        public void Delete(int id)
        {
            Food Food = Get(id);
            _context.Foods.Remove(Food);
        }
    }
}
