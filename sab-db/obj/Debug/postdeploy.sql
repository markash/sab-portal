/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

set identity_insert dbo.category on;
insert into dbo.category (category_id, category_description) values (0, 'Unassigned');
insert into dbo.category (category_id, category_description) values (1, 'Premium');
insert into dbo.category (category_id, category_description) values (2, 'Mainstream');
insert into dbo.category (category_id, category_description) values (3, 'Affordable');
insert into dbo.category (category_id, category_description) values (4, 'Opaque');
insert into dbo.category (category_id, category_description) values (5, 'AFB');
set identity_insert dbo.category off

set identity_insert dbo.territory on;
insert into dbo.territory (territory_id, territory_description) values (1, 'Pride in Origins');
insert into dbo.territory (territory_id, territory_description) values (2, 'Bring us Together');
insert into dbo.territory (territory_id, territory_description) values (3, 'Masculine Character');
insert into dbo.territory (territory_id, territory_description) values (4, 'Style');
insert into dbo.territory (territory_id, territory_description) values (5, 'Making it');
insert into dbo.territory (territory_id, territory_description) values (6, 'Lust for Life');
insert into dbo.territory (territory_id, territory_description) values (7, 'Men will be men');
insert into dbo.territory (territory_id, territory_description) values (8, 'Beer appreciation');
insert into dbo.territory (territory_id, territory_description) values (9, 'Idyllic relaxation');
set identity_insert dbo.territory off;

set identity_insert dbo.campaign_type on;
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (1, 'Emotional');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (2, 'Rational');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (3, 'Innovation');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (4, 'Promotion');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (5, 'Music sponsorship/event');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (6, 'Sport sponsorship/event');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (7, 'Other sponsorship/even');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (8, 'TTL');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (9, 'One visual');
set identity_insert dbo.campaign_type off

set identity_insert dbo.brand on;
insert into dbo.brand (brand_id, brand_description) values (1, 'Hansa');
insert into dbo.brand (brand_id, brand_description) values (2, 'CBL');
insert into dbo.brand (brand_id, brand_description) values (3, '2M');
insert into dbo.brand (brand_id, brand_description) values (4, 'Manica');
insert into dbo.brand (brand_id, brand_description) values (5, 'Laurentina Clara');
insert into dbo.brand (brand_id, brand_description) values (6, 'Laurentina Preta');
insert into dbo.brand (brand_id, brand_description) values (7, 'Lion');
insert into dbo.brand (brand_id, brand_description) values (8, 'Mosi');
insert into dbo.brand (brand_id, brand_description) values (9, 'Nile Special');
insert into dbo.brand (brand_id, brand_description) values (10, 'Club Pilsner');
insert into dbo.brand (brand_id, brand_description) values (11, 'Club Lager');
insert into dbo.brand (brand_id, brand_description) values (12, 'Kilimanjaro');
insert into dbo.brand (brand_id, brand_description) values (13, 'Safari');
insert into dbo.brand (brand_id, brand_description) values (14, 'Balimi');
insert into dbo.brand (brand_id, brand_description) values (15, 'Stone');
insert into dbo.brand (brand_id, brand_description) values (16, 'Hero');
insert into dbo.brand (brand_id, brand_description) values (17, 'Grand');
insert into dbo.brand (brand_id, brand_description) values (18, 'Trophy');
set identity_insert dbo.brand off

set identity_insert dbo.country on;
insert into dbo.country(country_id, country_description) values (1, 'Lesotho');
insert into dbo.country(country_id, country_description) values (2, 'Swaziland');
insert into dbo.country(country_id, country_description) values (3, 'Botswana');
insert into dbo.country(country_id, country_description) values (4, 'Mozambique');
insert into dbo.country(country_id, country_description) values (5, 'Zambia');
insert into dbo.country(country_id, country_description) values (6, 'Zimbabwe');
insert into dbo.country(country_id, country_description) values (7, 'Uganda');
insert into dbo.country(country_id, country_description) values (8, 'Tanzania');
insert into dbo.country(country_id, country_description) values (9, 'Kenya');
insert into dbo.country(country_id, country_description) values (10, 'Ghana');
insert into dbo.country(country_id, country_description) values (11, 'Nigeria');
set identity_insert dbo.country off;

set identity_insert dbo.usage_type on;
insert into dbo.usage_type(usage_type_id, usage_type_description) values (1, 'Login');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (2, 'Upload');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (3, 'Upload Report');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (4, 'Usage Report');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (5, 'Maintain Territories');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (6, 'Maintain Campaign Types');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (7, 'Maintain Brands');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (8, 'Maintain Countries');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (9, 'Read Document');
set identity_insert dbo.usage_type off;





 





GO
