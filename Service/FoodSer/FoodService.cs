using Data;
using Repository.FoodRepo;
namespace Service.FoodSer
{
    public class FoodService : IFoodService
    {
        private IFoodRepository _repository;

        public FoodService(IFoodRepository repository)
        {
            _repository = repository;
        }


        public List<Food> GetFoods()
        {
            return _repository.GetAll();
        }

        public Food GetFoodById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateFood(Food Food)
        {
            _repository.Create(Food);
        }

        public void UpdateFood(Food Food)
        {
            _repository.Update(Food);
        }

        public void DeleteFood(int id)
        {
            _repository.Delete(id);
        }
    }
}
