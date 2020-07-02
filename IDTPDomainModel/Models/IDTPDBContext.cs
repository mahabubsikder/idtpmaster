namespace IDTPDomainModel
{
    using IDTPDomainModel.Models;
    using IDTPKeyVaultManagement;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public partial class IDTPDBContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public IDTPDBContext()
        {
            
            //Database.EnsureDeleted();
           
            
        }
        public IDTPDBContext(DbContextOptions<IDTPDBContext> options)
       : base(options)
        {
            // _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(KeyVaultManagement.GetKey("azuresqldbconnectionstring"));
            optionsBuilder.UseSqlServer(Constants.Azuresqldbconnectionstring);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        if (string.IsNullOrEmpty(m_sqlConnectioNString))
        //        {
        //            var configurationBuilder = new ConfigurationBuilder();
        //            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("azurekeyvault.json", false, true)
        //            .AddJsonFile("appsettings.json", false, true)
        //            .AddEnvironmentVariables();

        //            var config = configurationBuilder.Build();

        //            configurationBuilder.AddAzureKeyVault(
        //                $"https://{config["azureKeyVault:vault"]}.vault.azure.net/",
        //                config["azureKeyVault:clientId"],
        //                config["azureKeyVault:clientSecret"]
        //            );

        //            config = configurationBuilder.Build();
        //            optionsBuilder.UseSqlServer(config.GetConnectionString("sqlconnectionstring"));
        //        }
        //        else
        //        {
        //            optionsBuilder.UseSqlServer(this.m_sqlConnectioNString);
        //        }
        //    }
        //}

        public virtual DbSet<IDTPUser> IDTPUsers { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<IDTPErrorLog> IDTPErrorLogs { get; set; }

        public virtual DbSet<IDTPAppErrorLog> IDTPAppErrorLogs { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DBLog> DBLogs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<GroupRoleManagement> GroupRoleManagements { get; set; }

        public virtual DbSet<IDTPPermission> IDTPPermissions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<ExternalNotification> ExternalNotifications { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Response> Responses { get; set; }

        public virtual DbSet<IDTPRole> Roles { get; set; }

        public virtual DbSet<RolePermissionManagement> RolePermissionManagements { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<ExternalTransaction> ExternalTransactions { get; set; }
        public virtual DbSet<TransactionResponseMap> TransactionResponseMaps { get; set; }

        public virtual DbSet<UserGroupManagement> UserGroupManagements { get; set; }

        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

        public virtual DbSet<FinInstitutionInfo> FinInstitutionInfoes { get; set; }
        public virtual DbSet<TransactionValueLimit> TransactionValueLimits { get; set; }
        public virtual DbSet<ParticipantCap> ParticipantCaps { get; set; }
        public virtual DbSet<ParticipantCapHistory> ParticipantCapHistories { get; set; }

        public virtual DbSet<GovtInstitutionInfo> GovtInstitutionInfoes { get; set; }

        //Modified Tables 
        public virtual DbSet<IDTPUserAdmin> IDTPUserAdmins { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
        public virtual DbSet<GovernmentInstitution> GovernmentInstitutions { get; set; }
        public virtual DbSet<ParticipantDebitCap> ParticipantDebitCaps { get; set; }
        public virtual DbSet<DisputeTransactionFund> DisputeTransactionFunds { get; set; }
        public virtual DbSet<BankUser> BankUsers { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<TransactionFund> TransactionFunds { get; set; }
        public virtual DbSet<BBSettlement> BBSettlements { get; set; }
        public virtual DbSet<TransactionRequestLog> TransactionRequestLogs { get; set; }
        public virtual DbSet<TransactionBill> TransactionBills { get; set; }
        public virtual DbSet<SuspenseTransactionHistory> SuspenseTransactionHistories { get; set; }


        //Api Tables
        public virtual DbSet<IDTPUserEntity> IDTPUserEntities { get; set; }
        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<EntityType> EntityTypes { get; set; }
        public virtual DbSet<DeviceLocationInfo> DeviceLocationInfos { get; set; }
        public virtual DbSet<PaymentRecord> PaymentRecords { get; set; }
        public virtual DbSet<GovtBillPayment> GovtBillPayments { get; set; }
        public virtual DbSet<TransferFund> TransferFunds { get; set; }
        public virtual DbSet<BillCategory> BillCategories { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
        public virtual DbSet<DisbursementDetail> DisbursementDetails { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<PayeeDetails> PayeeDetails { get; set; }
        public virtual DbSet<PaymentAuthorization> PaymentAuthorizations { get; set; }
        public virtual DbSet<ReportInfo> ReportInfos { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MasterToken> MasterTokens { get; set; }
        public virtual DbSet<MasterTokenDetail> MasterTokenDetails { get; set; }



        //[EntityTypeBuilder.Ignore]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<TransactionValueLimit>()
                .HasIndex(p => new { p.FinInstitutionInfoId, p.TransactionTypeId })
                .IsUnique(true);

                // base.OnModelCreating(modelBuilder);
                // modelBuilder.Entity<ApprovalUserGroup>().HasKey(ba => new { ba.ApprovalUserGroupID, ba.ApprovalUserLogin });

                // modelBuilder.Entity<ApplicationUser>()
                // .HasIndex(b => b.UserName)
                // .IsUnique();

                // modelBuilder.Entity<ApplicationInfo>()
                //        .Property(i => i.ApplicationID)
                //        .UseIdentityColumn();


                // modelBuilder.Entity<ApplicationInfo>()
                //.HasIndex(b => b.UserLogin);


                //modelBuilder.Entity<ApplicationUser>()
                //    .HasOne<Employee>()
                //    .WithOne(x => x.ApplicationUser);


                //modelBuilder.Entity<ApprovalUserGroup>()
                //.HasMany(e => e.ApprovalWorkflows)
                //.WithOptional(e => e.ApprovalUserGroup)
                //.HasForeignKey(e => new { e.ApprovalUserGroupID, e.ApprovalUserGroupApprovalUserLogin });

                //modelBuilder.Entity<ApplicationApprovalStatus>().HasOne(e => e.ApplicationInfo);

            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    //this.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~IDTPDBContext()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public new void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion

    }
}