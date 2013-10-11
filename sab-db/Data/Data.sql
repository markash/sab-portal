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

INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'common', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'health monitoring', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'membership', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'personalization', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'profile', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'role manager', N'1', 1)

INSERT [dbo].[aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (N'sab', N'sab', N'f7082b24-dc45-42d5-8299-74d424e339ba', NULL)

INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'1a83cd68-2faa-4f2e-9598-9765418e29da', N'admin', N'admin', NULL, 0, CAST(0x0000A2530114A391 AS DateTime))
INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'35605711-388b-4a4a-87ee-96cfb111dfd3', N'brianf', N'brianf', NULL, 0, CAST(0x0000A253006CDFEB AS DateTime))
INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'52a38262-b199-448d-9153-aaaa7512068c', N'marka', N'marka', NULL, 0, CAST(0x0000A2520152796F AS DateTime))

INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'c16d8212-71a0-4d4c-af0c-a91a44953825', N'Administrator', N'administrator', NULL)
INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'bd82e64d-f8d1-4f2e-9581-c73b7556ad01', N'User', N'user', NULL)

INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'1a83cd68-2faa-4f2e-9598-9765418e29da', N'c16d8212-71a0-4d4c-af0c-a91a44953825')
INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'35605711-388b-4a4a-87ee-96cfb111dfd3', N'bd82e64d-f8d1-4f2e-9581-c73b7556ad01')
INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'52a38262-b199-448d-9153-aaaa7512068c', N'bd82e64d-f8d1-4f2e-9581-c73b7556ad01')

INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'1a83cd68-2faa-4f2e-9598-9765418e29da', N'tMjKKnHJ4KbLxceVIFebXFykOwk=', 1, N'7IRSoeGypIATyE0dq5lLxQ==', NULL, N'admin@talentfactor.co.za', N'admin@talentfactor.co.za', NULL, NULL, 1, 0, CAST(0x0000A252014A120C AS DateTime), CAST(0x0000A2530114A391 AS DateTime), CAST(0x0000A252014A120C AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'35605711-388b-4a4a-87ee-96cfb111dfd3', N'iN7BmDigfzmmJOns+qRwU4jJJbo=', 1, N'JrrFibs8DPuZnZX+eKH4Ug==', NULL, N'brianf@talentfactor.co.za', N'brianf@talentfactor.co.za', NULL, NULL, 1, 0, CAST(0x0000A252014A39E4 AS DateTime), CAST(0x0000A253006CDFEB AS DateTime), CAST(0x0000A252014A39E4 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'f7082b24-dc45-42d5-8299-74d424e339ba', N'52a38262-b199-448d-9153-aaaa7512068c', N'MGOkuhU/w82jm3AIBpWXTLC1AVg=', 1, N'8y0PwiEzkUGHHyQUZtUh5Q==', NULL, N'mp.ashworth@gmail.com', N'mp.ashworth@gmail.com', NULL, NULL, 1, 0, CAST(0x0000A252014A5604 AS DateTime), CAST(0x0000A2520152796F AS DateTime), CAST(0x0000A252014A5604 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)



 




