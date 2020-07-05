USE [kitchen]
GO
/****** Object:  Table [dbo].[details_order]    Script Date: 5/7/2020 1:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[details_order](
	[id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[menu_item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_details_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_Items]    Script Date: 5/7/2020 1:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_Items](
	[item_name] [nchar](50) NOT NULL,
	[category_id] [int] NOT NULL,
	[description] [nchar](100) NULL,
	[ingredients] [text] NULL,
	[active] [bit] NOT NULL,
	[vege] [bit] NOT NULL,
	[lactose] [bit] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_menu_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 5/7/2020 1:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] NOT NULL,
	[order_status] [int] NOT NULL,
	[order_time] [date] NOT NULL,
	[ready_time] [date] NULL,
	[total_price] [real] NOT NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[menu_Items] ON 
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Zupa pomidorowa                                   ', 1, N'Zupa jest łagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 7, 6)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Krupnik                                           ', 1, N'Polska zupa z ziemniakami, kaszą jęczmienną i marchewką. Przygotowana jest na wywarze drobiowym.    ', N'ok. 600 g (2 sztuki) udek z kurczaka
2 litry wody
1 cebula
4 sredniej wielkosci ziemniaki
1 duza marchewka
5 lyzek kaszy jeczmiennej np. mazurska (wedlug uznania grubsza lub drobniejsza)
2 liscie laurowe
3 ziarna ziela angielskiego
5 ziaren czarnego pieprzu
1 lyzeczka soli
sól, czarny pieprz mielony do smaku
posiekana natka pietruszki i koperek', 1, 1, 1, 8, 6)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Rosół z kurczaka                                  ', 1, N'Rosół to tradycyjna, polska zupa, uwielbiana przez dzieci i dorosłych.                              ', N'kartofelki', 1, 1, 1, 9, 6)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Placki ziemniaczano- marchewkowe                  ', 2, N'Placki ziemniaczane wzbogacone o marchewkę i zieloną cebulkę, starte na grubych oczkach tarki.      ', N'ok. 500 g ziemniaków
2 nieduze marchewki (ok. 140g)
zielona cebulka lub szczypiorek
3 jajka (rozmiar M)
4 lyzki kaszy mannej (w wersji bezglutenowej: kaszy kukurydzianej)
sól, pieprz
olej do smazenia', 1, 1, 1, 10, 16)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Pierogi z serkiem kremowym                        ', 2, N'Pierogi nadziewane gęstym, kremowym serkiem.                                                        ', N'500 g maki pszennej
ok. 300 ml goracej, przegotowanej wody
1 plaska lyzka soli', 1, 1, 1, 11, 13)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Pierogi ruskie                                    ', 2, N'Cienkie, elastyczne ciasto pierogowe wypełnione farszem z twarogu, ugotowanych ziemniaków.          ', N'Ciasto pierogowe:

500 g maki pszennej
ok. 300 ml goracej, przegotowanej wody
1 plaska lyzka soli
Nadzienie:

500 g ziemniaków
500 g twarogu tlustego lub póltlustego
1 duza cebula
sól, pieprz
1 lyzka oleju do smazenia', 0, 1, 1, 12, 14)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Coca-cola                                         ', 3, N'x                                                                                                   ', N'Cienkie, elastyczne ciasto pierogowe wypelnione farszem z twarogu, ugotowanych ziemniaków i podsmazonej cebuli.', 1, 1, 1, 13, 5)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Pepsi                                             ', 3, N'x                                                                                                   ', N'x', 1, 1, 1, 14, 5)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Kompot                                            ', 3, NULL, NULL, 1, 0, 0, 18, 4)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Smoothie                                          ', 3, N'Smoothie z bananów.                                                                                 ', NULL, 1, 0, 0, 20, 9)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Kasztany jadalne                                  ', 4, N'Kasztany jadalne są lekko sypkie i słodkawe.                                                        ', NULL, 1, 0, 0, 21, 12.5)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Rogaliki ziemniaczane z fetą                      ', 4, N'Miękkie, ziemniaczane rogaliki z nadzieniem z sera fety i natki pietruszki.                         ', N'3 sredniej wielkosci ziemniaki jajko ok. 500g maki pszennej 3 lyzeczki proszku do pieczenia 125g masla sól, pieprz 125g sera feta 2 lyzki posiekanej natki pietruszki', 1, 0, 0, 22, 7.2)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Sernik z białą czekoladą                          ', 5, N'x                                                                                                   ', N'Spód:

150 g herbatników
1 lyzka kakao
60 g masla
Masa serowa:

300 g bialej czekolady
250 g serka mascarpone, temperatura pokojowa
500 g twarogu z wiaderka lub quarku, temperatura pokojowa
3 jajka (rozmiar M), temperatura pokojowa
20 g skrobi ziemniaczanej lub kukurydzianej
50 g cukru
2 lyzeczki cukru waniliowego
skórka starta z 1 cytryny
sok wycisniety z 1 cytryny', 1, 1, 0, 23, 11)
GO
INSERT [dbo].[menu_Items] ([item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [id], [price]) VALUES (N'Lody truskawkowe bez jajek                        ', 5, N'Mocno truskawkowe, pyszne, aromatyczne, domowe lody z maszyny bez dodatku jajek.                    ', N'500 g truskawek ok. 60 g cukru (lub do smaku) 2 lyzki soku z cytryny 200 g slodkiej smietany 30- 36%', 1, 1, 1, 24, 6.99)
GO
SET IDENTITY_INSERT [dbo].[menu_Items] OFF
GO
ALTER TABLE [dbo].[details_order]  WITH CHECK ADD  CONSTRAINT [FK_details_order_menu_Items] FOREIGN KEY([menu_item_id])
REFERENCES [dbo].[menu_Items] ([id])
GO
ALTER TABLE [dbo].[details_order] CHECK CONSTRAINT [FK_details_order_menu_Items]
GO
ALTER TABLE [dbo].[details_order]  WITH CHECK ADD  CONSTRAINT [FK_details_order_orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([id])
GO
ALTER TABLE [dbo].[details_order] CHECK CONSTRAINT [FK_details_order_orders]
GO
