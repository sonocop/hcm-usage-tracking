Create view HR.InstancesLoadTestData
as 
WITH
    -- Tally table Gen            Tally Rows:     X2                X3
t1 AS (SELECT 1 N UNION ALL SELECT 0 N),    -- 4            ,    8
t2 AS (SELECT 1 N FROM t1 x, t1 y),            -- 16            ,    64
t3 AS (SELECT 1 N FROM t2 x, t2 y),           -- 256            ,    4096
t4 AS (SELECT 1 N FROM t3 x, t3 y),            -- 65536        ,    16,777,216
t5 AS (SELECT 1 N FROM t4 x, t4 y),            -- 4,294,967,296,    A lot
Tally AS (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) N
          FROM t4 x, t4 y) -- Change the t3's to one of the other numbers above for more/less rows ,
,Id as (Select N from Tally)
select cast(N as varchar(10)) + '123urwye9834f9834u34098' as Identifier,
	   cast(right('00000000' + cast(N as varchar(10)),8) + '-0000-0000-0000-000000000000' as UNIQUEIDENTIFIER) as LicenseGuid,
		3 as VersionMajor,
		3 as VersionMinor,
		0 as VersionRevision,
		0 as VersionBuild,
		0 as LikelyTestSystem, 
		cast('00000000-0000-0000-0000-000000000000' as UNIQUEIDENTIFIER) as LastSSURunGuid,
		dateadd(day,(N * -1),getdate()) as LastAuditDate,
		dateadd(day,(N * -1),getdate()) as LatestLoggedInDate
from Id