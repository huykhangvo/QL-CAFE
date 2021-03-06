CREATE DATABASE QUANLYCAFE
GO
USE QUANLYCAFE
GO

CREATE TABLE NHANVIEN
(
	ID INT IDENTITY(1,1),
	MANV VARCHAR(10) PRIMARY KEY NOT NULL,
	TENNV NVARCHAR(30) NOT NULL,
	GIOITINH NVARCHAR(10) NOT NULL,
	NGAYSINH DATETIME NOT NULL,
	SDT VARCHAR(10) NOT NULL,
	TAIKHOAN VARCHAR(20) NOT NULL UNIQUE,
	MATKHAU VARCHAR(20) NOT NULL DEFAULT 12345,
	CHUCVU NVARCHAR(50) NOT NULL,
	DIACHI NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE KHACHHANG
(
	ID INT IDENTITY(1,1),
	MAKH VARCHAR(10) PRIMARY KEY NOT NULL,
	TENKH NVARCHAR(30) NOT NULL,
	SDT VARCHAR(10) NOT NULL UNIQUE,
)
GO
CREATE TABLE LOAIMON
(
	ID INT IDENTITY(1,1),
	MALOAI VARCHAR(10) PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(30) NOT NULL UNIQUE,
)
GO
CREATE TABLE MON
(
	ID INT IDENTITY(1,1),
	MAMON VARCHAR(10) PRIMARY KEY NOT NULL,
	TENMON NVARCHAR(30) NOT NULL UNIQUE,
	MALOAI VARCHAR(10) NOT NULL,
	DONGIA BIGINT NOT NULL,
	FOREIGN KEY(MALOAI) REFERENCES LOAIMON(MALOAI),
)
GO

CREATE TABLE HOADON
(
	ID INT IDENTITY(1,1),
	MAHD VARCHAR(10) PRIMARY KEY NOT NULL,
	MANV VARCHAR(10) NOT NULL,
	MAKH VARCHAR(10),
	SOBAN INT,
	NGAYBAN DATETIME NOT NULL,
	GIAMGIA BIGINT,
	TONGTIEN BIGINT,
	FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
)
GO
CREATE TABLE CTHD
(
	MAHD VARCHAR(10) NOT NULL,
	MAMON VARCHAR(10) NOT NULL,
	SL INT NOT NULL,
	DONGIA BIGINT,
	THANHTIEN BIGINT,
	FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD),
	FOREIGN KEY (MAMON) REFERENCES MON(MAMON),
)
GO
CREATE TABLE SANPHAM
(
	ID INT IDENTITY(1,1),
	MASP VARCHAR(10) PRIMARY KEY NOT NULL,
	TENSP NVARCHAR(30) NOT NULL UNIQUE,
	DVT NVARCHAR(30) NOT NULL,
	SL INT DEFAULT 0,
)
GO
CREATE TABLE PHIEUNHAP
(
	ID INT IDENTITY(1,1),
	MAPN VARCHAR(10) PRIMARY KEY NOT NULL,
	MANV VARCHAR(10) NOT NULL,
	NGAYNHAP DATETIME NOT NULL,
	FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
)
GO
CREATE TABLE CTPN
(
	MAPN VARCHAR(10) NOT NULL,
	MASP VARCHAR(10) NOT NULL,	
	SL INT NOT NULL,
	DONGIA BIGINT,
	THANHTIEN BIGINT,
	FOREIGN KEY(MAPN) REFERENCES PHIEUNHAP(MAPN),
	FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP),
)
GO
CREATE TABLE PHIEUXUAT
(
	ID INT IDENTITY(1,1),
	MAPX VARCHAR(10) PRIMARY KEY NOT NULL,
	MANV VARCHAR(10) NOT NULL,
	NGAYXUAT DATETIME NOT NULL,
	FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
)
GO
CREATE TABLE CTPX
(
	MAPX VARCHAR(10) NOT NULL,
	MASP VARCHAR(10) NOT NULL,
	SL INT NOT NULL,
	FOREIGN KEY(MAPX) REFERENCES PHIEUXUAT(MAPX),
	FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP),
)

