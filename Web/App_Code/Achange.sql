--====================================================================================
--=======================================表修改=======================================
--====================================================================================
--附件表修改---------------

ALTER TABLE dbo.tbl_Attach ADD
	IsWebImage char(1) NOT NULL CONSTRAINT DF_tbl_Attach_IsWebImage DEFAULT 0
GO

--会员表----------------------------------

ALTER TABLE dbo.tbl_Member
	DROP CONSTRAINT DF_tbl_Member_ContactSex
GO

ALTER TABLE dbo.tbl_Member  alter column ContactSex tinyint not null
GO

ALTER TABLE dbo.tbl_Member ADD CONSTRAINT
	DF_tbl_Member_ContactSex DEFAULT ((1)) FOR ContactSex 
GO

ALTER TABLE dbo.tbl_Member ADD IsAgent  char(1)  not null CONSTRAINT
	DF_tbl_Member_IsAgent DEFAULT 0

GO


ALTER TABLE dbo.tbl_Member ADD CommissonScale decimal(8, 2) NULL
GO
--订单表----------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Order](
	[OrderID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ProductID] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[OrderCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MemberID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MemberName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[MemberTel] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MemberSex] [tinyint] NOT NULL,
	[OrderState] [tinyint] NOT NULL,
	[PayState] [tinyint] NOT NULL DEFAULT ((1)),
	[IsCheck] [char](1) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ConfirmCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[IssueTime] [datetime] NOT NULL,
	[OrderPrice] [money] NULL DEFAULT ((0)),
	[PeopleNum] [int] NULL DEFAULT ((1)),
	[ContractText] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[IsealCheck] [char](1) COLLATE Chinese_PRC_CI_AS NOT NULL CONSTRAINT [DF_tbl_Order_IsealCheck]  DEFAULT ((0)),
 CONSTRAINT [PK_TBL_ORDER] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Order', @level2type=N'COLUMN',@level2name=N'ProductID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Order'
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PROD] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tbl_Product] ([ProductID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_TBL_ORDE_REFERENCE_TBL_PROD]

GO
--产品表------------------------------------------------------------------------------------------------

ALTER TABLE dbo.tbl_Product ADD
	ServiceQQ nvarchar(50) NULL,
	ContractType tinyint NOT NULL CONSTRAINT DF_tbl_Product_ContractType DEFAULT 1,
	ControlPeople int NOT NULL CONSTRAINT DF_tbl_Product_ControlPeople DEFAULT 1
GO
--产品类别表----------------------------------------------------------------------------------------------
ALTER TABLE dbo.tbl_ProductType add WebImg nvarchar(500) NULL

GO
--国家表--------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SysCountry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnName] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[Zones] [int] NOT NULL DEFAULT ((0)),
	[CnName] [nvarchar](255) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TBL_SYSCOUNTRY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCountry', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCountry', @level2type=N'COLUMN',@level2name=N'EnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zones' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCountry', @level2type=N'COLUMN',@level2name=N'Zones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCountry', @level2type=N'COLUMN',@level2name=N'CnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统国家表
   中文名称
   英文名称
   洲' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCountry'
   
