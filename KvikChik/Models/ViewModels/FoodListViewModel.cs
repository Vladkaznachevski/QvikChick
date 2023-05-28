using Data;
using KvikChik.Models.ViewModels.Default;

namespace KvikChik.Models.ViewModels
{
    public class FoodsListViewModel
    {
        public List<Food> Foods { get; }
        public PageViewModel PageViewModel { get; }
        public SortViewModel SortViewModel { get; }
        //public FilterViewModel FilterViewModel { get; }

        public FoodsListViewModel
        (
            List<Food> foods,
            PageViewModel pageViewModel,
            SortViewModel sortViewModel
        //FilterViewModel filterViewModel
        )
        {
            Foods = foods;
            PageViewModel = pageViewModel;
            SortViewModel = sortViewModel;
            //FilterViewModel = filterViewModel;
        }
    }
}
