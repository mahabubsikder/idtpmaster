using IDTPDomainModel;
using IDTPDomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = IDTPDomainModel.Models.Action;

namespace IDTPBusinessLayer
{
    public interface IBusinessLayer
    {
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(params Customer[] customers);
        void AddCustomer(Customer customer);
        void RemoveCustomer(params Customer[] customers);

        IQueryable<IDTPUserEntity> GetAllIDTPUserEntities();
        IDTPUserEntity GetIDTPUserEntityById(int id);
        void UpdateIDTPUserEntity(params IDTPUserEntity[] iDTPUserEntities);
        void AddIDTPUserEntity(IDTPUserEntity iDTPUserEntity);
        void RemoveIDTPUserEntity(params IDTPUserEntity[] iDTPUserEntities);

        IQueryable<IdentityType> GetAllIdentityTypes();
        IdentityType GetIdentityTypeById(int id);
        void UpdateIdentityType(params IdentityType[] identityTypes);
        void AddIdentityType(IdentityType identityType);
        void RemoveIdentityType(params IdentityType[] identityTypes);

        IQueryable<EntityType> GetAllEntityTypes();
        EntityType GetEntityTypeById(int id);
        void UpdateEntityType(params EntityType[] entityTypes);
        void AddEntityType(EntityType entityType);
        void RemoveEntityType(params EntityType[] entityTypes);

