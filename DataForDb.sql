USE MyStore;

INSERT INTO Categories
VALUES
('Smartphone'),
('Tablet'),
('Laptop'),
('PC'),
('TV'),
('Headphones')
GO

INSERT INTO Manufacturers
VALUES
('Apple'),
('Samsung'),
('Xiaomi'),
('Huawei'),
('Lenovo'),
('Asus'),
('Dell')
GO

INSERT INTO Products ([Name], [Description], Price, [Image], CategoryId, ManufacturerId, ShortDescript)
VALUES
('iPhone 12',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; font-size: 15px; line-height: inherit; font-family: Verdana, Arial, sans-serif; -webkit-font-smoothing: antialiased; vertical-align: baseline; color: rgb(4, 20, 39);">The&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;">6.1-inch iPhone 12</span>&nbsp;is a successor to the iPhone 11, while the&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;">5.4-inch iPhone 12</span>&nbsp;is an all-new size and marks the&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;">smallest iPhone</span>&nbsp;Apple has introduced since the 2016 iPhone SE. Aside from screen size and battery size, the two phones are technically identical. With its small size, the iPhone 12 mini is ideal for those who prefer an iPhone that can be&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;">used one-handed</span>.</p><p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; font-size: 15px; line-height: inherit; font-family: Verdana, Arial, sans-serif; -webkit-font-smoothing: antialiased; vertical-align: baseline; color: rgb(4, 20, 39);">All iPhone models this year feature&nbsp;<span style="margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: inherit; line-height: inherit; font-family: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;">Super Retina XDR OLED displays</span>&nbsp;for the first time, with an edge-to-edge design with the exception of the Face ID notch and small bezels around the edge. There is no difference in display quality between the standard iPhone 12 models and the Pro models.</p>', 
23000, 
'iPhone12.jpg', 
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Smartphone'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'The iPhone 12 is a part of Apple latest generation of smartphones, offering 5G connectivity and the A14 chip for better performance.'),

('Samsung Galaxy S20',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><font color="#000000" face="Open Sans">Samsung Galaxy S20 5G smartphone was launched on 11th February 2020. The phone comes with a 6.20-inch touchscreen display with a resolution of 1440x3200 pixels and an aspect ratio of 20:9. Samsung Galaxy S20 5G is powered by a 2GHz octa-core Samsung Exynos 990 processor that features 2 cores clocked at 2.73GHz, 2 cores clocked at 2.5GHz and 4 cores clocked at 2GHz. It comes with 12GB of RAM. The Samsung Galaxy S20 5G runs Android 10 and is powered by a 4000mAh non-removable battery. The Samsung Galaxy S20 5G supports wireless charging, as well as proprietary fast charging.</font><br></p>',
19500,
'SamsungS20.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Smartphone'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'One of the headline features of the Galaxy S20 line is its 120Hz refresh rate for the display, double the rate on most phones.'),

('Samsung Galaxy Fold',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><font color="#000000" face="Proxima Nova, sans-serif"><span style="font-size: 20px;">As a blueprint for how foldable phones could be truly useful, it undeniably succeeds. There is something physically satisfying about using the Fold, and its 7.3-inch screen is a dream for watching movies, looking at photos and reading anything. Wanting to multitask felt natural, and more than once I used the Fold as a second screen that was easy to fold up and zip into my jacket pocket the moment I was done.</span></font><br></p>',
30000,
'SamsungFold.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Smartphone'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'The Galaxy Fold extra-large display is excellent for watching videos, photos and reading!'),

('Xiaomi Mi 11 Ultra',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">It has a 5.5-inch Full-HD display and a 13 MP rear camera and 5 MP front camera. It runs on Android 5.1 Lollipop and is powered by a 4,100 mAh battery. In November 2016,&nbsp;</span><b style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">Xiaomi</b><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">&nbsp;released its new budget&nbsp;</span><b style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">phone</b><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">,&nbsp;</span><b style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">Redmi</b><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">&nbsp;4. It has a polycarbonate body, dual-SIM support and runs on MIUI 8 based on Android 6.0.1 Marshmallow.</span><br></p>',
20000,
'Xiaomi.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Smartphone'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Xiaomi'),
'It has a 5.5-inch Full-HD display and a 13 MP rear camera and 5 MP front camera.'),

('iPad Pro 12.9"',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(4, 20, 39); font-family: Verdana, Arial, sans-serif; font-size: 15px;">The iPad Pro is Apple high-end tablet computer. The latest iPad Pro models feature a powerful M1 chip, a Thunderbolt port, an improved front-facing camera, a Liquid Retina XDR mini-LED display option on the larger model, and up to 16GB of RAM and 2TB of storage. Apple typically updates the iPad Pro every 12 to 18 months.</span><br></p>',
22000,
'iPadPro.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Tablet'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'The Apple iPad Pro is a 12.9-inch touch screen tablet PC'),

('iPad 8th 10.2"',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(4, 20, 39); font-family: Verdana, Arial, sans-serif; font-size: 15px;">The iPad Pro is Apple high-end tablet computer. The latest iPad Pro models feature a powerful M1 chip, a Thunderbolt port, an improved front-facing camera, a Liquid Retina XDR mini-LED display option on the larger model, and up to 16GB of RAM and 2TB of storage. Apple typically updates the iPad Pro every 12 to 18 months.</span><br></p>',
12000,
'iPad8.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Tablet'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'The Apple iPad Pro is a 12.9-inch touch screen tablet PC'),

('iPad Pro 10.9"',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(4, 20, 39); font-family: Verdana, Arial, sans-serif; font-size: 15px;">The iPad Pro is Apple high-end tablet computer. The latest iPad Pro models feature a powerful M1 chip, a Thunderbolt port, an improved front-facing camera, a Liquid Retina XDR mini-LED display option on the larger model, and up to 16GB of RAM and 2TB of storage. Apple typically updates the iPad Pro every 12 to 18 months.</span><br></p>',
16000,
'iPad.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Tablet'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'The Apple iPad Pro is a 12.9-inch touch screen tablet PC'),

('MacBook Pro',
'<p style="margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">Apple&nbsp;</span><b style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">MacBook Pro</b><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">&nbsp;is a macOS laptop with a 13.30-inch display that has a resolution of 2560x1600 pixels. It is powered by a Core i5 processor and it comes with 12GB of RAM. The Apple&nbsp;</span><b style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">MacBook Pro</b><span style="color: rgb(32, 33, 36); font-family: arial, sans-serif;">&nbsp;packs 512GB of SSD storage.</span><br></p>',
40000,
'MacBook.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Laptop'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Apple'),
'MacOS laptop with a 13.30-inch display that has a resolution.'),

('Lenovo IdeaPad 15',
'Lenovo ThinkPad is a Windows 10 laptop with a 14.00-inch display that has a resolution of 1920x1080 pixels. It is powered by a Core i7 processor and it comes with 12GB of RAM. The Lenovo ThinkPad packs 256GB of SSD storage. Graphics are powered by Intel HD Graphics 520.',
24500,
'Lenovo5.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'Laptop'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Lenovo'),
'Lenovo ThinkPad is a Windows 10 laptop with a 14.00-inch display.'),

('Samsung Smart TV',
'<p style="text-align: justify; margin-right: 0px; margin-bottom: 20px; margin-left: 0px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; -webkit-font-smoothing: antialiased; vertical-align: baseline;"><span style="color: rgb(67, 67, 67); font-family: &quot;Open Sans&quot;, sans-serif; letter-spacing: -0.4px; text-align: start;">Samsung TVs, generally speaking, are very versatile and can provide good to very good picture quality. Samsung is known for their LED models that generally have VA panels, and their highest-end models are great for gaming. Samsung introduced new Neo QLED TVs in 2021, shifting their regular QLEDs down the lineup. So, while 2021s Samsung Q80/Q80A QLED replaces 2020s Samsung Q80/Q80T QLED&nbsp;and so on, there are now more high-end models to choose from with the Neo QLED lineup.</span><br></p>',
30500,
'samsungTV.jpg',
(SELECT TOP 1 [Id]
FROM Categories
WHERE [Name] = 'TV'),
(SELECT TOP 1 [Id]
FROM Manufacturers
WHERE [Name] = 'Samsung'),
'Lenovo ThinkPad is a Windows 10 laptop with a 14.00-inch display.')