using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_RES_MVC_ITI_PRJ.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "DishesCategories",
                columns: table => new
                {
                    DishesCategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishesCategoriesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesCategories", x => x.DishesCategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesCategories",
                columns: table => new
                {
                    EmployeesCategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesCategories", x => x.EmployeesCategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngerdientsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngerdientsId);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    OrderTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.OrderTypesId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TablesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChairsNumbers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TablesID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CustomersAddersses",
                columns: table => new
                {
                    CustomersAdderssesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustAddressApartment = table.Column<int>(type: "int", nullable: false),
                    CustAddressFloor = table.Column<int>(type: "int", nullable: false),
                    CustAddressBuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustAddressCounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersAddersses", x => x.CustomersAdderssesID);
                    table.ForeignKey(
                        name: "FK_CustomersAddersses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    TestimonialsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestimonialsText = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.TestimonialsID);
                    table.ForeignKey(
                        name: "FK_Testimonials_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishPrice = table.Column<double>(type: "float", nullable: false),
                    DishImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dish_DishesCategories_DishCategoryId",
                        column: x => x.DishCategoryId,
                        principalTable: "DishesCategories",
                        principalColumn: "DishesCategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ReservarionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    CustomersAdderssesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_CustomersAddersses_CustomersAdderssesID",
                        column: x => x.CustomersAdderssesID,
                        principalTable: "CustomersAddersses",
                        principalColumn: "CustomersAdderssesID");
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableID",
                        column: x => x.TableID,
                        principalTable: "Tables",
                        principalColumn: "TablesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishesIngredientsRel",
                columns: table => new
                {
                    DishesIngredientsRelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngerdientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesIngredientsRel", x => x.DishesIngredientsRelId);
                    table.ForeignKey(
                        name: "FK_DishesIngredientsRel_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishesIngredientsRel_Ingredient_IngerdientId",
                        column: x => x.IngerdientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngerdientsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EmpNationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    EmpHiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpSalary = table.Column<double>(type: "float", nullable: false),
                    EmpCategoryId = table.Column<int>(type: "int", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeesCategories_EmpCategoryId",
                        column: x => x.EmpCategoryId,
                        principalTable: "EmployeesCategories",
                        principalColumn: "EmployeesCategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.FranchiseId);
                    table.ForeignKey(
                        name: "FK_Franchise_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "OrderTypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDishesRel",
                columns: table => new
                {
                    OrderDishesRelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishesRel", x => x.OrderDishesRelId);
                    table.ForeignKey(
                        name: "FK_OrderDishesRel_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDishesRel_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
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
                name: "IX_CustomersAddersses_CustomerID",
                table: "CustomersAddersses",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishCategoryId",
                table: "Dish",
                column: "DishCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DishesIngredientsRel_DishId",
                table: "DishesIngredientsRel",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishesIngredientsRel_IngerdientId",
                table: "DishesIngredientsRel",
                column: "IngerdientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmpCategoryId",
                table: "Employee",
                column: "EmpCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FranchiseId",
                table: "Employee",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmpId",
                table: "EmployeeAddress",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Franchise_ManagerId",
                table: "Franchise",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FranchiseId",
                table: "Order",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishesRel_DishId",
                table: "OrderDishesRel",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishesRel_OrderId",
                table: "OrderDishesRel",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerID",
                table: "Reservations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomersAdderssesID",
                table: "Reservations",
                column: "CustomersAdderssesID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableID",
                table: "Reservations",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_CustomerID",
                table: "Testimonials",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Franchise_FranchiseId",
                table: "Employee",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "FranchiseId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeesCategories_EmpCategoryId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Franchise_FranchiseId",
                table: "Employee");

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
                name: "DishesIngredientsRel");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "OrderDishesRel");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "CustomersAddersses");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "DishesCategories");

            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmployeesCategories");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
