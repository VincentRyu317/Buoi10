create table Bang
(
	ThuTu int primary key,
	CauHoi Nvarchar(100),
	DapAn1 Nvarchar(100),
	DapAn2 Nvarchar(100),
	DapAn3 Nvarchar(100),
	DapAn4 Nvarchar(100)
)

ALTER TABLE Bang ADD DapAnDung nvarchar(1);
ALTER TABLE Bang ADD DapAnNguoiDung nvarchar(1);
Select * from Bang