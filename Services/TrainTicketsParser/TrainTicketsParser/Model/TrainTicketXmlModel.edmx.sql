
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2018 11:25:37
-- Generated from EDMX file: E:\WSG_CRM\WSG_CRM\Services\TrainTicketsParser\TrainTicketsParser\Model\TrainTicketXmlModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrainTicketDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InvoiceTravel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Travels] DROP CONSTRAINT [FK_InvoiceTravel];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelTrip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trips] DROP CONSTRAINT [FK_TravelTrip];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceSoldSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoldSeats] DROP CONSTRAINT [FK_PriceSoldSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_PriceInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_CounterPartInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CounterParts] DROP CONSTRAINT [FK_CounterPartInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_SoldSeatInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoldSeats] DROP CONSTRAINT [FK_SoldSeatInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articles] DROP CONSTRAINT [FK_PriceArticle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[Travels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Travels];
GO
IF OBJECT_ID(N'[dbo].[Trips]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trips];
GO
IF OBJECT_ID(N'[dbo].[SoldSeats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoldSeats];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[CounterParts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CounterParts];
GO
IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [InvoiceId] uniqueidentifier  NOT NULL,
    [Id] bigint  NOT NULL,
    [OuterId] int  NOT NULL,
    [SalePointName] nvarchar(max)  NOT NULL,
    [AspsCode] nvarchar(max)  NOT NULL,
    [AspsCode2] nvarchar(max)  NOT NULL,
    [State] int  NOT NULL,
    [IsElectronic] bit  NOT NULL,
    [CreationTime] datetime  NOT NULL,
    [OwnerEmail] nvarchar(max)  NOT NULL,
    [OwnerPhone] nvarchar(max)  NOT NULL,
    [OwnerId] int  NOT NULL,
    [BoardingPass] int  NOT NULL,
    [Price_PriceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Travels'
CREATE TABLE [dbo].[Travels] (
    [TravelId] uniqueidentifier  NOT NULL,
    [GuidIdx] uniqueidentifier  NOT NULL,
    [TransportType] int  NULL,
    [DepartureDateTime] datetime  NULL,
    [ArrivalDateTime] datetime  NULL,
    [Duration] nvarchar(max)  NOT NULL,
    [Src_Idx] bigint  NOT NULL,
    [Src_Name] nvarchar(max)  NOT NULL,
    [Dst_Name] nvarchar(max)  NOT NULL,
    [Dst_Idx] bigint  NOT NULL,
    [Invoice_InvoiceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Trips'
CREATE TABLE [dbo].[Trips] (
    [TripId] uniqueidentifier  NOT NULL,
    [Id] nvarchar(max)  NOT NULL,
    [Transporter] nvarchar(max)  NOT NULL,
    [Nickame] nvarchar(max)  NULL,
    [State] int  NOT NULL,
    [El] int  NOT NULL,
    [BoardingPass] int  NOT NULL,
    [Src_Idx] bigint  NOT NULL,
    [Src_Name] nvarchar(max)  NOT NULL,
    [Dst_Name] nvarchar(max)  NOT NULL,
    [Dst_Idx] bigint  NOT NULL,
    [Travel_TravelId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SoldSeats'
CREATE TABLE [dbo].[SoldSeats] (
    [SoldSeatId] uniqueidentifier  NOT NULL,
    [Id] int  NOT NULL,
    [CarId] int  NOT NULL,
    [TosId] int  NOT NULL,
    [Passenger_Surname] nvarchar(max)  NOT NULL,
    [Passenger_Name] nvarchar(max)  NOT NULL,
    [Price_PriceId] uniqueidentifier  NOT NULL,
    [Invoices_InvoiceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [PriceId] uniqueidentifier  NOT NULL,
    [Total] float  NOT NULL,
    [Tax] float  NOT NULL
);
GO

-- Creating table 'CounterParts'
CREATE TABLE [dbo].[CounterParts] (
    [CounterPartId] uniqueidentifier  NOT NULL,
    [Transporter_Name] nvarchar(max)  NOT NULL,
    [Transporter_Text] nvarchar(max)  NOT NULL,
    [Insurer_Text] nvarchar(max)  NOT NULL,
    [Insurer_Name] nvarchar(max)  NOT NULL,
    [Invoices_InvoiceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [ArticleId] uniqueidentifier  NOT NULL,
    [Code] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PriceField] float  NOT NULL,
    [Price_PriceId] uniqueidentifier  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [InvoiceId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC);
GO

-- Creating primary key on [TravelId] in table 'Travels'
ALTER TABLE [dbo].[Travels]
ADD CONSTRAINT [PK_Travels]
    PRIMARY KEY CLUSTERED ([TravelId] ASC);
GO

-- Creating primary key on [TripId] in table 'Trips'
ALTER TABLE [dbo].[Trips]
ADD CONSTRAINT [PK_Trips]
    PRIMARY KEY CLUSTERED ([TripId] ASC);
GO

-- Creating primary key on [SoldSeatId] in table 'SoldSeats'
ALTER TABLE [dbo].[SoldSeats]
ADD CONSTRAINT [PK_SoldSeats]
    PRIMARY KEY CLUSTERED ([SoldSeatId] ASC);
GO

-- Creating primary key on [PriceId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([PriceId] ASC);
GO

-- Creating primary key on [CounterPartId] in table 'CounterParts'
ALTER TABLE [dbo].[CounterParts]
ADD CONSTRAINT [PK_CounterParts]
    PRIMARY KEY CLUSTERED ([CounterPartId] ASC);
GO

-- Creating primary key on [ArticleId] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([ArticleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Invoice_InvoiceId] in table 'Travels'
ALTER TABLE [dbo].[Travels]
ADD CONSTRAINT [FK_InvoiceTravel]
    FOREIGN KEY ([Invoice_InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceTravel'
CREATE INDEX [IX_FK_InvoiceTravel]
ON [dbo].[Travels]
    ([Invoice_InvoiceId]);
GO

-- Creating foreign key on [Travel_TravelId] in table 'Trips'
ALTER TABLE [dbo].[Trips]
ADD CONSTRAINT [FK_TravelTrip]
    FOREIGN KEY ([Travel_TravelId])
    REFERENCES [dbo].[Travels]
        ([TravelId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelTrip'
CREATE INDEX [IX_FK_TravelTrip]
ON [dbo].[Trips]
    ([Travel_TravelId]);
GO

-- Creating foreign key on [Price_PriceId] in table 'SoldSeats'
ALTER TABLE [dbo].[SoldSeats]
ADD CONSTRAINT [FK_PriceSoldSeat]
    FOREIGN KEY ([Price_PriceId])
    REFERENCES [dbo].[Prices]
        ([PriceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceSoldSeat'
CREATE INDEX [IX_FK_PriceSoldSeat]
ON [dbo].[SoldSeats]
    ([Price_PriceId]);
GO

-- Creating foreign key on [Price_PriceId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_PriceInvoice]
    FOREIGN KEY ([Price_PriceId])
    REFERENCES [dbo].[Prices]
        ([PriceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceInvoice'
CREATE INDEX [IX_FK_PriceInvoice]
ON [dbo].[Invoices]
    ([Price_PriceId]);
GO

-- Creating foreign key on [Invoices_InvoiceId] in table 'CounterParts'
ALTER TABLE [dbo].[CounterParts]
ADD CONSTRAINT [FK_CounterPartInvoice]
    FOREIGN KEY ([Invoices_InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CounterPartInvoice'
CREATE INDEX [IX_FK_CounterPartInvoice]
ON [dbo].[CounterParts]
    ([Invoices_InvoiceId]);
GO

-- Creating foreign key on [Invoices_InvoiceId] in table 'SoldSeats'
ALTER TABLE [dbo].[SoldSeats]
ADD CONSTRAINT [FK_SoldSeatInvoice]
    FOREIGN KEY ([Invoices_InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoldSeatInvoice'
CREATE INDEX [IX_FK_SoldSeatInvoice]
ON [dbo].[SoldSeats]
    ([Invoices_InvoiceId]);
GO

-- Creating foreign key on [Price_PriceId] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [FK_PriceArticle]
    FOREIGN KEY ([Price_PriceId])
    REFERENCES [dbo].[Prices]
        ([PriceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceArticle'
CREATE INDEX [IX_FK_PriceArticle]
ON [dbo].[Articles]
    ([Price_PriceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------