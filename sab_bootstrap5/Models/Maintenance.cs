using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing;

namespace Models
{
    public class MaintainOptionModel
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }

    public class MaintainOptionsModel
    {
        public string CurrentController { get; set; }
        public IEnumerable<MaintainOptionModel> Options { get; set; }
    }

    public class MaintainTerritoriesModel : MaintainOptionsModel
    {
        public string NewTerritory { get; set; }
        public IEnumerable<TerritoryModel> Territories { get; set; }
    }

    public class MaintainCampaignTypesModel : MaintainOptionsModel
    {
        public string NewCampaignType { get; set; }
        public IEnumerable<CampaignTypeModel> CampaignTypes { get; set; }
    }

    public class MaintainBrandsModel : MaintainOptionsModel
    {
        public string NewBrand { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }

    public class MaintainCountriesModel : MaintainOptionsModel
    {
        public string NewCountry { get; set; }
        public IEnumerable<CountryModel> Countries { get; set; }
    }

    public class MaintainCategoriesModel : MaintainOptionsModel
    {
        public string NewCategory { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }

    public static class MaintenanceModelInitializer
    {
        public static IEnumerable<MaintainOptionModel> MaintainOptions()
        {
            var options = new List<MaintainOptionModel>();
            options.Add(new MaintainOptionModel{ Text = "Maintain Territories", Action = "Maintain", Controller = "Territories"});
            options.Add(new MaintainOptionModel{ Text = "Maintain Campaign Themes", Action = "Maintain", Controller = "CampaignTypes"});
            options.Add(new MaintainOptionModel { Text = "Maintain Brands", Action = "Maintain", Controller = "Brands" });
            options.Add(new MaintainOptionModel { Text = "Maintain Countries", Action = "Maintain", Controller = "Countries" });
            options.Add(new MaintainOptionModel { Text = "Maintain Categories", Action = "Maintain", Controller = "Categories" });
            return options;
        }

        public static MaintainTerritoriesModel InitializeMaintainTerritoriesModel()
        {
            var territoriesManager = new TerritoryDataManager();
            return new MaintainTerritoriesModel
            {
                CurrentController = "Territories",
                Options = MaintainOptions(),
                Territories = territoriesManager
                                .RetrieveAll()
                                .Select(territory => new TerritoryModel
                                {
                                    Id = territory.territory_id,
                                    Name = territory.territory_description,
                                    Active = territory.active.HasValue ? (bool) territory.active : false
                                })
                                .ToList()
            };
        }

        public static MaintainCampaignTypesModel InitializeMaintainCampaignTypesModel()
        {
            var manager = new CampaignTypeDataManager();
            return new MaintainCampaignTypesModel
            {
                CurrentController = "CampaignTypes",
                Options = MaintainOptions(),
                CampaignTypes = manager
                                .RetrieveAll()
                                .Select(campaign_type => new CampaignTypeModel
                                {
                                    Id = campaign_type.campaign_type_id,
                                    Name = campaign_type.campaign_type_description,
                                    Active = campaign_type.active.HasValue ? (bool)campaign_type.active : false
                                })
                                .ToList()
            };
        }

        public static MaintainBrandsModel InitializeMaintainBrandsModel()
        {
            var manager = new BrandDataManager();
            return new MaintainBrandsModel
            {
                CurrentController = "Brands",
                Options = MaintainOptions(),
                Brands = manager
                                .RetrieveAll()
                                .Select(brand => new BrandModel
                                {
                                    Id = brand.brand_id,
                                    Name = brand.brand_description,
                                    Active = brand.active.HasValue ? (bool)brand.active : false
                                })
                                .ToList()
            };
        }

        public static MaintainCountriesModel InitializeMaintainCountriesModel()
        {
            var manager = new CountryDataManager();
            return new MaintainCountriesModel
            {
                CurrentController = "Countries",
                Options = MaintainOptions(),
                Countries = manager
                                .RetrieveAll()
                                .Select(country => new CountryModel
                                {
                                    Id = country.country_id,
                                    Name = country.country_description,
                                    Active = country.active.HasValue ? (bool)country.active : false
                                })
                                .ToList()
            };
        }

        public static MaintainCategoriesModel InitializeMaintainCategoriesModel()
        {
            var manager = new CategoryDataManager();
            return new MaintainCategoriesModel
            {
                CurrentController = "Categories",
                Options = MaintainOptions(),
                Categories = manager
                                .RetrieveAll()
                                .Select(category => new CategoryModel
                                {
                                    Id = category.category_id,
                                    Name = category.category_description,
                                    Active = category.active.HasValue ? (bool)category.active : false
                                })
                                .ToList()
            };
        }
    }
}