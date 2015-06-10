GO
/****** Object:  Table [dbo].[tbl_WeiXin_YongHu]    Script Date: 01/16/2015 10:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_WeiXin_YongHu](
	[yonghuid] [char](36) NOT NULL,
	[subscribe] [nvarchar](50) NOT NULL,
	[openid] [nvarchar](50) NULL,
	[nickname] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[province] [nvarchar](50) NULL,
	[language] [nvarchar](50) NULL,
	[headimgurl] [nvarchar](255) NULL,
	[subscribe_time] [nvarchar](50) NULL,
	[unionid] [nvarchar](50) NULL,
	[createtime] [datetime] NOT NULL,
	[latesttime] [datetime] NOT NULL,
	[leixing] [int] NOT NULL,
 CONSTRAINT [PK_TBL_WEIXIN_YONGHU] PRIMARY KEY CLUSTERED 
(
	[yonghuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号（内部）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'yonghuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'subscribe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户的标识，对当前公众号唯一 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'openid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户的昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户的性别，值为1时是男性，值为2时是女性，值为0时是未知 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户所在城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户所在国家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'country'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户所在省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户的语言，简体中文为zh_CN ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'language'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'headimgurl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'subscribe_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'unionid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'createtime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'latesttime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu', @level2type=N'COLUMN',@level2name=N'leixing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信用户信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiXin_YongHu'
GO
/****** Object:  StoredProcedure [dbo].[proc_WeiXin_YongHu_CU]    Script Date: 01/16/2015 10:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2014-01-14
-- Description:	微信用户新增、修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_WeiXin_YongHu_CU]
	@yonghuid CHAR(36)
	,@subscribe NVARCHAR(50)
	,@openid NVARCHAR(50)
	,@nickname NVARCHAR(50)
	,@sex NVARCHAR(50)
	,@city NVARCHAR(50)
	,@country NVARCHAR(50)
	,@province NVARCHAR(50)
	,@language NVARCHAR(50)
	,@headimgurl NVARCHAR(50)
	,@subscribe_time  NVARCHAR(50)
	,@unionid NVARCHAR(50)
	,@createtime DATETIME
	,@latesttime DATETIME
	,@retcode INT OUTPUT
	,@leixing INT
AS
BEGIN
	SET @retcode=0
	DECLARE @FS CHAR(1)
	
	SET @FS='C'

	IF EXISTS(SELECT 1 FROM tbl_WeiXin_YongHu WHERE openid=@openid)
	BEGIN
		SET @FS='U'
	END	
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_WeiXin_YongHu]([yonghuid],[subscribe],[openid]
			,[nickname],[sex],[city]
			,[country],[province],[language]
			,[headimgurl],[subscribe_time],[unionid]
			,[createtime],[latesttime],[leixing])
		VALUES(@yonghuid,@subscribe,@openid
			,@nickname,@sex,@city
			,@country,@province,@language
			,@headimgurl,@subscribe_time,@unionid
			,@createtime,@latesttime,@leixing)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_WeiXin_YongHu] SET [subscribe]=@subscribe,[nickname]=@nickname
			,[sex]=@sex,[city]=@city
			,[country]=@country,[province]=@province
			,[language]=@language,[headimgurl]=@headimgurl
			,[subscribe_time]=@subscribe_time,[latesttime]=@latesttime
			,[unionid]=@unionid
		WHERE [openid]=@openid
	END	
	
	SET @retcode=1
	RETURN @retcode
END
GO
/****** Object:  Default [DF__tbl_WeiXi__subsc__6ABAD62E]    Script Date: 01/16/2015 10:53:30 ******/
ALTER TABLE [dbo].[tbl_WeiXin_YongHu] ADD  CONSTRAINT [DF__tbl_WeiXi__subsc__6ABAD62E]  DEFAULT ('0') FOR [subscribe]
GO
/****** Object:  Default [DF__tbl_WeiXi__creat__6BAEFA67]    Script Date: 01/16/2015 10:53:30 ******/
ALTER TABLE [dbo].[tbl_WeiXin_YongHu] ADD  CONSTRAINT [DF__tbl_WeiXi__creat__6BAEFA67]  DEFAULT (getdate()) FOR [createtime]
GO
/****** Object:  Default [DF__tbl_WeiXi__lates__6CA31EA0]    Script Date: 01/16/2015 10:53:30 ******/
ALTER TABLE [dbo].[tbl_WeiXin_YongHu] ADD  CONSTRAINT [DF__tbl_WeiXi__lates__6CA31EA0]  DEFAULT (getdate()) FOR [latesttime]
GO
/****** Object:  Default [DF_tbl_WeiXin_YongHu_leixing]    Script Date: 01/16/2015 10:53:30 ******/
ALTER TABLE [dbo].[tbl_WeiXin_YongHu] ADD  CONSTRAINT [DF_tbl_WeiXin_YongHu_leixing]  DEFAULT ((0)) FOR [leixing]
GO
--以上日志已更新 汪奇志 01 16 2015 10:54AM
GO


EXECUTE sp_rename N'dbo.tbl_WeiXin_YongHu.leixing', N'Tmp_LeiXing', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.tbl_WeiXin_YongHu.Tmp_LeiXing', N'LeiXing', 'COLUMN' 
GO
ALTER TABLE dbo.tbl_WeiXin_YongHu ADD
	HuiYuanId char(36) NOT NULL CONSTRAINT DF_tbl_WeiXin_YongHu_HuiYuanId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'会员编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WeiXin_YongHu', N'COLUMN', N'HuiYuanId'
GO

EXECUTE sp_rename N'dbo.tbl_WeiXin_YongHu.yonghuid', N'Tmp_YongHuId_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.tbl_WeiXin_YongHu.Tmp_YongHuId_1', N'YongHuId', 'COLUMN' 
GO
ALTER TABLE dbo.tbl_WeiXin_YongHu ADD
	BangDingTime datetime NOT NULL CONSTRAINT DF_tbl_WeiXin_YongHu_BangDingTime DEFAULT getdate()
GO
DECLARE @v sql_variant 
SET @v = N'绑定时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WeiXin_YongHu', N'COLUMN', N'BangDingTime'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2014-01-14
-- Description:	微信用户新增、修改
-- =============================================
ALTER PROCEDURE [dbo].[proc_WeiXin_YongHu_CU]
	@YongHuId CHAR(36)
	,@subscribe NVARCHAR(50)
	,@openid NVARCHAR(50)
	,@nickname NVARCHAR(50)
	,@sex NVARCHAR(50)
	,@city NVARCHAR(50)
	,@country NVARCHAR(50)
	,@province NVARCHAR(50)
	,@language NVARCHAR(50)
	,@headimgurl NVARCHAR(50)
	,@subscribe_time  NVARCHAR(50)
	,@unionid NVARCHAR(50)
	,@createtime DATETIME
	,@latesttime DATETIME
	,@RetCode INT OUTPUT
	,@LeiXing INT
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS CHAR(1)
	
	SET @FS='C'

	IF EXISTS(SELECT 1 FROM tbl_WeiXin_YongHu WHERE openid=@openid)
	BEGIN
		SET @FS='U'
	END	
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_WeiXin_YongHu]([YongHuId],[subscribe],[openid]
			,[nickname],[sex],[city]
			,[country],[province],[language]
			,[headimgurl],[subscribe_time],[unionid]
			,[createtime],[latesttime],[LeiXing]
			,[HuiYuanId],[BangDingTime])
		VALUES(@YongHuId,@subscribe,@openid
			,@nickname,@sex,@city
			,@country,@province,@language
			,@headimgurl,@subscribe_time,@unionid
			,@createtime,@latesttime,@LeiXing
			,'',@createtime)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_WeiXin_YongHu] SET [subscribe]=@subscribe,[nickname]=@nickname
			,[sex]=@sex,[city]=@city
			,[country]=@country,[province]=@province
			,[language]=@language,[headimgurl]=@headimgurl
			,[subscribe_time]=@subscribe_time,[latesttime]=@latesttime
			,[unionid]=@unionid
		WHERE [openid]=@openid
	END	
	
	SET @RetCode=1
	RETURN @RetCode
END
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-16
-- Description:	绑定会员
-- =============================================
CREATE PROCEDURE proc_WeiXin_BangDingHuiYuan
	@YongHuId CHAR(36)
	,@openid NVARCHAR(50)
	,@U NVARCHAR(50)
	,@P NVARCHAR(50)
	,@RetCode INT OUTPUT
	,@HuiYuanId NVARCHAR(50) OUTPUT
AS
BEGIN
	SET @RetCode=0
	SET @HuiYuanId=''
	
	IF NOT EXISTS(SELECT 1 FROM tbl_WeiXin_YongHu WHERE YongHuId=@YongHuId AND openid=@openid)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @HuiYuanId=HuiYuanId FROM tbl_WeiXin_YongHu WHERE YongHuId=@YongHuId AND openid=@openid
	
	IF(@HuiYuanId IS NOT NULL AND LEN(@HuiYuanId)>0)
	BEGIN
		SET @RetCode=1
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE UserName=@U AND UserPwd=@P)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	SELECT @HuiYuanId=UserID FROM tbl_Member WHERE UserName=@U AND UserPwd=@P
	
	UPDATE tbl_WeiXin_YongHu SET HuiYuanId=@HuiYuanId WHERE YongHuId=@YongHuId AND openid=@openid	
	
	SET @RetCode=1
	RETURN @RetCode
END
GO

