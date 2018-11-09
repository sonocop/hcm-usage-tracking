CREATE TABLE [HR].[Instances] (
    [InstanceId]         INT              IDENTITY (1, 1) NOT NULL,
    [InstanceIdentifier] VARCHAR (100)    NOT NULL,
    [LicenseGuid]        UNIQUEIDENTIFIER NOT NULL,
    [VersionMajor]       SMALLINT         NOT NULL,
    [VersionMinor]       SMALLINT         NOT NULL,
    [VersionRevision]    INT              NOT NULL,
    [VersionBuild]       INT              NOT NULL,
    [LikelyTestSystem]   BIT              NOT NULL,
    [LastSSURunGuid]     UNIQUEIDENTIFIER NOT NULL,
    [LastAuditDate]      DATETIME         NULL,
    [LatestLoggedInDate] DATETIME         NULL,
    [CreatedDate]        DATETIME         NOT NULL,
    [ModifiedDate]       DATETIME         NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Instance_Lookup]
    ON [HR].[Instances]([InstanceIdentifier] ASC, [LicenseGuid] ASC, [VersionMajor] ASC, [VersionMinor] ASC, [VersionRevision] ASC, [VersionBuild] ASC, [LikelyTestSystem] ASC, [LastSSURunGuid] ASC);