GO
CREATE TABLE CHAMCONG
(
	ID INT IDENTITY(1,1),
	MACC VARCHAR(10) PRIMARY KEY NOT NULL,
	MANV VARCHAR(10) NOT NULL,
	NGAYCC DATETIME,
)
GO
CREATE TABLE CTCC
(
	MACC VARCHAR(10) NOT NULL,
	MANV VARCHAR(10) NOT NULL,
	LUONGTHEONGAY BIGINT NOT NULL,
	SONGAYLAM INT NOT NULL DEFAULT 0,
	SONGAYNGHI INT NOT NULL DEFAULT 0,
	TAMUNG BIGINT NOT NULL DEFAULT 0,
	THUONG BIGINT NOT NULL DEFAULT 0,
	PHAT BIGINT NOT NULL DEFAULT 0,
	GHICHU VARCHAR(500),
	THUCLANH BIGINT,
	FOREIGN KEY(MACC) REFERENCES CHAMCONG(MACC),
	FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
)
GO

--Nhan vien
INSERT INTO NHANVIEN(MANV,TENNV,DIACHI,NGAYSINH,GIOITINH,SDT,TAIKHOAN,CHUCVU) VALUES('18004085',N'Mai Nhật Nam',N'Vĩnh Long','5-21-2000',N'Nam','0392923693','namsuxi',N'Quản lý')
INSERT INTO NHANVIEN(MANV,TENNV,DIACHI,NGAYSINH,GIOITINH,SDT,TAIKHOAN,CHUCVU) VALUES('18004090',N'Đặng Trí Nguyên',N'Vĩnh Long','2-15-2000',N'Nam','0392923694','nguyendang',N'Quản lý')
INSERT INTO NHANVIEN(MANV,TENNV,DIACHI,NGAYSINH,GIOITINH,SDT,TAIKHOAN,CHUCVU) VALUES('18004112',N'Nguyễn Phát Tài',N'Vĩnh Long','1-6-2000',N'Nam','0392923695','tainguyen',N'Quản lý')
INSERT INTO NHANVIEN(MANV,TENNV,DIACHI,NGAYSINH,GIOITINH,SDT,TAIKHOAN,CHUCVU) VALUES('18004111',N'Nguyễn Ngọc Như',N'Vĩnh Long','1-15-2000',N'Nữ','0392923691','nhunguyen',N'Nhân viên')

INSERT INTO KHACHHANG(MAKH,TENKH,SDT) VALUES('KH1',N'NGUYEN VAN A','0392923693')
INSERT INTO KHACHHANG(MAKH,TENKH,SDT) VALUES('KH2',N'NGUYEN VAN B','0392923692')
INSERT INTO KHACHHANG(MAKH,TENKH,SDT) VALUES('KH3',N'NGUYEN VAN C','0392923694')
INSERT INTO KHACHHANG(MAKH,TENKH,SDT) VALUES('KH4',N'NGUYEN VAN D','0392923697')

--Loai mon
INSERT INTO LOAIMON(MALOAI,TENLOAI) VALUES('LM1',N'Cafe')
INSERT INTO LOAIMON(MALOAI,TENLOAI) VALUES('LM2',N'Trà')
INSERT INTO LOAIMON(MALOAI,TENLOAI) VALUES('LM3',N'Nước giải khát')
INSERT INTO LOAIMON(MALOAI,TENLOAI) VALUES('LM4',N'Sinh tố')

--Mon
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon1',N'Cafe đen đá','LM1',10000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon2',N'Cafe sữa đá','LM1',15000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon3',N'Cafe chồn','LM1',50000)

INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon4',N'Trà chanh','LM2',10000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon5',N'Trà đường','LM2',5000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon6',N'Trà đá','LM2',0)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon7',N'Trà sửa','LM2',20000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon8',N'Trà đào','LM2',10000)

INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon9',N'Tăng lực','LM3',15000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon10',N'Sting','LM3',10000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon11',N'Pepsi','LM3',10000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon12',N'Trà xanh','LM3',10000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon13',N'7Up','LM3',10000)

INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon14',N'Sinh tố dâu','LM4',20000)
INSERT INTO MON(MAMON,TENMON,MALOAI,DONGIA) VALUES('Mon15',N'Sinh tố bơ','LM4',20000)


--Hoa don
INSERT INTO HOADON(MAHD,MANV,MAKH,SOBAN,NGAYBAN) VALUES('HD1','18004112','KH1',1,'11-17-2020')
INSERT INTO HOADON(MAHD,MANV,MAKH,SOBAN,NGAYBAN) VALUES('HD2','18004085','KH2',2,'11-17-2020')
INSERT INTO HOADON(MAHD,MANV,MAKH,SOBAN,NGAYBAN) VALUES('HD3','18004090','KH3',3,'11-17-2020')

--CTHD
INSERT INTO CTHD(MAHD,MAMON,SL) VALUES('HD1','Mon1',1)
INSERT INTO CTHD(MAHD,MAMON,SL) VALUES('HD2','Mon2',2)
INSERT INTO CTHD(MAHD,MAMON,SL) VALUES('HD3','Mon3',3)

--San pham
INSERT INTO SANPHAM(MASP,TENSP,DVT,SL) VALUES('SP1',N'Cafe',N'Bịch',10)
INSERT INTO SANPHAM(MASP,TENSP,DVT,SL) VALUES('SP2',N'Trà',N'Thùng',20)
INSERT INTO SANPHAM(MASP,TENSP,DVT,SL) VALUES('SP3',N'Sting',N'Thùng',15)

--Phieu nhap
INSERT INTO PHIEUNHAP(MAPN,MANV,NGAYNHAP) VALUES('PN1','18004112','11-17-2020')
INSERT INTO PHIEUNHAP(MAPN,MANV,NGAYNHAP) VALUES('PN2','18004112','11-17-2020')

--CTPN
INSERT INTO CTPN(MAPN,MASP,SL,DONGIA) VALUES('PN1','SP1',20,50000)
INSERT INTO CTPN(MAPN,MASP,SL,DONGIA) VALUES('PN1','SP2',20,50000)
INSERT INTO CTPN(MAPN,MASP,SL,DONGIA) VALUES('PN2','SP1',15,105000)
INSERT INTO CTPN(MAPN,MASP,SL,DONGIA) VALUES('PN2','SP3',20,50000)

--Phieu xuat
INSERT INTO PHIEUXUAT(MAPX,MANV,NGAYXUAT) VALUES('PX1','18004090','11-13-2020')
INSERT INTO PHIEUXUAT(MAPX,MANV,NGAYXUAT) VALUES('PX2','18004090','11-14-2020')

--CTPX
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX1','SP1',2)
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX1','SP2',1)
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX1','SP3',2)
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX2','SP1',3)
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX2','SP2',2)
INSERT INTO CTPX(MAPX,MASP,SL) VALUES('PX2','SP3',4)

--Cham cong
INSERT INTO CHAMCONG VALUES ('MaCC1','18004112','1-12-2020')
INSERT INTO CHAMCONG VALUES ('MaCC2','18004085','1-12-2020')
INSERT INTO CHAMCONG VALUES ('MaCC3','18004090','1-12-2020')

INSERT INTO CTCC(MACC,MANV,LUONGTHEONGAY,SONGAYLAM,SONGAYNGHI) VALUES('MaCC1','18004085',200000,28,3)
INSERT INTO CTCC(MACC,MANV,LUONGTHEONGAY,SONGAYLAM,SONGAYNGHI) VALUES('MaCC2','18004090',300000,31,0)
INSERT INTO CTCC(MACC,MANV,LUONGTHEONGAY,SONGAYLAM,SONGAYNGHI) VALUES('MaCC3','18004112',300000,30,1)

--TRIGGER PN
GO
CREATE TRIGGER IS_PHIEUNHAP
ON CTPN
FOR INSERT
AS
BEGIN
	UPDATE SANPHAM SET SANPHAM.SL = SANPHAM.SL + inserted.SL FROM inserted, SANPHAM WHERE SANPHAM.MASP = inserted.MASP
END
GO

