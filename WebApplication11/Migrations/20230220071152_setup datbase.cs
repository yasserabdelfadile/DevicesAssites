using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication11.Migrations
{
    /// <inheritdoc />
    public partial class setupdatbase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    DESCRPTION = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEPARTMENTS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE_STOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSE_STOCK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAREHOUSE_STOCK_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE_STOCK_FOR_CAMRA_DVRS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSE_STOCK_FOR_CAMRA_DVRS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAREHOUSE_STOCK_FOR_CAMRA_DVRS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    STARTEDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ENDDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_DEPARTMENTS_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCESS_POINTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    LOCATION = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    DESCRPTION = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: true),
                    Is_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCESS_POINTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCESS_POINTS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ACCESS_POINTS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KVMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KVMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KVMS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KVMS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PARCODE_MACHINES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MODEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARCODE_MACHINES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARCODE_MACHINES_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PARCODE_MACHINES_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRINTERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Is_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    DESCRPTION = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRINTERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRINTERS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRINTERS_DEPARTMENTS_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PRINTERS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PROJECTORS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IS_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTORS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROJECTORS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PROJECTORS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RACKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    DESCRPTION = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RACKS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RACKS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RACKS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ROUTERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMBER_OF_PORTS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SERVICES = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MAC_ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUTERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROUTERS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ROUTERS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SWITCHS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LOCATION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NUMBER_OF_PORTS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ADDTIONAL_PORTS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWITCHS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SWITCHS_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SWITCHS_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UPSES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CAPASTY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    LOCATION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UPSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UPSES_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UPSES_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SURVIEILLANCES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Serial_Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Internail_Ip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Externail_IP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Port_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DVR_NVR_MODEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NUMBER_OF_CHANNEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    USED_CHANNEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CONECTIVETY_TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    STORAGE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    USER_LOGIN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VERIFICATION_CODE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SURVIEILLANCES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SURVIEILLANCES_BRANCHES_BRANCH_ID",
                        column: x => x.BRANCH_ID,
                        principalTable: "BRANCHES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SURVIEILLANCES_WAREHOUSE_STOCK_FOR_CAMRA_DVRS_WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID",
                        column: x => x.WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID,
                        principalTable: "WAREHOUSE_STOCK_FOR_CAMRA_DVRS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DEVICESES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MODEL_NO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SERIAL_NO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PROCESSOR = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RAME_SIZE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    QUANTITY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BUS_SPEED = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RAM_GENERATION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HDD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SDD_NVME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MOINTOR_BRANCH_INCH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BIOS_VERSION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WINDOWS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RECIVED_DEVICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RE_RECIVED_DEVICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICESES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEVICESES_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DEVICESES_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HANDHELDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MODEL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    RAM_SIZE = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    ANDROID_VERSION = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Is_warehouse = table.Column<bool>(type: "bit", nullable: false),
                    RECIVED_DEVICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RE_RECIVED_DEVICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_STOCK_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HANDHELDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HANDHELDs_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HANDHELDs_WAREHOUSE_STOCK_WAREHOUSE_STOCK_ID",
                        column: x => x.WAREHOUSE_STOCK_ID,
                        principalTable: "WAREHOUSE_STOCK",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCESS_POINTS_BRANCH_ID",
                table: "ACCESS_POINTS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCESS_POINTS_CODE",
                table: "ACCESS_POINTS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ACCESS_POINTS_SERIAL_NUMBER",
                table: "ACCESS_POINTS",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ACCESS_POINTS_WAREHOUSE_STOCK_ID",
                table: "ACCESS_POINTS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BRANCHES_CODE",
                table: "BRANCHES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_BRANCH_ID",
                table: "DEPARTMENTS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_CODE",
                table: "DEPARTMENTS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICESES_CODE",
                table: "DEVICESES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICESES_EMPLOYEE_ID",
                table: "DEVICESES",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEVICESES_Name",
                table: "DEVICESES",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICESES_SERIAL_NO",
                table: "DEVICESES",
                column: "SERIAL_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEVICESES_WAREHOUSE_STOCK_ID",
                table: "DEVICESES",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_BRANCH_ID",
                table: "EMPLOYEES",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_CODE",
                table: "EMPLOYEES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_DEPARTMENT_ID",
                table: "EMPLOYEES",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HANDHELDs_CODE",
                table: "HANDHELDs",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HANDHELDs_EMPLOYEE_ID",
                table: "HANDHELDs",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HANDHELDs_SERIAL_NUMBER",
                table: "HANDHELDs",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HANDHELDs_WAREHOUSE_STOCK_ID",
                table: "HANDHELDs",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KVMS_BRANCH_ID",
                table: "KVMS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KVMS_CODE",
                table: "KVMS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KVMS_SERIAL_NUMBER",
                table: "KVMS",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KVMS_WAREHOUSE_STOCK_ID",
                table: "KVMS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARCODE_MACHINES_BRANCH_ID",
                table: "PARCODE_MACHINES",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARCODE_MACHINES_CODE",
                table: "PARCODE_MACHINES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARCODE_MACHINES_SERIAL_NUMBER",
                table: "PARCODE_MACHINES",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARCODE_MACHINES_WAREHOUSE_STOCK_ID",
                table: "PARCODE_MACHINES",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRINTERS_BRANCH_ID",
                table: "PRINTERS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRINTERS_CODE",
                table: "PRINTERS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRINTERS_DEPARTMENT_ID",
                table: "PRINTERS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRINTERS_SERIAL_NUMBER",
                table: "PRINTERS",
                column: "SERIAL_NUMBER",
                unique: true,
                filter: "[SERIAL_NUMBER] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PRINTERS_WAREHOUSE_STOCK_ID",
                table: "PRINTERS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTORS_BRANCH_ID",
                table: "PROJECTORS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTORS_CODE",
                table: "PROJECTORS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTORS_SERIAL_NUMBER",
                table: "PROJECTORS",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTORS_WAREHOUSE_STOCK_ID",
                table: "PROJECTORS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RACKS_BRANCH_ID",
                table: "RACKS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RACKS_CODE",
                table: "RACKS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RACKS_WAREHOUSE_STOCK_ID",
                table: "RACKS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROUTERS_BRANCH_ID",
                table: "ROUTERS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROUTERS_CODE",
                table: "ROUTERS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ROUTERS_SERIAL_NUMBER",
                table: "ROUTERS",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ROUTERS_WAREHOUSE_STOCK_ID",
                table: "ROUTERS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVIEILLANCES_BRANCH_ID",
                table: "SURVIEILLANCES",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVIEILLANCES_Code",
                table: "SURVIEILLANCES",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SURVIEILLANCES_Serial_Number",
                table: "SURVIEILLANCES",
                column: "Serial_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SURVIEILLANCES_WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID",
                table: "SURVIEILLANCES",
                column: "WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SWITCHS_BRANCH_ID",
                table: "SWITCHS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SWITCHS_CODE",
                table: "SWITCHS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SWITCHS_SERIAL_NUMBER",
                table: "SWITCHS",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SWITCHS_WAREHOUSE_STOCK_ID",
                table: "SWITCHS",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UPSES_BRANCH_ID",
                table: "UPSES",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UPSES_CODE",
                table: "UPSES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UPSES_SERIAL_NUMBER",
                table: "UPSES",
                column: "SERIAL_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UPSES_WAREHOUSE_STOCK_ID",
                table: "UPSES",
                column: "WAREHOUSE_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSE_STOCK_BRANCH_ID",
                table: "WAREHOUSE_STOCK",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSE_STOCK_CODE",
                table: "WAREHOUSE_STOCK",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSE_STOCK_FOR_CAMRA_DVRS_BRANCH_ID",
                table: "WAREHOUSE_STOCK_FOR_CAMRA_DVRS",
                column: "BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSE_STOCK_FOR_CAMRA_DVRS_CODE",
                table: "WAREHOUSE_STOCK_FOR_CAMRA_DVRS",
                column: "CODE",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCESS_POINTS");

            migrationBuilder.DropTable(
                name: "DEVICESES");

            migrationBuilder.DropTable(
                name: "HANDHELDs");

            migrationBuilder.DropTable(
                name: "KVMS");

            migrationBuilder.DropTable(
                name: "PARCODE_MACHINES");

            migrationBuilder.DropTable(
                name: "PRINTERS");

            migrationBuilder.DropTable(
                name: "PROJECTORS");

            migrationBuilder.DropTable(
                name: "RACKS");

            migrationBuilder.DropTable(
                name: "ROUTERS");

            migrationBuilder.DropTable(
                name: "SURVIEILLANCES");

            migrationBuilder.DropTable(
                name: "SWITCHS");

            migrationBuilder.DropTable(
                name: "UPSES");

            migrationBuilder.DropTable(
                name: "USERES");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "WAREHOUSE_STOCK_FOR_CAMRA_DVRS");

            migrationBuilder.DropTable(
                name: "WAREHOUSE_STOCK");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "BRANCHES");
        }
    }
}