        IQueryable<DeviceLocationInfo> GetAllDeviceLocationInfos();
        DeviceLocationInfo GetDeviceLocationInfoById(int id);
        void UpdateDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos);
        void AddDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos);
        void RemoveDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos);

        IQueryable<PaymentRecord> GetAllPaymentRecords();
        PaymentRecord GetPaymentRecordById(int id);
        void UpdatePaymentRecord(params PaymentRecord[] paymentRecords);
        void AddPaymentRecord(PaymentRecord paymentRecord);
        void RemovePaymentRecord(params PaymentRecord[] paymentRecords);

        IQueryable<PaymentAuthorization> GetAllPaymentAuthorizations();
        PaymentAuthorization GetPaymentAuthorizationById(int id);
        void UpdatePaymentAuthorization(params PaymentAuthorization[] paymentAuthorizations);
        void AddPaymentAuthorization(PaymentAuthorization paymentAuthorization);
        void RemovePaymentAuthorization(params PaymentAuthorization[] paymentAuthorizations);

        IQueryable<GovtBillPayment> GetAllGovtBillPayments();
        GovtBillPayment GetGovtBillPaymentById(int id);
        void UpdateGovtBillPayment(params GovtBillPayment[] govtBillPayments);
        void AddGovtBillPayment(GovtBillPayment govtBillPayment);
        void RemoveGovtBillPayment(params GovtBillPayment[] govtBillPayments);

        IQueryable<TransferFund> GetAllTransferFunds();
        TransferFund GetTransferFundById(int id);
        void UpdateTransferFund(params TransferFund[] transferFunds);
        void AddTransferFund(TransferFund transferFund);
        void RemoveTransferFund(params TransferFund[] transferFunds);


        IQueryable<SuspenseTransaction> GetAllSuspenseTransactions();
        SuspenseTransaction GetSuspenseTransactionById(int id);
        void UpdateSuspenseTransaction(params SuspenseTransaction[] suspenseTransactions);
        void AddSuspenseTransaction(SuspenseTransaction suspenseTransaction);
        void RemoveSuspenseTransaction(params SuspenseTransaction[] suspenseTransactions);
        void RunRawSqlCommand(string sqlCommand);



        IQueryable<TransactionRequestLog> GetAllTransactionRequestLogs();
        TransactionRequestLog GetTransactionRequestLogById(int id);
        void UpdateTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs);
        void AddTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs);
        void RemoveTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs);


        IQueryable<EndUserLimit> GetAllEndUserLimits();
        EndUserLimit GetEndUserLimitById(int id);
        void UpdateEndUserLimit(params EndUserLimit[] endUserLimits);
        void AddEndUserLimit(EndUserLimit endUserLimit);
        void RemoveEndUserLimit(params EndUserLimit[] endUserLimits);

        IQueryable<ParticipantCapHistory> GetAllParticipantCapHistories();
        ParticipantCapHistory GetParticipantCapHistoryById(int id);
        void UpdateParticipantCapHistory(params ParticipantCapHistory[] participantCapHistories);
        void AddParticipantCapHistory(ParticipantCapHistory participantCapHistory);
        void RemoveParticipantCapHistory(params ParticipantCapHistory[] participantCapHistories);

        IQueryable<ParticipantDebitCap> GetAllParticipantDebitCaps();
        ParticipantDebitCap GetParticipantDebitCapById(string id);
        void UpdateParticipantDebitCap(params ParticipantDebitCap[] participantDebitCaps);
        void AddParticipantDebitCap(ParticipantDebitCap participantDebitCap);
        void RemoveParticipantDebitCap(params ParticipantDebitCap[] participantDebitCaps);


        IQueryable<TransactionValueLimit> GetAllTransactionValueLimits();
        TransactionValueLimit GetTransactionValueLimitById(int id);
        void UpdateTransactionValueLimit(params TransactionValueLimit[] transactionValueLimits);
        void AddTransactionValueLimit(TransactionValueLimit transactionValueLimit);
        void RemoveTransactionValueLimit(params TransactionValueLimit[] transactionValueLimits);

        IQueryable<FinancialInstitution> GetAllFinInstitutionInfos();
        FinancialInstitution GetFinInstitutionInfoById(string id);
        void UpdateFinInstitutionInfo(params FinancialInstitution[] finInstitutionInfos);
        void AddFinInstitutionInfo(FinancialInstitution finInstitutionInfo);
        void RemoveFinInstitutionInfo(params FinancialInstitution[] finInstitutionInfos);

        IQueryable<Business> GetAllMerchants();
        Business GetMerchantById(string id);
        void UpdateMerchant(params Business[] merchants);
        void AddMerchant(Business merchant);
        void RemoveMerchant(params Business[] merchants);

        IQueryable<GovernmentInstitution> GetAllGovtInstitutionInfos();
        GovernmentInstitution GetGovtInstitutionInfoById(string id);
        void UpdateGovtInstitutionInfo(params GovernmentInstitution[] govtInstitutionInfos);
        void AddGovtInstitutionInfo(GovernmentInstitution govtInstitutionInfo);
        void RemoveGovtInstitutionInfo(params GovernmentInstitution[] govtInstitutionInfos);

        IQueryable<DBLog> GetAllDBLogs();
        DBLog GetDBLogById(int id);
        void UpdateDBLog(params DBLog[] dblogs);
        void AddDBLog(params DBLog[] items);
        void RemoveDBLog(params DBLog[] items);

        IQueryable<Group> GetAllGroups();
        Group GetGroupById(int id);
        void UpdateGroup(params Group[] groups);
        void AddGroup(Group group);
        void RemoveGroup(params Group[] groups);

        IQueryable<GroupRoleManagement> GetAllGroupRoleManagements();
        GroupRoleManagement GetGroupRoleManagementById(int id);
        void UpdateGroupRoleManagement(params GroupRoleManagement[] groupRolemanagements);
        void AddGroupRoleManagement(GroupRoleManagement groupRoleManagement);
        void RemoveGroupRoleManagement(params GroupRoleManagement[] groupRolemanagements);

        IQueryable<IDTPPermission> GetAllIDTPPermissions();
        IDTPPermission GetIDTPPermissionById(int id);
        void UpdateIDTPPermission(params IDTPPermission[] iDTPPermissions);
        void AddIDTPPermission(IDTPPermission iDTPPermission);
        void RemoveIDTPPermission(params IDTPPermission[] iDTPPermissions);

        IQueryable<IDTPUserAdmin> GetAllUsers();
        IDTPUserAdmin GetUserById(string id);
        void UpdateUser(params IDTPUserAdmin[] users);
        void AddUser(IDTPUserAdmin user);
        void RemoveUser(params IDTPUserAdmin[] users);

        #region Notification Module
        IQueryable<Notification> GetAllNotifications();
        Notification GetNotificationById(int id);
        void UpdateNotification(params Notification[] notifications);
        void AddNotification(Notification notification);
        void RemoveNotification(params Notification[] notifications);
        #endregion Notification Module

        IQueryable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void UpdatePayment(params Payment[] payments);
        void AddPayment(Payment payment);
        void RemovePayment(params Payment[] payments);

        IQueryable<Response> GetAllResponses();
        Response GetResponseById(int id);
        void UpdateResponse(params Response[] responses);
        void AddResponse(Response response);
        void RemoveResponse(int id);

        IQueryable<IDTPRole> GetAllRoles();
        IDTPRole GetRoleById(int id);
        void UpdateRole(params IDTPRole[] roles);
        void AddRole(IDTPRole role);
        void RemoveRole(params IDTPRole[] roles);

        IQueryable<RolePermissionManagement> GetAllRolePermissionManagements();
        RolePermissionManagement GetRolePermissionManagementById(int id);
        void UpdateRolePermissionManagement(params RolePermissionManagement[] rolePermissionManagements);
        void AddRolePermissionManagement(RolePermissionManagement rolePermissionManagement);
        void RemoveRolePermissionManagement(params RolePermissionManagement[] rolePermissionManagements);

        IQueryable<TransactionFund> GetAllTransactions();
        TransactionFund GetTransactionById(int id);
        void UpdateTransaction(params TransactionFund[] transactions);
        void AddTransaction(TransactionFund transaction);
        void RemoveTransaction(params TransactionFund[] transactions);

        IQueryable<TransactionBill> GetAllTransactionBills();
        TransactionBill GetTransactionBillById(int id);
        void UpdateTransactionBill(params TransactionBill[] transactions);
        void AddTransactionBill(TransactionBill transaction);
        void RemoveTransactionBill(params TransactionBill[] transactions);

        IQueryable<TransactionResponseMap> GetAllTransactionResponseMaps();
        TransactionResponseMap GetTransactionResponseMapById(int id);
        void UpdateTransactionResponseMap(params TransactionResponseMap[] transactionResponseMaps);
        void AddTransactionResponseMap(TransactionResponseMap transactionResponseMap);
        void RemoveTransactionResponseMap(int id);

        IQueryable<UserGroupManagement> GetAllUserGroupManagements();
        UserGroupManagement GetUserGroupManagementById(int id);
        void UpdateUserGroupManagement(params UserGroupManagement[] userGroupManagements);
        void AddUserGroupManagement(UserGroupManagement userGroupManagement);
        void RemoveUserGroupManagement(params UserGroupManagement[] userGroupManagements);

        IQueryable<ExternalNotification> GetAllExternalNotifications();
        ExternalNotification GetExternalNotificationById(int id);
        void UpdateExternalNotification(params ExternalNotification[] externalNotifications);
        void AddExternalNotification(ExternalNotification externalNotification);
        void RemoveExternalNotification(params ExternalNotification[] externalNotifications);

        IQueryable<ExternalTransaction> GetAllExternalTransactions();
        ExternalTransaction GetExternalTransactionById(int id);
        void UpdateExternalTransaction(params ExternalTransaction[] externalTransactions);
        void AddExternalTransaction(ExternalTransaction externalTransaction);
        void RemoveExternalTransaction(params ExternalTransaction[] externalTransactions);

        IQueryable<TransactionStatus> GetAllTransactionStatuses();
        TransactionStatus GetTransactionStatusById(int id);
        void UpdateTransactionStatus(params TransactionStatus[] transactionStatuses);
        void AddTransactionStatus(TransactionStatus transactionStatus);
        void RemoveTransactionStatus(params TransactionStatus[] transactionStatuses);

        IQueryable<TransactionType> GetAllTransactionTypes();
        TransactionType GetTransactionTypeById(int id);
        void UpdateTransactionType(params TransactionType[] transactionTypes);
        void AddTransactionType(TransactionType transactionType);
        void RemoveTransactionType(params TransactionType[] transactionTypes);

        IQueryable<Beneficiary> GetAllBeneficiary();
        Beneficiary GetBeneficiaryById(int id);
        void UpdateBeneficiary(params Beneficiary[] beneficiaries);
        void AddBeneficiary(Beneficiary beneficiary);
        void RemoveBeneficiary(params Beneficiary[] beneficiaries);

        IQueryable<Bank> GetAllBanks();
        Bank GetBankById(string id);
        Bank GetBankBySwiftBic(string swiftBic);
        void UpdateBank(params Bank[] banks);
        void AddBank(Bank bank);
        void RemoveBank(params Bank[] banks);

        IQueryable<BankUser> GetAllBankUsers();
        BankUser GetBankUserById(int id);
        void UpdateBankUser(params BankUser[] bankusers);
        void AddBankUser(BankUser bankuser);
        void RemoveBankUser(params BankUser[] bankusers);

        IQueryable<Branch> GetAllBranchs();
        Branch GetBranchById(int id);
        void UpdateBranch(params Branch[] branchs);
        void AddBranch(Branch branch);
        void RemoveBranch(params Branch[] branches);

        IQueryable<ReportInfo> GetAllReportInfos();
        ReportInfo GetReportInfoById(int id);
        void UpdateReportInfo(params ReportInfo[] reportInfos);
        void AddReportInfo(ReportInfo reportInfo);
        void RemoveReportInfo(params ReportInfo[] reportInfos);


        IQueryable<MasterToken> GetAllMasterTokens();
        MasterToken GetMasterTokenById(int id);
        MasterToken GetMasterTokenByTokenNo(string tokenNo);
        void UpdateMasterToken(params MasterToken[] masterTokens);
        void AddMasterToken(MasterToken masterToken);
        void RemoveMasterToken(params MasterToken[] masterTokens);

        IQueryable<MasterTokenDetail> GetAllMasterTokenDetails();
        MasterTokenDetail GetMasterTokenDetailById(int id);
        void UpdateMasterTokenDetail(params MasterTokenDetail[] masterTokenDetails);
        void AddMasterTokenDetail(MasterTokenDetail masterTokenDetail);
        void RemoveMasterTokenDetail(params MasterTokenDetail[] masterTokenDetails);


        void LogUserActivity(int? UserID, string activity, System.Uri pageUrl);
        void LogIDTPError(int? UserID, int errorNumber, string errorContext, string errorMessage, string errorTimeStamp);
        List<ActivityLog> GetUserActivityLog(DateTime? logDate);

        List<IDTPErrorLog> GetIDTPErrorLog(DateTime? logDate);


        void LogAppErrorInfo(int UserID, string ErrorMessage, string ErrorStackTrace, int ErrorType, DateTime ErrorTimeStamp, string ErrorDeviceInfo);
        List<IDTPAppErrorLog> GetIDTPAppErrorLog(DateTime? logDate);

        #region Transaction Monitoring
        IQueryable<TransactionMonitoringInfo> GetAllTranMonitoringInfo();
        TransactionMonitoringInfo GetTranMonitoringInfoByTranId(string tranId);
        void UpdateTranMonitoringInfo(params TransactionMonitoringInfo[] items);
        void AddTranMonitoringInfo(params TransactionMonitoringInfo[] items);
        #endregion

        #region Actions
        IQueryable<Action> GetAllAction();
        void AddAction(Action action);
        #endregion

        #region Dispute Management Module
        IQueryable<DisputeTransactionFund> GetAllDisputeTransactions();
        DisputeTransactionFund GetDisputeTransactionById(int id);
        void UpdateDisputeTransaction(params DisputeTransactionFund[] disputeTransactions);
        void AddDisputeTransaction(DisputeTransactionFund disputeTransaction);

        IQueryable<DisputeAction> GetAllDisputeActions();
        DisputeAction GetDisputeActionById(int id);
        void UpdateDisputeAction(params DisputeAction[] disputeActions);
        void AddDisputeAction(DisputeAction disputeAction);
        void RemoveDisputeAction(params DisputeAction[] disputeActions);

        IQueryable<DisputeSeverity> GetAllDisputeSeverity();
        DisputeSeverity GetDisputeSeverityById(int id);
        void UpdateDisputeSeverity(params DisputeSeverity[] disputeSeveritys);
        void AddDisputeSeverity(DisputeSeverity disputeSeverity);
        void RemoveDisputeSeverity(params DisputeSeverity[] disputeSeveritys);
        #endregion Dispute Management Module

        #region BBSettlement
        IQueryable<BBSettlement> GetAllBBSettlements();
        BBSettlement GetBBSettlementById(string SwiftBic);
        void UpdateBBSettlement(params BBSettlement[] BBSettlements);
        void AddBBSettlement(BBSettlement BBSettlement);
        void RemoveBBSettlement(params BBSettlement[] BBSettlements);
        #endregion

        #region SuspenseTransaction History
        IQueryable<SuspenseTransactionHistory> GetAllSuspenseTransactionHistories();
        SuspenseTransactionHistory GetSuspenseTransactionHistoryById(int id);
        void UpdateSuspenseTransactionHistory(params SuspenseTransactionHistory[] suspenseTransactionHistories);
        void AddSuspenseTransactionHistories(params SuspenseTransactionHistory[] suspenseTransactionHistories);
        void RemoveSuspenseTransactionHistory(params SuspenseTransactionHistory[] suspenseTransactionHistories);
        #endregion

        #region Disbursment
        void AddDisbursment(params Disbursement[] disbursements);
        void AddDisbursmentDetail(params DisbursementDetail[] disbursementDetails);
        #endregion
    }
}