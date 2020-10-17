using System.Collections.Generic;
using applestore.Data.Enum;

namespace applestore.Data.Entity {
    public class Category {
        public int id {get; set;}
        public int sortOrder {get; set;}
        public bool isPublic {get; set;}
        public int? parentId {get; set;}
        public Status status {get; set;}

        public List<ProductInCategory> productInCategories {get; set;}

        public List<CategoryTranslation> categoryTranslations {get; set;}
    }
}