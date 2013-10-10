using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.IO;
using System.Web.Routing;

namespace Marketing.Controllers
{
    [Authorize]
    public class HomeController : BootstrapBaseController
    {
        static HomeModel _model = ModelIntializer.CreateHomeModel();

        public ActionResult Index()
        {
            var campaignManager = new CampaignDataManager();

            _model.RecentDocuments.Clear();
            _model.RecentDocuments.AddRange(campaignManager.RetrieveRecent());
            _model.Lookup = ModelIntializer.InitializeLookupModel();
            return View(_model);
        }

        [HttpPost]
        public ActionResult Upload(HomeModel model)
        {
            var campaignManager = new CampaignDataManager();
            var campaign = campaignManager.Save(model.Upload, Request.Files[0], Security.CurrentUserName());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(HomeModel model)
        {
            var categories = model.Search.Categories != null ? model.Search.Categories.Where(x => x.IsChecked).Select(v => v.Id).ToArray() : new int[0];
            var territories = model.Search.Territories != null ? model.Search.Territories.Where(x => x.IsChecked).Select(v => v.Id).ToArray() : new int[0];
            var campaignTypes = model.Search.CampaignTypes != null ? model.Search.CampaignTypes.Where(x => x.IsChecked).Select(v => v.Id).ToArray() : new int[0];
            var brandId = model.Search.Brand == null || "".Equals(model.Search.Brand) ? 0 : Int32.Parse(model.Search.Brand);
            var countryId = model.Search.Country == null || "".Equals(model.Search.Country) ? 0 : Int32.Parse(model.Search.Country);

            var campaignManager = new CampaignDataManager();
            _model.SearchDocuments.Clear();
            _model.SearchDocuments.AddRange(campaignManager.Search(model.Search.Search, categories, territories, campaignTypes, brandId, countryId));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadDocument(CampaignModel model)
        {
            var campaignManager = new CampaignDataManager();
            var campaign = campaignManager.SaveDocument(model, Request.Files[0], Security.CurrentUserName());

            RouteValueDictionary p = new RouteValueDictionary();
            p.Add("campaign_id", campaign.Id);
            return RedirectToAction("EditCampaign", p);
        }

        public ActionResult ViewDocument()
        {
            var campaignId = Request.Params["campaign_id"] != null && !Request.Params["campaign_id"].Trim().Equals("") ? Int32.Parse(Request.Params["campaign_id"]) : 0;
            var documentId = Request.Params["document_id"] != null && !Request.Params["document_id"].Trim().Equals("") ? Int32.Parse(Request.Params["document_id"]) : 0;

            var campaignManager = new CampaignDataManager();
            DocumentModel document = campaignManager.ReadDocument(Security.CurrentUserName(), campaignId, documentId);
            if (document != null)
            {
                return new FileStreamResult(new MemoryStream(document.Data), document.ContentType)
                {
                    FileDownloadName = document.FileName
                };
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult RemoveDocument()
        {
            var campaignId = Request.Params["campaign_id"] != null && !Request.Params["campaign_id"].Trim().Equals("") ? Int32.Parse(Request.Params["campaign_id"]) : 0;
            var documentId = Request.Params["document_id"] != null && !Request.Params["document_id"].Trim().Equals("") ? Request.Params["document_id"] : "";
            var campaignManager = new CampaignDataManager();
            var documentCount = campaignManager.DeleteDocument(campaignId, documentId);

            if (documentCount > 0)
            {
                RouteValueDictionary p = new RouteValueDictionary();
                p.Add("campaign_id", campaignId);
                return RedirectToAction("EditCampaign", p);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditCampaign()
        {
            var campaignId = Request.Params["campaign_id"] != null && !Request.Params["campaign_id"].Trim().Equals("") ? Int32.Parse(Request.Params["campaign_id"]) : 0;
            
            var campaignModel = ModelIntializer.InitializeCampaignModel(campaignId);
            if (campaignModel == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(campaignModel);
        }

        [HttpPost]
        public ActionResult SaveCampaign(CampaignModel campaign)
        {
            var campaignManager = new CampaignDataManager();
            campaignManager.Update(campaign);

            RouteValueDictionary p = new RouteValueDictionary();
            p.Add("campaign_id", campaign.Id);
            return RedirectToAction("EditCampaign", p);
        }

        [HttpPost]
        public ActionResult Create(HomeInputModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _model.Inputs.Count==0?1:_model.Inputs.Select(x => x.Id).Max() + 1;
                _model.Inputs.Add(model);
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new HomeInputModel());
        }

        public ActionResult Delete(int id)
        {
            _model.Inputs.Remove(_model.Inputs.Get(id));
            Information("Your widget was deleted");
            if(_model.Inputs.Count==0)
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            var model = _model.Inputs.Get(id);
            return View("Create", model);
        }
        [HttpPost]        
        public ActionResult Edit(HomeInputModel model,int id)
        {
            if(ModelState.IsValid)
            {
                _model.Inputs.Remove(_model.Inputs.Get(id));
                model.Id = id;
                _model.Inputs.Add(model);
                Success("The model was updated!");
                return RedirectToAction("index");
            }
            return View("Create", model);
        }

		public ActionResult Details(int id)
        {
            var model = _model.Inputs.Get(id);
            return View(model);
        }

    }
}