CREATE TABLE [dbo].[tbl_WeiDian](
	[WeiDianId] [char](36) NOT NULL,
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[HuiYuanId] [char](36) NOT NULL,
	[MingCheng] [nvarchar](255) NULL,
	[Status] [int] NOT NULL,
	[ShenQingTime] [datetime] NOT NULL,
	[ShenHeTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_WEIDIAN] PRIMARY KEY CLUSTERED 
(
	[WeiDianId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'WeiDianId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'HuiYuanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微店名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'MingCheng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微店状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'ShenQingTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian', @level2type=N'COLUMN',@level2name=N'ShenHeTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微店信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDian'
GO
/****** Object:  Default [DF__tbl_WeiDi__Statu__753864A1]    Script Date: 01/16/2015 16:45:02 ******/
ALTER TABLE [dbo].[tbl_WeiDian] ADD  CONSTRAINT [DF__tbl_WeiDi__Statu__753864A1]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF__tbl_WeiDi__ShenQ__762C88DA]    Script Date: 01/16/2015 16:45:02 ******/
ALTER TABLE [dbo].[tbl_WeiDian] ADD  CONSTRAINT [DF__tbl_WeiDi__ShenQ__762C88DA]  DEFAULT (getdate()) FOR [ShenQingTime]
GO
/****** Object:  Default [DF__tbl_WeiDi__ShenH__7720AD13]    Script Date: 01/16/2015 16:45:02 ******/
ALTER TABLE [dbo].[tbl_WeiDian] ADD  CONSTRAINT [DF__tbl_WeiDi__ShenH__7720AD13]  DEFAULT (getdate()) FOR [ShenHeTime]
GO
--以上日志已更新 汪奇志 01 16 2015  5:35PM
GO

ALTER TABLE dbo.tbl_WeiDian ADD
	JieShao nvarchar(MAX) NULL
GO
DECLARE @v sql_variant 
SET @v = N'微店介绍'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WeiDian', N'COLUMN', N'JieShao'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-19
-- Description:	微店新增修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_WeiDian_CU]
	@WeiDianId CHAR(36)
	,@HuiYuanId CHAR(36)
	,@MingCheng NVARCHAR(255)
	,@Status INT
	,@ShenQingTime DATETIME
	,@ShenHeTime DATETIME
	,@JieShao NVARCHAR(MAX)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS CHAR(1)
	DECLARE @YuanStatus INT
	SET @FS='C'
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE UserId=@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_WeiDian WHERE HuiYuanId=@HuiYuanId AND WeiDianId<>@WeiDianId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_WeiDian WHERE WeiDianId=@WeiDianId)
	BEGIN
		SET @FS='U'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_WeiDian]([WeiDianId],[HuiYuanId],[MingCheng]
			,[Status],[ShenQingTime],[ShenHeTime]
			,[JieShao])
		VALUES(@WEiDianId,@HuiYuanId,@MingCheng
			,@Status,@ShenQingTime,@ShenHeTime
			,@JieShao)
	END
	
	IF(@FS='U')
	BEGIN
		SELECT @YuanStatus=[Status] FROM tbl_WeiDian WHERE WeiDianId=@WeiDianId
		UPDATE [tbl_WeiDian] SET [MingCheng]=@MingCheng,[JieShao]=@JieShao
		WHERE WeiDianId=@WeiDianId
		
		IF(@YuanStatus=0 AND @Status=1)
		BEGIN
			UPDATE [tbl_WeiDian] SET [Status]=@Status,[ShenHeTime]=@ShenHeTime
			WHERE WeiDianId=@WeiDianId
		END
	END
		
	SET @RetCode=1
	RETURN @RetCode
END
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-01-20
-- Description:	微店信息
-- =============================================
CREATE VIEW [view_WeiDian]
AS
SELECT A.[WeiDianId]
	,A.[IdentityId]
	,A.[HuiYuanId]
	,A.[MingCheng]
	,A.[Status]
	,A.[ShenQingTime]
	,A.[ShenHeTime]
	,A.[JieShao]
	,B.UserName AS YongHuMing
	,B.ContactName AS HuiYuanName
FROM [tbl_WeiDian] AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId=B.UserId
GO

ALTER TABLE dbo.tbl_Member ADD
	WeiXinHao nvarchar(255) NULL,
	GoSiName nvarchar(255) NULL,
	ZhiWei nvarchar(255) NULL,
	ShouJi nvarchar(255) NULL,
	TuXiangFilepath nvarchar(255) NULL,
	QQ nvarchar(255) NULL,
	YouXiang nvarchar(255) NULL,
	DiZhi nvarchar(255) NULL,
	IsLvYouGuWen char(1) NOT NULL CONSTRAINT DF_tbl_Member_IsLvYouGuWen DEFAULT 0,
	GuWenRenZhengTime datetime NOT NULL CONSTRAINT DF_tbl_Member_GuWenRenZhengTime DEFAULT getdate()
GO
DECLARE @v sql_variant 
SET @v = N'微信号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'WeiXinHao'
GO
DECLARE @v sql_variant 
SET @v = N'公司名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'GoSiName'
GO
DECLARE @v sql_variant 
SET @v = N'职位'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'ZhiWei'
GO
DECLARE @v sql_variant 
SET @v = N'手机'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'ShouJi'
GO
DECLARE @v sql_variant 
SET @v = N'图像'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'TuXiangFilepath'
GO
DECLARE @v sql_variant 
SET @v = N'QQ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'QQ'
GO
DECLARE @v sql_variant 
SET @v = N'邮箱'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'YouXiang'
GO
DECLARE @v sql_variant 
SET @v = N'地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'DiZhi'
GO
DECLARE @v sql_variant 
SET @v = N'是否旅游顾问'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'IsLvYouGuWen'
GO
DECLARE @v sql_variant 
SET @v = N'旅游顾问认证时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'GuWenRenZhengTime'
GO
EXECUTE sp_rename N'dbo.tbl_Member.GoSiName', N'Tmp_GongSiName', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.tbl_Member.Tmp_GongSiName', N'GongSiName', 'COLUMN' 
GO

EXECUTE sp_rename N'dbo.tbl_Member.GuWenRenZhengTime', N'Tmp_LvYouGuWenRenZhengTime_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.tbl_Member.Tmp_LvYouGuWenRenZhengTime_1', N'LvYouGuWenRenZhengTime', 'COLUMN' 
GO

ALTER TABLE dbo.tbl_Member ADD
	ZanJiShu int NOT NULL CONSTRAINT DF_tbl_Member_ZanJiShu DEFAULT 0,
	GuanZhuJiShu int NOT NULL CONSTRAINT DF_tbl_Member_GuanZhuJiShu DEFAULT 0,
	LiuYanJiShu int NOT NULL CONSTRAINT DF_tbl_Member_LiuYanJiShu DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'赞计数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'ZanJiShu'
GO
DECLARE @v sql_variant 
SET @v = N'关注计数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'GuanZhuJiShu'
GO
DECLARE @v sql_variant 
SET @v = N'留言计数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'LiuYanJiShu'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-21
-- Description:	会员新增、修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_HuiYuan_CU]
	@HuiYuanId CHAR(36)--会员编号
	,@YongHuMing NVARCHAR(255)--用户名
	,@MiMa NVARCHAR(50)--密码
	,@MiMaMD5 NVARCHAR(50)--MD5密码
	,@XingMing NVARCHAR(50)--姓名
	,@XingBie TINYINT--性别
	,@BeiZhu NVARCHAR(MAX)--备注
	,@IssueTime DATETIME--操作时间
	,@FanYong MONEY--返佣
	,@IsDaiLi CHAR(1)--是否代理
	,@ZhuCeMa NVARCHAR(50)--注册码
	,@TuiGuangMa NVARCHAR(50)--推广码
	,@IsYanZheng CHAR(1)--是否通过验证
	,@YuE MONEY--余额
	,@IsYunXuZhuanZhang CHAR(1)--是否允许转账
	,@WeiXinHao NVARCHAR(255)--微信号
	,@GongSiName NVARCHAR(255)--公司名称
	,@ZhiWei NVARCHAR(255)--职位
	,@ShouJi NVARCHAR(255)--手机
	,@TuXiangFilepath NVARCHAR(255)--图像文件路径
	,@QQ NVARCHAR(255)--QQ
	,@YouXiang NVARCHAR(255)--邮箱
	,@DiZhi NVARCHAR(255)--地址
	,@IsLvYouGuWen CHAR(1)--是否旅游顾问
	,@LvYouGuWenRenZhengTime DATETIME--旅游顾认证时间
	,@RetCode INT OUTPUT--返回值
AS
BEGIN
	DECLARE @FS CHAR(1)
	DECLARE @YuanIsLvYouGuWen CHAR(1)
	SET @FS='C'
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserName=@YongHuMing AND UserID<>@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserId=@HuiYuanId)
	BEGIN
		SET @FS='U'
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE PromotionCode=@ZhuCeMa)
	BEGIN
		SET @ZhuCeMa=''
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_Member]([UserID],[UserName],[UserPwd]
			,[ContactName],[ContactSex],[Remark]
			,[IssueTime],[CommissonScale],[IsAgent]
			,[PollCode],[PromotionCode],[valiUser]
			,[YuE],[IsZZ],[WeiXinHao]
			,[GongSiName],[ZhiWei],[ShouJi]
			,[TuXiangFilepath],[QQ],[YouXiang]
			,[DiZhi],[IsLvYouGuWen],[LvYouGuWenRenZhengTime])
		VALUES(@HuiYuanId,@YongHuMing,@MiMa
			,@XingMing,@XingBie,@BeiZhu
			,@IssueTime,@FanYong,@IsDaiLi
			,@ZhuCeMa,@TuiGuangMa,@IsYanZheng
			,@YuE,@IsYunXuZhuanZhang,@WeiXinHao
			,@GongSiName,@ZhiWei,@ShouJi
			,@TuXiangFilepath,@QQ,@YouXiang
			,@DiZhi,@IsLvYouGuWen,@LvYouGuWenRenZhengTime)
	END
	
	IF(@FS='U')
	BEGIN
		SELECT @YuanIsLvYouGuWen=IsLvYouGuWen FROM tbl_Member WHERE UserID=@HuiYuanId
	
		UPDATE tbl_Member SET ContactName=@XingMing,ContactSex=@XingBie
			,Remark=@BeiZhu,CommissonScale=@FanYong
			,IsAgent=@IsDaiLi,PollCode=@ZhuCeMa
			,PromotionCode=@TuiGuangMa,valiUser=@IsYanZheng
			,IsZZ=@IsYunXuZhuanZhang,WeiXinHao=@WeiXinHao
			,GongSiName=@GongSiName,ZhiWei=@ZhiWei
			,ShouJi=@ShouJi,TuXiangFilepath=@TuXiangFilepath
			,QQ=@QQ,YouXiang=@YouXiang
			,DiZhi=@DiZhi
		WHERE UserId=@HuiYuanId
		
		IF(@YuanIsLvYouGuWen=0 AND @IsLvYouGuWen=1)
		BEGIN
			UPDATE tbl_Member SET IsLvYouGuWen=@IsLvYouGuWen,LvYouGuWenRenZhengTime=@LvYouGuWenRenZhengTime
			WHERE UserId=@HuiYuanId
		END
	END
	
	SET @RetCode=1
	RETURN @RetCode
