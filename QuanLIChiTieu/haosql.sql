create table QuanLyChiTieuCaNhan(
Id int identity(1,1) primary key,
Date date not null,
Amount int not null,
Detail nvarchar(max) null



)