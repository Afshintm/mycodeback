IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Application') IS NULL EXEC(N'CREATE SCHEMA [Application];');

GO

IF SCHEMA_ID(N'Identity') IS NULL EXEC(N'CREATE SCHEMA [Identity];');

GO

CREATE TABLE [Application].[AccountGroup] (
    [Id] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_AccountGroup] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Application].[Vendor] (
    [Id] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Vendor] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Identity].[Role] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Application].[Account] (
    [Id] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [GroupId] nvarchar(450) NULL,
    [VendorId] nvarchar(450) NULL,
    [AccountNo] nvarchar(max) NULL,
    [VendorAccountNo] nvarchar(max) NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_AccountGroup_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Application].[AccountGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Account_Vendor_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Application].[Vendor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Application].[EssenceEvent] (
    [Id] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT '2019-02-19T02:00:27.3413405Z',
    [VendorId] nvarchar(450) NULL,
    [Account] int NOT NULL,
    [Event_Code] int NOT NULL,
    [Event_Severity] int NOT NULL,
    [Event_Details] nvarchar(max) NULL,
    [Event_IsMobile] bit NULL,
    [Event_Location_Latitude] nvarchar(max) NULL,
    [Event_Location_Longitude] nvarchar(max) NULL,
    [Event_Location_HorizontalAccuracy] int NULL,
    [PanelTime] nvarchar(max) NULL,
    [ServerTime] nvarchar(max) NULL,
    [ServiceProvider] int NULL,
    [ServiceType] int NULL,
    [Ids] nvarchar(max) NULL,
    CONSTRAINT [PK_EssenceEvent_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EssenceEvent_Vendor_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Application].[Vendor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Identity].[User] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [UserType] nvarchar(max) NULL,
    [Email] nvarchar(256) NULL,
    [CellPhoneNumber] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [VendorId] nvarchar(450) NULL,
    [VendorUserId] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [UserId] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_User_Vendor_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Application].[Vendor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Identity].[RoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_RoleClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Application].[Event] (
    [Id] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [AccountId] nvarchar(450) NULL,
    [AlertType] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [PanelTime] nvarchar(max) NULL,
    [ServiceProvider] int NULL,
    [ServerTime] nvarchar(max) NULL,
    [IsMobile] bit NULL,
    [VendorEventId] nvarchar(max) NULL,
    [HSCCode] nvarchar(max) NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [HorizontalAccuracy] int NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Details_DeviceId] int NULL,
    [Details_DeviceType] int NULL,
    [Details_DeviceDescription] nvarchar(max) NULL,
    [Details_BatteryLevel] int NULL,
    [EmergencyPanicDetails_Details_DeviceId] int NULL,
    [EmergencyPanicDetails_Details_DeviceType] int NULL,
    [EmergencyPanicDetails_Details_DeviceDescription] nvarchar(max) NULL,
    [FallAlertDetails_Details_DeviceId] int NULL,
    [FallAlertDetails_Details_DeviceType] int NULL,
    [FallAlertDetails_Details_DeviceDescription] nvarchar(max) NULL,
    [Details_Activitytype] int NULL,
    [Details_DurationInRoom] nvarchar(max) NULL,
    [Details_LastContactTime] nvarchar(max) NULL,
    [PowerDetails_Details_DeviceId] int NULL,
    [PowerDetails_Details_DeviceType] int NULL,
    [PowerDetails_Details_DeviceDescription] nvarchar(max) NULL,
    [Details_PowerFailureDuration] nvarchar(max) NULL,
    [Details_PowerRestoredDuration] nvarchar(max) NULL,
    [Details_ExitTime] nvarchar(max) NULL,
    [Details_PeriodStartTime] nvarchar(max) NULL,
    [Details_PeriodEndTime] nvarchar(max) NULL,
    [Details_MaximumOutOfHomeDuration] nvarchar(max) NULL,
    [Details_EntryTime] nvarchar(max) NULL,
    [UnexpectedActivityDetails_Details_DeviceId] int NULL,
    [UnexpectedActivityDetails_Details_DeviceType] int NULL,
    [UnexpectedActivityDetails_Details_DeviceDescription] nvarchar(max) NULL,
    [Details_Grade] real NULL,
    [UnexpectedEntryExitDetails_Details_DeviceId] int NULL,
    [UnexpectedEntryExitDetails_Details_DeviceType] int NULL,
    [UnexpectedEntryExitDetails_Details_DeviceDescription] nvarchar(max) NULL,
    [Details_Period_Is24Hours] bit NULL,
    [Details_Period_PeriodStartTime] nvarchar(max) NULL,
    [Details_Period_PeriodEndTime] nvarchar(max) NULL,
    CONSTRAINT [PK_HCSEvent_Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Event_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Application].[Account] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Application].[AccountUser] (
    [AccountId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(450) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_AccountUser] PRIMARY KEY ([AccountId], [UserId]),
    CONSTRAINT [FK_AccountUser_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Application].[Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountUser_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Identity].[UserClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Identity].[UserLogin] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Identity].[UserRole] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Identity].[UserToken] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_UserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Application].[AccountGroup]'))
    SET IDENTITY_INSERT [Application].[AccountGroup] ON;
INSERT INTO [Application].[AccountGroup] ([Id], [CreatedDate], [Name])
VALUES (N'65f0d143-190f-4106-8c69-cdafd0b5ab1b', '2019-02-19T02:00:27.3846006Z', N'TestGroup');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Application].[AccountGroup]'))
    SET IDENTITY_INSERT [Application].[AccountGroup] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Application].[Vendor]'))
    SET IDENTITY_INSERT [Application].[Vendor] ON;
INSERT INTO [Application].[Vendor] ([Id], [CreatedDate], [Name])
VALUES (N'8b175488-30a2-4768-993d-05ee1d441923', '2019-02-19T02:00:27.3829176Z', N'Essence');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Application].[Vendor]'))
    SET IDENTITY_INSERT [Application].[Vendor] OFF;

GO

CREATE INDEX [IX_Account_GroupId] ON [Application].[Account] ([GroupId]);

GO

CREATE INDEX [IX_Account_VendorId] ON [Application].[Account] ([VendorId]);

GO

CREATE INDEX [IX_AccountUser_UserId] ON [Application].[AccountUser] ([UserId]);

GO

CREATE INDEX [IX_EssenceEvent_VendorId] ON [Application].[EssenceEvent] ([VendorId]);

GO

CREATE INDEX [IX_Event_AccountId] ON [Application].[Event] ([AccountId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [Identity].[Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_RoleClaim_RoleId] ON [Identity].[RoleClaim] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [Identity].[User] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [Identity].[User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_User_VendorId] ON [Identity].[User] ([VendorId]);

GO

CREATE INDEX [IX_UserClaim_UserId] ON [Identity].[UserClaim] ([UserId]);

GO

CREATE INDEX [IX_UserLogin_UserId] ON [Identity].[UserLogin] ([UserId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [Identity].[UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190219020027_ApplicationIdentity', N'2.2.1-servicing-10028');

GO