END

GO
--以上日志已更新 汪奇志 01 22 2015  9:47AM
GO

ALTER TABLE dbo.tbl_Member ADD
	MingPianId char(36) NOT NULL CONSTRAINT DF_tbl_Member_MingPianId DEFAULT newid()
GO
DECLARE @v sql_variant 
SET @v = N'名片编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Member', N'COLUMN', N'MingPianId'
GO
--以上日志已更新 汪奇志 02  3 2015 11:40AM
GO

GO
/****** Object:  Table [dbo].[tbl_HuiYuanDianZan]    Script Date: 02/04/2015 13:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HuiYuanDianZan](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[HuiYuanId1] [char](36) NOT NULL,
	[HuiYuanId2] [char](36) NOT NULL,
	[IssueTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_HUIYUANDIANZAN] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanDianZan', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanDianZan', @level2type=N'COLUMN',@level2name=N'HuiYuanId1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanDianZan', @level2type=N'COLUMN',@level2name=N'HuiYuanId2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanDianZan', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员点赞信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanDianZan'
GO
/****** Object:  Table [dbo].[tbl_HuiYuanGuanZhu]    Script Date: 02/04/2015 13:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HuiYuanGuanZhu](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[HuiYuanId1] [char](26) NOT NULL,
	[HuiYuanId2] [char](36) NOT NULL,
	[IssueTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_HUIYUANGUANZHU] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'HuiYuanId1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'HuiYuanId2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员关注信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu'
GO
/****** Object:  Table [dbo].[tbl_HuiYuanLiuYan]    Script Date: 02/04/2015 13:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HuiYuanLiuYan](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[HuiYuanId1] [char](36) NOT NULL,
	[HuiYuanId2] [char](36) NOT NULL,
	[LiuYanNeiRong] [nvarchar](max) NULL,
	[LiuYanTime] [datetime] NOT NULL,
	[HuiFuNeiRong] [nvarchar](max) NULL,
	[HuiFuTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_HUIYUANLIUYAN] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'HuiYuanId1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'HuiYuanId2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'LiuYanNeiRong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'LiuYanTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'HuiFuNeiRong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan', @level2type=N'COLUMN',@level2name=N'HuiFuTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员留言信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanLiuYan'
GO
/****** Object:  StoredProcedure [dbo].[proc_HuiYuan_GuanXi_Sync]    Script Date: 02/04/2015 13:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员关系数据同步
-- =============================================
CREATE PROCEDURE [dbo].[proc_HuiYuan_GuanXi_Sync]
	@HuiYuanId CHAR(36)
AS
BEGIN	
	DECLARE @ZanJiShu INT
	DECLARE @GuanZhuJiShu INT
	DECLARE @LiuYanJiShu INT
	
	SELECT @ZanJiShu=COUNT(*) FROM tbl_HuiYuanDianZan WHERE HuiYuanId1=@HuiYuanId
	SELECT @GuanZhuJiShu=COUNT(*) FROM tbl_HuiYuanGuanZhu WHERE HuiYuanId1=@HuiYuanId
	SELECT @LiuYanJiShu=COUNT(*) FROM tbl_HuiYuanLiuYan WHERE HuiYuanId1=@HuiYuanId
	
	UPDATE tbl_Member SET ZanJiShu=@ZanJiShu,GuanZhuJiShu=@GuanZhuJiShu,LiuYanJiShu=@LiuYanJiShu
	WHERE UserID=@HuiYuanId
	
END
GO
/****** Object:  View [dbo].[view_HuiYuan_DianZan]    Script Date: 02/04/2015 13:59:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员点赞信息视图
-- =============================================
CREATE VIEW [dbo].[view_HuiYuan_DianZan]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[IssueTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
FROM tbl_HuiYuanDianZan AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId
GO
/****** Object:  View [dbo].[view_HuiYuan_GuanZhu]    Script Date: 02/04/2015 13:59:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员关注信息视图
-- =============================================
CREATE VIEW [dbo].[view_HuiYuan_GuanZhu]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[IssueTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
FROM tbl_HuiYuanGuanZhu AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId
GO
/****** Object:  View [dbo].[view_HuiYuan_LiuYan]    Script Date: 02/04/2015 13:59:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员留言信息视图
-- =============================================
CREATE VIEW [dbo].[view_HuiYuan_LiuYan]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[LiuYanNeiRong]
	,A.[LiuYanTime]
	,A.[HuiFuNeiRong]
	,A.[HuiFuTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
FROM tbl_HuiYuanLiuYan AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId
GO
/****** Object:  StoredProcedure [dbo].[proc_HuiYuan_DianZan_CUD]    Script Date: 02/04/2015 13:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员点赞新增、修改、删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_HuiYuan_DianZan_CUD]
	@IdentityId INT
	,@HuiYuanId1 CHAR(36)
	,@HuiYuanId2 CHAR(36)
	,@IssueTime DATETIME
	,@FS CHAR(1)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM tbl_HuiYuanDianZan WHERE HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2)
	BEGIN
		IF(@FS IN('C','U')) SET @FS='U'
	END
	ELSE
	BEGIN
		SET @FS='C'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_HuiYuanDianZan]([HuiYuanId1],[HuiYuanId2],[IssueTime])
		VALUES(@HuiYuanId1,@HuiYuanId2,@IssueTime)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_HuiYuanDianZan] SET [IssueTime]=@IssueTime WHERE HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='D')
	BEGIN
		DELETE FROM [tbl_HuiYuanDianZan] WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	EXEC proc_HuiYuan_GuanXi_Sync @HuiYuanId=@HuiYuanId2
	
	SET @RetCode=1		
	RETURN @RetCode	
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HuiYuan_LiuYan_CUD]    Script Date: 02/04/2015 13:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员留言新增、修改、删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_HuiYuan_LiuYan_CUD]
	@IdentityId INT
	,@HuiYuanId1 CHAR(36)
	,@HuiYuanId2 CHAR(36)
	,@LiuYanNeiRong NVARCHAR(MAX)
	,@LiuYanTime DATETIME
	,@HuiFuNeiRong NVARCHAR(MAX)
	,@HuiFuTime DATETIME
	,@FS CHAR(1)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM tbl_HuiYuanGuanZhu WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2)
	BEGIN
		IF(@FS IN('C','U')) SET @FS='U'
		IF(@FS NOT IN('C','U','D','H')) SET @FS='U'
	END
	ELSE
	BEGIN
		SET @FS='C'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_HuiYuanLiuYan]([HuiYuanId1],[HuiYuanId2],[LiuYanNeiRong]
			,[LiuYanTime],[HuiFuNeiRong],[HuiFuTime])
		VALUES(@HuiYuanId1,@HuiYuanId2,@LiuYanNeiRong
			,@LiuYanTime,@HuiFuNeiRong,@HuiFuTime)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_HuiYuanLiuYan] SET [LiuYanNeiRong]=@LiuYanNeiRong,LiuYanTime=@LiuYanTime
			,[HuiFuNeiRong]=@HuiFuNeiRong,[HuiFuTime]=@HuiFuTime
		WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='H')
	BEGIN
		UPDATE [tbl_HuiYuanLiuYan] SET [HuiFuNeiRong]=@HuiFuNeiRong,[HuiFuTime]=@HuiFuTime
		WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='D')
	BEGIN
		DELETE FROM  [tbl_HuiYuanLiuYan] WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	EXEC proc_HuiYuan_GuanXi_Sync @HuiYuanId=@HuiYuanId2
	
	SET @RetCode=1		
	RETURN @RetCode	
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HuiYuan_GuanZhu_CUD]    Script Date: 02/04/2015 13:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员关注新增、修改、删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_HuiYuan_GuanZhu_CUD]
	@IdentityId INT
	,@HuiYuanId1 CHAR(36)
	,@HuiYuanId2 CHAR(36)
	,@IssueTime DATETIME
	,@FS CHAR(1)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM tbl_HuiYuanGuanZhu WHERE HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2)
	BEGIN
		IF(@FS IN('C','U')) SET @FS='U'
	END
	ELSE
	BEGIN
		SET @FS='C'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO tbl_HuiYuanGuanZhu([HuiYuanId1],[HuiYuanId2],[IssueTime])
		VALUES(@HuiYuanId1,@HuiYuanId2,@IssueTime)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE tbl_HuiYuanGuanZhu SET [IssueTime]=@IssueTime WHERE HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='D')
	BEGIN
		DELETE FROM tbl_HuiYuanGuanZhu WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	EXEC proc_HuiYuan_GuanXi_Sync @HuiYuanId=@HuiYuanId2
	
	SET @RetCode=1		
	RETURN @RetCode	
END
GO
/****** Object:  Default [DF__tbl_HuiYu__Issue__02925FBF]    Script Date: 02/04/2015 13:59:34 ******/
ALTER TABLE [dbo].[tbl_HuiYuanDianZan] ADD  CONSTRAINT [DF__tbl_HuiYu__Issue__02925FBF]  DEFAULT (getdate()) FOR [IssueTime]
GO
/****** Object:  Default [DF__tbl_HuiYu__Issue__056ECC6A]    Script Date: 02/04/2015 13:59:34 ******/
ALTER TABLE [dbo].[tbl_HuiYuanGuanZhu] ADD  CONSTRAINT [DF__tbl_HuiYu__Issue__056ECC6A]  DEFAULT (getdate()) FOR [IssueTime]
GO
/****** Object:  Default [DF__tbl_HuiYu__LiuYa__084B3915]    Script Date: 02/04/2015 13:59:34 ******/
ALTER TABLE [dbo].[tbl_HuiYuanLiuYan] ADD  CONSTRAINT [DF__tbl_HuiYu__LiuYa__084B3915]  DEFAULT (getdate()) FOR [LiuYanTime]
GO
/****** Object:  Default [DF__tbl_HuiYu__HuiFu__093F5D4E]    Script Date: 02/04/2015 13:59:34 ******/
ALTER TABLE [dbo].[tbl_HuiYuanLiuYan] ADD  CONSTRAINT [DF__tbl_HuiYu__HuiFu__093F5D4E]  DEFAULT (getdate()) FOR [HuiFuTime]
GO

