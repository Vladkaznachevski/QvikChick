using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.FoodSer
{
    public interface IFoodService
    {
        List<Food> GetFoods();
        Food GetFoodById(int id);
        void CreateFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int id);
    }
}
