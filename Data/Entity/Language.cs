using System.Collections.Generic;

namespace applestore.Data.Entity {
    public class Language {
        public int id {get; set;}
        public string name {get; set;}
        public bool isDefault {get; set;}

        public List<CategoryTranslation> categoryTranslations {get; set;}
        public List<ProductTranslation> productTranslations {get; set;}
    }
}