--以上日志已更新 汪奇志 02  4 2015  2:01PM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员关系数据同步
-- =============================================
ALTER PROCEDURE [dbo].[proc_HuiYuan_GuanXi_Sync]
	@HuiYuanId CHAR(36)
AS
BEGIN	
	DECLARE @ZanJiShu INT
	DECLARE @GuanZhuJiShu INT
	DECLARE @LiuYanJiShu INT
	
	SELECT @ZanJiShu=COUNT(*) FROM tbl_HuiYuanDianZan WHERE HuiYuanId2=@HuiYuanId
	SELECT @GuanZhuJiShu=COUNT(*) FROM tbl_HuiYuanGuanZhu WHERE HuiYuanId2=@HuiYuanId
	SELECT @LiuYanJiShu=COUNT(*) FROM tbl_HuiYuanLiuYan WHERE HuiYuanId2=@HuiYuanId
	
	UPDATE tbl_Member SET ZanJiShu=@ZanJiShu,GuanZhuJiShu=@GuanZhuJiShu,LiuYanJiShu=@LiuYanJiShu
	WHERE UserID=@HuiYuanId
	
END
GO

GO
/****** Object:  Table [dbo].[tbl_HuiYuanGuanZhu]    Script Date: 02/04/2015 14:57:12 ******/
ALTER TABLE [dbo].[tbl_HuiYuanGuanZhu] DROP CONSTRAINT [DF__tbl_HuiYu__Issue__15A53433]
GO
DROP TABLE [dbo].[tbl_HuiYuanGuanZhu]
GO
/****** Object:  Table [dbo].[tbl_HuiYuanGuanZhu]    Script Date: 02/04/2015 14:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HuiYuanGuanZhu](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[HuiYuanId1] [char](36) NOT NULL,
	[HuiYuanId2] [char](36) NOT NULL,
	[IssueTime] [datetime] NOT NULL CONSTRAINT [DF__tbl_HuiYu__Issue__15A53433]  DEFAULT (getdate()),
 CONSTRAINT [PK_TBL_HUIYUANGUANZHU] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'HuiYuanId1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对方会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'HuiYuanId2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员关注信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HuiYuanGuanZhu'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-03
-- Description:	会员留言新增、修改、删除
-- =============================================
ALTER PROCEDURE [dbo].[proc_HuiYuan_LiuYan_CUD]
	@IdentityId INT
	,@HuiYuanId1 CHAR(36)
	,@HuiYuanId2 CHAR(36)
	,@LiuYanNeiRong NVARCHAR(MAX)
	,@LiuYanTime DATETIME
	,@HuiFuNeiRong NVARCHAR(MAX)
	,@HuiFuTime DATETIME
	,@FS CHAR(1)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM [tbl_HuiYuanLiuYan] WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2)
	BEGIN
		IF(@FS IN('C','U')) SET @FS='U'
		IF(@FS NOT IN('C','U','D','H')) SET @FS='U'
	END
	ELSE
	BEGIN
		SET @FS='C'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_HuiYuanLiuYan]([HuiYuanId1],[HuiYuanId2],[LiuYanNeiRong]
			,[LiuYanTime],[HuiFuNeiRong],[HuiFuTime])
		VALUES(@HuiYuanId1,@HuiYuanId2,@LiuYanNeiRong
			,@LiuYanTime,@HuiFuNeiRong,@HuiFuTime)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_HuiYuanLiuYan] SET [LiuYanNeiRong]=@LiuYanNeiRong,LiuYanTime=@LiuYanTime
			,[HuiFuNeiRong]=@HuiFuNeiRong,[HuiFuTime]=@HuiFuTime
		WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='H')
	BEGIN
		UPDATE [tbl_HuiYuanLiuYan] SET [HuiFuNeiRong]=@HuiFuNeiRong,[HuiFuTime]=@HuiFuTime
		WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	IF(@FS='D')
	BEGIN
		DELETE FROM  [tbl_HuiYuanLiuYan] WHERE IdentityId=@IdentityId AND HuiYuanId1=@HuiYuanId1 AND HuiYuanId2=@HuiYuanId2
	END
	
	EXEC proc_HuiYuan_GuanXi_Sync @HuiYuanId=@HuiYuanId2
	
	SET @RetCode=1		
	RETURN @RetCode	
END
GO
--以上日志已更新 汪奇志 02  4 2015  3:34PM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员留言信息视图
-- =============================================
ALTER VIEW [dbo].[view_HuiYuan_LiuYan]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[LiuYanNeiRong]
	,A.[LiuYanTime]
	,A.[HuiFuNeiRong]
	,A.[HuiFuTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
	,B.MingPianId AS MingPianId1
	,C.MingPianId AS MingPianId2
FROM tbl_HuiYuanLiuYan AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员关注信息视图
-- =============================================
ALTER VIEW [dbo].[view_HuiYuan_GuanZhu]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[IssueTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
	,B.MingPianId AS MingPianId1
	,C.MingPianId AS MingPianId2
FROM tbl_HuiYuanGuanZhu AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId

GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-03
-- Description:	会员点赞信息视图
-- =============================================
ALTER VIEW [dbo].[view_HuiYuan_DianZan]
AS
SELECT A.[IdentityId]
	,A.[HuiYuanId1]
	,A.[HuiYuanId2]
	,A.[IssueTime]
	,B.[ContactName] AS HuiYuanXingMing1
	,B.[TuXiangFilepath] AS HuiYuanTuXiangFilepath1
	,C.[ContactName] AS HuiYuanXingMing2
	,C.[TuXiangFilepath] AS HuiYuanTuXiangFilepath2
	,B.MingPianId AS MingPianId1
	,C.MingPianId AS MingPianId2
FROM tbl_HuiYuanDianZan AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId1=B.UserID INNER JOIN tbl_Member AS C
ON A.HuiYuanId2=C.UserId

GO
--以上日志已更新 汪奇志 02  6 2015 10:59AM
GO

ALTER TABLE dbo.tbl_WeiDian ADD
	LogoFilepath nvarchar(255) NULL,
	DianHua nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'微店logo'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WeiDian', N'COLUMN', N'LogoFilepath'
GO
DECLARE @v sql_variant 
SET @v = N'微店电话'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WeiDian', N'COLUMN', N'DianHua'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-19
-- Description:	微店新增修改
-- =============================================
ALTER PROCEDURE [dbo].[proc_WeiDian_CU]
	@WeiDianId CHAR(36)
	,@HuiYuanId CHAR(36)
	,@MingCheng NVARCHAR(255)
	,@Status INT
	,@ShenQingTime DATETIME
	,@ShenHeTime DATETIME
	,@JieShao NVARCHAR(MAX)
	,@RetCode INT OUTPUT
	,@LogoFilepath NVARCHAR(255)
	,@DianHua NVARCHAR(255)
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS CHAR(1)
	DECLARE @YuanStatus INT
	SET @FS='C'
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE UserId=@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_WeiDian WHERE HuiYuanId=@HuiYuanId AND WeiDianId<>@WeiDianId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_WeiDian WHERE WeiDianId=@WeiDianId)
	BEGIN
		SET @FS='U'
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_WeiDian]([WeiDianId],[HuiYuanId],[MingCheng]
			,[Status],[ShenQingTime],[ShenHeTime]
			,[JieShao],[LogoFilepath],[DianHua])
		VALUES(@WEiDianId,@HuiYuanId,@MingCheng
			,@Status,@ShenQingTime,@ShenHeTime
			,@JieShao,@LogoFilepath,@DianHua)
	END
	
	IF(@FS='U')
	BEGIN
		SELECT @YuanStatus=[Status] FROM tbl_WeiDian WHERE WeiDianId=@WeiDianId
		UPDATE [tbl_WeiDian] SET [MingCheng]=@MingCheng,[JieShao]=@JieShao
			,LogoFilepath=@LogoFilepath,DianHua=@DianHua
		WHERE WeiDianId=@WeiDianId
		
		IF(@YuanStatus=0 AND @Status=1)
		BEGIN
			UPDATE [tbl_WeiDian] SET [Status]=@Status,[ShenHeTime]=@ShenHeTime
			WHERE WeiDianId=@WeiDianId
		END
	END
		
	SET @RetCode=1
	RETURN @RetCode
END
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-01-20
-- Description:	微店信息
-- =============================================
ALTER VIEW [dbo].[view_WeiDian]
AS
SELECT A.[WeiDianId]
	,A.[IdentityId]
	,A.[HuiYuanId]
	,A.[MingCheng]
	,A.[Status]
	,A.[ShenQingTime]
	,A.[ShenHeTime]
	,A.[JieShao]
	,B.UserName AS YongHuMing
	,B.ContactName AS HuiYuanName
	,A.LogoFilepath
	,A.DianHua
FROM [tbl_WeiDian] AS A INNER JOIN tbl_Member AS B
ON A.HuiYuanId=B.UserId

GO

ALTER TABLE dbo.tbl_Order ADD
	WeiDianId char(36) NOT NULL CONSTRAINT DF_tbl_Order_WeiDianId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'微店编号（标识在该微店下单）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Order', N'COLUMN', N'WeiDianId'
GO

ALTER  PROCEDURE [dbo].[proc_Order_Add]
	@OrderID CHAR(36)
	,@ProductID CHAR(36)
	,@OrderCode NVARCHAR(50) OUTPUT
	,@MemberID CHAR(36)
	,@MemberName NVARCHAR(50)
	,@MemberTel NVARCHAR(50)
	,@MemberSex TINYINT
	,@OrderState TINYINT
	,@PayState TINYINT
	,@IsCheck CHAR(1)
	,@ConfirmCode NVARCHAR(50)
	,@Remark NVARCHAR(max)
	,@OrderPrice MONEY
	,@PeopleNum INT
	,@Result INT OUTPUT
	,@WeiDianId CHAR(36)
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	DECLARE @LiuShuiHiao INT
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM [tbl_Order]
	SET @OrderCode=CONVERT(VARCHAR(8),GETDATE(),112)+'8'+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)
	
	begin tran
	IF(@error=0)
	BEGIN
		INSERT INTO tbl_Order (OrderID,ProductID,OrderCode
			,MemberID,MemberName,MemberTel
			,MemberSex,OrderState,PayState
			,IsCheck,ConfirmCode,Remark
			,IssueTime,OrderPrice,PeopleNum
			,WeiDianId)
		VALUES (@OrderID,@ProductID,@OrderCode
			,@MemberID,@MemberName,@MemberTel
			,@MemberSex,@OrderState,@PayState
			,@IsCheck,@ConfirmCode,@Remark
			,GETDATE(),@OrderPrice,@PeopleNum
			,@WeiDianId)
          SET @error=@error+@@ERROR
           
	END	
	
	IF(@error=0)
	BEGIN
		UPDATE tbl_Product SET ControlPeople=ControlPeople-@PeopleNum WHERE ProductID=@ProductID
	END
	
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	end
END
GO

ALTER TABLE dbo.tbl_PlanTicket ADD
	WeiDianId char(36) NOT NULL CONSTRAINT DF_tbl_PlanTicket_WeiDianId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'微店编号（标识在该微店下单）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanTicket', N'COLUMN', N'WeiDianId'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_WeiDianChanPinGuanXi](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[WeiDianId] [char](36) NOT NULL,
	[HuiYuanId] [char](36) NOT NULL,
	[ChanPinId] [char](36) NOT NULL,
	[IssueTime] [datetime] NOT NULL,
	[PaiXuId] [int] NOT NULL,
 CONSTRAINT [PK_TBL_WEIDIANCHANPINGUANXI] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'WeiDianId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'HuiYuanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'ChanPinId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi', @level2type=N'COLUMN',@level2name=N'PaiXuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员微店产品关系信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_WeiDianChanPinGuanXi'
GO
/****** Object:  StoredProcedure [dbo].[proc_WeiDian_ChanPinGuanXi_CD]    Script Date: 02/09/2015 11:29:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-02-06
-- Description:	微店产品关系新增、删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_WeiDian_ChanPinGuanXi_CD]
	@WeiDianId CHAR(36)
	,@HuiYuanId CHAR(36)
	,@GuanXiId INT
	,@ChanPinId CHAR(36)
	,@CaoZuoTime DATETIME
	,@FS CHAR(1)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_WeiDian WHERE WeiDianId=@WeiDianId AND HuiYuanId=@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF(@FS='C' AND EXISTS(SELECT 1 FROM tbl_WeiDianChanPinGuanXi WHERE WeiDianId=@WeiDianId AND HuiYuanId=@HuiYuanId AND ChanPinId=@ChanPinId))
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END	
	
	IF(@FS='D' AND NOT EXISTS(SELECT 1 FROM tbl_WeiDianChanPinGuanXi WHERE WeiDianId=@WeiDianId AND HuiYuanId=@HuiYuanId AND IdentityId=@GuanXiId AND ChanPinId=@ChanPinId))
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END	
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_WeiDianChanPinGuanXi]([WeiDianId],[HuiYuanId],[ChanPinId]
			,[IssueTime],[PaiXuId])
		VALUES(@WeiDianId,@HuiYuanId,@ChanPinId
		,@CaoZuoTIme,0)
	END
	
	IF(@FS='D')
	BEGIN
		DELETE FROM tbl_WeiDianChanPinGuanXi WHERE WeiDianId=@WeiDianId AND HuiYuanId=@HuiYuanId AND IdentityId=@GuanXiId AND ChanPinId=@ChanPinId
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  View [dbo].[view_WeiDian_ChanPin]    Script Date: 02/09/2015 11:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-06
-- Description:	微店产品信息
-- =============================================
CREATE VIEW [dbo].[view_WeiDian_ChanPin]
AS
SELECT A.[IdentityId]
	,A.[WeiDianId]
	,A.[HuiYuanId]
	,A.[ChanPinId]
	,A.[IssueTime]
	,A.[PaiXuId]
	,B.ProductName AS ChanPinName
	,(SELECT TOP 1 A1.Filepath FROM tbl_Attach AS A1 WHERE A1.ItemId=A.ChanPinId) AS ChanPinTuPianFilepath

FROM tbl_WeiDianChanPinGuanXi AS A INNER JOIN [tbl_Product] AS B
ON A.ChanPinId=B.ProductID
GO
/****** Object:  Default [DF__tbl_WeiDi__Issue__1C5231C2]    Script Date: 02/09/2015 11:29:18 ******/
ALTER TABLE [dbo].[tbl_WeiDianChanPinGuanXi] ADD  CONSTRAINT [DF__tbl_WeiDi__Issue__1C5231C2]  DEFAULT (getdate()) FOR [IssueTime]
GO
/****** Object:  Default [DF__tbl_WeiDi__PaiXu__1D4655FB]    Script Date: 02/09/2015 11:29:18 ******/
ALTER TABLE [dbo].[tbl_WeiDianChanPinGuanXi] ADD  CONSTRAINT [DF__tbl_WeiDi__PaiXu__1D4655FB]  DEFAULT ((0)) FOR [PaiXuId]
GO
--以上日志已更新 汪奇志 02  9 2015 11:40AM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-06
-- Description:	微店产品信息
-- =============================================
ALTER VIEW [dbo].[view_WeiDian_ChanPin]
AS
SELECT A.[IdentityId]
	,A.[WeiDianId]
	,A.[HuiYuanId]
	,A.[ChanPinId]
	,A.[IssueTime]
	,A.[PaiXuId]
	,B.ProductName AS ChanPinName
	,(SELECT TOP 1 A1.Filepath FROM tbl_Attach AS A1 WHERE A1.ItemId=A.ChanPinId) AS ChanPinTuPianFilepath
	,B.MarketPrice AS ShiChangJiaGe
	,B.AppPrice AS JieSuanJiaGe
	,B.TourDate AS ChuTuanRiQi
	,B.IsEveryDay AS IsTianTianFaTuan
	,(SELECT COUNT(*) FROM tbl_Comment AS A1 WHERE A1.ProductID=A.ChanPinId) AS PingLunJiShu