GO
--省份表---------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SysProvince](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[HeaderLetter] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[AreaId] [int] NULL,
	[SortId] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBL_SYSPROVINCE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'CountryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份简拼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'HeaderLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'AreaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysProvince', @level2type=N'COLUMN',@level2name=N'SortId'
GO
--城市------------------------------------------------------------------------------

GO
/****** 对象:  Table [dbo].[tbl_SysCity]    脚本日期: 10/31/2013 14:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SysCity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CenterCityId] [int] NOT NULL,
	[HeaderLetter] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[IsSite] [char](1) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT ('0'),
	[DomainName] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[IsEnabled] [char](1) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT ('0'),
 CONSTRAINT [PK_TBL_SYSCITY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'ProvinceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省会城市ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'CenterCityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市简拼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'HeaderLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否出港城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'IsSite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市二级域名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'DomainName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysCity', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
--县区-------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SysDistrict](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ProvinceId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[HeaderLetter] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TBL_SYSDISTRICT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysDistrict', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县区名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysDistrict', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysDistrict', @level2type=N'COLUMN',@level2name=N'ProvinceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysDistrict', @level2type=N'COLUMN',@level2name=N'CityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'县区简拼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SysDistrict', @level2type=N'COLUMN',@level2name=N'HeaderLetter'

GO
--公告-------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_TravelArticle](
	[ArticleID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Source] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ArticleTitle] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ImgPath] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[Description] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[ArticleText] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[ArticleTag] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[TitleColor] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[KeyWords] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[ClassId] [int] NULL DEFAULT ((0)),
	[IsFrontPage] [char](1) COLLATE Chinese_PRC_CI_AS NULL DEFAULT ('0'),
	[IsHot] [char](1) COLLATE Chinese_PRC_CI_AS NULL DEFAULT ('0'),
	[IssueTime] [datetime] NULL DEFAULT (getdate()),
	[OperatorId] [char](36) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''),
	[LinkUrl] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[Click] [int] NULL DEFAULT ((0)),
	[SortRule] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBL_TRAVELARTICLE] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资讯编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ArticleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ArticleTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ImgPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ArticleText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键词标签(,分隔)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ArticleTag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题文字颜色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'TitleColor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键词(,分隔)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'KeyWords'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'焦点产品=1,旅游资讯=2,公司公告=3,帮助中心=4,旅游攻略=5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'ClassId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否首页显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'IsFrontPage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否头条' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'IsHot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'OperatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'Click'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序规则:1低，2常规，3高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle', @level2type=N'COLUMN',@level2name=N'SortRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旅游资讯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticle'

GO
--公告类别----------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TravelArticleClass](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[IsSystem] [int] NULL DEFAULT ((0)),
	[SortRule] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBL_TRAVELARTICLECLASS] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticleClass', @level2type=N'COLUMN',@level2name=N'ClassId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticleClass', @level2type=N'COLUMN',@level2name=N'ClassName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:：资讯，1：公告，2：' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticleClass', @level2type=N'COLUMN',@level2name=N'IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序规则:1低，2常规，3高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticleClass', @level2type=N'COLUMN',@level2name=N'SortRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旅游资讯类别表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TravelArticleClass'

GO
--管理员表-----------------------------------------------------------------------------------------

ALTER TABLE dbo.tbl_User
	DROP CONSTRAINT DF_tbl_User_ContactSex
GO

ALTER TABLE dbo.tbl_User
	alter column ContactSex tinyint
GO

ALTER TABLE dbo.tbl_User ADD CONSTRAINT
	DF_tbl_User_ContactSex DEFAULT ((1)) FOR ContactSex
GO

ALTER TABLE dbo.tbl_User ADD SealImg nvarchar(255) NULL

GO

--地址表---------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_UserAddress](
	[AddressID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserID] [char](36) COLLATE Chinese_PRC_CI_AS NULL,
	[AddressProvince] [int] NULL,
	[AddressCity] [int] NULL,
	[AddressCountry] [int] NULL,
	[AddressInfo] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[IsDefault] [char](1) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[ContactName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ZpCode] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[MobileNum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[TelNum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_TBL_USERADDRESS] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户地址表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_UserAddress'
GO
--====================================================================================
--=================================存储过程修改记录===================================
--====================================================================================

---------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[proc_Order_Add]
@OrderID CHAR(36),
@ProductID CHAR(36),
@OrderCode NVARCHAR(50) OUTPUT,
@MemberID CHAR(36),
@MemberName NVARCHAR(50),
@MemberTel NVARCHAR(50),
@MemberSex TINYINT,
@OrderState TINYINT,
@PayState TINYINT,
@IsCheck CHAR(1),
@ConfirmCode NVARCHAR(50),
@Remark NVARCHAR(max),
@OrderPrice MONEY,
@PeopleNum INT,
@Result INT OUTPUT
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
		INSERT INTO tbl_Order (OrderID,ProductID,OrderCode,MemberID,MemberName,MemberTel,MemberSex,OrderState,PayState,IsCheck,ConfirmCode,Remark,IssueTime,OrderPrice,PeopleNum)
		VALUES			      (@OrderID,@ProductID,@OrderCode,@MemberID,@MemberName,@MemberTel,@MemberSex,@OrderState,@PayState,@IsCheck,@ConfirmCode,@Remark,GETDATE(),@OrderPrice,@PeopleNum)
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
----------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Order_Delete]
@OrderID CHAR(36),
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
		DELETE FROM  tbl_Order       WHERE  OrderID=@OrderID
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
---------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Order_Update]
@OrderState TINYINT,
@Remark NVARCHAR(255),
@OrderID char(36),
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
		UPDATE  tbl_Order   SET OrderState = @OrderState,Remark = @Remark WHERE OrderID=@OrderID
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
--------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_OrderState_Update]
@OrderID CHAR(36),
@PayState TINYINT,
@ConfirmCode NVARCHAR(50),
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
		UPDATE  tbl_Order   SET PayState = @PayState ,ConfirmCode = @ConfirmCode WHERE OrderID=@OrderID
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
---------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Proc_Product_Add]
@ProductID NVARCHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size="" IsWebImage="" /></ROOT>
@IsEveryDay CHAR(1),  
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT, 
@ControlPeople INT,            
@result INT OUTPUT
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
		INSERT INTO tbl_Product(ProductID,ProductName,ProductType,TourDate,MarketPrice,AppPrice,FavourCode,LinkTel,ProductDis,TourDis,SendTourKnow,ValidiDate,ProductState,IsEveryDay,IsHot,CreateDate,ServiceQQ,ContractType,ControlPeople)
     VALUES
           (@ProductID,@ProductName,@ProductType,@TourDate,@MarketPrice,@AppPrice,@FavourCode,@LinkTel,@ProductDis,@TourDis,@SendTourKnow,@ValidiDate,@ProductState,@IsEveryDay,@IsHot,GETDATE(),@ServiceQQ,@ContractType,@ControlPeople)
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

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
---------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Proc_Product_Delete]
	@ProductID varchar(Max),
	@Result int OUTPUT --操作结果 正值1：成功 负值或0：失败
AS
BEGIN
	DECLARE  @error INT
	SET  @Result=0
	SET  @error=0
	DECLARE @count int
	SELECT @count=COUNT(1) FROM [tbl_Order] WHERE ProductID IN (select [value] from dbo.fn_split(@ProductID,','))
		BEGIN  TRAN
		IF(@count=0)
			BEGIN 
				DELETE FROM tbl_Comment   WHERE ProductID in (select [value] from dbo.fn_split(@ProductID,','))
				SET @error=@error+@@ERROR
				DELETE FROM tbl_Attach   WHERE ItemId in (select [value] from dbo.fn_split(@ProductID,','))
				SET @error=@error+@@ERROR
				DELETE FROM  tbl_Product   WHERE ProductID in (select [value] from dbo.fn_split(@ProductID,','))
				SET @error=@error+@@ERROR
			END
		ELSE
			BEGIN
				SET @error=9999
			END
		
	IF(@error>0)
	BEGIN
		IF(@error=9999)
			BEGIN
				SET @Result=-1
			END
		ELSE
			BEGIN
				SET @Result=0
			END
			
		ROLLBACK TRAN
	END
	ELSE
	BEGIN	
		SET @Result=1	
		COMMIT TRAN
	end
	
END

GO
-------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Proc_Product_Update]
@ProductID CHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
@IsEveryDay CHAR(1),    
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT,  
@ControlPeople INT,              
@result INT OUTPUT
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
		UPDATE tbl_Product  SET  ProductName = @ProductName,ProductType = @ProductType,TourDate = @TourDate,MarketPrice = @MarketPrice,AppPrice = @AppPrice,FavourCode = @FavourCode,LinkTel = @LinkTel,ProductDis = @ProductDis,TourDis = @TourDis,SendTourKnow = @SendTourKnow,ValidiDate = @ValidiDate,ProductState = @ProductState,IsEveryDay=@IsEveryDay,IsHot=@IsHot,ServiceQQ=@ServiceQQ,ContractType=@ContractType,ControlPeople=@ControlPeople  WHERE ProductID=@ProductID
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
----------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_User_Delete]
@UserID CHAR(36),
@result INT OUTPUT
AS
BEGIN
	IF  EXISTS(SELECT 1 FROM tbl_Member WHERE UserID = @UserID )
	BEGIN
		IF EXISTS(SELECT 1 FROM tbl_Member WHERE UserID = @UserID   )
		BEGIN
			DELETE FROM  tbl_Member   WHERE  UserID = @UserID  
			DELETE FROM  tbl_UserAddress   WHERE  UserID = @UserID  
			SET @result=1
			RETURN @result
		END	
		SET @result=-99
		RETURN @result
	END	
	
	
	IF EXISTS(SELECT 1 FROM tbl_User WHERE UserID = @UserID   and IsAdmin='0' )
	BEGIN
		UPDATE tbl_User  SET UserState =2 WHERE UserID = @UserID
		SET @result=2
		RETURN @result
	END
	IF EXISTS(SELECT 1 FROM tbl_User WHERE UserID = @UserID   and IsAdmin='1' )
	BEGIN
		SET @result=3
		RETURN @result
	END
END

GO
------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_UserAddress_DefaultUpdate]
@AddressID CHAR(36),
@UserID CHAR(36),
@IsDefault CHAR(1),
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
	IF(@IsDefault=1)
		BEGIN
		UPDATE  tbl_UserAddress  SET IsDefault = 0  WHERE UserID =@UserID
		END
	
		UPDATE  tbl_UserAddress  SET IsDefault=@IsDefault WHERE AddressID =@AddressID
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

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_UserAddress_Update]
@AddressID CHAR(36),
@UserID CHAR(36),
@AddressProvince INT,
@AddressCity INT,
@AddressCountry INT,
@AddressInfo NVARCHAR(255),
@IsDefault CHAR(1),
@Remark NVARCHAR(max),
@ContactName NVARCHAR(50),
@ZpCode NVARCHAR(20),
@MobileNum NVARCHAR(50),
@TelNum NVARCHAR(50),
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
	IF(@IsDefault=1)
		BEGIN
		UPDATE  tbl_UserAddress  SET IsDefault = 1  WHERE UserID =@UserID
		END
	
		UPDATE  tbl_UserAddress  SET AddressProvince = @AddressProvince,AddressCity = @AddressCity,AddressCountry=@AddressCountry,AddressInfo = @AddressInfo,IsDefault = @IsDefault,Remark = @Remark ,ContactName=@ContactName,ZpCode=@ZpCode,MobileNum=@MobileNum,TelNum=@TelNum WHERE AddressID =@AddressID
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
--====================================================================================
--========================================视图修改====================================
--====================================================================================

-------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
  FROM tbl_Order


GO
------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[view_Product]
AS
SELECT      
a.ProductID, 
a.ProductName, 
a.ProductType, 
a.TourDate, 
a.MarketPrice, 
a.AppPrice, 
a.FavourCode, 
a.LinkTel, 
a.ProductDis, 
a.TourDis, 
a.SendTourKnow, 
a.ValidiDate, 
a.ProductState,
a.IsEveryDay, 
a.IsHot,
a.CreateDate,
a.ServiceQQ,
a.ContractType,
a.ControlPeople,
ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum,
ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum,
b.AdminName
FROM         
dbo.tbl_Product AS a 
	LEFT  JOIN
dbo.tbl_ProductType AS b 
	ON b.TypeID = a.ProductType
	

GO
--====================================================================================
--========================================函数修改====================================
--====================================================================================


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_PadLeft]
(
	--输入的字符串
	@Input NVARCHAR(50),
	--填充字符
	@PaddingChar CHAR(1),
	--结果字符串中的字符数，等于原始字符数加上任何其他填充字符。
	@TotalWidth INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @tmp varchar(50)
	SELECT @tmp = ISNULL(REPLICATE(@PaddingChar,@TotalWidth - LEN(ISNULL(@Input ,0))), '') + @Input
	RETURN @tmp
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

--------------2013-11-1--------------------------------------------------------------------------



GO

ALTER TABLE dbo.tbl_Member ADD
	PollCode nvarchar(50) NULL

GO

ALTER TABLE dbo.tbl_Member ADD
	PromotionCode nvarchar(50) NULL
	
GO

--------------2013-11-13--------------------------------------------------------------------------

ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
  FROM tbl_Order
  --------------------------------------

 
GO

ALTER PROCEDURE [dbo].[proc_Order_Update]
@OrderState TINYINT,
@Remark NVARCHAR(255),
@OrderID char(36),
@OrderPrice MONEY,
@Result INT OUTPUT
AS
BEGIN
	declare @error int  
	set @error=0
	set @Result=0
	begin TRAN
		IF(@error=0)
	BEGIN
		UPDATE  tbl_Order   SET OrderState = @OrderState,Remark = @Remark,OrderPrice=@OrderPrice WHERE OrderID=@OrderID
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
 

 /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
 CREATE PROCEDURE [dbo].[proc_Order_UpdatePDF]
@OrderID char(36),
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
@Result INT OUTPUT
AS
BEGIN
	declare @error int  ,@doc int
	set @error=0
	set @Result=0
	begin TRAN
		delete from tbl_Attach where   ItemId=@OrderID
		set @error=@error+@@error
	if(@ComAttachXML is not null)
	BEGIN 
	exec sp_xml_preparedocument @doc output,@ComAttachXML
		insert into tbl_Attach(ItemId,[Name],FilePath,[Size],IsWebImage)
		select ItemId,[Name],FilePath,[Size],IsWebImage
		from openxml(@doc,N'/ROOT/ComAttach',1)
		WITH(ItemId char(36),[Name] nvarchar(255),FilePath nvarchar(255),[Size] INT,IsWebImage CHAR(1))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
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

 /****************************************************************************************/
 ALTER TABLE  tbl_Order ADD
	AddressID char(36) NULL
	
	
GO
 
ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
  FROM tbl_Order
 
 GO
 
 
ALTER PROCEDURE [dbo].[proc_OrderState_Update]
@OrderID CHAR(36),
@PayState TINYINT,
@ConfirmCode NVARCHAR(50),
@OrderState TINYINT,
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
		UPDATE  tbl_Order   SET PayState = @PayState ,ConfirmCode = @ConfirmCode, OrderState=@OrderState WHERE OrderID=@OrderID
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


 
create table tbl_MsgLog (
   msgID                int                  identity,
   TelCode              nvarchar(50)         not null,
   MsgText              nvarchar(500)        not null,
   ReResult             nvarchar(50)          null,
   Issuetime            datetime             not null,
   constraint PK_TBL_MSGLOG primary key (msgID)
)
 
GO

ALTER TABLE dbo.tbl_Member ADD
	valiUser char(1) NOT NULL CONSTRAINT DF_tbl_Member_valiUser DEFAULT 0
GO

 ALTER TABLE dbo.tbl_Order ADD
	RebackMoney money NOT NULL CONSTRAINT DF_tbl_Order_RebackMoney DEFAULT 0
GO


ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
	  ,RebackMoney
	  ,(((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
  FROM tbl_Order
GO





-------------------------------------------------------------------------------2014-02-08修改--------------------------------------------------------------------------------------------

ALTER TABLE dbo.tbl_Product ADD
	ProductOpState tinyint NOT NULL CONSTRAINT DF_tbl_Product_ProductOpState DEFAULT 1,
	ProductSdate datetime NULL,
	ZCodeViaDate datetime NULL
	PType int NOT NULL CONSTRAINT DF_tbl_Product_PType DEFAULT 1
	
GO

ALTER TABLE dbo.tbl_Order ADD
	ConSumState tinyint NOT NULL  DEFAULT 0
	
GO

/************************************************************************************************************************************/


ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
	  ,(select ProductOpState from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductOpState
	  ,(select ProductSdate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductSdate
  	  ,(select ZCodeViaDate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ZCodeViaDate
  	  ,(select PType from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS PType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
	  ,RebackMoney
	  ,(((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	  ,ConSumState
  FROM tbl_Order

  GO
/***********************************************************************************************************/

ALTER view [dbo].[view_Product]
AS
SELECT      
a.ProductID, 
a.ProductName, 
a.ProductType, 
a.TourDate, 
a.MarketPrice, 
a.AppPrice, 
a.FavourCode, 
a.LinkTel, 
a.ProductDis, 
a.TourDis, 
a.SendTourKnow, 
a.ValidiDate, 
a.ProductState,
a.IsEveryDay, 
a.IsHot,
a.CreateDate,
a.ServiceQQ,
a.ContractType,
a.ControlPeople,
ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum,
ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum,
b.AdminName,
a.ProductOpState,
a.ProductSdate,
a.ZCodeViaDate,
a.PType
FROM         
dbo.tbl_Product AS a 
	LEFT  JOIN
dbo.tbl_ProductType AS b 
	ON b.TypeID = a.ProductType
GO

/***********************************************************************************************************/
ALTER PROCEDURE [dbo].[Proc_Product_Add]
@ProductID NVARCHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size="" IsWebImage="" /></ROOT>
@IsEveryDay CHAR(1),  
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT, 
@ControlPeople INT,
@ProductOpState TINYINT,
@ProductSdate DATETIME,
@ZCodeViaDate DATETIME,   
@PType INT,
@result INT OUTPUT
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
		INSERT INTO tbl_Product(ProductID,ProductName,ProductType,TourDate,MarketPrice,AppPrice,FavourCode,LinkTel,ProductDis,TourDis,SendTourKnow,ValidiDate,ProductState,IsEveryDay,IsHot,CreateDate,ServiceQQ,ContractType,ControlPeople,ProductOpState,ProductSdate,ZCodeViaDate,PType)
     VALUES
           (@ProductID,@ProductName,@ProductType,@TourDate,@MarketPrice,@AppPrice,@FavourCode,@LinkTel,@ProductDis,@TourDis,@SendTourKnow,@ValidiDate,@ProductState,@IsEveryDay,@IsHot,GETDATE(),@ServiceQQ,@ContractType,@ControlPeople,@ProductOpState,@ProductSdate,@ZCodeViaDate,@PType)
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

/***********************************************************************************************************/
ALTER PROCEDURE [dbo].[Proc_Product_Update]
@ProductID CHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
@IsEveryDay CHAR(1),    
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT,  
@ControlPeople INT,
@ProductOpState TINYINT,
@ProductSdate DATETIME,
@ZCodeViaDate DATETIME,   
@result INT OUTPUT
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
		UPDATE tbl_Product  SET  ProductName = @ProductName,ProductType = @ProductType,TourDate = @TourDate,MarketPrice = @MarketPrice,AppPrice = @AppPrice,FavourCode = @FavourCode,LinkTel = @LinkTel,ProductDis = @ProductDis,TourDis = @TourDis,SendTourKnow = @SendTourKnow,ValidiDate = @ValidiDate,ProductState = @ProductState,IsEveryDay=@IsEveryDay,IsHot=@IsHot,ServiceQQ=@ServiceQQ,ContractType=@ContractType,ControlPeople=@ControlPeople,ProductOpState=@ProductOpState,ProductSdate=@ProductSdate,ZCodeViaDate=@ZCodeViaDate WHERE ProductID=@ProductID
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

/***********************************************************************************************************/
CREATE TABLE [dbo].[GYSTicket](
	[ID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CusName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CusSex] [tinyint] NOT NULL,
	[CusMob] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[PlaneTicket] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[IssueTime] [datetime] NOT NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[OpertorID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrderState] [tinyint] NOT NULL CONSTRAINT [DF_GYSTicket_OrderState]  DEFAULT ((0)),
	[TicketState] [tinyint] NOT NULL CONSTRAINT [DF_GYSTicket_TicketState]  DEFAULT ((1)),
 CONSTRAINT [PK_GYSTICKET] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/********************************************2014-03-25增加同类比较*********************************************************/
ALTER TABLE dbo.tbl_Product ADD
	Scompare nvarchar(MAX) NULL
GO


ALTER PROCEDURE [dbo].[Proc_Product_Add]
@ProductID NVARCHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size="" IsWebImage="" /></ROOT>
@IsEveryDay CHAR(1),  
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT, 
@ControlPeople INT,
@ProductOpState TINYINT,
@ProductSdate DATETIME,
@ZCodeViaDate DATETIME,   
@PType INT,
@Scompare NVARCHAR(max),
@result INT OUTPUT
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
		INSERT INTO tbl_Product(ProductID,ProductName,ProductType,TourDate,MarketPrice,AppPrice,FavourCode,LinkTel,ProductDis,TourDis,SendTourKnow,ValidiDate,ProductState,IsEveryDay,IsHot,CreateDate,ServiceQQ,ContractType,ControlPeople,ProductOpState,ProductSdate,ZCodeViaDate,PType,Scompare)
     VALUES
           (@ProductID,@ProductName,@ProductType,@TourDate,@MarketPrice,@AppPrice,@FavourCode,@LinkTel,@ProductDis,@TourDis,@SendTourKnow,@ValidiDate,@ProductState,@IsEveryDay,@IsHot,GETDATE(),@ServiceQQ,@ContractType,@ControlPeople,@ProductOpState,@ProductSdate,@ZCodeViaDate,@PType,@Scompare)
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
@ProductID CHAR(36),
@ProductName NVARCHAR(50),
@ProductType int,
@TourDate datetime,
@MarketPrice MONEY,
@AppPrice MONEY,
@FavourCode NVARCHAR(50),
@LinkTel NVARCHAR(50),
@ProductDis NVARCHAR(MAX),
@TourDis NVARCHAR(MAX),
@SendTourKnow NVARCHAR(MAX),
@ValidiDate DATETIME,
@ProductState TINYINT,
@ComAttachXML xml,--附件XML:<ROOT><ComAttach  ItemId="" Name="" FilePath="" Size=""  IsWebImage=""  /></ROOT>
@IsEveryDay CHAR(1),    
@IsHot TINYINT,
@ServiceQQ NVARCHAR(50),
@ContractType TINYINT,  
@ControlPeople INT,
@ProductOpState TINYINT,
@ProductSdate DATETIME,
@ZCodeViaDate DATETIME, 
@Scompare NVARCHAR(max),  
@result INT OUTPUT
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
		UPDATE tbl_Product  SET  ProductName = @ProductName,ProductType = @ProductType,TourDate = @TourDate,MarketPrice = @MarketPrice,AppPrice = @AppPrice,FavourCode = @FavourCode,LinkTel = @LinkTel,ProductDis = @ProductDis,TourDis = @TourDis,SendTourKnow = @SendTourKnow,ValidiDate = @ValidiDate,ProductState = @ProductState,IsEveryDay=@IsEveryDay,IsHot=@IsHot,ServiceQQ=@ServiceQQ,ContractType=@ContractType,ControlPeople=@ControlPeople,ProductOpState=@ProductOpState,ProductSdate=@ProductSdate,ZCodeViaDate=@ZCodeViaDate,Scompare=@Scompare WHERE ProductID=@ProductID
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
SELECT      
a.ProductID, 
a.ProductName, 
a.ProductType, 
a.TourDate, 
a.MarketPrice, 
a.AppPrice, 
a.FavourCode, 
a.LinkTel, 
a.ProductDis, 
a.TourDis, 
a.SendTourKnow, 
a.ValidiDate, 
a.ProductState,
a.IsEveryDay, 
a.IsHot,
a.CreateDate,
a.ServiceQQ,
a.ContractType,
a.ControlPeople,
ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum,
ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum,
b.AdminName,
a.ProductOpState,
a.ProductSdate,
a.ZCodeViaDate,
a.PType,
a.Scompare
FROM         
dbo.tbl_Product AS a 
	LEFT  JOIN
dbo.tbl_ProductType AS b 
	ON b.TypeID = a.ProductType
GO
/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/


ALTER TABLE dbo.tbl_Order ADD
	AppUserId char(36) NULL,
	AppTime datetime NULL
GO



ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
	  ,(select ProductOpState from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductOpState
	  ,(select ProductSdate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductSdate
  	  ,(select ZCodeViaDate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ZCodeViaDate
  	  ,(select PType from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS PType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
	  ,RebackMoney
	  ,(((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	  ,ConSumState,
   (select UserName from tbl_Member where UserID=tbl_Order.AppUserId) as AppUserName,
AppUserId,
AppTime
  FROM tbl_Order

GO
 

CREATE TABLE [dbo].[tbl_WeiXinBind](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CustomerId] [int] NOT NULL   DEFAULT  0 ,
	[CustomerName] [nvarchar](250)  NULL,
	[MobilePhone] [nvarchar](100)  NULL,
	[OpenId] [nvarchar](50)  NOT NULL,
	[NickName] [nvarchar](50)  NULL,
	[Sex] [nvarchar](50)  NULL,
	[BindTime] [datetime] NOT NULL   DEFAULT (getdate()),
	[SubscribeTime] [datetime] NULL,
	[Country] [nvarchar](50)  NULL,
	[Province] [nvarchar](50)  NULL,
	[City] [nvarchar](50) NULL,
	[Language] [nvarchar](50)  NULL
)  
GO
CREATE TABLE [dbo].[tbl_Recommend](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OpenId] [nvarchar](50)  NOT NULL,
	[NickName] [nvarchar](50)   NULL,
	[Sex] [nvarchar](50)   NULL,
	[CommendInfo] [nvarchar](max)   NULL,
	[IssueTime] [datetime] NOT NULL DEFAULT (getdate())
)
--------------------------------------------------------2014-05-23--------------------------------------------------------------------
GO
ALTER TABLE dbo.tbl_Order ADD
	JState tinyint NOT NULL DEFAULT 0
GO

ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
	  ,(select ProductOpState from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductOpState
	  ,(select ProductSdate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductSdate
  	  ,(select ZCodeViaDate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ZCodeViaDate
  	  ,(select PType from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS PType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
	  ,RebackMoney
	  ,(((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	  ,ConSumState,
   (select UserName from tbl_Member where UserID=tbl_Order.AppUserId) as AppUserName,
AppUserId,
AppTime,
JState
  FROM tbl_Order
GO
-------------------------------------------------------------------------------2014-05-26-----------------------------------------------------------------------------------------------
ALTER TABLE dbo.tbl_ProductType ADD
	XianLu tinyint NOT NULL  DEFAULT 0
GO

ALTER view [dbo].[view_Product]
AS
SELECT      
a.ProductID, 
a.ProductName, 
a.ProductType, 
a.TourDate, 
a.MarketPrice, 
a.AppPrice, 
a.FavourCode, 
a.LinkTel, 
a.ProductDis, 
a.TourDis, 
a.SendTourKnow, 
a.ValidiDate, 
a.ProductState,
a.IsEveryDay, 
a.IsHot,
a.CreateDate,
a.ServiceQQ,
a.ContractType,
a.ControlPeople,
ISNULL((SELECT sum(PeopleNum) FROM tbl_Order WHERE tbl_Order.ProductID=a.ProductID),0) AS SaleNum,
ISNULL((SELECT ControlPeople-ISNULL((SELECT SUM(PeopleNum) FROM dbo.view_Order WHERE ProductID=a.ProductID),0)),0 )AS ResidueNum,
b.AdminName,
a.ProductOpState,
a.ProductSdate,
a.ZCodeViaDate,
a.PType,
a.Scompare,
b.XianLu
FROM         
dbo.tbl_Product AS a 
	LEFT  JOIN
dbo.tbl_ProductType AS b 
	ON b.TypeID = a.ProductType
	
GO
GO

ALTER PROCEDURE [dbo].[proc_OrderState_Update]
@OrderID CHAR(36),
@PayState TINYINT,
@ConfirmCode NVARCHAR(50),
@OrderState TINYINT,
@JState TINYINT,
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	set @error=0
	set @Result=0
	begin tran
	IF(@error=0)
	BEGIN
		UPDATE  tbl_Order   SET PayState = @PayState ,ConfirmCode = @ConfirmCode, OrderState=@OrderState,JState=@JState WHERE OrderID=@OrderID
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
ALTER  PROCEDURE [dbo].[proc_Order_Add]
@OrderID CHAR(36),
@ProductID CHAR(36),
@OrderCode NVARCHAR(50) OUTPUT,
@MemberID CHAR(36),
@MemberName NVARCHAR(50),
@MemberTel NVARCHAR(50),
@MemberSex TINYINT,
@OrderState TINYINT,
@PayState TINYINT,
@IsCheck CHAR(1),
@ConfirmCode NVARCHAR(50),
@Remark NVARCHAR(max),
@OrderPrice MONEY,
@PeopleNum INT,
@Result INT OUTPUT
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
		INSERT INTO tbl_Order (OrderID,ProductID,OrderCode,MemberID,MemberName,MemberTel,MemberSex,OrderState,PayState,IsCheck,ConfirmCode,Remark,IssueTime,OrderPrice,PeopleNum)
		VALUES			      (@OrderID,@ProductID,@OrderCode,@MemberID,@MemberName,@MemberTel,@MemberSex,@OrderState,@PayState,@IsCheck,@ConfirmCode,@Remark,GETDATE(),@OrderPrice,@PeopleNum)
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


create table tbl_YuYue (
   YYID                 int                  IDENTITY PRIMARY  KEY ,
   YYRoute              nvarchar(50)         null,
   YYName               nvarchar(50)         null,
   YYMobile             nvarchar(50)         null,
   YYInfo               nvarchar(max)        NULL,
   YYTime				DATETIME			NOT NULL DEFAULT GETDATE()
)
 






ALTER TABLE dbo.tbl_Order ADD
	AvailNum int NOT NULL DEFAULT(0)
GO




GO
/****** 对象:  StoredProcedure [dbo].[proc_Order_Add]    脚本日期: 08/17/2014 10:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[proc_Order_Add]
@OrderID CHAR(36),
@ProductID CHAR(36),
@OrderCode NVARCHAR(50) OUTPUT,
@MemberID CHAR(36),
@MemberName NVARCHAR(50),
@MemberTel NVARCHAR(50),
@MemberSex TINYINT,
@OrderState TINYINT,
@PayState TINYINT,
@IsCheck CHAR(1),
@ConfirmCode NVARCHAR(50),
@Remark NVARCHAR(max),
@OrderPrice MONEY,
@PeopleNum INT,
@Result INT OUTPUT
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
		INSERT INTO tbl_Order (OrderID,ProductID,OrderCode,MemberID,MemberName,MemberTel,MemberSex,OrderState,PayState,IsCheck,ConfirmCode,Remark,IssueTime,OrderPrice,PeopleNum,AvailNum)
		VALUES			      (@OrderID,@ProductID,@OrderCode,@MemberID,@MemberName,@MemberTel,@MemberSex,@OrderState,@PayState,@IsCheck,@ConfirmCode,@Remark,GETDATE(),@OrderPrice,@PeopleNum,@PeopleNum)
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
Go




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[view_Order]
as
SELECT OrderId
      ,ProductID
	  ,(select ProductName from tbl_Product where ProductID=tbl_Order.ProductID) as ProductName
	  ,(select TourDate from tbl_Product where ProductID=tbl_Order.ProductID) as TourDate
	  ,(select FavourCode from tbl_Product where ProductID=tbl_Order.ProductID) as FavourCode
	  ,(select IsEveryDay from tbl_Product where ProductID=tbl_Order.ProductID) as isEvery
	  ,(select ProductType from tbl_Product where ProductID=tbl_Order.ProductID) as ProductType
	  ,(select ContractType from tbl_Product where ProductID=tbl_Order.ProductID) as ContractType
	  ,(select ProductOpState from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductOpState
	  ,(select ProductSdate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ProductSdate
  	  ,(select ZCodeViaDate from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS ZCodeViaDate
  	  ,(select PType from dbo.tbl_Product where ProductID=tbl_Order.ProductID)AS PType
  	  ,(select PollCode from tbl_Member where UserID=tbl_Order.MemberID) as PollCode
	  ,(select PromotionCode from tbl_Member where UserID=tbl_Order.MemberID) as PromotionCode
	  ,((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)AS fyje
	  ,(SELECT Name,FilePath,Size,IsWebImage  FROM tbl_Attach WHERE   ItemId=tbl_Order.OrderID FOR XML RAW,ROOT('ROOT'))AS ComAttachXML  
      ,OrderCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,MemberSex
      ,OrderState
      ,PayState
      ,IsCheck
      ,ConfirmCode
      ,Remark
      ,IssueTime
      ,OrderPrice
      ,PeopleNum
	  ,ContractText
	  ,IsealCheck
	  ,AddressID
	  ,RebackMoney
	  ,(((select CommissonScale from tbl_Member where UserID=tbl_Order.MemberID)/100*OrderPrice)-RebackMoney)AS backMoney
	  ,ConSumState,
   (select UserName from tbl_Member where UserID=tbl_Order.AppUserId) as AppUserName,
AppUserId,
AppTime,
JState,AvailNum
  FROM tbl_Order
GO

GO
/****** 对象:  Table [dbo].[tbl_OrderAppScan]    脚本日期: 08/19/2014 14:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_OrderAppScan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [char](36) NOT NULL,
	[OrderType] [tinyint] NOT NULL,
	[AppUserId] [char](36) NOT NULL,
	[AppTime] [datetime] NOT NULL CONSTRAINT [DF_tbl_OrderAppScan_AppTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_tbl_OrderAppScan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[view_OrderScan]
as
SELECT a.OrderId
      ,a.ProductID
	  ,(select ProductName from tbl_Product where ProductID=a.ProductID) as ProductName
	  ,(select ProductType from tbl_Product where ProductID=a.ProductID) as ProductType
      ,OrderCode,ConfirmCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,OrderState
      ,PayState
      ,IsCheck
	  ,ConSumState,
		IssueTime,
   (select UserName from tbl_Member where UserID=b.AppUserId) as AppUserName,
b.AppUserId,
b.AppTime

  FROM tbl_Order a,tbl_OrderAppScan b
where a.orderid=b.orderid

GO

alter table tbl_OrderAppScan add AppMobNo varchar(50)

GO

ALTER view [dbo].[view_OrderScan]
as
SELECT a.OrderId
      ,a.ProductID
	  ,(select ProductName from tbl_Product where ProductID=a.ProductID) as ProductName
	  ,(select ProductType from tbl_Product where ProductID=a.ProductID) as ProductType
      ,OrderCode,ConfirmCode
      ,MemberID
      ,MemberName
      ,MemberTel
      ,OrderState
      ,PayState
      ,IsCheck
	  ,ConSumState,
		IssueTime,
   (select UserName from tbl_Member where UserID=b.AppUserId) as AppUserName,
b.AppUserId,
b.AppTime,
b.AppMobNo
  FROM tbl_Order a,tbl_OrderAppScan b
where a.orderid=b.orderid
GO




create table tbl_UserAccont 
(
   ID                   char(36)                       not NULL primary key,
   JiaoYiFangShi        tinyint                        not NULL ,
   YongHuBianHao        char(36)                       not NULL REFERENCES  tbl_Member(UserID),
   JiaoYiHao            nvarchar(50)                   not null,
   JiaoYiShiJian        datetime                       not null,
   JiaoYiJinE           money                          not null default 0,
   YuE                  money                          not null default 0,
   ChongZhiFangShi      tinyint                        not null,
   DingDanHao           nvarchar(50)                   not null,
   DingDanLeiBie        tinyint                        not NULL 
 
);
GO
create table tbl_PlanTicket 
(
   OrderID              char(36)                       not null primary key ,
   OrderCode            nvarchar(50)                   not null,
   TicketID             nvarchar(50)                   not null,
   FlightNO             nvarchar(10)                   not NULL 
 );
 GO
 ALTER TABLE dbo.tbl_Member ADD
	YuE money NOT NULL  DEFAULT 0
GO
CREATE TABLE tmp_tbl_ChongZhi(
	OrderID char(36)  NOT NULL PRIMARY KEY,
	OrderCode nvarchar(50) NOT NULL,
	OperatorID char(36) NOT NULL,
	OptMoney money NOT NULL DEFAULT ((0)),
	Issuetime datetime NOT NULL DEFAULT (getdate()),
	PayState tinyint NOT NULL DEFAULT ((1))

) 
	
CREATE TABLE [dbo].[tbl_PlanTicket](
	[OrderID] [char](36) NOT NULL  PRIMARY KEY,
	[OrderCode] [nvarchar](50)   NOT NULL,
	[OpeatorID] [char](36)   NOT NULL,
	[OpeatorName] [nvarchar](50)   NOT NULL,
	[IssueTime]	  [DATETIME]	NOT NULL
)
GO
ALTER TABLE dbo.tbl_PlanTicket ADD payState TINYINT DEFAULT 0 NOT NULL 
GO
ALTER TABLE dbo.tbl_Member ADD
	IsZZ char(1) NOT NULL  DEFAULT 0
GO
--返回值-99余额不足，-98不能给自己转账，0转账失败，1转账成功
CREATE PROCEDURE [dbo].[proc_ZhuanZhang]
@memnberId CHAR(36),
@userAccount NVARCHAR(50),
@jinE MONEY,
@Result INT OUTPUT
AS
BEGIN
	declare @error int  
	set @error=0
	set @Result=0
	
		
		IF((SELECT YuE FROM tbl_Member WHERE UserID =@memnberId)<@jinE)
		BEGIN
			SET @Result=-99
			RETURN @Result
		END
		
		IF(@memnberId=(SELECT TOP 1 UserID FROM tbl_Member WHERE UserName =@userAccount))
		BEGIN
			SET @Result=-98
			RETURN @Result
		END
	begin TRAN
		IF(@error=0)
	BEGIN
		update tbl_Member set YuE=YuE-@jinE where UserID=@memnberId 
		set @error=@error+@@error
		update tbl_Member set YuE=YuE+@jinE where UserName=@userAccount  
		set @error=@error+@@error
	END	
		IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
		RETURN @Result
	END
		ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
		RETURN @Result
	end

END
GO

--返回值-99余额不足，0支付失败，1支付成功
CREATE PROCEDURE [dbo].[proc_zhifu]
@memnberId CHAR(36),
@orderid CHAR(36),
@price MONEY,
@Result INT OUTPUT
AS
BEGIN
	declare @error int  
	set @error=0
	set @Result=0
	
		
		IF((SELECT YuE FROM tbl_Member WHERE UserID =@memnberId)<@price)
		BEGIN
			SET @Result=-99
			RETURN @Result
		END
		
	begin TRAN
		IF(@error=0)
	BEGIN
		UPDATE tbl_Member   SET YuE = YuE-@price  WHERE UserID = @memnberId
		set @error=@error+@@error
		UPDATE tbl_PlanTicket   SET payState = 1  WHERE OrderID = @orderid
		set @error=@error+@@error
	END	
		IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
		RETURN @Result
	END
		ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
		RETURN @Result
	end

END
GO

create table tbl_ConDetailed 
(
   ID                   int           IDENTITY(1,1)           not NULL	primary key,
   HuiYuanID            char(36)                       not NULL REFERENCES dbo.tbl_Member(UserID),
   JiaoYiHao            nvarchar(50)                   not null,
   JinE                 money                          not null default 0,
   JiaoYiShiJian        datetime                       not null default getdate(),
   XiaoFeiFangShi       tinyint                        not null,
   DingDanBianHao       nvarchar(50)                   not null,
   JiaoYiDuiXiang       char(36)                       null,
   DingDanLeiBie        tinyint                        not null
);
GO
ALTER TABLE dbo.tbl_PlanTicket ADD
	ModifyTag nvarchar(50) NULL
	
GO	
create table dbo.tbl_orderpassenger(
	id int identity(1,1) not null,
	ordercode varchar(50) not null,
	psrname nvarchar(50) not null,
	psrtype tinyint not null,
	identitytype tinyint not null,
	identitycard nvarchar(50) not null,
	mobile nvarchar(50) null
)

GO
ALTER TABLE dbo.tbl_PlanTicket ADD
	JpAdress nvarchar(100)  NULL  
	
create table tbl_PlantIns 
(
   ID                   int      PRIMARY KEY IDENTITY(1,1)     not null,
   OrderID              char(36)                       not null,
   InsNO                nvarchar(20)                   not null,
   InsName              nvarchar(50)                   not null,
   OperatorID           char(36)                       not null,
   OperatorName         nvarchar(50)                   not null,
   IssueTime            datetime                       not null,
   PlantID              char(36)                       null,
   InsMoney             money                          not null default 0,
   OrderCode            nvarchar(50)                   not NULL,
   PolicTor				NVARCHAR(20)					NULL,
   LinkTel				NVARCHAR(20)					NULL,
   LinkMail				NVARCHAR(50)					NULL,
   LinkAddress			NVARCHAR(200)					NULL,
   STATE				TINYINT							NOT NULL DEFAULT 0				
);
GO
ALTER TABLE dbo.tbl_PlanTicket ADD
	InsPrice money NOT NULL  DEFAULT 0
GO
ALTER TABLE tbl_PlanTicket ADD
	OrderPrice MONEY NOT NULL   DEFAULT 0
GO
 --使用账户余额支付旅游订单
CREATE PROCEDURE [dbo].[proc_XiaoFei]
@HuiYuanBianHao CHAR(36),
@DingDanBianHao CHAR(36),
@DingDanZT TINYINT,
@JinE MONEY,
@Result INT OUTPUT
AS
BEGIN
	declare @error int 
	DECLARE @YuE MONEY
	set @error=0
	set @Result=0
	IF NOT EXISTS(SELECT 1 FROM dbo.tbl_Order WHERE OrderID=@DingDanBianHao AND PayState=1)
		BEGIN
			SET @Result=-99
			RETURN
		END
	SELECT @YuE=YuE FROM dbo.tbl_Member WHERE UserID=@HuiYuanBianHao
	IF(@JinE>@YuE)
		BEGIN
			SET @Result=-98
			RETURN
		END
	
	begin tran
	IF(@error=0)
	BEGIN
	
		UPDATE tbl_Order SET PayState = @DingDanZT WHERE OrderID=@DingDanBianHao
        SET @error=@error+@@ERROR
        UPDATE tbl_Member set YuE=YuE-@JinE where UserID=@HuiYuanBianHao
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
