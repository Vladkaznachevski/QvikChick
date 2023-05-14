using Data;

namespace KvikChik.Models.ViewModels
{
    public class ShoppingListViewModel
    {

        public int Id2 { get; set; }
        public List<Food> Foods { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    
    }
}