FROM tbl_WeiDianChanPinGuanXi AS A INNER JOIN [tbl_Product] AS B
ON A.ChanPinId=B.ProductID

GO
--以上日志已更新 汪奇志 02  9 2015  5:45PM
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-06
-- Description:	微店产品信息
-- =============================================
ALTER VIEW [dbo].[view_WeiDian_ChanPin]
AS
SELECT A.[IdentityId]
	,A.[WeiDianId]
	,A.[HuiYuanId]
	,A.[ChanPinId]
	,A.[IssueTime]
	,A.[PaiXuId]
	,B.ProductName AS ChanPinName
	,(SELECT TOP 1 A1.Filepath FROM tbl_Attach AS A1 WHERE A1.ItemId=A.ChanPinId) AS ChanPinTuPianFilepath
	,B.MarketPrice AS ShiChangJiaGe
	,B.AppPrice AS JieSuanJiaGe
	,B.TourDate AS ChuTuanRiQi
	,B.IsEveryDay AS IsTianTianFaTuan
	,(SELECT COUNT(*) FROM tbl_Comment AS A1 WHERE A1.ProductID=A.ChanPinId) AS PingLunJiShu
	,B.ProductType AS ChanPinLeiXing
FROM tbl_WeiDianChanPinGuanXi AS A INNER JOIN [tbl_Product] AS B
ON A.ChanPinId=B.ProductID
GO
--以上日志已更新 汪奇志 02 10 2015 10:34AM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 205-02-10
-- Description:	微店订单信息
-- =============================================
CREATE VIEW [dbo].[view_WeiDian_DingDan]
AS
SELECT A.OrderId AS DingDanId
	,A.ProductId AS ChanPinId
	,A.OrderCode AS JiaoYiHao
	,A.MemberId AS XiaDanRenId
	,A.OrderState AS DingDanStatus
	,A.PayState AS ZhiFuStatus
	,A.IsCheck AS ShenHeStatus
	,A.ConSumState AS XiaoFeiStatus
	,ISNULL(A.OrderPrice,0) AS JinE
	,A.IssueTime AS XiaDanTime
	,A.WeiDianId
	,B.ProductName AS ChanPinName
	,(SELECT TOP 1 A1.Filepath FROM tbl_Attach AS A1 WHERE A1.ItemId=A.ProductId) AS ChanPinTuPianFilepath

FROM tbl_Order AS A INNER JOIN tbl_Product AS B
ON A.ProductID=B.ProductID
GO
--以上日志已更新 汪奇志 02 10 2015  4:20PM
GO
ALTER TABLE dbo.tbl_User ADD
	LeiXing int NOT NULL CONSTRAINT DF_tbl_User_LeiXing DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'用户类型'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_User', N'COLUMN', N'LeiXing'
GO

ALTER TABLE dbo.tbl_Product ADD
	FaBuRenId char(36) NOT NULL CONSTRAINT DF_tbl_Product_FaBuRenId DEFAULT '',
	ShenHeStatus int NOT NULL CONSTRAINT DF_tbl_Product_ShenHeStatus DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'发布人编号（标识是否是供应商产品）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Product', N'COLUMN', N'FaBuRenId'
GO
DECLARE @v sql_variant 
SET @v = N'审核状态'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Product', N'COLUMN', N'ShenHeStatus'
GO

ALTER PROCEDURE [dbo].[Proc_Product_Add]
	@ProductID NVARCHAR(36)
	,@ProductName NVARCHAR(50)
	,@ProductType int
	,@TourDate datetime
	,@MarketPrice MONEY
	,@AppPrice MONEY
	,@FavourCode NVARCHAR(50)
	,@LinkTel NVARCHAR(50)
	,@ProductDis NVARCHAR(MAX)
	,@TourDis NVARCHAR(MAX)
	,@SendTourKnow NVARCHAR(MAX)
	,@ValidiDate DATETIME
	,@ProductState TINYINT
	,@ComAttachXML xml--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size="" IsWebImage="" /></ROOT>
	,@IsEveryDay CHAR(1)
	,@IsHot TINYINT
	,@ServiceQQ NVARCHAR(50)
	,@ContractType TINYINT
	,@ControlPeople INT
	,@ProductOpState TINYINT
	,@ProductSdate DATETIME
	,@ZCodeViaDate DATETIME   
	,@PType INT
	,@Scompare NVARCHAR(max)
	,@result INT OUTPUT
	,@FaBuRenId CHAR(36)
	,@ShenHeStatus INT
