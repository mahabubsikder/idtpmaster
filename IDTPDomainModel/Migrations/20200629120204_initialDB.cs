using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDTPDomainModel.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ActionDescription = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    ActivityLogKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    PageUrl = table.Column<string>(nullable: true),
                    ActivityDate = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.ActivityLogKey);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    TotalPaidAmount = table.Column<decimal>(nullable: false),
                    TotalDueAmount = table.Column<decimal>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DBLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceLocationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    LatLong = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    IEMEIID = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    App = table.Column<string>(nullable: true),
                    Capability = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceLocationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disbursements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderVID = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ReferenceNo = table.Column<string>(nullable: true),
                    DeviceLocationInfoId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disbursements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisputeAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisputeAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisputeSeverity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisputeSeverity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinInstitutionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    InstitutionName = table.Column<string>(nullable: true),
                    InstitutionBranch = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonDesignation = table.Column<string>(nullable: true),
                    ContactPersonOffice = table.Column<string>(nullable: true),
                    ContactPersonNID = table.Column<string>(nullable: true),
                    ContactPersonMobile = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: false),
                    PINSalt = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinInstitutionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovtBillPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    BillInfo = table.Column<string>(nullable: true),
                    OtherInfo = table.Column<string>(nullable: true),
                    DeviceLocationInfoId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovtBillPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovtInstitutionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonDesignation = table.Column<string>(nullable: true),
                    ContactPersonOffice = table.Column<string>(nullable: true),
                    ContactPersonNID = table.Column<string>(nullable: true),
                    ContactPersonMobile = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: false),
                    PINSalt = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovtInstitutionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDTPAppErrorLog",
                columns: table => new
                {
                    Errorlogkey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ErrorType = table.Column<int>(nullable: false),
                    ErrorStackTrace = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true),
                    ErrorTimeStamp = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPAppErrorLog", x => x.Errorlogkey);
                });

            migrationBuilder.CreateTable(
                name: "IDTPErrorLog",
                columns: table => new
                {
                    Errorlogkey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ErrorNumber = table.Column<int>(nullable: false),
                    ErrorContext = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true),
                    ErrorTimeStamp = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPErrorLog", x => x.Errorlogkey);
                });

            migrationBuilder.CreateTable(
                name: "IDTPPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDTPUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NID = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankBranch = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    PIN = table.Column<string>(nullable: false),
                    PINSalt = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    VID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Basic = table.Column<double>(nullable: false),
                    TotalAllowance = table.Column<double>(nullable: false),
                    TotalDeductions = table.Column<double>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayeeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAuthorization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    OtherInfo = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAuthorization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    OtherInfo = table.Column<string>(nullable: true),
                    DeviceLocationInfoId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ReportName = table.Column<string>(nullable: true),
                    ReportPath = table.Column<string>(nullable: true),
                    SProcName = table.Column<string>(nullable: true),
                    HasFilter = table.Column<bool>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseStatus = table.Column<string>(nullable: true),
                    ResponseMessage = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    EntityTransactionRef = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspenseTransactionHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SuspenseTransactionId = table.Column<Guid>(nullable: false),
                    SenderAccountNo = table.Column<string>(nullable: true),
                    SendingBankId = table.Column<int>(nullable: true),
                    SendingBankSuspanseAccount = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    SuspenseStatus = table.Column<bool>(nullable: true),
                    TransactionInitiatedOn = table.Column<DateTime>(nullable: true),
                    SuspenseClearingTime = table.Column<DateTime>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseTransactionHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    RequestFrom = table.Column<string>(nullable: true),
                    RequestTo = table.Column<string>(nullable: true),
                    RequestMessage = table.Column<string>(nullable: true),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionStatusName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferFund",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Narration = table.Column<string>(nullable: true),
                    SenderBankId = table.Column<int>(nullable: true),
                    ReceiverBankId = table.Column<int>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    SendingBankRoutingNo = table.Column<string>(nullable: true),
                    ReceivingBankRoutingNo = table.Column<string>(nullable: true),
                    DeviceLocationInfoId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferFund", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    InstituteType = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NID = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialInstitution",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    InstitutionName = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonDesignation = table.Column<string>(nullable: true),
                    ContactPersonOffice = table.Column<string>(nullable: true),
                    ContactPersonNID = table.Column<string>(nullable: true),
                    ContactPersonMobile = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInstitution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialInstitution_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentInstitution",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonDesignation = table.Column<string>(nullable: true),
                    ContactPersonOffice = table.Column<string>(nullable: true),
                    ContactPersonNID = table.Column<string>(nullable: true),
                    ContactPersonMobile = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentInstitution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentInstitution_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDTPUserAdmin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPUserAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IDTPUserAdmin_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    PaymentAmount = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisbursementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DisbursementId = table.Column<int>(nullable: true),
                    ReceiverVID = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbursementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisbursementDetails_Disbursements_DisbursementId",
                        column: x => x.DisbursementId,
                        principalTable: "Disbursements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantCap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CurrentNetDebitCap = table.Column<decimal>(nullable: false),
                    RequestedNetDebitCap = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantCap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantCap_FinInstitutionInfo_Id",
                        column: x => x.Id,
                        principalTable: "FinInstitutionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantCapHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CurrentNetDebitCap = table.Column<decimal>(nullable: false),
                    PreviousNetDebitCap = table.Column<decimal>(nullable: false),
                    FinInstitutionInfoId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantCapHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantCapHistory_FinInstitutionInfo_FinInstitutionInfoId",
                        column: x => x.FinInstitutionInfoId,
                        principalTable: "FinInstitutionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IDTPUserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IdentityTypeId = table.Column<int>(nullable: true),
                    EntityTypeId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    VirtualId = table.Column<string>(nullable: true),
                    NidTinBin = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    SecretSalt = table.Column<string>(nullable: true),
                    DeviceLocationInfoId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTPUserEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IDTPUserEntity_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IDTPUserEntity_IdentityType_IdentityTypeId",
                        column: x => x.IdentityTypeId,
                        principalTable: "IdentityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryType = table.Column<string>(nullable: true),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    BeneficiaryBranch = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiary_IDTPUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndUserLimit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DailyLimitCount = table.Column<int>(nullable: false),
                    DailyLimitAmount = table.Column<decimal>(nullable: false),
                    MonthlyLimitCount = table.Column<int>(nullable: false),
                    MonthlyLimitAmount = table.Column<decimal>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUserLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndUserLimit_IDTPUser_Id",
                        column: x => x.Id,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupManagement_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroupManagement_IDTPUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupRoleManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoleManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRoleManagement_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupRoleManagement_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: true),
                    PermissionId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionManagement_IDTPPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "IDTPPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissionManagement_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_IDTPUser_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_IDTPUser_SenderId",
                        column: x => x.SenderId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TransactionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_IDTPUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionValueLimit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Limit = table.Column<decimal>(nullable: false),
                    FinInstitutionInfoId = table.Column<int>(nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionValueLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionValueLimit_FinInstitutionInfo_FinInstitutionInfoId",
                        column: x => x.FinInstitutionInfoId,
                        principalTable: "FinInstitutionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionValueLimit_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SwiftBic = table.Column<string>(nullable: true),
                    SuspenseAccount = table.Column<string>(nullable: true),
                    CbaccountNo = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_FinancialInstitution_Id",
                        column: x => x.Id,
                        principalTable: "FinancialInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantDebitCap",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CurrentNetDebitCap = table.Column<decimal>(nullable: false),
                    ActualDebitCap = table.Column<decimal>(nullable: false),
                    SettlementStatus = table.Column<bool>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantDebitCap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantDebitCap_FinancialInstitution_Id",
                        column: x => x.Id,
                        principalTable: "FinancialInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    ResponseId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalTransaction_Beneficiary_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Beneficiary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalTransaction_Response_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalTransaction_IDTPUser_SenderId",
                        column: x => x.SenderId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalTransaction_TransactionStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TransactionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalTransaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisputeTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    OriginatorTypeId = table.Column<int>(nullable: true),
                    OriginatorId = table.Column<int>(nullable: true),
                    ExecutorTypeId = table.Column<int>(nullable: true),
                    ExecutorId = table.Column<int>(nullable: true),
                    TransactionSettlementStatusId = table.Column<int>(nullable: true),
                    DisputeSettlementType = table.Column<string>(nullable: true),
                    DisputeSettlementTime = table.Column<DateTime>(nullable: false),
                    DisputeSettlementStatus = table.Column<bool>(nullable: true),
                    DisputeSeverityId = table.Column<int>(nullable: true),
                    DisputeSettledBy = table.Column<int>(nullable: true),
                    DisputeTitle = table.Column<string>(nullable: true),
                    DisputeType = table.Column<string>(nullable: true),
                    DisputeDetail = table.Column<string>(nullable: true),
                    DisputeActionId = table.Column<int>(nullable: true),
                    ParticipantAction = table.Column<bool>(nullable: true),
                    ParticipantResponseText = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisputeTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisputeTransaction_DisputeAction_DisputeActionId",
                        column: x => x.DisputeActionId,
                        principalTable: "DisputeAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisputeTransaction_DisputeSeverity_DisputeSeverityId",
                        column: x => x.DisputeSeverityId,
                        principalTable: "DisputeSeverity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisputeTransaction_Transaction_Id",
                        column: x => x.Id,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NotificationDate = table.Column<DateTime>(nullable: false),
                    SenderConcurrentBalance = table.Column<double>(nullable: false),
                    ReceiverConcurrentBalance = table.Column<double>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    IDTPUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_IDTPUser_IDTPUserId",
                        column: x => x.IDTPUserId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_Transaction_Id",
                        column: x => x.Id,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMonitoringInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    Flagged = table.Column<bool>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Alert = table.Column<string>(nullable: true),
                    RequsetFrom = table.Column<int>(nullable: false),
                    IMEIIP = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    LastTransactionType = table.Column<int>(nullable: false),
                    LastTransactionAmount = table.Column<double>(nullable: false),
                    LastTransactionDate = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ActionId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMonitoringInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionMonitoringInfo_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionMonitoringInfo_Transaction_Id",
                        column: x => x.Id,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BBSettlements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BBSettlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BBSettlements_Banks_Id",
                        column: x => x.Id,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    BankId = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    RoutingNumber = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuspenseTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SuspenseTransactionId = table.Column<Guid>(nullable: false),
                    SenderAccountNo = table.Column<string>(nullable: true),
                    SendingBankId = table.Column<string>(nullable: true),
                    SendingBankSuspanseAccount = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    SuspenseStatus = table.Column<bool>(nullable: true),
                    TransactionInitiatedOn = table.Column<DateTime>(nullable: true),
                    SuspenseClearingTime = table.Column<DateTime>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuspenseTransaction_Banks_SendingBankId",
                        column: x => x.SendingBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    SenderBankId = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    SendingBankRoutingNo = table.Column<string>(nullable: true),
                    BillReferenceId = table.Column<string>(nullable: true),
                    BillCategoryId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionBill_BillCategory_BillCategoryId",
                        column: x => x.BillCategoryId,
                        principalTable: "BillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionBill_Banks_SenderBankId",
                        column: x => x.SenderBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionBill_BankUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "BankUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionFund",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    Narration = table.Column<string>(nullable: true),
                    SenderBankId = table.Column<string>(nullable: true),
                    ReceiverBankId = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    SendingBankRoutingNo = table.Column<string>(nullable: true),
                    ReceivingBankRoutingNo = table.Column<string>(nullable: true),
                    SettlementStatus = table.Column<bool>(nullable: false),
                    SettledOn = table.Column<DateTime>(nullable: false),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionFund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionFund_Banks_ReceiverBankId",
                        column: x => x.ReceiverBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionFund_BankUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "BankUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionFund_BankUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "BankUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NotificationDate = table.Column<DateTime>(nullable: false),
                    SenderConcurrentBalance = table.Column<double>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    IDTPUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalNotification_IDTPUser_IDTPUserId",
                        column: x => x.IDTPUserId,
                        principalTable: "IDTPUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalNotification_ExternalTransaction_Id",
                        column: x => x.Id,
                        principalTable: "ExternalTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionResponseMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: true),
                    ResponseId = table.Column<int>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionResponseMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionResponseMap_Response_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionResponseMap_ExternalTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "ExternalTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisputeTransactionFund",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    OriginatorTypeId = table.Column<int>(nullable: true),
                    OriginatorId = table.Column<string>(nullable: true),
                    ExecutorTypeId = table.Column<int>(nullable: true),
                    ExecutorId = table.Column<string>(nullable: true),
                    TransactionSettlementStatusId = table.Column<int>(nullable: true),
                    DisputeSettlementType = table.Column<string>(nullable: true),
                    DisputeSettlementTime = table.Column<DateTime>(nullable: false),
                    DisputeSettlementStatus = table.Column<bool>(nullable: true),
                    DisputeSeverityId = table.Column<int>(nullable: true),
                    DisputeSettledBy = table.Column<int>(nullable: true),
                    DisputeTitle = table.Column<string>(nullable: true),
                    DisputeType = table.Column<string>(nullable: true),
                    DisputeDetail = table.Column<string>(nullable: true),
                    DisputeActionId = table.Column<int>(nullable: true),
                    ParticipantAction = table.Column<bool>(nullable: true),
                    ParticipantResponseText = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisputeTransactionFund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisputeTransactionFund_DisputeAction_DisputeActionId",
                        column: x => x.DisputeActionId,
                        principalTable: "DisputeAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisputeTransactionFund_DisputeSeverity_DisputeSeverityId",
                        column: x => x.DisputeSeverityId,
                        principalTable: "DisputeSeverity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisputeTransactionFund_TransactionFund_Id",
                        column: x => x.Id,
                        principalTable: "TransactionFund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_UserId",
                table: "Beneficiary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BankId",
                table: "Branches",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_DisbursementDetails_DisbursementId",
                table: "DisbursementDetails",
                column: "DisbursementId");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeTransaction_DisputeActionId",
                table: "DisputeTransaction",
                column: "DisputeActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeTransaction_DisputeSeverityId",
                table: "DisputeTransaction",
                column: "DisputeSeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeTransactionFund_DisputeActionId",
                table: "DisputeTransactionFund",
                column: "DisputeActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeTransactionFund_DisputeSeverityId",
                table: "DisputeTransactionFund",
                column: "DisputeSeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalNotification_IDTPUserId",
                table: "ExternalNotification",
                column: "IDTPUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransaction_ReceiverId",
                table: "ExternalTransaction",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransaction_ResponseId",
                table: "ExternalTransaction",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransaction_SenderId",
                table: "ExternalTransaction",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransaction_StatusId",
                table: "ExternalTransaction",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTransaction_TransactionTypeId",
                table: "ExternalTransaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleManagement_GroupId",
                table: "GroupRoleManagement",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleManagement_RoleId",
                table: "GroupRoleManagement",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IDTPUserEntity_EntityTypeId",
                table: "IDTPUserEntity",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IDTPUserEntity_IdentityTypeId",
                table: "IDTPUserEntity",
                column: "IdentityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_IDTPUserId",
                table: "Notification",
                column: "IDTPUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantCapHistory_FinInstitutionInfoId",
                table: "ParticipantCapHistory",
                column: "FinInstitutionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionManagement_PermissionId",
                table: "RolePermissionManagement",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionManagement_RoleId",
                table: "RolePermissionManagement",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspenseTransaction_SendingBankId",
                table: "SuspenseTransaction",
                column: "SendingBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReceiverId",
                table: "Transaction",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SenderId",
                table: "Transaction",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_StatusId",
                table: "Transaction",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionBill_BillCategoryId",
                table: "TransactionBill",
                column: "BillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionBill_SenderBankId",
                table: "TransactionBill",
                column: "SenderBankId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionBill_SenderId",
                table: "TransactionBill",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFund_ReceiverBankId",
                table: "TransactionFund",
                column: "ReceiverBankId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFund_ReceiverId",
                table: "TransactionFund",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFund_SenderId",
                table: "TransactionFund",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMonitoringInfo_ActionId",
                table: "TransactionMonitoringInfo",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionResponseMap_ResponseId",
                table: "TransactionResponseMap",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionResponseMap_TransactionId",
                table: "TransactionResponseMap",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionValueLimit_TransactionTypeId",
                table: "TransactionValueLimit",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionValueLimit_FinInstitutionInfoId_TransactionTypeId",
                table: "TransactionValueLimit",
                columns: new[] { "FinInstitutionInfoId", "TransactionTypeId" },
                unique: true,
                filter: "[FinInstitutionInfoId] IS NOT NULL AND [TransactionTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupManagement_GroupId",
                table: "UserGroupManagement",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupManagement_UserId",
                table: "UserGroupManagement",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BBSettlements");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "DBLog");

            migrationBuilder.DropTable(
                name: "DeviceLocationInfo");

            migrationBuilder.DropTable(
                name: "DisbursementDetails");

            migrationBuilder.DropTable(
                name: "DisputeTransaction");

            migrationBuilder.DropTable(
                name: "DisputeTransactionFund");

            migrationBuilder.DropTable(
                name: "EndUserLimit");

            migrationBuilder.DropTable(
                name: "ExternalNotification");

            migrationBuilder.DropTable(
                name: "GovernmentInstitution");

            migrationBuilder.DropTable(
                name: "GovtBillPayment");

            migrationBuilder.DropTable(
                name: "GovtInstitutionInfo");

            migrationBuilder.DropTable(
                name: "GroupRoleManagement");

            migrationBuilder.DropTable(
                name: "IDTPAppErrorLog");

            migrationBuilder.DropTable(
                name: "IDTPErrorLog");

            migrationBuilder.DropTable(
                name: "IDTPUserAdmin");

            migrationBuilder.DropTable(
                name: "IDTPUserEntity");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ParticipantCap");

            migrationBuilder.DropTable(
                name: "ParticipantCapHistory");

            migrationBuilder.DropTable(
                name: "ParticipantDebitCap");

            migrationBuilder.DropTable(
                name: "PayeeDetails");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PaymentAuthorization");

            migrationBuilder.DropTable(
                name: "PaymentRecord");

            migrationBuilder.DropTable(
                name: "ReportInfo");

            migrationBuilder.DropTable(
                name: "RolePermissionManagement");

            migrationBuilder.DropTable(
                name: "SuspenseTransaction");

            migrationBuilder.DropTable(
                name: "SuspenseTransactionHistories");

            migrationBuilder.DropTable(
                name: "TransactionBill");

            migrationBuilder.DropTable(
                name: "TransactionMonitoringInfo");

            migrationBuilder.DropTable(
                name: "TransactionRequestLogs");

            migrationBuilder.DropTable(
                name: "TransactionResponseMap");

            migrationBuilder.DropTable(
                name: "TransactionValueLimit");

            migrationBuilder.DropTable(
                name: "TransferFund");

            migrationBuilder.DropTable(
                name: "UserGroupManagement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Disbursements");

            migrationBuilder.DropTable(
                name: "DisputeAction");

            migrationBuilder.DropTable(
                name: "DisputeSeverity");

            migrationBuilder.DropTable(
                name: "TransactionFund");

            migrationBuilder.DropTable(
                name: "EntityType");

            migrationBuilder.DropTable(
                name: "IdentityType");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "IDTPPermission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "BillCategory");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ExternalTransaction");

            migrationBuilder.DropTable(
                name: "FinInstitutionInfo");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BankUsers");

            migrationBuilder.DropTable(
                name: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "TransactionStatus");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "FinancialInstitution");

            migrationBuilder.DropTable(
                name: "IDTPUser");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
