using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing;

namespace Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class HomeModel
    {
        public List<CampaignModel> RecentDocuments { get; set; }
        public List<CampaignModel> SearchDocuments { get; set; }
        public List<HomeInputModel> Inputs { get; set; }
        public SearchModel Search { get; set; }
        public LookupModel Lookup { get; set; }
        public CampaignModel Upload { get; set; }
    }

    public class MyUploadsModel
    {
        public List<CampaignModel> Documents { get; set; }
    }

    public class CampaignModel : LookupModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        public string Category { get; set; }
        public string CategoryId { get; set; }

        public string Territory { get; set; }
        public string CampaignType { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }

        [Required]
        [Display(Name = "Territory")]
        public string TerritoryId { get; set; }

        [Required]
        [Display(Name = "Campaign Theme")]
        public string CampaignTypeId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string BrandId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Uploaded { get; set; }
        
        public IEnumerable<DocumentModel> Documents { get; set; }

        public string Owner { get; set; }

        public bool IsOwnedByCurrentUser()
        {
            return Security.CurrentUserName() != null ? Owner.ToUpper().Equals(Security.CurrentUserName().ToUpper()) : false;
        }

        public bool IsSubjectToAdministrator()
        {
            return Security.CurrentUserInRole(ApplicationRole.Administrator);
        }

        public bool IsEditableByCurrentUser()
        {
            return IsOwnedByCurrentUser() || IsSubjectToAdministrator();
        }
    }

    

    public class DocumentModel
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string DocumentType { get; set; }
        public int ContentLength { get; set; }
        public byte[] Data { get; set; }

    }

    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class TerritoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class CampaignTypeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class BrandModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class CountryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class SearchModel
    {
        public string Search { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public CheckItem[] Categories { get; set; }
        public CheckItem[] Territories { get; set; }
        public CheckItem[] CampaignTypes { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        public SearchModel()  { }

        public SearchModel(IEnumerable<category> categories, IEnumerable<campaign_type> campaignTypes, IEnumerable<territory> territories, IEnumerable<brand> brands, IEnumerable<country> countries)
        {
            Categories = categories.OrderBy(c => c.category_description).Select(c => new CheckItem
            {
                Id = c.category_id,
                Name = c.category_description,
                IsChecked = false
            }).ToArray();

            Territories = territories.OrderBy(t => t.territory_description).Select(t => new CheckItem
            {
                Id = t.territory_id, 
                Name = t.territory_description, 
                IsChecked = false
            }).ToArray();

            CampaignTypes = campaignTypes.OrderBy(c => c.list_order).Select(c => new CheckItem
            {
                Id = c.campaign_type_id,
                Name = c.campaign_type_description,
                IsChecked = false
            }).ToArray();

            Brands = brands.OrderBy(b => b.brand_description).Select(b => new SelectListItem
            {
                Text = b.brand_description,
                Value = b.brand_id.ToString(),
                Selected = false
            });

            Countries = countries.OrderBy(c => c.country_description).Select(c => new SelectListItem
            {
                Text = c.country_description,
                Value = c.country_id.ToString(),
                Selected = false
            });
        }
    }

    public class CheckItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

    }

    public class LookupModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Territories { get; set; }
        public IEnumerable<SelectListItem> CampaignTypes { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        public LookupModel() { }

        public LookupModel(IEnumerable<category> categories, IEnumerable<campaign_type> campaignTypes, IEnumerable<territory> territories, IEnumerable<brand> brands, IEnumerable<country> countries)
        {
            Categories = categories.OrderBy(c => c.category_description).Select(c => new SelectListItem
            {
                Text = c.category_description,
                Value = c.category_id.ToString(),
                Selected = false
            });

            CampaignTypes = campaignTypes.OrderBy(c => c.list_order).Select(c => new SelectListItem
            {
                Text = c.campaign_type_description,
                Value = c.campaign_type_id.ToString(),
                Selected = false
            });

            Territories = territories.OrderBy(t => t.territory_description).Select(t => new SelectListItem
            {
                Text = t.territory_description,
                Value = t.territory_id.ToString(),
                Selected = false
            });

            Brands = brands.OrderBy(b => b.brand_description).Select(b => new SelectListItem
            {
                Text = b.brand_description,
                Value = b.brand_id.ToString(),
                Selected = false
            });

            Countries = countries.OrderBy(c => c.country_description).Select(c => new SelectListItem
            {
                Text = c.country_description,
                Value = c.country_id.ToString(),
                Selected = false
            });
        }
    }

    public class HomeInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string Blog { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


    public static class ModelIntializer
    {
        public static CampaignModel InitializeCampaignModel(int campaignId)
        {
            var campaignManager = new CampaignDataManager();
            return campaignManager.Retrieve(campaignId);
        }

        public static LookupModel InitializeLookupModel()
        {
            var categoryManager = new CategoryDataManager();
            var territoryManager = new TerritoryDataManager();
            var campaignTypeManager = new CampaignTypeDataManager();
            var brandManager = new BrandDataManager();
            var campaignManager = new CampaignDataManager();
            var countryManager = new CountryDataManager();

            var brands = brandManager.RetrieveActive();
            var categories = categoryManager.RetrieveActive();
            var campaignTypes = campaignTypeManager.RetrieveActive();
            var territories = territoryManager.RetrieveActive();
            var countries = countryManager.RetrieveActive();

            return new LookupModel(categories, campaignTypes, territories, brands, countries);
        }

        public static HomeModel CreateHomeModel()
        {
            var categoryManager = new CategoryDataManager();
            var territoryManager = new TerritoryDataManager();
            var campaignTypeManager = new CampaignTypeDataManager();
            var brandManager = new BrandDataManager();
            var campaignManager = new CampaignDataManager();
            var countryManager = new CountryDataManager();

            var brands = brandManager.RetrieveActive();
            var categories = categoryManager.RetrieveActive();
            var campaignTypes = campaignTypeManager.RetrieveActive();
            var territories = territoryManager.RetrieveActive();
            var countries = countryManager.RetrieveActive();

            return new HomeModel
            {
                RecentDocuments = new List<CampaignModel>(),
                SearchDocuments = new List<CampaignModel>(),
                Search = new SearchModel(categories, campaignTypes, territories, brands, countries),
                Upload = new CampaignModel(),
                Lookup = new LookupModel(categories, campaignTypes, territories, brands, countries)
            };
        }
    }

    public static class ModelExtention
    {
        public static CampaignModel Get(this List<CampaignModel> models, int id)
        {
            return models.First(x => x.Id == id);
        }

        public static HomeInputModel Get(this List<HomeInputModel> models, int id)
        {
            return models.First(x => x.Id == id);
        }
    }
}