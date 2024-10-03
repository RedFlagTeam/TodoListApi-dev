using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyPublicAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6628eeb0-ec38-4b5b-81b0-f0778e7ad0a6"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("818e0c0f-df3e-4c34-aeb2-fa58cf453357"));

            migrationBuilder.DeleteData(
                table: "UserCompanies",
                keyColumns: new[] { "CompanyId", "UserId" },
                keyValues: new object[] { new Guid("a91c72dc-a6ee-4da3-8131-941c4c14109e"), new Guid("ddac5c59-8119-4fa2-9d0e-fd07795b6ab5") });

            migrationBuilder.DeleteData(
                table: "UserCompanies",
                keyColumns: new[] { "CompanyId", "UserId" },
                keyValues: new object[] { new Guid("792f9cfd-8cff-45af-809a-7a82858c8b1e"), new Guid("f9b27a16-a0ba-4145-b6e9-18392ace1663") });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountNumber", "AccountType" },
                values: new object[,]
                {
                    { new Guid("040727d6-1c5b-437a-9526-1031536d1323"), "Main Account", 1234, "Asset" },
                    { new Guid("febdfc21-5ce6-4ec9-a1de-e6ec1a3b52d1"), "Expense Account", 5678, "Expense" }
                });

            migrationBuilder.InsertData(
                table: "UserCompanies",
                columns: new[] { "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0afe6a62-c857-4d89-a2b3-f01b9b094c7a"), new Guid("8b68918c-1636-4997-a73e-f19d181c0c56") },
                    { new Guid("886a91f3-121e-4cc6-9f18-cfefa3ddcf21"), new Guid("af629495-ca8a-41db-ba1f-40ce4d1c9ce5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("040727d6-1c5b-437a-9526-1031536d1323"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("febdfc21-5ce6-4ec9-a1de-e6ec1a3b52d1"));

            migrationBuilder.DeleteData(
                table: "UserCompanies",
                keyColumns: new[] { "CompanyId", "UserId" },
                keyValues: new object[] { new Guid("0afe6a62-c857-4d89-a2b3-f01b9b094c7a"), new Guid("8b68918c-1636-4997-a73e-f19d181c0c56") });

            migrationBuilder.DeleteData(
                table: "UserCompanies",
                keyColumns: new[] { "CompanyId", "UserId" },
                keyValues: new object[] { new Guid("886a91f3-121e-4cc6-9f18-cfefa3ddcf21"), new Guid("af629495-ca8a-41db-ba1f-40ce4d1c9ce5") });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountNumber", "AccountType" },
                values: new object[,]
                {
                    { new Guid("6628eeb0-ec38-4b5b-81b0-f0778e7ad0a6"), "Main Account", 1234, "Asset" },
                    { new Guid("818e0c0f-df3e-4c34-aeb2-fa58cf453357"), "Expense Account", 5678, "Expense" }
                });

            migrationBuilder.InsertData(
                table: "UserCompanies",
                columns: new[] { "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a91c72dc-a6ee-4da3-8131-941c4c14109e"), new Guid("ddac5c59-8119-4fa2-9d0e-fd07795b6ab5") },
                    { new Guid("792f9cfd-8cff-45af-809a-7a82858c8b1e"), new Guid("f9b27a16-a0ba-4145-b6e9-18392ace1663") }
                });
        }
    }
}