AS
BEGIN
	declare @error int ,@doc int
	set @error=0
	set @Result=0
	begin tran
	
	if(@ComAttachXML is not null)
	begin
	exec sp_xml_preparedocument @doc output,@ComAttachXML
		insert into tbl_Attach(ItemId,[Name],FilePath,[Size],IsWebImage)
		select ItemId,[Name],FilePath,[Size],IsWebImage
		from openxml(@doc,N'/ROOT/ComAttach',1)
		WITH(ItemId char(36),[Name] nvarchar(255),FilePath nvarchar(255),[Size] INT,IsWebImage CHAR(1))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	END
	
	IF(@error=0)
	BEGIN
		INSERT INTO tbl_Product(ProductID,ProductName,ProductType
			,TourDate,MarketPrice,AppPrice
			,FavourCode,LinkTel,ProductDis
			,TourDis,SendTourKnow,ValidiDate
			,ProductState,IsEveryDay,IsHot
			,CreateDate,ServiceQQ,ContractType
			,ControlPeople,ProductOpState,ProductSdate
			,ZCodeViaDate,PType,Scompare
			,FaBuRenId,ShenHeStatus)
		VALUES(@ProductID,@ProductName,@ProductType
			,@TourDate,@MarketPrice,@AppPrice
			,@FavourCode,@LinkTel,@ProductDis
			,@TourDis,@SendTourKnow,@ValidiDate
			,@ProductState,@IsEveryDay,@IsHot
			,GETDATE(),@ServiceQQ,@ContractType
			,@ControlPeople,@ProductOpState,@ProductSdate
			,@ZCodeViaDate,@PType,@Scompare
			,@FaBuRenId,@ShenHeStatus)
		SET @error=@error+@@ERROR           
	END	
	
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	END
END
GO

ALTER PROCEDURE [dbo].[Proc_Product_Update]
	@ProductID CHAR(36)
	,@ProductName NVARCHAR(50)
	,@ProductType int
	,@TourDate datetime
	,@MarketPrice MONEY
	,@AppPrice MONEY
	,@FavourCode NVARCHAR(50)
	,@LinkTel NVARCHAR(50)
	,@ProductDis NVARCHAR(MAX)
	,@TourDis NVARCHAR(MAX)
	,@SendTourKnow NVARCHAR(MAX)
	,@ValidiDate DATETIME
	,@ProductState TINYINT
	,@ComAttachXML xml--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
	,@IsEveryDay CHAR(1)    
	,@IsHot TINYINT
	,@ServiceQQ NVARCHAR(50)
	,@ContractType TINYINT 
	,@ControlPeople INT
	,@ProductOpState TINYINT
	,@ProductSdate DATETIME
	,@ZCodeViaDate DATETIME
	,@Scompare NVARCHAR(max)
	,@result INT OUTPUT
	,@FaBuRenId CHAR(36)
	,@ShenHeStatus INT
AS
BEGIN
	declare @error int ,@doc int
	set @error=0
	set @Result=0
	begin TRAN
	
	delete from tbl_Attach where   ItemId=@ProductID
	set @error=@error+@@error
	
	if(@ComAttachXML is not null)
	begin
	exec sp_xml_preparedocument @doc output,@ComAttachXML
		insert into tbl_Attach(ItemId,[Name],FilePath,[Size],IsWebImage)
		select ItemId,[Name],FilePath,[Size],IsWebImage
		from openxml(@doc,N'/ROOT/ComAttach',1)
		WITH(ItemId char(36),[Name] nvarchar(255),FilePath nvarchar(255),[Size] INT,IsWebImage CHAR(1))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	END
	
	IF(@error=0)
	BEGIN
		UPDATE tbl_Product  
		SET  ProductName = @ProductName,ProductType = @ProductType
			,TourDate = @TourDate,MarketPrice = @MarketPrice
			,AppPrice = @AppPrice,FavourCode = @FavourCode
			,LinkTel = @LinkTel,ProductDis = @ProductDis
			,TourDis = @TourDis,SendTourKnow = @SendTourKnow
			,ValidiDate = @ValidiDate,ProductState = @ProductState
			,IsEveryDay=@IsEveryDay,IsHot=@IsHot
			,ServiceQQ=@ServiceQQ,ContractType=@ContractType
			,ControlPeople=@ControlPeople,ProductOpState=@ProductOpState
			,ProductSdate=@ProductSdate,ZCodeViaDate=@ZCodeViaDate
			,Scompare=@Scompare 
		WHERE ProductID=@ProductID
        SET @error=@error+@@ERROR           
	END	
	
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	end
END
GO

ALTER view [dbo].[view_Product]
AS
SELECT a.ProductID
	,a.ProductName
	,a.ProductType 
	,a.TourDate
	,a.MarketPrice
	,a.AppPrice
	,a.FavourCode 
	,a.LinkTel
	,a.ProductDis
	,a.TourDis
	,a.SendTourKnow
	,a.ValidiDate
	,a.ProductState
	,a.IsEveryDay
	,a.IsHot
	,a.CreateDate
	,a.ServiceQQ
	,a.ContractType
	,a.ControlPeople
	,ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum
	,ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum
	,b.AdminName
	,a.ProductOpState
	,a.ProductSdate
	,a.ZCodeViaDate
	,a.PType
	,a.Scompare
	,b.XianLu
	,A.FaBuRenId
	,A.ShenHeStatus
FROM         
dbo.tbl_Product AS a LEFT  JOIN dbo.tbl_ProductType AS b 
ON b.TypeID = a.ProductType
GO

ALTER view [dbo].[view_Product]
AS
SELECT a.ProductID
	,a.ProductName
	,a.ProductType 
	,a.TourDate
	,a.MarketPrice
	,a.AppPrice
	,a.FavourCode 
	,a.LinkTel
	,a.ProductDis
	,a.TourDis
	,a.SendTourKnow
	,a.ValidiDate
	,a.ProductState
	,a.IsEveryDay
	,a.IsHot
	,a.CreateDate
	,a.ServiceQQ
	,a.ContractType
	,a.ControlPeople
	,ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum
	,ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum
	,b.AdminName
	,a.ProductOpState
	,a.ProductSdate
	,a.ZCodeViaDate
	,a.PType
	,a.Scompare
	,b.XianLu
	,A.FaBuRenId
	,A.ShenHeStatus
	,(SELECT A1.ContactName FROM tbl_User AS A1 WHERE A1.UserId=A.FaBuRenId) AS FaBuRenName
FROM         
dbo.tbl_Product AS a LEFT  JOIN dbo.tbl_ProductType AS b 
ON b.TypeID = a.ProductType
GO

ALTER PROCEDURE [dbo].[Proc_Product_Update]
	@ProductID CHAR(36)
	,@ProductName NVARCHAR(50)
	,@ProductType int
	,@TourDate datetime
	,@MarketPrice MONEY
	,@AppPrice MONEY
	,@FavourCode NVARCHAR(50)
	,@LinkTel NVARCHAR(50)
	,@ProductDis NVARCHAR(MAX)
	,@TourDis NVARCHAR(MAX)
	,@SendTourKnow NVARCHAR(MAX)
	,@ValidiDate DATETIME
	,@ProductState TINYINT
	,@ComAttachXML xml--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
	,@IsEveryDay CHAR(1)    
	,@IsHot TINYINT
	,@ServiceQQ NVARCHAR(50)
	,@ContractType TINYINT 
	,@ControlPeople INT
	,@ProductOpState TINYINT
	,@ProductSdate DATETIME
	,@ZCodeViaDate DATETIME
	,@Scompare NVARCHAR(max)
	,@result INT OUTPUT
	,@FaBuRenId CHAR(36)
	,@ShenHeStatus INT
AS
BEGIN
	declare @error int ,@doc int
	set @error=0
	set @Result=0
	DECLARE @YuanShenHeStatus INT
	
	SELECT @YuanShenHeStatus=ShenHeStatus FROM tbl_Product WHERE ProductId=@ProductID
	
	begin TRAN
	
	delete from tbl_Attach where   ItemId=@ProductID
	set @error=@error+@@error
	
	if(@ComAttachXML is not null)
	begin
	exec sp_xml_preparedocument @doc output,@ComAttachXML
		insert into tbl_Attach(ItemId,[Name],FilePath,[Size],IsWebImage)
		select ItemId,[Name],FilePath,[Size],IsWebImage
		from openxml(@doc,N'/ROOT/ComAttach',1)
		WITH(ItemId char(36),[Name] nvarchar(255),FilePath nvarchar(255),[Size] INT,IsWebImage CHAR(1))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	END
	
	IF(@error=0)
	BEGIN
		UPDATE tbl_Product  
		SET  ProductName = @ProductName,ProductType = @ProductType
			,TourDate = @TourDate,MarketPrice = @MarketPrice
			,AppPrice = @AppPrice,FavourCode = @FavourCode
			,LinkTel = @LinkTel,ProductDis = @ProductDis
			,TourDis = @TourDis,SendTourKnow = @SendTourKnow
			,ValidiDate = @ValidiDate,ProductState = @ProductState
			,IsEveryDay=@IsEveryDay,IsHot=@IsHot
			,ServiceQQ=@ServiceQQ,ContractType=@ContractType
			,ControlPeople=@ControlPeople,ProductOpState=@ProductOpState
			,ProductSdate=@ProductSdate,ZCodeViaDate=@ZCodeViaDate
			,Scompare=@Scompare 
		WHERE ProductID=@ProductID
        SET @error=@error+@@ERROR     
        
        IF(@YuanShenHeStatus=0 AND @ShenHeStatus=1)
        BEGIN
			UPDATE tbl_Product SET ShenHeStatus=@ShenHeStatus WHERE ProductID=@ProductID
        END      
	END	
	
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	end
END
GO

