using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class AddProductSemiFinalSubmitToCreateProducts
    {
        public string PRDCTName { get; set; }
        public string PRDCTDescription { get; set; }
        public string AllImagesByID { get; set; }
        public string PRDCTType { get; set; }
        public string PRDCTMainCat { get; set; }
        public string PRDCTSubCat { get; set; }
        public string PRDCTDemansion { get; set; }
        public string PRDCTPriceDemansion { get; set; }
        public string PRDCTOffType { get; set; }
        public string PRDCTOffPriceValue { get; set; }
        public string PRDCTPricePer1Demansion { get; set; }
        public string PRDCTDemansionValue { get; set; }
        public string PRDCTPriceShowType { get; set; }
        public string PRDCTTagSectionOfProduct { get; set; }
        public List<AllSubcategory_Keys_Vals_class> AllSubcategory_Keys_Vals { get; set; }
        public List<TagTargetAdded_class> TagTargetAdded { get; set; }
        public string PRDCTMultyPricePer1Demansion { get; set; }
        public string PRDCTMultyDemansionValue { get; set; }
    }

    public class AllSubcategory_Keys_Vals_class
    {
        public string ItemSubCategoryKeyID { get; set; }
        public string[] SubCategoryKeyAllValues { get; set; }

    }
    public class TagTargetAdded_class
    {
        public string TagTargeName { get; set; }
        public string TagTargeValue { get; set; }
        public string TagTargetID { get; set; }
    }
    public class AllSubcategory_Keys_Vals_ModelJaygashtCalculator
    {
        public string ItemSubCategoryKeyID { get; set; }
        public string SubCategoryKeyValue { get; set; }
        public string ItemSubCategoryValuOfKeyName { get; set; }

    }

}