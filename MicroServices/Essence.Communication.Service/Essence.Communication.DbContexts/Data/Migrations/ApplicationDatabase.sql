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

CREATE TABLE [Application].[EssenceEvent] (
    [Id] nvarchar(450) NOT NULL DEFAULT N'd1f7b951-243a-41a0-9549-9a040cbbaf1a',
    [CreateDate] datetime2 NOT NULL DEFAULT '2019-01-30T06:23:01.5801471Z',
    [Vendor] nvarchar(max) NOT NULL,
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
    CONSTRAINT [PK_EssenceEvent_Id] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Application].[Event] (
    [Id] nvarchar(450) NOT NULL DEFAULT N'85e44370-293b-496e-b765-d2c9230045a3',
    [CreateDate] datetime2 NOT NULL DEFAULT '2019-01-30T06:23:01.5680105Z',
    [Account] int NOT NULL,
    [Severity] int NOT NULL,
    [PanelTime] nvarchar(max) NULL,
    [ServiceProvider] int NULL,
    [ServiceType] int NULL,
    [ServerTime] nvarchar(max) NULL,
    [IsMobile] bit NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [HorizontalAccuracy] int NULL,
    [VendorType] nvarchar(max) NOT NULL,
    [VendorEventId] nvarchar(max) NULL,
    [EmergencyLevel] int NOT NULL,
    [EmergencyDescriptoin] nvarchar(max) NULL,
    [UserID] nvarchar(max) NULL,
    [HSCCode] nvarchar(max) NULL,
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
    CONSTRAINT [PK_HCSEvent_Id] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190130062301_ApplicationDatabase', N'2.2.1-servicing-10028');

GO