ALTER view [dbo].[view_Order]
as
SELECT A.OrderId
	,A.ProductID
	,A.AvailNum
	,(select ProductName from tbl_Product where ProductID=A.ProductID) as ProductName
	,(select TourDate from tbl_Product where ProductID=A.ProductID) as TourDate
	,(select FavourCode from tbl_Product where ProductID=A.ProductID) as FavourCode
	,(select IsEveryDay from tbl_Product where ProductID=A.ProductID) as isEvery
	,(select ProductType from tbl_Product where ProductID=A.ProductID) as ProductType
	,(select ContractType from tbl_Product where ProductID=A.ProductID) as ContractType
	,(select ProductOpState from dbo.tbl_Product where ProductID=A.ProductID)AS ProductOpState
	,(select ProductSdate from dbo.tbl_Product where ProductID=A.ProductID)AS ProductSdate
	,(select ZCodeViaDate from dbo.tbl_Product where ProductID=A.ProductID)AS ZCodeViaDate
	,(select PType from dbo.tbl_Product where ProductID=A.ProductID)AS PType
	,(select PollCode from tbl_Member where UserID=A.MemberID) as PollCode
	,(select PromotionCode from tbl_Member where UserID=A.MemberID) as PromotionCode
	,((select CommissonScale from tbl_Member where UserID=A.MemberID)/100*OrderPrice)AS fyje
	,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=A.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
	,A.OrderCode
	,A.MemberID
	,A.MemberName
	,MemberTel
	,A.MemberSex
	,A.OrderState
	,A.PayState
	,A.IsCheck
	,A.ConfirmCode
	,A.Remark
	,A.IssueTime
	,A.OrderPrice
	,A.PeopleNum
	,A.ContractText
	,A.IsealCheck
	,A.AddressID
	,A.RebackMoney
	,(((select CommissonScale from tbl_Member where UserID=A.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	,A.ConSumState
	,(select UserName from tbl_Member where UserID=A.AppUserId) as AppUserName
	,A.AppUserId
	,A.AppTime
	,A.JState
	,B.FaBuRenId AS ChanPinFaBuRenId
FROM tbl_Order AS A INNER JOIN tbl_Product AS B
ON A.ProductID=B.ProductID
GO

ALTER  PROCEDURE [dbo].[proc_Order_Add]
	@OrderID CHAR(36)
	,@ProductID CHAR(36)
	,@OrderCode NVARCHAR(50) OUTPUT
	,@MemberID CHAR(36)
	,@MemberName NVARCHAR(50)
	,@MemberTel NVARCHAR(50)
	,@MemberSex TINYINT
	,@OrderState TINYINT
	,@PayState TINYINT
	,@IsCheck CHAR(1)
	,@ConfirmCode NVARCHAR(50)
	,@Remark NVARCHAR(max)
	,@OrderPrice MONEY
	,@PeopleNum INT
	,@Result INT OUTPUT
	,@WeiDianId CHAR(36)
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	DECLARE @LiuShuiHiao INT
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM [tbl_Order]
	SET @OrderCode=CONVERT(VARCHAR(8),GETDATE(),112)+'8'+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)
	
	IF(@WeiDianId IS NULL)
	BEGIN
		SET @WeiDianId=''
	END
	
	begin tran
	IF(@error=0)
	BEGIN
		INSERT INTO tbl_Order (OrderID,ProductID,OrderCode
			,MemberID,MemberName,MemberTel
			,MemberSex,OrderState,PayState
			,IsCheck,ConfirmCode,Remark
			,IssueTime,OrderPrice,PeopleNum
			,WeiDianId)
		VALUES (@OrderID,@ProductID,@OrderCode
			,@MemberID,@MemberName,@MemberTel
			,@MemberSex,@OrderState,@PayState
			,@IsCheck,@ConfirmCode,@Remark
			,GETDATE(),@OrderPrice,@PeopleNum
			,@WeiDianId)
          SET @error=@error+@@ERROR
           
	END	
	
	IF(@error=0)
	BEGIN
		UPDATE tbl_Product SET ControlPeople=ControlPeople-@PeopleNum WHERE ProductID=@ProductID
	END
	
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	end
END
GO

ALTER view [dbo].[view_Order]
as
SELECT A.OrderId
	,A.ProductID
	,A.AvailNum
	,(select ProductName from tbl_Product where ProductID=A.ProductID) as ProductName
	,(select TourDate from tbl_Product where ProductID=A.ProductID) as TourDate
	,(select FavourCode from tbl_Product where ProductID=A.ProductID) as FavourCode
	,(select IsEveryDay from tbl_Product where ProductID=A.ProductID) as isEvery
	,(select ProductType from tbl_Product where ProductID=A.ProductID) as ProductType
	,(select ContractType from tbl_Product where ProductID=A.ProductID) as ContractType
	,(select ProductOpState from dbo.tbl_Product where ProductID=A.ProductID)AS ProductOpState
	,(select ProductSdate from dbo.tbl_Product where ProductID=A.ProductID)AS ProductSdate
	,(select ZCodeViaDate from dbo.tbl_Product where ProductID=A.ProductID)AS ZCodeViaDate
	,(select PType from dbo.tbl_Product where ProductID=A.ProductID)AS PType
	,(select PollCode from tbl_Member where UserID=A.MemberID) as PollCode
	,(select PromotionCode from tbl_Member where UserID=A.MemberID) as PromotionCode
	,((select CommissonScale from tbl_Member where UserID=A.MemberID)/100*OrderPrice)AS fyje
	,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=A.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
	,A.OrderCode
	,A.MemberID
	,A.MemberName
	,MemberTel
	,A.MemberSex
	,A.OrderState
	,A.PayState
	,A.IsCheck
	,A.ConfirmCode
	,A.Remark
	,A.IssueTime
	,A.OrderPrice
	,A.PeopleNum
	,A.ContractText
	,A.IsealCheck
	,A.AddressID
	,A.RebackMoney
	,(((select CommissonScale from tbl_Member where UserID=A.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	,A.ConSumState
	,(select UserName from tbl_Member where UserID=A.AppUserId) as AppUserName
	,A.AppUserId
	,A.AppTime
	,A.JState
	,B.FaBuRenId AS ChanPinFaBuRenId
	,(SELECT A1.MingCheng FROM tbl_WeiDian AS A1 WHERE A1.WeiDianId=A.WeidianId) AS WeiDianName
FROM tbl_Order AS A INNER JOIN tbl_Product AS B
ON A.ProductID=B.ProductID
GO
--以上日志已更新 汪奇志 02 12 2015 10:46AM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-16
-- Description:	绑定会员
-- =============================================
ALTER PROCEDURE [dbo].[proc_WeiXin_BangDingHuiYuan]
	@YongHuId CHAR(36)
	,@openid NVARCHAR(50)
	,@U NVARCHAR(50)
	,@P NVARCHAR(50)
	,@RetCode INT OUTPUT
	,@HuiYuanId NVARCHAR(50) OUTPUT
AS
BEGIN
	SET @RetCode=0
	SET @HuiYuanId=''
	
	IF NOT EXISTS(SELECT 1 FROM tbl_WeiXin_YongHu WHERE YongHuId=@YongHuId AND openid=@openid)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @HuiYuanId=HuiYuanId FROM tbl_WeiXin_YongHu WHERE YongHuId=@YongHuId AND openid=@openid
	
	IF(@HuiYuanId IS NOT NULL AND LEN(@HuiYuanId)>0)
	BEGIN
		SET @RetCode=1
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE UserName=@U AND UserPwd=@P)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	SELECT @HuiYuanId=UserID FROM tbl_Member WHERE UserName=@U AND UserPwd=@P
	
	IF EXISTS(SELECT 1 FROM tbl_WeiXin_YongHu WHERE HuiYuanId=@HuiYuanId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	UPDATE tbl_WeiXin_YongHu SET HuiYuanId=@HuiYuanId WHERE YongHuId=@YongHuId AND openid=@openid	
	
	SET @RetCode=1
	RETURN @RetCode
END

GO
--以上日志已更新 汪奇志 02 14 2015  2:31PM
GO




alter table tbl_ProductType alter column AdminName nvarchar(1000) 
GO

update tbl_ProductType SET AdminName='[{"AdminN":"'+AdminName+'"}]'
GO

alter table tbl_Member add MemberOption int default -1 not null
GO

alter table tbl_Member add DianZanTime datetime default getdate() not null
GO
alter table tbl_Member add LiuYanTime datetime default getdate() not null
GO
alter table tbl_Member add GuanZhuTime datetime default getdate() not null
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-21
-- Description:	会员新增、修改
-- =============================================
ALTER PROCEDURE [dbo].[proc_HuiYuan_CU]
	@HuiYuanId CHAR(36)--会员编号
	,@YongHuMing NVARCHAR(255)--用户名
	,@MiMa NVARCHAR(50)--密码
	,@MiMaMD5 NVARCHAR(50)--MD5密码
	,@XingMing NVARCHAR(50)--姓名
	,@XingBie TINYINT--性别
	,@BeiZhu NVARCHAR(MAX)--备注
	,@IssueTime DATETIME--操作时间
	,@FanYong MONEY--返佣
	,@IsDaiLi CHAR(1)--是否代理
	,@ZhuCeMa NVARCHAR(50)--注册码
	,@TuiGuangMa NVARCHAR(50)--推广码
	,@IsYanZheng CHAR(1)--是否通过验证
	,@YuE MONEY--余额
	,@IsYunXuZhuanZhang CHAR(1)--是否允许转账
	,@WeiXinHao NVARCHAR(255)--微信号
	,@GongSiName NVARCHAR(255)--公司名称
	,@ZhiWei NVARCHAR(255)--职位
	,@ShouJi NVARCHAR(255)--手机
	,@TuXiangFilepath NVARCHAR(255)--图像文件路径
	,@QQ NVARCHAR(255)--QQ
	,@YouXiang NVARCHAR(255)--邮箱
	,@DiZhi NVARCHAR(255)--地址
	,@IsLvYouGuWen CHAR(1)--是否旅游顾问
	,@LvYouGuWenRenZhengTime DATETIME--旅游顾认证时间
	,@RetCode INT OUTPUT--返回值
AS
BEGIN
	DECLARE @FS CHAR(1)
	DECLARE @YuanIsLvYouGuWen CHAR(1)
	SET @FS='C'
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserName=@YongHuMing AND UserID<>@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserId=@HuiYuanId)
	BEGIN
		SET @FS='U'
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE PromotionCode=@ZhuCeMa)
	BEGIN
		SET @ZhuCeMa=''
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_Member]([UserID],[UserName],[UserPwd]
			,[ContactName],[ContactSex],[Remark]
			,[IssueTime],[CommissonScale],[IsAgent]
			,[PollCode],[PromotionCode],[valiUser]
			,[YuE],[IsZZ],[WeiXinHao]
			,[GongSiName],[ZhiWei],[ShouJi]
			,[TuXiangFilepath],[QQ],[YouXiang]
			,[DiZhi],[IsLvYouGuWen],[LvYouGuWenRenZhengTime])
		VALUES(@HuiYuanId,@YongHuMing,@MiMa
			,@XingMing,@XingBie,@BeiZhu
			,@IssueTime,@FanYong,@IsDaiLi
			,@ZhuCeMa,@TuiGuangMa,@IsYanZheng
			,@YuE,@IsYunXuZhuanZhang,@WeiXinHao
			,@GongSiName,@ZhiWei,@ShouJi
			,@TuXiangFilepath,@QQ,@YouXiang
			,@DiZhi,@IsLvYouGuWen,@LvYouGuWenRenZhengTime)
	END
	
	IF(@FS='U')
	BEGIN
		SELECT @YuanIsLvYouGuWen=IsLvYouGuWen FROM tbl_Member WHERE UserID=@HuiYuanId
	
		UPDATE tbl_Member SET ContactName=@XingMing,ContactSex=@XingBie
			,Remark=@BeiZhu,CommissonScale=@FanYong
			,IsAgent=@IsDaiLi,PollCode=@ZhuCeMa
			,PromotionCode=@TuiGuangMa,valiUser=@IsYanZheng
			,IsZZ=@IsYunXuZhuanZhang,WeiXinHao=@WeiXinHao
			,GongSiName=@GongSiName,ZhiWei=@ZhiWei
			,ShouJi=@ShouJi,TuXiangFilepath=@TuXiangFilepath
			,QQ=@QQ,YouXiang=@YouXiang
			,DiZhi=@DiZhi
		WHERE UserId=@HuiYuanId
		
		IF(@YuanIsLvYouGuWen=0 AND @IsLvYouGuWen=1)
		BEGIN
			UPDATE tbl_Member SET IsLvYouGuWen=@IsLvYouGuWen,LvYouGuWenRenZhengTime=@LvYouGuWenRenZhengTime
			WHERE UserId=@HuiYuanId
		END
        IF(@YuanIsLvYouGuWen=1 AND @IsLvYouGuWen=0)
		BEGIN
			UPDATE tbl_Member SET IsLvYouGuWen=@IsLvYouGuWen WHERE UserId=@HuiYuanId
		END
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



alter table tbl_Member add ProviceId int default 0 not null
GO
alter table tbl_Member add CityId int default 0 not null
GO
alter table tbl_Member add AreaId int default 0 not null
GO
alter table tbl_Member add StreetId int default 0 not null
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-01-21
-- Description:	会员新增、修改
-- =============================================
ALTER PROCEDURE [dbo].[proc_HuiYuan_CU]
	@HuiYuanId CHAR(36)--会员编号
	,@YongHuMing NVARCHAR(255)--用户名
	,@MiMa NVARCHAR(50)--密码
	,@MiMaMD5 NVARCHAR(50)--MD5密码
	,@XingMing NVARCHAR(50)--姓名
	,@XingBie TINYINT--性别
	,@BeiZhu NVARCHAR(MAX)--备注
	,@IssueTime DATETIME--操作时间
	,@FanYong MONEY--返佣
	,@IsDaiLi CHAR(1)--是否代理
	,@ZhuCeMa NVARCHAR(50)--注册码
	,@TuiGuangMa NVARCHAR(50)--推广码
	,@IsYanZheng CHAR(1)--是否通过验证
	,@YuE MONEY--余额
	,@IsYunXuZhuanZhang CHAR(1)--是否允许转账
	,@WeiXinHao NVARCHAR(255)--微信号
	,@GongSiName NVARCHAR(255)--公司名称
	,@ZhiWei NVARCHAR(255)--职位
	,@ShouJi NVARCHAR(255)--手机
	,@TuXiangFilepath NVARCHAR(255)--图像文件路径
	,@QQ NVARCHAR(255)--QQ
	,@YouXiang NVARCHAR(255)--邮箱
	,@DiZhi NVARCHAR(255)--地址
	,@IsLvYouGuWen CHAR(1)--是否旅游顾问
	,@LvYouGuWenRenZhengTime DATETIME--旅游顾认证时间
    ,@ProviceId int
    ,@CityId int
    ,@AreaId int
    ,@StreetId int
	,@RetCode INT OUTPUT--返回值
AS
BEGIN
	DECLARE @FS CHAR(1)
	DECLARE @YuanIsLvYouGuWen CHAR(1)
	SET @FS='C'
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserName=@YongHuMing AND UserID<>@HuiYuanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserId=@HuiYuanId)
	BEGIN
		SET @FS='U'
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Member WHERE PromotionCode=@ZhuCeMa)
	BEGIN
		SET @ZhuCeMa=''
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_Member]([UserID],[UserName],[UserPwd]
			,[ContactName],[ContactSex],[Remark]
			,[IssueTime],[CommissonScale],[IsAgent]
			,[PollCode],[PromotionCode],[valiUser]
			,[YuE],[IsZZ],[WeiXinHao]
			,[GongSiName],[ZhiWei],[ShouJi]
			,[TuXiangFilepath],[QQ],[YouXiang]
			,[DiZhi],[IsLvYouGuWen],[LvYouGuWenRenZhengTime])
		VALUES(@HuiYuanId,@YongHuMing,@MiMa
			,@XingMing,@XingBie,@BeiZhu
			,@IssueTime,@FanYong,@IsDaiLi
			,@ZhuCeMa,@TuiGuangMa,@IsYanZheng
			,@YuE,@IsYunXuZhuanZhang,@WeiXinHao
			,@GongSiName,@ZhiWei,@ShouJi
			,@TuXiangFilepath,@QQ,@YouXiang
			,@DiZhi,@IsLvYouGuWen,@LvYouGuWenRenZhengTime)
	END
	
	IF(@FS='U')
	BEGIN
		SELECT @YuanIsLvYouGuWen=IsLvYouGuWen FROM tbl_Member WHERE UserID=@HuiYuanId
	
		UPDATE tbl_Member SET ContactName=@XingMing,ContactSex=@XingBie
			,Remark=@BeiZhu,CommissonScale=@FanYong
			,IsAgent=@IsDaiLi,PollCode=@ZhuCeMa
			,PromotionCode=@TuiGuangMa,valiUser=@IsYanZheng
			,IsZZ=@IsYunXuZhuanZhang,WeiXinHao=@WeiXinHao
			,GongSiName=@GongSiName,ZhiWei=@ZhiWei
			,ShouJi=@ShouJi,TuXiangFilepath=@TuXiangFilepath
			,QQ=@QQ,YouXiang=@YouXiang
			,DiZhi=@DiZhi,StreetId=@StreetId,ProviceId=@ProviceId,CityId=@CityId,AreaId=@AreaId

		WHERE UserId=@HuiYuanId
		
		IF(@YuanIsLvYouGuWen=0 AND @IsLvYouGuWen=1)
		BEGIN
			UPDATE tbl_Member SET IsLvYouGuWen=@IsLvYouGuWen,LvYouGuWenRenZhengTime=@LvYouGuWenRenZhengTime
			WHERE UserId=@HuiYuanId
		END
        IF(@YuanIsLvYouGuWen=1 AND @IsLvYouGuWen=0)
		BEGIN
			UPDATE tbl_Member SET IsLvYouGuWen=@IsLvYouGuWen WHERE UserId=@HuiYuanId
		END
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



