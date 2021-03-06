USE [NewKitchen]
GO
/****** Object:  Table [dbo].[DetailsOrder]    Script Date: 19/7/2020 9:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailsOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[menu_item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_DetailsOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 19/7/2020 9:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[item_name] [text] NOT NULL,
	[category_id] [int] NOT NULL,
	[description] [text] NULL,
	[ingredients] [text] NULL,
	[active] [bit] NOT NULL,
	[vege] [bit] NOT NULL,
	[lactose] [bit] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 19/7/2020 9:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_status] [int] NOT NULL,
	[order_time] [datetime2](7) NULL,
	[ready_time] [datetime2](7) NULL,
	[total_price] [float] NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DetailsOrder] ON 

INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (1, 2, 27, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (2, 2, 27, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (3, 2, 21, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (4, 2, 22, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (5, 2, 22, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (6, 4, 8, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (7, 4, 14, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (8, 5, 28, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (9, 5, 22, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (10, 6, 7, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (11, 6, 22, 9)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (12, 8, 8, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (13, 8, 22, 3)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (14, 8, 24, 2)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (15, 9, 8, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (16, 9, 23, 1)
INSERT [dbo].[DetailsOrder] ([id], [order_id], [menu_item_id], [quantity]) VALUES (17, 9, 23, 1)
SET IDENTITY_INSERT [dbo].[DetailsOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 

INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (7, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (8, N'Krupnik                                           ', 1, N'Polska zupa z ziemniakami, kasza jeczmienna i marchewka. Przygotowana jest na wywarze drobiowym.    ', N'ok. 600 g (2 sztuki) udek z kurczaka
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
posiekana natka pietruszki i koperek', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (9, N'Rosól z kurczaka                                  ', 1, N'Rosól to tradycyjna, polska zupa, uwielbiana przez dzieci i doroslych.                              ', N'kartofelki', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (10, N'Placki ziemniaczano- marchewkowe                  ', 2, N'Placki ziemniaczane wzbogacone o marchewke i zielona cebulke, starte na grubych oczkach tarki.      ', N'ok. 500 g ziemniaków
2 nieduze marchewki (ok. 140g)
zielona cebulka lub szczypiorek
3 jajka (rozmiar M)
4 lyzki kaszy mannej (w wersji bezglutenowej: kaszy kukurydzianej)
sól, pieprz
olej do smazenia', 1, 1, 1, 16)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (11, N'Pierogi z serkiem kremowym                        ', 2, N'Pierogi nadziewane gestym, kremowym serkiem.                                                        ', N'500 g maki pszennej
ok. 300 ml goracej, przegotowanej wody
1 plaska lyzka soli', 1, 1, 1, 13)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (12, N'Pierogi ruskie                                    ', 2, N'Cienkie, elastyczne ciasto pierogowe wypelnione farszem z twarogu, ugotowanych ziemniaków.          ', N'Ciasto pierogowe:

500 g maki pszennej
ok. 300 ml goracej, przegotowanej wody
1 plaska lyzka soli
Nadzienie:

500 g ziemniaków
500 g twarogu tlustego lub póltlustego
1 duza cebula
sól, pieprz
1 lyzka oleju do smazenia', 0, 1, 1, 14)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (13, N'Coca-cola                                         ', 3, N'x                                                                                                   ', N'Cienkie, elastyczne ciasto pierogowe wypelnione farszem z twarogu, ugotowanych ziemniaków i podsmazonej cebuli.', 1, 1, 1, 5)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (14, N'Pepsi                                             ', 3, N'x                                                                                                   ', N'x', 1, 1, 1, 5)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (18, N'Kompot                                            ', 3, NULL, NULL, 1, 0, 0, 4)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (20, N'Smoothie                                          ', 3, N'Smoothie z bananów.                                                                                 ', NULL, 1, 0, 0, 9)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (21, N'Kasztany jadalne                                  ', 4, N'Kasztany jadalne sa lekko sypkie i slodkawe.                                                        ', NULL, 1, 0, 0, 12.5)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (22, N'Rogaliki ziemniaczane z feta                      ', 4, N'Miekkie, ziemniaczane rogaliki z nadzieniem z sera fety i natki pietruszki.                         ', N'3 sredniej wielkosci ziemniaki jajko ok. 500g maki pszennej 3 lyzeczki proszku do pieczenia 125g masla sól, pieprz 125g sera feta 2 lyzki posiekanej natki pietruszki', 1, 0, 0, 7.2)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (23, N'Sernik z biala czekolada                          ', 5, N'x                                                                                                   ', N'Spód:

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
sok wycisniety z 1 cytryny', 1, 1, 0, 11)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (24, N'Lody truskawkowe bez jajek                        ', 5, N'Mocno truskawkowe, pyszne, aromatyczne, domowe lody z maszyny bez dodatku jajek.                    ', N'500 g truskawek ok. 60 g cukru (lub do smaku) 2 lyzki soku z cytryny 200 g slodkiej smietany 30- 36%', 1, 1, 1, 6.99)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (25, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (26, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (27, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (28, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (29, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
INSERT [dbo].[MenuItems] ([id], [item_name], [category_id], [description], [ingredients], [active], [vege], [lactose], [price]) VALUES (30, N'Zupa pomidorowa                                   ', 1, N'Zupa jest lagodna, kremowa i bardzo smaczna. Lubiana bardzo przez dzieci.                           ', N'ok.600 g (2 sztuki) udek z kurczaka (lub skrzydelka, caly korpus z kurczaka, kosci ze schabu, zeberka itp.)
2 litry wody
ok. 300 g marchewki
ok. 130 g pietruszki
ok. 100 g korzenia selera
kawalek pora
cebula
6 ziaren ziela angielskiego
5 ziaren czarnego pieprzu
2 liscie laurowe', 1, 1, 1, 6)
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (2, 2, CAST(N'2020-07-18T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-19T15:40:38.0000000' AS DateTime2), 51, N'Stolik nr 5')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (3, 1, CAST(N'2020-07-18T00:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2), 38.2, N'stolik 11')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (4, 1, CAST(N'2020-07-18T11:32:05.0000000' AS DateTime2), CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2), 11, N'Zupa i Pepsi dla stolika nr 22')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (5, 1, CAST(N'2020-07-18T13:40:26.0000000' AS DateTime2), CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2), 13.2, N'test')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (6, 1, CAST(N'2020-07-18T16:16:48.0000000' AS DateTime2), CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2), 70.8, N'Stolik nr 11')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (7, 2, CAST(N'2020-07-18T22:38:24.0000000' AS DateTime2), CAST(N'2020-07-19T16:07:15.0000000' AS DateTime2), 0, N'')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (8, 2, CAST(N'2020-07-19T15:40:38.0000000' AS DateTime2), CAST(N'2020-07-19T15:54:44.0000000' AS DateTime2), 41.58, N'Stolik nr 10, zupa dla mezczyzny')
INSERT [dbo].[Orders] ([id], [order_status], [order_time], [ready_time], [total_price], [note]) VALUES (9, 1, CAST(N'2020-07-19T18:09:44.0000000' AS DateTime2), CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2), 28, N'Zamówienie')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[DetailsOrder]  WITH CHECK ADD  CONSTRAINT [FK_DetailsOrder_MenuItems] FOREIGN KEY([menu_item_id])
REFERENCES [dbo].[MenuItems] ([id])
GO
ALTER TABLE [dbo].[DetailsOrder] CHECK CONSTRAINT [FK_DetailsOrder_MenuItems]
GO
ALTER TABLE [dbo].[DetailsOrder]  WITH CHECK ADD  CONSTRAINT [FK_DetailsOrder_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[DetailsOrder] CHECK CONSTRAINT [FK_DetailsOrder_Orders]
GO
