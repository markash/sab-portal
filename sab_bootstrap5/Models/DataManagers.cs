using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Models
{
    public class UsageDataManager
    {
        protected static int USAGE_LOGIN = 1;
        protected static int USAGE_UPLOAD = 2;
        protected static int USAGE_REPORT_UPLOAD = 3;
        protected static int USAGE_REPORT_USAGE = 4;
        protected static int USAGE_MAINTAIN_TERRITORIES = 5;
        protected static int USAGE_MAINTAIN_CAMPAIGN_TYPES = 6;
        protected static int USAGE_MAINTAIN_BRANDS = 7;
        protected static int USAGE_MAINTAIN_COUNTRIES = 8;
        protected static int USAGE_READ_DOCUMENT = 9;
        protected static string SQL_INSERT_USAGE = "INSERT INTO usage (username, usage_type_id) VALUES (@username, @usage_type_id)";

        protected MarketingDataContext ctx = new MarketingDataContext();

        protected static SqlCommand CreateUsageCommand(string username, int usageTypeId, SqlConnection connection, SqlTransaction txn)
        {
            SqlCommand command = new SqlCommand(SQL_INSERT_USAGE, connection, txn);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@usage_type_id", usageTypeId));
            return command;
        }

        public void TrackLoginUsage(string username)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    CreateUsageCommand(username, USAGE_LOGIN, conn, txn).ExecuteNonQuery();
                    txn.Commit();
                }
                conn.Close();
            }
        }
    }

    public class CategoryDataManager
    {
        private MarketingDataContext ctx = new MarketingDataContext();

        public List<category> RetrieveAll()
        {
            var query = from category in ctx.categories
                        select category;
            return query.ToList();
        }

        public List<category> RetrieveActive()
        {
            var query = from category in ctx.categories
                        where category.active == true
                        select category;
            return query.ToList();
        }

        public List<category> RetrieveActiveAndId(int id)
        {
            var query = from category in ctx.categories
                        where category.active == true || category.category_id == id
                        select category;
            return query.ToList();
        }

        internal static category RetrieveById(MarketingDataContext ctx, int id)
        {
            var query = from category in ctx.categories
                        where category.category_id == id
                        select category;

            return query.FirstOrDefault();
        }

        public category Save(category category)
        {
            var existing = ctx.categories.SingleOrDefault(x => x.category_id == category.category_id);
            if (existing != default(category))
            {
                existing.update_ts = DateTime.Now;
                existing.category_description = category.category_description;
                ctx.SubmitChanges();
                return existing;
            }

            category.active = true;
            category.create_ts = DateTime.Now;

            ctx.categories.InsertOnSubmit(category);
            ctx.SubmitChanges();
            return category;
        }

        public void Deactivate(int id)
        {
            var existing = ctx.categories.Where(category => category.category_id == id).SingleOrDefault();
            if (existing != default(category))
            {
                existing.active = false;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public void Activate(int id)
        {
            var existing = ctx.categories.Where(category => category.category_id == id).SingleOrDefault();
            if (existing != default(category))
            {
                existing.active = true;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }
    }

    public class TerritoryDataManager
    {
        private MarketingDataContext ctx = new MarketingDataContext();

        public List<territory> RetrieveAll()
        {
            var query = from territory in ctx.territories
                        select territory;
            return query.ToList();
        }

        public List<territory> RetrieveActive()
        {
            var query = from territory in ctx.territories
                        where territory.active == true
                        select territory;
            return query.ToList();
        }

        public List<territory> RetrieveActiveAndId(int id)
        {
            var query = from territory in ctx.territories
                        where territory.active == true || territory.territory_id == id
                        select territory;
            return query.ToList();
        }

        public territory Save(territory territory)
        {
            var existing = ctx.territories.SingleOrDefault(x => x.territory_id == territory.territory_id);
            if (existing != default(territory))
            {
                existing.update_ts = DateTime.Now;
                existing.territory_description = territory.territory_description;
                ctx.SubmitChanges();
                return existing;
            }

            territory.active = true;
            territory.create_ts = DateTime.Now;

            ctx.territories.InsertOnSubmit(territory);
            ctx.SubmitChanges();
            return territory;
        }

        public void Deactivate(int id)
        {
            var existing = ctx.territories.Where(territory => territory.territory_id == id).SingleOrDefault();
            if (existing != default(territory))
            {
                existing.active = false;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public void Activate(int id)
        {
            var existing = ctx.territories.Where(territory => territory.territory_id == id).SingleOrDefault();
            if (existing != default(territory))
            {
                existing.active = true;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }
    }

    public class CampaignTypeDataManager
    {
        private MarketingDataContext ctx = new MarketingDataContext();

        public List<campaign_type> RetrieveAll()
        {
            var query = from campaign_type in ctx.campaign_types
                        select campaign_type;
            return query.ToList();
        }

        public List<campaign_type> RetrieveActive()
        {
            var query = from campaign_type in ctx.campaign_types
                        where campaign_type.active == true
                        select campaign_type;
            return query.ToList();
        }

        public List<campaign_type> RetrieveActiveAndId(int id)
        {
            var query = from campaign_type in ctx.campaign_types
                        where campaign_type.active == true || campaign_type.campaign_type_id == id
                        select campaign_type;
            return query.ToList();
        }

        public campaign_type Save(campaign_type campaign_type)
        {
            var existing = ctx.campaign_types.SingleOrDefault(x => x.campaign_type_id == campaign_type.campaign_type_id);
            if (existing != default(campaign_type))
            {
                existing.update_ts = DateTime.Now;
                existing.campaign_type_description = campaign_type.campaign_type_description;
                ctx.SubmitChanges();
                return existing;
            }

            campaign_type.active = true;
            campaign_type.create_ts = DateTime.Now;

            ctx.campaign_types.InsertOnSubmit(campaign_type);
            ctx.SubmitChanges();
            return campaign_type;
        }

        public void Deactivate(int id)
        {
            var existing = ctx.campaign_types.Where(campaign_type => campaign_type.campaign_type_id == id).SingleOrDefault();
            if (existing != default(campaign_type))
            {
                existing.active = false;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public void Activate(int id)
        {
            var existing = ctx.campaign_types.Where(campaign_type => campaign_type.campaign_type_id == id).SingleOrDefault();
            if (existing != default(campaign_type))
            {
                existing.active = true;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }
    }

    public class BrandDataManager
    {
        private MarketingDataContext ctx = new MarketingDataContext();

        public List<brand> RetrieveAll()
        {
            var query = from brand in ctx.brands
                        select brand;

            return query.ToList();
        }

        public List<brand> RetrieveActive()
        {
            var query = from brand in ctx.brands
                        where brand.active == true
                        select brand;

            return query.ToList();
        }

        public List<brand> RetrieveActiveAndId(int id)
        {
            var query = from brand in ctx.brands
                        where brand.active == true || brand.brand_id == id
                        select brand;

            return query.ToList();
        }

        public brand Save(brand brand)
        {
            var existing = ctx.brands.SingleOrDefault(x => x.brand_id == brand.brand_id);
            if (existing != default(brand))
            {
                existing.update_ts = DateTime.Now;
                existing.brand_description = brand.brand_description;
                ctx.SubmitChanges();
                return existing;
            }

            brand.active = true;
            brand.create_ts = DateTime.Now;
            ctx.brands.InsertOnSubmit(brand);
            ctx.SubmitChanges();
            return brand;
        }

        public void Deactivate(int id)
        {
            var existing = ctx.brands.Where(brand => brand.brand_id == id).SingleOrDefault();
            if (existing != default(brand))
            {
                existing.active = false;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public void Activate(int id)
        {
            var existing = ctx.brands.Where(brand => brand.brand_id == id).SingleOrDefault();
            if (existing != default(brand))
            {
                existing.active = true;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }
    }

    public class CountryDataManager
    {
        private MarketingDataContext ctx = new MarketingDataContext();

        public List<country> RetrieveAll()
        {
            var query = from country in ctx.countries
                        select country;

            return query.ToList();
        }

        public List<country> RetrieveActive()
        {
            var query = from country in ctx.countries
                        where country.active == true
                        select country;

            return query.ToList();
        }

        public List<country> RetrieveActiveAndId(int id)
        {
            var query = from country in ctx.countries
                        where country.active == true || country.country_id == id
                        select country;

            return query.ToList();
        }

        public country Save(country country)
        {
            var existing = ctx.countries.SingleOrDefault(x => x.country_id == country.country_id);
            if (existing != default(country))
            {
                existing.country_description = country.country_description;
                ctx.SubmitChanges();
                return existing;
            }

            country.active = true;
            ctx.countries.InsertOnSubmit(country);
            ctx.SubmitChanges();
            return country;
        }

        public void Deactivate(int id)
        {
            var existing = ctx.countries.Where(country => country.country_id == id).SingleOrDefault();
            if (existing != default(country))
            {
                existing.active = false;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public void Activate(int id)
        {
            var existing = ctx.countries.Where(country => country.country_id == id).SingleOrDefault();
            if (existing != default(country))
            {
                existing.active = true;
                existing.update_ts = DateTime.Now;
                ctx.SubmitChanges();
            }
        }
    }

    
    public class CampaignDataManager : UsageDataManager
    {
        public bool Exists(int campaignId)
        {
            return Retrieve(campaignId) != null;
        }

        public CampaignModel Retrieve(int campaignId)
        {
            var query = from campaign in ctx.campaigns
                        where campaign.campaign_id == campaignId
                        select campaign;

            foreach (var c in query)
            {
                return createCampaignModel(c, RetrieveDocuments(c));
            }
            return null;
        }

        public List<DocumentModel> RetrieveDocuments(campaign c)
        {
            if (c == null)
            {
                return new List<DocumentModel>();
            }

            var query = from campaign_document in ctx.campaign_documents
                        where campaign_document.campaign_id == c.campaign_id
                        select campaign_document;

            List<DocumentModel> documents = new List<DocumentModel>();
            foreach (var d in query)
            {
                DocumentModel documentModel = new DocumentModel
                {
                    Id = d.id.ToString(),
                    ContentType = d.content_type,
                    DocumentType = ContentTypeToDocumentType(d.content_type),
                    ContentLength = (int)d.content_length,
                    FileName = d.file_name
                };
                documents.Add(documentModel);
            }
            return documents;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="documentId"></param>
        /// <returns>The document count</returns>
        public int DeleteDocument(int campaignId, string documentId)
        {
            int documentCount = -1;
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    string sql = "DELETE FROM campaign_document where campaign_id = " + campaignId.ToString() + " AND id = '" + documentId + "';" +
                                "SELECT COUNT(*) from campaign_document where campaign_id = " + campaignId.ToString();

                    SqlCommand cmd = new SqlCommand(sql, conn, txn);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            documentCount = (Int32)rdr[0];
                        }
                    }

                    if (documentCount == 0)
                    {
                        sql = "DELETE FROM campaign where campaign_id = " + campaignId.ToString();
                        cmd = new SqlCommand(sql, conn, txn);
                        cmd.ExecuteNonQuery();
                    }
                    txn.Commit();
                }
            }
            return documentCount;
        }

        public DocumentModel ReadDocumentUsingFileStream(string username, int campaignId, int documentId)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    CreateUsageCommand(username, USAGE_READ_DOCUMENT, conn, txn).ExecuteNonQuery();

                    string sql = "SELECT document.PathName()" +
                                ",GET_FILESTREAM_TRANSACTION_CONTEXT()" +
                                ",content_length" + 
                                ",content_type" + 
                                ",file_name" +
                                " FROM campaign_document " +
                                " WHERE campaign_id = " + campaignId.ToString();

                    SqlCommand cmd = new SqlCommand(sql, conn, txn);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            string filePath = rdr[0].ToString();
                            byte[] objContext = (byte[])rdr[1];
                            string fileName = rdr["file_name"].ToString();
                            string contentType = rdr["content_type"].ToString();
                            int contentLength = (int)rdr["content_length"];

                            SqlFileStream sfs = new SqlFileStream(filePath, objContext, System.IO.FileAccess.Read);

                            byte[] buffer = new byte[(int)sfs.Length];
                            sfs.Read(buffer, 0, buffer.Length);
                            sfs.Close();

                            return new DocumentModel
                            {
                                FileName = fileName,
                                ContentType = contentType,
                                ContentLength = contentLength,
                                DocumentType = ContentTypeToDocumentType(contentType),
                                Data = buffer
                            };
                        }
                    }

                    txn.Commit();
                }
            }

            return null;
        }

        public DocumentModel ReadDocument(string username, int campaignId, int documentId)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    CreateUsageCommand(username, USAGE_READ_DOCUMENT, conn, txn).ExecuteNonQuery();

                    string sql = "SELECT " +
                                "content_length" +
                                ",content_type" +
                                ",file_name" +
                                ",document" +
                                " FROM campaign_document " +
                                " WHERE campaign_id = " + campaignId.ToString();

                    SqlCommand cmd = new SqlCommand(sql, conn, txn);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            string filePath = rdr[0].ToString();
                            byte[] document = (byte[])rdr["document"];
                            string fileName = rdr["file_name"].ToString();
                            string contentType = rdr["content_type"].ToString();
                            int contentLength = (int)rdr["content_length"];

                            return new DocumentModel
                            {
                                FileName = fileName,
                                ContentType = contentType,
                                ContentLength = contentLength,
                                DocumentType = ContentTypeToDocumentType(contentType),
                                Data = document
                            };
                        }
                    }

                    txn.Commit();
                }
            }

            return null;
        }

        public CampaignModel Update(CampaignModel campaign)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {

                    string sql = @"UPDATE campaign SET " +
                                    "territory_id=@territory_id" +
                                    ",campaign_type_id=@campaign_type_id" +
                                    ",brand_id=@brand_id" +
                                    ",country_id=@country_id" +
                                    ",title=@title" +
                                 " WHERE campaign_id=@campaign_id";

                    SqlCommand command = new SqlCommand(sql, conn, txn);

                    SqlParameter param = command.CreateParameter();
                    param.ParameterName = "@territory_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(campaign.TerritoryId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@campaign_type_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(campaign.CampaignTypeId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@brand_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(campaign.BrandId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@country_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(campaign.CountryId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@title";
                    param.DbType = System.Data.DbType.String;
                    param.Value = campaign.Title;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@campaign_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = campaign.Id;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    txn.Commit();
                    campaign = Retrieve(campaign.Id);
                }
                conn.Close();
            }

            return campaign;
        }

        public CampaignModel Save(CampaignModel document, HttpPostedFileBase file, string username)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    CreateUsageCommand(username, USAGE_UPLOAD, conn, txn).ExecuteNonQuery();

                    string sql = @"INSERT INTO campaign (" +
                                    "category_id," +
                                    "territory_id," +
                                    "campaign_type_id," +
                                    "brand_id," +
                                    "country_id," +
                                    "username," +
                                    "title" +
                                 ") VALUES (" +
                                    "default," +
                                    "@territory_id," +
                                    "@campaign_type_id," +
                                    "@brand_id," +
                                    "@country_id," +
                                    "@username," +
                                    "@title" +
                                ") SET @id=SCOPE_IDENTITY()";


                    SqlCommand command = new SqlCommand(sql, conn, txn);
                    
                    SqlParameter param = command.CreateParameter();
                    param.ParameterName = "@territory_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(document.TerritoryId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@campaign_type_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(document.CampaignTypeId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@brand_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(document.BrandId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@country_id";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = Int32.Parse(document.CountryId);
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@username";
                    param.DbType = System.Data.DbType.String;
                    param.Value = username;
                    command.Parameters.Add(param);

                    param = command.CreateParameter();
                    param.ParameterName = "@title";
                    param.DbType = System.Data.DbType.String;
                    param.Value = document.Title;
                    command.Parameters.Add(param);

                    SqlParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@id";
                    idParameter.DbType = System.Data.DbType.Int32;
                    idParameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(idParameter);

                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        document.Id = (Int32)idParameter.Value;

                        //foreach (HttpPostedFileBase file in files)
                        //{
                        if (file != null && file.ContentLength > 0)
                        {
                            byte[] buffer = new byte[file.ContentLength + 1];
                            file.InputStream.Read(buffer, 0, file.ContentLength + 1);

                            sql = @"INSERT INTO campaign_document(" +
                                    "id, campaign_id, content_length, content_type, file_name, document" + 
                                    ") VALUES (" + 
                                    "default, @campaign_id, @content_length, @content_type, @file_name, @document" +
                                    ")";

                            command = new SqlCommand(sql, conn, txn);

                            param = command.CreateParameter();
                            param.ParameterName = "@campaign_id";
                            param.DbType = System.Data.DbType.Int32;
                            param.Value = document.Id;
                            command.Parameters.Add(param);

                            param = command.CreateParameter();
                            param.ParameterName = "@content_length";
                            param.DbType = System.Data.DbType.Int32;
                            param.Value = file.ContentLength;
                            command.Parameters.Add(param);

                            param = command.CreateParameter();
                            param.ParameterName = "@content_type";
                            param.DbType = System.Data.DbType.String;
                            param.Value = file.ContentType;
                            command.Parameters.Add(param);

                            param = command.CreateParameter();
                            param.ParameterName = "@file_name";
                            param.DbType = System.Data.DbType.String;
                            param.Value = file.FileName;
                            command.Parameters.Add(param);

                            param = command.CreateParameter();
                            param.ParameterName = "@document";
                            param.DbType = System.Data.DbType.Binary;
                            param.Value = buffer;
                            command.Parameters.Add(param);

                            command.ExecuteNonQuery();
                            /*
                            sql = @"INSERT INTO campaign_document (id, campaign_id, content_length, content_type, file_name, document) " +
                                "OUTPUT INSERTED.document.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() " +
                                "VALUES (default" + 
                                    "," + document.Id.ToString() + 
                                    "," + file.ContentLength +
                                    ",'" + file.ContentType + "'" +
                                    ",'" + file.FileName + "'" +
                                    ", 0x)";

                            command = new SqlCommand(sql, conn, txn);

                            string path = null;
                            byte[] context = null;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                path = reader.GetString(0);
                                context = reader.GetSqlBytes(1).Buffer;
                                reader.Close();
                            }
                            using (SqlFileStream sfs = new SqlFileStream(path, context, FileAccess.Write))
                            {
                                file.InputStream.CopyTo(sfs);
                            }
                            */
                        }
                        //}
                    }
                    txn.Commit();
                    document = Retrieve(document.Id);
                }
                conn.Close();
            }

            return document;
        }

        public CampaignModel SaveDocument(CampaignModel campaign, HttpPostedFileBase file, string username)
        {
            using (SqlConnection conn = (SqlConnection)ctx.Connection)
            {
                conn.Open();
                using (SqlTransaction txn = conn.BeginTransaction())
                {
                    CreateUsageCommand(username, USAGE_UPLOAD, conn, txn).ExecuteNonQuery();

                    //foreach (HttpPostedFileBase file in files)
                    //{
                    if (file != null && file.ContentLength > 0)
                    {
                        string sql = @"INSERT INTO campaign_document (id, campaign_id, content_length, content_type, file_name, document) " +
                            "OUTPUT INSERTED.document.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() " +
                            "VALUES (default" +
                                "," + campaign.Id +
                                "," + file.ContentLength +
                                ",'" + file.ContentType + "'" +
                                ",'" + file.FileName + "'" +
                                ", 0x)";

                        SqlCommand command = new SqlCommand(sql, conn, txn);

                        string path = null;
                        byte[] context = null;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            path = reader.GetString(0);
                            context = reader.GetSqlBytes(1).Buffer;
                            reader.Close();
                        }
                        using (SqlFileStream sfs = new SqlFileStream(path, context, FileAccess.Write))
                        {
                            file.InputStream.CopyTo(sfs);
                        }
                    }
                    //}

                    txn.Commit();
                    campaign = Retrieve(campaign.Id);
                }
                conn.Close();
            }

            return campaign;
        }

        public List<CampaignModel> RetrieveRecent()
        {
            var query = from campaign in ctx.campaigns
                        select campaign;

            List<CampaignModel> results = new List<CampaignModel>();
            foreach(var c in query)
            {
                results.Add(createCampaignModel(c, RetrieveDocuments(c)));
            }

            return results;
        }

        public List<CampaignModel> Search(string search, int[] categories, int[] territories, int[] campaignTypes, int brandId, int countryId)
        {
            var query = from campaign in ctx.campaigns
                            select campaign;

            if (search != null && !search.Trim().Equals(""))
            {
                query = query.Where(campaign => campaign.title.Contains(search));
            }
            if (categories != null && categories.Count() > 0)
            {
                query = query.Where(campaign => categories.Contains(campaign.category_id));
            }
            if (territories != null && territories.Count() > 0)
            {
                query = query.Where(campaign => territories.Contains(campaign.territory_id));
            }
            if (campaignTypes != null && campaignTypes.Count() > 0)
            {
                query = query.Where(campaign => campaignTypes.Contains(campaign.campaign_type_id));
            }
            if (brandId > 0)
            {
                query = query.Where(campaign => campaign.brand_id == brandId);
            }
            if (countryId > 0)
            {
                query = query.Where(campaign => campaign.country_id == countryId);
            }

            return query.Select(campaign => createCampaignModel(campaign, RetrieveDocuments(campaign))).ToList();
        }

        public List<CampaignModel> RetrieveForUser(string username)
        {
            var query = from campaign in ctx.campaigns
                        where campaign.username == username
                        select campaign;

            List<CampaignModel> results = new List<CampaignModel>();
            foreach (var c in query)
            {
                results.Add(createCampaignModel(c, RetrieveDocuments(c)));
            }

            return results;
        }

        public List<CampaignModel> RetrieveForAdmin(string username)
        {
            var query = from campaign in ctx.campaigns
                        select campaign;

            List<CampaignModel> results = new List<CampaignModel>();
            foreach (var c in query)
            {
                results.Add(createCampaignModel(c, RetrieveDocuments(c)));
            }

            return results;
        }

        public static string ContentTypeToDocumentType(string contentType)
        {
            string type = null;
            switch (contentType)
            {
                case "application/vnd.ms-excel": type = "xls"; break;
                case "application/pdf": type = "pdf"; break;
                case "image/jpeg": type = "jpg"; break;
                case "application/msword" : type = "doc"; break;
                case "audio/mp3": type = "mp3"; break;

                default: type = "txt"; break;
            }
            return type;
        }

        internal static CampaignModel createCampaignModel(campaign c, List<DocumentModel> d)
        {
            if (c != null)
            {
                var categoryManager = new CategoryDataManager();
                var territoryManager = new TerritoryDataManager();
                var campaignTypeManager = new CampaignTypeDataManager();
                var brandManager = new BrandDataManager();
                var countryManager = new CountryDataManager();

                var brands = brandManager.RetrieveActiveAndId(c.brand_id);
                var categories = categoryManager.RetrieveActiveAndId(c.category_id);
                var campaignTypes = campaignTypeManager.RetrieveActiveAndId(c.campaign_type_id);
                var territories = territoryManager.RetrieveActiveAndId(c.territory_id);
                var countries = countryManager.RetrieveActiveAndId(c.country_id);

                return new CampaignModel
                {
                    Id = c.campaign_id,
                    Category = c.category.category_description,
                    TerritoryId = c.territory_id.ToString(),
                    Territory = c.territory.territory_description,
                    CampaignTypeId = c.campaign_type_id.ToString(),
                    CampaignType = c.campaign_type.campaign_type_description,
                    BrandId = c.brand_id.ToString(),
                    Brand = c.brand.brand_description,
                    CountryId = c.country_id.ToString(),
                    Country = c.country.country_description,
                    Title = c.title,
                    Owner = c.username,
                    Uploaded = c.create_ts,
                    Documents = d,
                    Categories = categories.OrderBy(category => category.category_description).Select(category => new SelectListItem
                    {
                        Text = category.category_description,
                        Value = category.category_id.ToString(),
                        Selected = category.category_id == c.category_id
                    }).ToList(),
                    CampaignTypes = campaignTypes.OrderBy(campaignType => campaignType.campaign_type_description).Select(campaignType => new SelectListItem
                    {
                        Text = campaignType.campaign_type_description,
                        Value = campaignType.campaign_type_id.ToString(),
                        Selected = campaignType.campaign_type_id == c.campaign_type_id
                    }).ToList(),
                    Territories = territories.OrderBy(territory => territory.territory_description).Select(territory => new SelectListItem
                    {
                        Text = territory.territory_description,
                        Value = territory.territory_id.ToString(),
                        Selected = territory.territory_id == c.territory_id
                    }).ToList(),
                    Brands = brands.OrderBy(brand => brand.brand_description).Select(brand => new SelectListItem
                    {
                        Text = brand.brand_description,
                        Value = brand.brand_id.ToString(),
                        Selected = brand.brand_id == c.brand_id
                    }).ToList(),
                    Countries = countries.OrderBy(country => country.country_description).Select(country => new SelectListItem
                    {
                        Text = country.country_description,
                        Value = country.country_id.ToString(),
                        Selected = country.country_id == c.country_id
                    }).ToList()
                };
            }
            else
            {
                return new CampaignModel();
            }
        }
    }

    public class ReportDataManager : UsageDataManager
    {
        public IEnumerable<UsageReportItemModel> UsageReport(DateTime? startDate, DateTime? endDate)
        {
            var query = from usage_report in ctx.usage_report(startDate, endDate)
                        select usage_report;

            List<UsageReportItemModel> results = new List<UsageReportItemModel>();
            foreach (var item in query)
            {
                results.Add(new UsageReportItemModel
                {
                    Email = item.username,
                    Country = item.country,
                    LastEntry = item.last_entry,
                    EntryCount = item.entry_count.HasValue ? (int)item.entry_count : 0
                });
            }

            return results;
        }

        public IEnumerable<UploadReportItemModel> UploadReport(DateTime? startDate, DateTime? endDate)
        {
            var query = from upload_report in ctx.upload_report(startDate, endDate)
                        select upload_report;

            List<UploadReportItemModel> results = new List<UploadReportItemModel>();
            foreach (var item in query)
            {
                results.Add(new UploadReportItemModel
                {
                    Email = item.username,
                    Country = item.country,
                    UploadCount = item.upload_count.HasValue ? (int) item.upload_count : 0
                });
            }


            /*
            if (startDate != null && endDate != null)
            {
                var q = from campaign in ctx.campaigns
                        where campaign.create_ts >= startDate && campaign.create_ts <= endDate
                        group campaign.campaign_id by new { campaign.username, campaign.country.country_description } into g
                        select new { g.Key, UploadCount = g.Count() };

                foreach (var item in q)
                {
                    results.Add(new UploadReportItemModel
                    {
                        Email = item.Key.username,
                        Country = item.Key.country_description,
                        UploadCount = item.UploadCount
                    });
                }
            }
            else if (startDate == null && endDate != null)
            {
                var q = from campaign in ctx.campaigns
                        where campaign.create_ts <= endDate
                        group campaign.campaign_id by new { campaign.username, campaign.country.country_description } into g
                        select new { g.Key, UploadCount = g.Count() };

                foreach (var item in q)
                {
                    results.Add(new UploadReportItemModel
                    {
                        Email = item.Key.username,
                        Country = item.Key.country_description,
                        UploadCount = item.UploadCount
                    });
                }
            }
            else if (startDate != null && endDate == null)
            {
                var q = from campaign in ctx.campaigns
                        where campaign.create_ts >= startDate
                        group campaign.campaign_id by new { campaign.username, campaign.country.country_description } into g
                        select new { g.Key, UploadCount = g.Count() };

                foreach (var item in q)
                {
                    results.Add(new UploadReportItemModel
                    {
                        Email = item.Key.username,
                        Country = item.Key.country_description,
                        UploadCount = item.UploadCount
                    });
                }
            }
            else
            {
                var q = from campaign in ctx.campaigns
                        group campaign.campaign_id by new { campaign.username, campaign.country.country_description } into g
                        select new { g.Key, UploadCount = g.Count() };

                foreach (var item in q)
                {
                    results.Add(new UploadReportItemModel
                    {
                        Email = item.Key.username,
                        Country = item.Key.country_description,
                        UploadCount = item.UploadCount
                    });
                }
            }
            */
            return results;
        }
    }

}