CREATE TRIGGER DL_PHIEUNHAP
ON CTPN
FOR DELETE
AS
BEGIN
	UPDATE SANPHAM SET SANPHAM.SL = SANPHAM.SL - deleted.SL FROM deleted, SANPHAM WHERE SANPHAM.MASP = deleted.MASP
END
GO

--TRIGGER PX
CREATE TRIGGER IS_PHIEUXUAT
ON CTPX
FOR INSERT
AS
BEGIN
	DECLARE @SLT INT;
	DECLARE @SL INT
	SELECT @SLT = SANPHAM.SL FROM SANPHAM, inserted WHERE SANPHAM.MASP = inserted.MASP
	SELECT @SL = inserted.SL FROM inserted,SANPHAM WHERE SANPHAM.MASP = inserted.MASP
	IF @SLT <@SL
		BEGIN
			RAISERROR(N'EROR',16,1)
			ROLLBACK TRANSACTION
		END
	ELSE
		BEGIN
			UPDATE SANPHAM SET SANPHAM.SL = SANPHAM.SL - inserted.SL FROM inserted, SANPHAM WHERE SANPHAM.MASP = inserted.MASP
		END
END
GO

CREATE TRIGGER DL_PHIEUXUAT
ON CTPX
FOR DELETE
AS
BEGIN
	UPDATE SANPHAM SET SANPHAM.SL = SANPHAM.SL + deleted.SL FROM deleted, SANPHAM WHERE SANPHAM.MASP = deleted.MASP
END
GO

CREATE PROCEDURE BAOCAODOANHTHU(@NGAYBATDAU DATETIME,@DENNGAY DATETIME)
AS
DECLARE @STAR DATETIME = @NGAYBATDAU
DECLARE @END DATETIME = @DENNGAY
SELECT HOADON.MANV+' - '+TENNV AS N'Nhân viên lập phiếu' ,CTHD.MAHD AS N'Mã hóa đơn', NGAYBAN AS N'Ngày bán',SUM(THANHTIEN) AS N'Doanh thu', @STAR AS N'Từ ngày',@END AS N'Đến ngày'
FROM CTHD,NHANVIEN,HOADON WHERE HOADON.MANV = NHANVIEN.MANV AND HOADON.MAHD = CTHD.MAHD AND NGAYBAN BETWEEN @NGAYBATDAU AND @DENNGAY 
GROUP BY CTHD.MAHD , NGAYBAN ,HOADON.MANV, NHANVIEN.TENNV
GO

CREATE PROCEDURE BAOCAOCHAMCONG(@MACC VARCHAR(10),@NGUOICHAMCONG NVARCHAR(30))
AS
DECLARE @NCC NVARCHAR(30) = @NGUOICHAMCONG
SELECT @NCC AS N'Người chấm công',CHAMCONG.MACC AS N'Phiếu chấm công',CTCC.MANV+' - '+TENNV AS N'Nhân viên',LUONGTHEONGAY AS N'Lương theo ngày', SONGAYLAM AS N'Số ngày làm', 
SONGAYLAM AS N'Số ngày nghỉ',THUONG AS N'Thưởng', PHAT AS N'Phạt',TAMUNG AS N'Tạm ứng',THUCLANH AS N'Thực lãng',GHICHU AS N'Ghi chú'
FROM CHAMCONG,CTCC,NHANVIEN
WHERE CHAMCONG.MACC=CTCC.MACC AND NHANVIEN.MANV=CTCC.MANV AND CHAMCONG.MACC=@MACC


SELECT CTHD.MAHD AS N'Mã hóa đơn', SUM(TONGTIEN) AS N'Doanh thu bán', NGAYBAN AS N'Ngày bán', TENNV AS N'Nhân viên lập phiếu' FROM CTHD,NHANVIEN,HOADON 
WHERE HOADON.MANV = NHANVIEN.MANV AND HOADON.MAHD = CTHD.MAHD AND NGAYBAN BETWEEN '12-16-2020' AND '12-18-2020' 
GROUP BY CTHD.MAHD , NGAYBAN ,HOADON.MANV, NHANVIEN.TENNV
