using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlusLTD.Data.Migrations
{
    public partial class EventsPlusLTD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TicketPrice = table.Column<float>(type: "real", nullable: false),
                    StartDateandTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateandTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventStatus = table.Column<int>(type: "int", nullable: false),
                    EventPictureOne = table.Column<byte>(type: "tinyint", nullable: true),
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Organizer_OrganizerID",
                        column: x => x.OrganizerID,
                        principalTable: "Organizer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentConfirmed = table.Column<bool>(name: "PaymentConfirmed?", type: "bit", nullable: false),
                    Quantityoftickets = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    AttendeeID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Attendee_AttendeeID",
                        column: x => x.AttendeeID,
                        principalTable: "Attendee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VenueCapacity = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    VenuePictureOne = table.Column<byte>(type: "tinyint", nullable: true),
                    VenuePictureTwo = table.Column<byte>(type: "tinyint", nullable: true),
                    VenuePictureThree = table.Column<byte>(type: "tinyint", nullable: true),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Venues_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameoncard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityCode = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_City",
                table: "Attendee",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_DoB",
                table: "Attendee",
                column: "DoB");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_EmailAddress",
                table: "Attendee",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_FirstName",
                table: "Attendee",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_Gender",
                table: "Attendee",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_ID",
                table: "Attendee",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_LastName",
                table: "Attendee",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_PhoneNumber",
                table: "Attendee",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_Postcode",
                table: "Attendee",
                column: "Postcode");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_StreetAddress",
                table: "Attendee",
                column: "StreetAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AttendeeID",
                table: "Bookings",
                column: "AttendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingDate",
                table: "Bookings",
                column: "BookingDate");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventID",
                table: "Bookings",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ID",
                table: "Bookings",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentConfirmed?",
                table: "Bookings",
                column: "PaymentConfirmed?");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Quantityoftickets",
                table: "Bookings",
                column: "Quantityoftickets");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TotalPrice",
                table: "Bookings",
                column: "TotalPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreationDate",
                table: "Event",
                column: "CreationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Description",
                table: "Event",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EndDateandTime",
                table: "Event",
                column: "EndDateandTime");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventName",
                table: "Event",
                column: "EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventPictureOne",
                table: "Event",
                column: "EventPictureOne");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventStatus",
                table: "Event",
                column: "EventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventType",
                table: "Event",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ID",
                table: "Event",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_ModifiedDate",
                table: "Event",
                column: "ModifiedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerID",
                table: "Event",
                column: "OrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_RegistrationEndDate",
                table: "Event",
                column: "RegistrationEndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Event_StartDateandTime",
                table: "Event",
                column: "StartDateandTime");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TicketPrice",
                table: "Event",
                column: "TicketPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_City",
                table: "Organizer",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_DoB",
                table: "Organizer",
                column: "DoB");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_EmailAddress",
                table: "Organizer",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_FirstName",
                table: "Organizer",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_Gender",
                table: "Organizer",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_ID",
                table: "Organizer",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_LastName",
                table: "Organizer",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_PhoneNumber",
                table: "Organizer",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_Postcode",
                table: "Organizer",
                column: "Postcode");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_StreetAddress",
                table: "Organizer",
                column: "StreetAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingID",
                table: "Payments",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CardNumber",
                table: "Payments",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CardType",
                table: "Payments",
                column: "CardType");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ExpiryDate",
                table: "Payments",
                column: "ExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ID",
                table: "Payments",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Nameoncard",
                table: "Payments",
                column: "Nameoncard");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SecurityCode",
                table: "Payments",
                column: "SecurityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_City",
                table: "Venues",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_EventID",
                table: "Venues",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_ID",
                table: "Venues",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Postcode",
                table: "Venues",
                column: "Postcode");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_StreetAddress",
                table: "Venues",
                column: "StreetAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueCapacity",
                table: "Venues",
                column: "VenueCapacity");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenuePictureOne",
                table: "Venues",
                column: "VenuePictureOne");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenuePictureThree",
                table: "Venues",
                column: "VenuePictureThree");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenuePictureTwo",
                table: "Venues",
                column: "VenuePictureTwo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Organizer");
        }
    }
}
