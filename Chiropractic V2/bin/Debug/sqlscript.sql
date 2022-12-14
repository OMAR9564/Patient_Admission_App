Create database Chiropractic
GO
use [Chiropractic]
GO
/****** Object:  Table [dbo].[AgreementText]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgreementText](
	[Center_Name] [nvarchar](250) NULL,
	[Agreement_text] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Name] [nvarchar](250) NULL,
	[Date] [nvarchar](50) NULL,
	[Hour] [nvarchar](50) NULL,
	[Method] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Commnet] [nvarchar](250) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deserved]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deserved](
	[Des_ID] [int] NOT NULL,
	[Price] [real] NULL,
	[Date] [nvarchar](50) NULL,
	[Notes] [nvarchar](250) NULL,
	[Type_ID] [int] NULL,
 CONSTRAINT [PK_Deserved] PRIMARY KEY CLUSTERED 
(
	[Des_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deserved_Type]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deserved_Type](
	[Des_ID] [int] NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Des_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[No] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Surname] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Logo] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[New_Patients]    Script Date: 9/12/2021 1:41:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[New_Patients](
	[Patient_ID] [int] NOT NULL,
	[Patient_Name] [nvarchar](250) NULL,
	[Patient_Surname] [nvarchar](250) NULL,
	[Patient_Phone] [nvarchar](50) NULL,
	[Patient_OldGoOtherDr] [nvarchar](50) NULL,
	[Patient_HealthAbout] [nvarchar](250) NULL,
	[Patient_Surgical] [nvarchar](50) NULL,
	[Patient_Date] [nvarchar](50) NULL,
 CONSTRAINT [PK_New_Patients] PRIMARY KEY CLUSTERED 
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
