
ALTER TABLE dbo.tbl_Order ADD
	RebackMoney money NOT NULL default 0,
	ConSumState tinyint NOT NULL  DEFAULT 0
	
GO

ALTER TABLE dbo.tbl_Product ADD
	ProductOpState tinyint NOT NULL CONSTRAINT DF_tbl_Product_ProductOpState DEFAULT 1,
	ProductSdate datetime NULL,
	ZCodeViaDate datetime NULL,
	PType int NOT NULL CONSTRAINT DF_tbl_Product_PType DEFAULT 1
	
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
GO
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
/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/

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