USE [yhqdb]
GO
/****** 对象:  Table [dbo].[tbl_HuiYouYouJi]    脚本日期: 03/10/2015 10:07:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HuiYouYouJi](
	[YouJiId] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[HuiYuanId] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[YouJiTitle] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[YouJiContent] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[IssueTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_HuiYouYouJi] PRIMARY KEY CLUSTERED 
(
	[YouJiId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE tbl_HuiYouYouJi ADD	YouJiLeiXing tinyint NOT NULL  DEFAULT 0
ALTER TABLE tbl_HuiYouYouJi ADD	ShiPinLink nvarchar(200) NULL

GO
 
ALTER TABLE dbo.tmp_tbl_ChongZhi ADD
	TradeNo nvarchar(50) NULL
GO

create  view [dbo].[view_ChongZhi]
as
SELECT     a.UserName,  a.ContactName,    b.*
FROM         tmp_tbl_ChongZhi b ,   tbl_Member a WHERE a.UserID=b.OperatorID
GO


--20150508--
 
CREATE TABLE [dbo].[tbl_HongBao](
	[ID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[IssueTime] [datetime] NOT NULL DEFAULT (getdate()),
	[HongBaoJinE] [money] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_TBL_HONGBAO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[tbl_ChouJiang](
	[ChouJiangID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[LiuShuiHao] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ID] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[CaoZuoRenID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ChouJiangShiJian] [datetime] NOT NULL DEFAULT (getdate()),
	[JieGuo] [tinyint] NOT NULL DEFAULT ((0)),
	[DianShu] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBL_CHOUJIANG] PRIMARY KEY CLUSTERED 
(
	[ChouJiangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[tbl_ZengZhiJiLu](
	[FenXiangID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[FenXiangRenID] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[FenXiangShiJian] [datetime] NOT NULL DEFAULT (getdate()),
	[ZengZhi] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBL_ZENGZHIJILU] PRIMARY KEY CLUSTERED 
(
	[FenXiangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE VIEW [dbo].[View_HongBao]
AS
SELECT     dbo.tbl_HongBao.ID, dbo.tbl_HongBao.UserID, dbo.tbl_HongBao.IssueTime, dbo.tbl_HongBao.HongBaoJinE, dbo.tbl_Member.UserName, 
                      dbo.tbl_Member.ContactName
FROM         dbo.tbl_HongBao INNER JOIN
                      dbo.tbl_Member ON dbo.tbl_HongBao.UserID = dbo.tbl_Member.UserID
GO
 CREATE VIEW [dbo].[view_ChouJiang]
AS 
SELECT     b.*,a.ContactName,a.UserName
FROM         tbl_Member AS a , tbl_ChouJiang AS b where a.UserID=b.CaoZuoRenID

GO

CREATE VIEW [dbo].[view_ZengZhi]
AS 
SELECT     b.*,a.ContactName,a.UserName
FROM         tbl_Member AS a , tbl_ZengZhiJiLu AS b where a.UserID=b.FenXiangRenID
GO

alter table tbl_HuiYouYouJi add WeiXinMa varchar(6)
go 
