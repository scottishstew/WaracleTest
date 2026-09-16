CREATE TABLE [Hotel].[HotelRoomBookings]
(
	HotelRoomBookingId		UNIQUEIDENTIFIER	 NOT NULL		CONSTRAINT PK_HotelBooking_HotelBookingId		 PRIMARY KEY,
	HotelId					UNIQUEIDENTIFIER	 NOT NULL		CONSTRAINT FK_HotelBooking_HotelId				 FOREIGN KEY REFERENCES Hotel.Hotels (HotelId),
	HotelRoomId				UNIQUEIDENTIFIER	 NOT NULL		CONSTRAINT FK_HotelBooking_HotelRoomId			 FOREIGN KEY REFERENCES Hotel.HotelRooms (HotelRoomId),
	BookingReference		NVARCHAR(MAX)		 NOT NULL,		
	FromDate				DATETIME			 NOT NULL,
	ToDate					DATETIME			 NOT NULL,
	NumberOfGuests			INT					 NOT NULL,
	BookerName				NVARCHAR(MAX)		 NOT NULL
)