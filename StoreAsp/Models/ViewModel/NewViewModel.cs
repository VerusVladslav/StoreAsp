using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAsp.Models.ViewModel
{
    public class NewViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public virtual CategoryModel Category { get; set; }

        public NewViewModel()
        {
            Category = new CategoryModel();
        }
    }
}