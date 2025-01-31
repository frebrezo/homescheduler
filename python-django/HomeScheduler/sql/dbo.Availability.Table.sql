USE [HomeScheduler]
GO
/****** Object:  Table [dbo].[Availability]    Script Date: 10/3/2023 8:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availability](
	[AvailabilityId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Available] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](256) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Availability] PRIMARY KEY CLUSTERED 
(
	[AvailabilityId] ASC
)
)
GO
/****** Object:  Index [UX_Availability_UserId]    Script Date: 10/3/2023 8:22:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Availability_UserId] ON [dbo].[Availability]
(
	[UserId] ASC
)
GO
ALTER TABLE [dbo].[Availability] ADD  CONSTRAINT [DF_Availability_Available]  DEFAULT ((0)) FOR [Available]
GO
ALTER TABLE [dbo].[Availability]  WITH CHECK ADD  CONSTRAINT [FK_Availability_UserId_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Availability] CHECK CONSTRAINT [FK_Availability_UserId_User_UserId]
GO
