CREATE TABLE [dbo].[Shipping] (
    [User_ID]           INT          IDENTITY (1, 1) NOT NULL,
    [Ship_Address]      VARCHAR (50) NOT NULL,
    [Ship_Instructions] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[User]
);
