using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KvikChik.Models.ViewModels.Default
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Food> companies, int? food, string name)
        {
            companies.Insert(0, new Food { Name = "Все", Id = 0 });
            Foods = new SelectList(companies, "Id", "Name", food);
            SelectedName = name;
            SelectedFood = food;
            SelectedName = name;
        }
        public SelectList Foods { get; private set; } // список компаний
        public int? SelectedFood { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}