using System;
using System.Collections.ObjectModel;

namespace Fox.Common.Models
{
    public class Item : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Cover { get; set; }
        public double Price { get; set; }
        public bool Featured { get; set; }
        public bool OnPromotion { get; set; }
        public bool IsNew { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<Image> Images { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
