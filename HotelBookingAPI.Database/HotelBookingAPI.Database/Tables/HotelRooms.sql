CREATE TABLE [Hotel].[HotelRooms]
(
	HotelRoomId			UNIQUEIDENTIFIER     NOT NULL		CONSTRAINT PK_HotelRooms_HotelRoomId	 PRIMARY KEY,
	HotelId				UNIQUEIDENTIFIER	 NOT NULL		CONSTRAINT FK_HotelRooms_HotelId		 FOREIGN KEY REFERENCES Hotel.Hotels(HotelId),
	RoomType			NVARCHAR(50)		 NOT NULL,
	RoomNumber			INT					 NOT NULL
)
