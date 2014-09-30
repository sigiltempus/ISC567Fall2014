USE [TESTDB]
GO



CREATE PROCEDURE [dbo].[sp_Report_CourseOutcome_in_DOD] 
AS 
(
SELECT 
	a.Key1ID,
	a.Key2ID,
	a.dodobjectivenum, 
	SUBSTRING (a.dodobjectivenumvalue,7,len(a.dodobjectivenumvalue)) as DODvalue ,
	a.crsoutcomenum,
	a.crsShortOutcome,
	a.crsoutcometext
	
	
FROM
	CrsOutcome_maps_DODobjective a
)

GO

CREATE PROCEDURE [dbo].[sp_Report_DOD_CourseOutcome] 
AS 
(
SELECT 
	K1.key1ID
	,K1.courseid + '.' + CAST(k1.SequenceNumber as Varchar(50)) As CourseOutcome,
	REPLACE(k1.crsoutcometext,(K1.courseid + '.' + CAST(k1.SequenceNumber as Varchar(50))),'') AS CrsText
	,k1.crsoutcometext As CourseText
	,RIGHT(LEFT(k2.dodobjectivenumvalue,6),5) AS dodObjectiveNum,
	SUBSTRING(k2.dodobjectivenumvalue,8,len(k2.dodobjectivenumvalue)) AS ObjectiveName
FROM
	KEY1  k1
		LEFT OUTER JOIN DodMapsCourseOutcome d  on d.key1id = k1.key1id
		LEFT OUTER JOIN key2 k2 on k2.key2id = d.key2id
)

GO


CREATE PROCEDURE [dbo].[sp_Report_Skill_SubSkill] 
AS 
(
SELECT 
	
	k3.key3id,
	k3.SkillsName,
	k3.SubskillTitle
		
FROM
	key3 k3
)

GO


CREATE Procedure [dbo].[sp_Report_SKills_CourseOutcome] 
AS 
(
SELECT 
	K1.key1ID
	,K1.courseid + '.' + CAST(k1.SequenceNumber as Varchar(50)) As CourseOutcome,
	REPLACE(k1.crsoutcometext,(K1.courseid + '.' + CAST(k1.SequenceNumber as Varchar(50))),'') AS CrsText
	,k1.crsoutcometext As CourseText
	,k3.SkillsName AS SKillsName
	,k3.SubskillTitle 
	
FROM
	KEY1  k1
		LEFT OUTER JOIN SubskillMapsCourseOutcome d  on d.key1id = k1.key1id
		LEFT OUTER JOIN key3 k3 on k3.key3id = d.key3id
)
GO

CREATE Procedure [dbo].[sp_Report_Subskills_CourseOutcome] 
AS 
(
SELECT 
	k1.key1id,
	k3.key3id,
	k3.SubskillTitle,
	k1.crsoutcometext As CourseText

	
FROM
	KEY1  k1
		LEFT OUTER JOIN SubskillMapsCourseOutcome d  on d.key1id = k1.key1id
		LEFT OUTER JOIN key3 k3 on k3.key3id = d.key3id
)

GO



