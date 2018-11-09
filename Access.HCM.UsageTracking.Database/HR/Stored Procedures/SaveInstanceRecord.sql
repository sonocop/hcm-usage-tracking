CREATE PROCEDURE [HR].[SaveInstanceRecord] 
	@Identifier [varchar](100),
	@LicenseGuid [uniqueidentifier],
	@VersionMajor [smallint],
	@VersionMinor [smallint],
	@VersionRevision [int],
	@VersionBuild [int],
	@LikelyTestSystem [bit],
	@LastSSURunGuid [uniqueidentifier],
	@LastAuditDate [datetime] ,
	@LatestLoggedInDate [datetime] 
AS
BEGIN
SET NOCOUNT ON;

	if exists (SELECT *
	FROM [HR].Instances
	WHERE [InstanceIdentifier] = @Identifier
	AND [LicenseGuid] = @LicenseGuid
	AND [VersionMajor] = @VersionMajor
	AND [VersionMinor] = @VersionMinor
	AND [VersionRevision] = @VersionRevision
	AND [VersionBuild] = @VersionBuild
	AND [LikelyTestSystem] = @LikelyTestSystem
	AND ISNULL([LastSSURunGuid], '0x0') = ISNULL(@LastSSURunGuid, '0x0'))
BEGIN
		UPDATE hri
		SET [LastAuditDate] = @LastAuditDate
		   ,[LatestLoggedInDate] = @LatestLoggedInDate
		   ,[ModifiedDate] = GETDATE()
		FROM [HR].Instances hri
		WHERE hri.[InstanceIdentifier] = @Identifier
		AND hri.[LicenseGuid] = @LicenseGuid
		AND hri.[VersionMajor] = @VersionMajor
		AND hri.[VersionMinor] = @VersionMinor
		AND hri.[VersionRevision] = @VersionRevision
		AND hri.[VersionBuild] = @VersionBuild
		AND hri.[LikelyTestSystem] = @LikelyTestSystem
		AND ISNULL(hri.[LastSSURunGuid], '0x0') = ISNULL(@LastSSURunGuid, '0x0')
		END
ELSE
BEGIN
		INSERT INTO [HR].[Instances] (
		[InstanceIdentifier]
		, [LicenseGuid]
		, [VersionMajor]
		, [VersionMinor]
		, [VersionRevision]
		, [VersionBuild]
		, [LikelyTestSystem]
		, [LastSSURunGuid]
		, [LastAuditDate]
		, [LatestLoggedInDate]
		, [CreatedDate]
		, [ModifiedDate])
		VALUES (@Identifier, @LicenseGuid, @VersionMajor, @VersionMinor, @VersionRevision, @VersionBuild, @LikelyTestSystem, @LastSSURunGuid, @LastAuditDate, @LatestLoggedInDate, GETDATE(), GETDATE())
END

END
