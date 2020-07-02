using IDTPDataAccessLayer;
using IDTPDataAccessLayer.Interfaces;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = IDTPDomainModel.Models.Action;

namespace IDTPBusinessLayer
{
    public class BusinessLayer : IBusinessLayer, IDisposable
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDBLogRepository _dBLogRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupRoleManagementRepository _groupRoleManagementRepository;
        private readonly IIDTPPermissionRepository _iDTPPermissionRepository;
        private readonly IIDTPUserAdminRepository _iIdtpUserRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IResponseRepository _responseRepository;
        private readonly IRolePermissionManagementRepository _rolePermissionManagementRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITransactionFundRepository _transactionRepository;
        private readonly ITransactionResponseMapRepository _transactionResponseMapRepository;
        private readonly IUserGroupManagementRepository _userGroupManagementRepository;
        private readonly IExternalNotificationRepository _externalNotificationRepository;
        private readonly IExternalTransactionRepository _externalTransactionRepository;
        private readonly ITransactionStatusRepository _transactionStatusRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IEndUserLimitRepository _endUserLimitRepository;
        private readonly IFinancialInstitutionRepository _finInstitutionInfoRepository;
        private readonly IGovernmentInstitutionRepository _govtInstitutionInfoRepository;
        private readonly IParticipantCapHistoryRepository _participantCapHistoryRepository;
        private readonly IParticipantDebitCapRepository _participantDebitCapRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly ITransactionRequestLogRepository _transactionRequestLogRepository;
        private readonly IIDTPLog _IDTPLog;
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly ITransactionValueLimitRepository _transactionValueLimitRepository;
        private readonly ITransactionMonitoringRepository _transactionMonitoringRepository;
        private readonly IDisputeTransactionRepository _disputeTransactionRepository;
        private readonly IDisputeActionRepository _disputeActionRepository;
        private readonly IDisputeSeverityRepository _disputeSeverityRepository;
        private readonly IActionRepository _actionRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IBankUserRepository _bankUserRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IBBSettlementRepository _settlementRepository;
        private readonly ISuspenseTransactionRepository _suspenseTransactionRepository;
        private readonly ITransactionBillRepository _transactionBillRepository;
        private readonly IIDTPUserEntityRepository _iDTPUserEntityRepository;
        private readonly IDeviceLocationInfoRepository _deviceLocationInfoRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IIdentityTypeRepository _identityTypeRepository;
        private readonly IGovtBillPaymentRepository _govtBillPaymentRepository;
        private readonly IPaymentRecordRepository _paymentRecordRepository;
        private readonly ITransferFundRepository _transferFundRepository;
        private readonly ISuspenseTransactionHistoryRepository _suspenseTransactionHistoryRepository;
        private readonly IDisbursementRepository _disbursementRepository;
        private readonly IDisbursementDetailRepository _disbursementDetailRepository;
        private readonly IPaymentAuthorizationRepository _paymentAuthorizationRepository;
        private readonly IReportInfoRepository _reportInfoRepository;
        private readonly IMasterTokenRepository _masterTokenRepository;
        private readonly IMasterTokenDetailRepository _masterTokenDetailRepository;


        //private List<string> _imageExt = new List<string>() { "", ".jpg", ".gif", ".png", ".jpeg", ".bmp" };

        public BusinessLayer()
        {
            _dBLogRepository = new DBLogRepository();
            _groupRepository = new GroupRespository();
            _groupRoleManagementRepository = new GroupRoleManagementRespository();
            _iDTPPermissionRepository = new IDTPPermissionRepository();
            _iIdtpUserRepository = new IDTPUserAdminRepository();
            _notificationRepository = new NotificationRepository();
            _paymentRepository = new PaymentRepository();
            _responseRepository = new ResponseRepository();
            _rolePermissionManagementRepository = new RolePermissionManagementRepository();
            _roleRepository = new RoleRepository();
            _transactionRepository = new TransactionFundRepository();
            _transactionResponseMapRepository = new TransactionResponseMapRepository();
            _userGroupManagementRepository = new UserGroupManagementRepository();
            _externalTransactionRepository = new ExternalTransactionRepository();
            _externalNotificationRepository = new ExternalNotificationRepository();
            _transactionTypeRepository = new TransactionTypeRepository();
            _transactionStatusRepository = new TransactionStatusRepository();
            _beneficiaryRepository = new BeneficiaryRepository();
            _endUserLimitRepository = new EndUserLimitRepository();
            _finInstitutionInfoRepository = new FinancialInstitutionRepository();
            _govtInstitutionInfoRepository = new GovernmentInstitutionRepository();
            _transactionValueLimitRepository = new TransactionValueLimitRepository();
            _participantCapHistoryRepository = new ParticipantCapHistoryRepository();
            _participantDebitCapRepository = new ParticipantDebitCapRepository();
            _merchantRepository = new MerchantRepository();
            _IDTPLog = new IDTPLog();
            _customerRepository = new CustomerRepository();
            _transactionMonitoringRepository = new TransactionMonitoringRepository();
            _disputeTransactionRepository = new DisputeTransactionRepository();
            _disputeActionRepository = new DisputeActionRepository();
            _disputeSeverityRepository = new DisputeSeverityRepository();
            _actionRepository = new ActionRepository();
            _bankRepository = new BankRepository();
            _bankUserRepository = new BankUserRepository();
            _transactionRequestLogRepository = new TransactionRequestLogRepository();
            _branchRepository = new BranchRepository();
            _suspenseTransactionRepository = new SuspenseTransactionRepository();
            _settlementRepository = new BBSettlementRepository();
            _transactionBillRepository = new TransactionBillRepository();
            _iDTPUserEntityRepository = new IDTPUserEntityRepository();
            _deviceLocationInfoRepository = new DeviceLocationInfoRepository();
            _entityTypeRepository = new EntityTypeRepository();
            _govtBillPaymentRepository = new GovtBillPaymentRepository();
            _identityTypeRepository = new IdentityTypeRepository();
            _paymentRecordRepository = new PaymentRecordRepository();
            _transferFundRepository = new TransferFundRepository();
            _suspenseTransactionHistoryRepository = new SuspenseTransactionHistoryRepository();
            _disbursementRepository = new DisbursementRepository();
            _disbursementDetailRepository = new DisbursementDetailRepository();
            _paymentAuthorizationRepository = new PaymentAuthorizationRepository();
            _reportInfoRepository = new ReportInfoRepository();
            _masterTokenRepository = new MasterTokenRepository();
            _masterTokenDetailRepository = new MasterTokenDetailRepository();
        }


        /* public BusinessLayer(IIDTPUserRepository userRepository, IAPIClientRepository apiClientRepository)
         {
             _userRepository = userRepository;
             _apiClientRepository = apiClientRepository;
         }*/


        /// <summary>
        /// IDTPUserADmin
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDTPUserAdmin> GetAllUsers()
        {
            return _iIdtpUserRepository.GetAll();
        }

        public IDTPUserAdmin GetUserById(string id)
        {
            return _iIdtpUserRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateUser(params IDTPUserAdmin[] users)
        {
            _iIdtpUserRepository.Update(users);
        }

        public void AddUser(IDTPUserAdmin user)
        {
            _iIdtpUserRepository.Add(user);
        }

        public void RemoveUser(params IDTPUserAdmin[] users)
        {
            _iIdtpUserRepository.Remove(users);
        }


        /// <summary>
        /// SuspenseTransaction
        /// </summary>
        /// <returns></returns>
        public IQueryable<SuspenseTransaction> GetAllSuspenseTransactions()
        {
            return _suspenseTransactionRepository.GetAll();
        }

        public SuspenseTransaction GetSuspenseTransactionById(int id)
        {
            return _suspenseTransactionRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateSuspenseTransaction(params SuspenseTransaction[] suspenseTransactions)
        {
            _suspenseTransactionRepository.Update(suspenseTransactions);
        }

        public void AddSuspenseTransaction(SuspenseTransaction suspenseTransaction)
        {
            _suspenseTransactionRepository.Add(suspenseTransaction);
        }

        public void RemoveSuspenseTransaction(params SuspenseTransaction[] suspenseTransactions)
        {
            _suspenseTransactionRepository.Remove(suspenseTransactions);
        }
        public void RunRawSqlCommand(string sqlCommand)
        {
            _suspenseTransactionRepository.RunRawSqlCommand(sqlCommand);
        }


        /// <summary>
        /// Merchant
        /// </summary>
        /// <returns></returns>
        public IQueryable<Business> GetAllMerchants()
        {
            return _merchantRepository.GetAll();
        }

        public Business GetMerchantById(string id)
        {
            return _merchantRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateMerchant(params Business[] merchants)
        {
            _merchantRepository.Update(merchants);
        }

        public void AddMerchant(Business merchant)
        {
            _merchantRepository.Add(merchant);
        }

        public void RemoveMerchant(params Business[] merchants)
        {
            _merchantRepository.Remove(merchants);
        }


        /// <summary>
        /// TransactionRequestLog
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionRequestLog> GetAllTransactionRequestLogs()
        {
            return _transactionRequestLogRepository.GetAll();
        }

        public TransactionRequestLog GetTransactionRequestLogById(int id)
        {
            return _transactionRequestLogRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs)
        {
            _transactionRequestLogRepository.Update(transactionRequestLogs);
        }

        public void AddTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs)
        {
            _transactionRequestLogRepository.Add(transactionRequestLogs);
        }

        public void RemoveTransactionRequestLog(params TransactionRequestLog[] transactionRequestLogs)
        {
            _transactionRequestLogRepository.Remove(transactionRequestLogs);
        }



        /// <summary>
        /// Financial Institution 
        /// </summary>
        /// <returns></returns>
        public IQueryable<FinancialInstitution> GetAllFinInstitutionInfos()
        {
            return _finInstitutionInfoRepository.GetAll();
        }

        public FinancialInstitution GetFinInstitutionInfoById(string id)
        {
            return _finInstitutionInfoRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateFinInstitutionInfo(params FinancialInstitution[] finInstitutionInfo)
        {
            _finInstitutionInfoRepository.Update(finInstitutionInfo);
        }

        public void AddFinInstitutionInfo(FinancialInstitution finInstitutionInfo)
        {
            _finInstitutionInfoRepository.Add(finInstitutionInfo);
        }

        public void RemoveFinInstitutionInfo(params FinancialInstitution[] finInstitutionInfos)
        {
            _finInstitutionInfoRepository.Remove(finInstitutionInfos);
        }


        /// <summary>
        /// Government Institution Info
        /// </summary>
        /// <returns></returns>
        public IQueryable<GovernmentInstitution> GetAllGovtInstitutionInfos()
        {
            return _govtInstitutionInfoRepository.GetAll();
        }

        public GovernmentInstitution GetGovtInstitutionInfoById(string id)
        {
            return _govtInstitutionInfoRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateGovtInstitutionInfo(params GovernmentInstitution[] govtInstitutionInfo)
        {
            _govtInstitutionInfoRepository.Update(govtInstitutionInfo);
        }

        public void AddGovtInstitutionInfo(GovernmentInstitution govtInstitutionInfo)
        {
            _govtInstitutionInfoRepository.Add(govtInstitutionInfo);
        }

        public void RemoveGovtInstitutionInfo(params GovernmentInstitution[] govtInstitutionInfos)
        {
            _govtInstitutionInfoRepository.Remove(govtInstitutionInfos);
        }





        /// <summary>
        /// EndUserLimit
        /// </summary>
        /// <returns></returns>
        public IQueryable<EndUserLimit> GetAllEndUserLimits()
        {
            return _endUserLimitRepository.GetAll();
        }

        public EndUserLimit GetEndUserLimitById(int id)
        {
            return _endUserLimitRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateEndUserLimit(params EndUserLimit[] endUserLimits)
        {
            _endUserLimitRepository.Update(endUserLimits);
        }

        public void AddEndUserLimit(EndUserLimit endUserLimit)
        {
            _endUserLimitRepository.Add(endUserLimit);
        }

        public void RemoveEndUserLimit(params EndUserLimit[] endUserLimits)
        {
            _endUserLimitRepository.Remove(endUserLimits);
        }


        /// <summary>
        /// Participant Cap History
        /// </summary>
        /// <returns></returns>
        public IQueryable<ParticipantCapHistory> GetAllParticipantCapHistories()
        {
            return _participantCapHistoryRepository.GetAll();
        }

        public ParticipantCapHistory GetParticipantCapHistoryById(int id)
        {
            return _participantCapHistoryRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateParticipantCapHistory(params ParticipantCapHistory[] participantCapHistories)
        {
            _participantCapHistoryRepository.Update(participantCapHistories);
        }

        public void AddParticipantCapHistory(ParticipantCapHistory participantCapHistory)
        {
            _participantCapHistoryRepository.Add(participantCapHistory);
        }

        public void RemoveParticipantCapHistory(params ParticipantCapHistory[] participantCapHistories)
        {
            _participantCapHistoryRepository.Remove(participantCapHistories);
        }


        /// <summary>
        /// Participant Cap 
        /// </summary>
        /// <returns></returns>
        public IQueryable<ParticipantDebitCap> GetAllParticipantDebitCaps()
        {
            return _participantDebitCapRepository.GetAll();
        }

        public ParticipantDebitCap GetParticipantDebitCapById(string id)
        {
            return _participantDebitCapRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateParticipantDebitCap(params ParticipantDebitCap[] participantDebitCaps)
        {
            _participantDebitCapRepository.Update(participantDebitCaps);
        }

        public void AddParticipantDebitCap(ParticipantDebitCap participantDebitCap)
        {
            _participantDebitCapRepository.Add(participantDebitCap);
        }

        public void RemoveParticipantDebitCap(params ParticipantDebitCap[] participantDebitCaps)
        {
            _participantDebitCapRepository.Remove(participantDebitCaps);
        }



        /// <summary>
        /// Transaction Value Limit
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionValueLimit> GetAllTransactionValueLimits()
        {
            return _transactionValueLimitRepository.GetAll();
        }

        public TransactionValueLimit GetTransactionValueLimitById(int id)
        {
            return _transactionValueLimitRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionValueLimit(params TransactionValueLimit[] transactionValueLimits)
        {
            _transactionValueLimitRepository.Update(transactionValueLimits);
        }

        public void AddTransactionValueLimit(TransactionValueLimit transactionValueLimit)
        {
            _transactionValueLimitRepository.Add(transactionValueLimit);
        }

        public void RemoveTransactionValueLimit(params TransactionValueLimit[] transactionValueLimits)
        {
            _transactionValueLimitRepository.Remove(transactionValueLimits);
        }


        /// <summary>
        /// Customer
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateCustomer(params Customer[] customers)
        {
            _customerRepository.Update(customers);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void RemoveCustomer(params Customer[] customers)
        {
            _customerRepository.Remove(customers);
        }

        /// <summary>
        /// DBLog
        /// </summary>
        /// <returns></returns>
        public IQueryable<DBLog> GetAllDBLogs()
        {
            return _dBLogRepository.GetAll();
        }

        public DBLog GetDBLogById(int id)
        {
            return _dBLogRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateDBLog(params DBLog[] dBLogs)
        {
            _dBLogRepository.Update(dBLogs);
        }

        public void AddDBLog(params DBLog[] items)
        {
            _dBLogRepository.Add(items);
        }

        public void RemoveDBLog(params DBLog[] items)
        {
            _dBLogRepository.Remove(items);
        }



        /// <summary>
        /// Group
        /// </summary>
        /// <returns></returns>
        public IQueryable<Group> GetAllGroups()
        {
            return _groupRepository.GetAll();
        }

        public Group GetGroupById(int id)
        {
            return _groupRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateGroup(params Group[] groups)
        {
            _groupRepository.Update(groups);
        }

        public void AddGroup(Group group)
        {
            _groupRepository.Add(group);
        }

        public void RemoveGroup(params Group[] groups)
        {
            _groupRepository.Remove(groups);
        }





        /// <summary>
        /// GroupRoleManagement
        /// </summary>
        /// <returns></returns>
        public IQueryable<GroupRoleManagement> GetAllGroupRoleManagements()
        {
            return _groupRoleManagementRepository.GetAll();
        }

        public GroupRoleManagement GetGroupRoleManagementById(int id)
        {
            return _groupRoleManagementRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateGroupRoleManagement(params GroupRoleManagement[] groupRoleManagements)
        {
            _groupRoleManagementRepository.Update(groupRoleManagements);
        }

        public void AddGroupRoleManagement(GroupRoleManagement groupRoleManagement)
        {
            _groupRoleManagementRepository.Add(groupRoleManagement);
        }

        public void RemoveGroupRoleManagement(params GroupRoleManagement[] groupRolemanagements)
        {
            _groupRoleManagementRepository.Remove(groupRolemanagements);
        }




        /// <summary>
        /// IDTPPermission
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDTPPermission> GetAllIDTPPermissions()
        {
            return _iDTPPermissionRepository.GetAll();
        }

        public IDTPPermission GetIDTPPermissionById(int id)
        {
            return _iDTPPermissionRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateIDTPPermission(params IDTPPermission[] iDTPPermissions)
        {
            _iDTPPermissionRepository.Update(iDTPPermissions);
        }

        public void AddIDTPPermission(IDTPPermission iDTPPermission)
        {
            _iDTPPermissionRepository.Add(iDTPPermission);
        }

        public void RemoveIDTPPermission(params IDTPPermission[] iDTPPermissions)
        {
            _iDTPPermissionRepository.Remove(iDTPPermissions);
        }




        /// <summary>
        /// Notification
        /// </summary>
        /// <returns></returns>
        public IQueryable<Notification> GetAllNotifications()
        {
            return _notificationRepository.GetAll()
                .Include(x => x.Transaction)
                .Include(x => x.Transaction.Sender)
                .Include(x => x.Transaction.Receiver)
                .Include(x => x.Transaction.IDTPUser);
        }

        public Notification GetNotificationById(int id)
        {
            return _notificationRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateNotification(params Notification[] notifications)
        {
            _notificationRepository.Update(notifications);
        }

        public void AddNotification(Notification notification)
        {
            _notificationRepository.Add(notification);
        }

        public void RemoveNotification(params Notification[] notifications)
        {
            _notificationRepository.Remove(notifications);
        }


        /// <summary>
        /// Payment
        /// </summary>
        /// <returns></returns>
        public IQueryable<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAll();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdatePayment(params Payment[] payments)
        {
            _paymentRepository.Update(payments);
        }

        public void AddPayment(Payment payment)
        {
            _paymentRepository.Add(payment);
        }

        public void RemovePayment(params Payment[] payments)
        {
            _paymentRepository.Remove(payments);
        }



        /// <summary>
        /// Response
        /// </summary>
        /// <returns></returns>
        public IQueryable<Response> GetAllResponses()
        {
            return _responseRepository.GetAll();
        }

        public Response GetResponseById(int id)
        {
            return _responseRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateResponse(params Response[] responses)
        {
            _responseRepository.Update(responses);
        }

        public void AddResponse(Response response)
        {
            _responseRepository.Add(response);
        }

        public void RemoveResponse(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Role
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDTPRole> GetAllRoles()
        {
            return _roleRepository.GetAll();
        }

        public IDTPRole GetRoleById(int id)
        {
            return _roleRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateRole(params IDTPRole[] roles)
        {
            _roleRepository.Update(roles);
        }

        public void AddRole(IDTPRole role)
        {
            _roleRepository.Add(role);
        }

        public void RemoveRole(params IDTPRole[] roles)
        {
            _roleRepository.Remove(roles);
        }


        /// <summary>
        /// RolePermissionManagement
        /// </summary>
        /// <returns></returns>
        public IQueryable<RolePermissionManagement> GetAllRolePermissionManagements()
        {
            return _rolePermissionManagementRepository.GetAll();
        }

        public RolePermissionManagement GetRolePermissionManagementById(int id)
        {
            return _rolePermissionManagementRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateRolePermissionManagement(params RolePermissionManagement[] rolePermissionManagements)
        {
            _rolePermissionManagementRepository.Update(rolePermissionManagements);
        }

        public void AddRolePermissionManagement(RolePermissionManagement rolePermissionManagement)
        {
            _rolePermissionManagementRepository.Add(rolePermissionManagement);
        }

        public void RemoveRolePermissionManagement(params RolePermissionManagement[] rolePermissionManagements)
        {
            _rolePermissionManagementRepository.Remove(rolePermissionManagements);
        }


        /// <summary>
        /// Transaction
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionFund> GetAllTransactions()
        {
            return _transactionRepository.GetAll()
                .Include(x => x.Sender)
                .Include(x => x.Receiver);
                
        }

        public TransactionFund GetTransactionById(int id)
        {
            return _transactionRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransaction(params TransactionFund[] transactions)
        {
            _transactionRepository.Update(transactions);
        }

        public void AddTransaction(TransactionFund transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public void RemoveTransaction(params TransactionFund[] transactions)
        {
            _transactionRepository.Remove(transactions);
        }

        /// <summary>
        /// TransactionBill
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionBill> GetAllTransactionBills()
        {
            return _transactionBillRepository.GetAll();
        }

        public TransactionBill GetTransactionBillById(int id)
        {
            return _transactionBillRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionBill(params TransactionBill[] transactions)
        {
            _transactionBillRepository.Update(transactions);
        }

        public void AddTransactionBill(TransactionBill transaction)
        {
            _transactionBillRepository.Add(transaction);
        }

        public void RemoveTransactionBill(params TransactionBill[] transactions)
        {
            _transactionBillRepository.Remove(transactions);
        }


        /// <summary>
        /// TransactionResponseMap
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionResponseMap> GetAllTransactionResponseMaps()
        {
            return _transactionResponseMapRepository.GetAll();
        }

        public TransactionResponseMap GetTransactionResponseMapById(int id)
        {
            return _transactionResponseMapRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionResponseMap(params TransactionResponseMap[] transactionResponseMaps)
        {
            _transactionResponseMapRepository.Update(transactionResponseMaps);
        }

        public void AddTransactionResponseMap(TransactionResponseMap transactionResponseMap)
        {
            _transactionResponseMapRepository.Add(transactionResponseMap);
        }

        public void RemoveTransactionResponseMap(int id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// UserGroupManagement
        /// </summary>
        /// <returns></returns>
        public IQueryable<UserGroupManagement> GetAllUserGroupManagements()
        {
            return _userGroupManagementRepository.GetAll();
        }

        public UserGroupManagement GetUserGroupManagementById(int id)
        {
            return _userGroupManagementRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateUserGroupManagement(params UserGroupManagement[] userGroupManagements)
        {
            _userGroupManagementRepository.Update(userGroupManagements);
        }

        public void AddUserGroupManagement(UserGroupManagement userGroupManagement)
        {
            _userGroupManagementRepository.Add(userGroupManagement);
        }

        public void RemoveUserGroupManagement(params UserGroupManagement[] userGroupManagements)
        {
            _userGroupManagementRepository.Remove(userGroupManagements);
        }

        /// <summary>
        /// ExternalTransaction
        /// </summary>
        /// <returns></returns>
        public IQueryable<ExternalTransaction> GetAllExternalTransactions()
        {
            return _externalTransactionRepository.GetAll()
                .Include(x => x.Response)
                .Include(x => x.Receiver);
        }

        public ExternalTransaction GetExternalTransactionById(int id)
        {
            return _externalTransactionRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateExternalTransaction(params ExternalTransaction[] externalTransactions)
        {
            _externalTransactionRepository.Update(externalTransactions);
        }

        public void AddExternalTransaction(ExternalTransaction externalTransaction)
        {
            _externalTransactionRepository.Add(externalTransaction);
        }

        public void RemoveExternalTransaction(params ExternalTransaction[] externalTransactions)
        {
            _externalTransactionRepository.Remove(externalTransactions);
        }

        /// <summary>
        /// ExternalNotification
        /// </summary>
        /// <returns></returns>
        public IQueryable<ExternalNotification> GetAllExternalNotifications()
        {
            return _externalNotificationRepository.GetAll()
                .Include(x => x.ExternalTransaction)
                .Include(y => y.ExternalTransaction.Sender)
                .Include(y => y.ExternalTransaction.Receiver)
                .Include(y => y.ExternalTransaction.Response);
        }

        public ExternalNotification GetExternalNotificationById(int id)
        {
            return _externalNotificationRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateExternalNotification(params ExternalNotification[] externalNotifications)
        {
            _externalNotificationRepository.Update(externalNotifications);
        }

        public void AddExternalNotification(ExternalNotification externalNotification)
        {
            _externalNotificationRepository.Add(externalNotification);
        }

        public void RemoveExternalNotification(params ExternalNotification[] externalNotifications)
        {
            _externalNotificationRepository.Remove(externalNotifications);
        }

        /// <summary>
        /// TransactionType
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionType> GetAllTransactionTypes()
        {
            return _transactionTypeRepository.GetAll();
        }

        public TransactionType GetTransactionTypeById(int id)
        {
            return _transactionTypeRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionType(params TransactionType[] transactionTypes)
        {
            _transactionTypeRepository.Update(transactionTypes);
        }

        public void AddTransactionType(TransactionType transactionType)
        {
            _transactionTypeRepository.Add(transactionType);
        }

        public void RemoveTransactionType(params TransactionType[] transactionTypes)
        {
            _transactionTypeRepository.Remove(transactionTypes);
        }

        /// <summary>
        /// TransactionStatus
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransactionStatus> GetAllTransactionStatuses()
        {
            return _transactionStatusRepository.GetAll();
        }

        public TransactionStatus GetTransactionStatusById(int id)
        {
            return _transactionStatusRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransactionStatus(params TransactionStatus[] transactionStatuses)
        {
            _transactionStatusRepository.Update(transactionStatuses);
        }

        public void AddTransactionStatus(TransactionStatus transactionStatus)
        {
            _transactionStatusRepository.Add(transactionStatus);
        }

        public void RemoveTransactionStatus(params TransactionStatus[] transactionStatuses)
        {
            _transactionStatusRepository.Remove(transactionStatuses);
        }

        /// <summary>
        /// Beneficiary
        /// </summary>
        /// <returns></returns>
        public IQueryable<Beneficiary> GetAllBeneficiary()
        {
            return _beneficiaryRepository.GetAll();
        }

        public Beneficiary GetBeneficiaryById(int id)
        {
            return _beneficiaryRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateBeneficiary(params Beneficiary[] beneficiaries)
        {
            _beneficiaryRepository.Update(beneficiaries);
        }

        public void AddBeneficiary(Beneficiary beneficiary)
        {
            _beneficiaryRepository.Add(beneficiary);
        }

        public void RemoveBeneficiary(params Beneficiary[] beneficiaries)
        {
            _beneficiaryRepository.Remove(beneficiaries);
        }

        /// <summary>
        /// Bank
        /// </summary>
        /// <returns></returns>
        public IQueryable<Bank> GetAllBanks()
        {
            return _bankRepository.GetAll().Include(x => x.FinancialInstitution);
        }

        public Bank GetBankById(string id)
        {
            return _bankRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public Bank GetBankBySwiftBic(string swiftBic)
        {
            return _bankRepository.GetAll().Include(x => x.FinancialInstitution).Where(p => p.SwiftBic == swiftBic).FirstOrDefault();
        }

        public void UpdateBank(params Bank[] banks)
        {
            _bankRepository.Update(banks);
        }

        public void AddBank(Bank bank)
        {
            _bankRepository.Add(bank);
        }

        public void RemoveBank(params Bank[] banks)
        {
            _bankRepository.Remove(banks);
        }


        /// <summary>
        /// Branch
        /// </summary>
        /// <returns></returns>
        public IQueryable<Branch> GetAllBranchs()
        {
            return _branchRepository.GetAll();
        }

        public Branch GetBranchById(int id)
        {
            return _branchRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateBranch(params Branch[] branches)
        {
            _branchRepository.Update(branches);
        }

        public void AddBranch(Branch branch)
        {
            _branchRepository.Add(branch);
        }

        public void RemoveBranch(params Branch[] branches)
        {
            _branchRepository.Remove(branches);
        }




        /// <summary>
        /// BankUser
        /// </summary>
        /// <returns></returns>
        public IQueryable<BankUser> GetAllBankUsers()
        {
            return _bankUserRepository.GetAll();
        }

        public BankUser GetBankUserById(int id)
        {
            return _bankUserRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateBankUser(params BankUser[] bankusers)
        {
            _bankUserRepository.Update(bankusers);
        }

        public void AddBankUser(BankUser bankuser)
        {
            _bankUserRepository.Add(bankuser);
        }

        public void RemoveBankUser(params BankUser[] bankusers)
        {
            _bankUserRepository.Remove(bankusers);
        }

        public void LogUserActivity(int? UserID, string activity, System.Uri pageUrl)
        {
            _IDTPLog.LogUserActivity(UserID, activity, pageUrl);
        }


        public void LogIDTPError(int? UserID, int errorNumber, string errorContext, string errorMessage, string errorTimeStamp)
        {
            _IDTPLog.LogIDTPError(UserID, errorNumber, errorContext, errorMessage, errorTimeStamp);
        }


        public List<ActivityLog> GetUserActivityLog(DateTime? logDate)
        {
            return _IDTPLog.GetUserActivityLog(logDate);
        }

        public List<IDTPErrorLog> GetIDTPErrorLog(DateTime? logDate)
        {
            return _IDTPLog.GetIDTPErrorLog(logDate);
        }


        public void LogAppErrorInfo(int UserID, string ErrorMessage, string ErrorStackTrace, int ErrorType, DateTime ErrorTimeStamp, string ErrorDeviceInfo)
        {
            _IDTPLog.LogAppErrorInfo(UserID, ErrorMessage, ErrorStackTrace, ErrorType, ErrorTimeStamp, ErrorDeviceInfo);
        }

        public List<IDTPAppErrorLog> GetIDTPAppErrorLog(DateTime? logDate)
        {
            return _IDTPLog.GetIDTPAppErrorLog(logDate);
        }

        #region Transaction Monitoring
        public IQueryable<TransactionMonitoringInfo> GetAllTranMonitoringInfo()
        {
            return _transactionMonitoringRepository.GetAll();
        }
        public TransactionMonitoringInfo GetTranMonitoringInfoByTranId(string tranId)
        {
            return _transactionMonitoringRepository.GetList(x => x.TransactionId == tranId).FirstOrDefault();
        }
        public void UpdateTranMonitoringInfo(params TransactionMonitoringInfo[] items)
        {
            _transactionMonitoringRepository.Update(items);
        }
        public void AddTranMonitoringInfo(params TransactionMonitoringInfo[] items)
        {
            _transactionMonitoringRepository.Add(items);
        }
        #endregion

        #region Action
        public IQueryable<Action> GetAllAction()
        {
            return _actionRepository.GetAll();
        }

        public void AddAction(Action action)
        {
            _actionRepository.Add(action);
        }
        #endregion

        #region Dispute Management Module
        public IQueryable<DisputeTransactionFund> GetAllDisputeTransactions()
        {
            return _disputeTransactionRepository.GetAll()
                .Include(x => x.DisputeAction)
                .Include(x => x.DisputeSeverity)
                .Include(x => x.TransactionFund);
        }

        public DisputeTransactionFund GetDisputeTransactionById(int id)
        {
            return _disputeTransactionRepository.GetAll()
                .Include(x => x.DisputeAction)
                .Include(x => x.DisputeSeverity)
                .Include(x => x.TransactionFund)
                .Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateDisputeTransaction(params DisputeTransactionFund[] items)
        {
            _disputeTransactionRepository.Update(items);
        }

        public void AddDisputeTransaction(DisputeTransactionFund disputeTransaction)
        {
            _disputeTransactionRepository.Add(disputeTransaction);
        }

        public IQueryable<DisputeAction> GetAllDisputeActions()
        {
            return _disputeActionRepository.GetAll();
        }

        public DisputeAction GetDisputeActionById(int id)
        {
            return _disputeActionRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateDisputeAction(params DisputeAction[] items)
        {
            _disputeActionRepository.Update(items);
        }

        public void AddDisputeAction(DisputeAction disputeAction)
        {
            _disputeActionRepository.Add(disputeAction);
        }

        public void RemoveDisputeAction(params DisputeAction[] actions)
        {
            _disputeActionRepository.Remove(actions);
        }


        public IQueryable<DisputeSeverity> GetAllDisputeSeverity()
        {
            return _disputeSeverityRepository.GetAll();
        }

        public DisputeSeverity GetDisputeSeverityById(int id)
        {
            return _disputeSeverityRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateDisputeSeverity(params DisputeSeverity[] items)
        {
            _disputeSeverityRepository.Update(items);
        }

        public void AddDisputeSeverity(DisputeSeverity disputeSeverity)
        {
            _disputeSeverityRepository.Add(disputeSeverity);
        }

        public void RemoveDisputeSeverity(params DisputeSeverity[] disputeSeverities)
        {
            _disputeSeverityRepository.Remove(disputeSeverities);
        }
        #endregion Dispute Management Module


        public IQueryable<BBSettlement> GetAllBBSettlements()
        {
            return _settlementRepository.GetAll();
        }

        public BBSettlement GetBBSettlementById(string SwiftBic)
        {
            return _settlementRepository.GetList(x => x.Bank.SwiftBic == SwiftBic).FirstOrDefault();
        }

        public void UpdateBBSettlement(params BBSettlement[] Settlements)
        {
            _settlementRepository.Update(Settlements);
        }

        public void AddBBSettlement(BBSettlement settlement)
        {
            _settlementRepository.Add(settlement);
        }

        public void RemoveBBSettlement(params BBSettlement[] settlements)
        {
            _settlementRepository.Add(settlements);
        }

        //For External API

        /// <summary>
        /// IDTPUserEntity
        /// </summary>
        /// <returns></returns>
        public IQueryable<IDTPUserEntity> GetAllIDTPUserEntities()
        {
            return _iDTPUserEntityRepository.GetAll();
        }

        public IDTPUserEntity GetIDTPUserEntityById(int id)
        {
            return _iDTPUserEntityRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateIDTPUserEntity(params IDTPUserEntity[] iDTPUserEntities)
        {
            _iDTPUserEntityRepository.Update(iDTPUserEntities);
        }

        public void AddIDTPUserEntity(IDTPUserEntity iDTPUserEntity)
        {
            _iDTPUserEntityRepository.Add(iDTPUserEntity);
        }

        public void RemoveIDTPUserEntity(params IDTPUserEntity[] iDTPUserEntities)
        {
            _iDTPUserEntityRepository.Remove(iDTPUserEntities);
        }


        /// <summary>
        /// DeviceLocationInfo
        /// </summary>
        /// <returns></returns>
        public IQueryable<DeviceLocationInfo> GetAllDeviceLocationInfos()
        {
            return _deviceLocationInfoRepository.GetAll();
        }

        public DeviceLocationInfo GetDeviceLocationInfoById(int id)
        {
            return _deviceLocationInfoRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos)
        {
            _deviceLocationInfoRepository.Update(deviceLocationInfos);
        }

        public void AddDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos)
        {
            _deviceLocationInfoRepository.Add(deviceLocationInfos);
        }

        public void RemoveDeviceLocationInfo(params DeviceLocationInfo[] deviceLocationInfos)
        {
            _deviceLocationInfoRepository.Remove(deviceLocationInfos);
        }

        /// <summary>
        /// EntityType
        /// </summary>
        /// <returns></returns>
        public IQueryable<EntityType> GetAllEntityTypes()
        {
            return _entityTypeRepository.GetAll();
        }

        public EntityType GetEntityTypeById(int id)
        {
            return _entityTypeRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateEntityType(params EntityType[] entityTypes)
        {
            _entityTypeRepository.Update(entityTypes);
        }

        public void AddEntityType(EntityType entityType)
        {
            _entityTypeRepository.Add(entityType);
        }

        public void RemoveEntityType(params EntityType[] entityTypes)
        {
            _entityTypeRepository.Remove(entityTypes);
        }

        /// <summary>
        /// GovtBillPayment
        /// </summary>
        /// <returns></returns>
        public IQueryable<GovtBillPayment> GetAllGovtBillPayments()
        {
            return _govtBillPaymentRepository.GetAll();
        }

        public GovtBillPayment GetGovtBillPaymentById(int id)
        {
            return _govtBillPaymentRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateGovtBillPayment(params GovtBillPayment[] govtBillPayments)
        {
            _govtBillPaymentRepository.Update(govtBillPayments);
        }

        public void AddGovtBillPayment(GovtBillPayment govtBillPayment)
        {
            _govtBillPaymentRepository.Add(govtBillPayment);
        }

        public void RemoveGovtBillPayment(params GovtBillPayment[] govtBillPayments)
        {
            _govtBillPaymentRepository.Remove(govtBillPayments);
        }

        /// <summary>
        /// IdentityType
        /// </summary>
        /// <returns></returns>
        public IQueryable<IdentityType> GetAllIdentityTypes()
        {
            return _identityTypeRepository.GetAll();
        }

        public IdentityType GetIdentityTypeById(int id)
        {
            return _identityTypeRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateIdentityType(params IdentityType[] identityTypes)
        {
            _identityTypeRepository.Update(identityTypes);
        }

        public void AddIdentityType(IdentityType identityType)
        {
            _identityTypeRepository.Add(identityType);
        }

        public void RemoveIdentityType(params IdentityType[] identityTypes)
        {
            _identityTypeRepository.Remove(identityTypes);
        }

        /// <summary>
        /// PaymentRecord
        /// </summary>
        /// <returns></returns>
        public IQueryable<PaymentRecord> GetAllPaymentRecords()
        {
            return _paymentRecordRepository.GetAll();
        }

        public PaymentRecord GetPaymentRecordById(int id)
        {
            return _paymentRecordRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdatePaymentRecord(params PaymentRecord[] paymentRecords)
        {
            _paymentRecordRepository.Update(paymentRecords);
        }

        public void AddPaymentRecord(PaymentRecord paymentRecord)
        {
            _paymentRecordRepository.Add(paymentRecord);
        }

        public void RemovePaymentRecord(params PaymentRecord[] paymentRecords)
        {
            _paymentRecordRepository.Remove(paymentRecords);
        }

        /// <summary>
        /// PaymentAuthorization
        /// </summary>
        /// <returns></returns>

        public IQueryable<PaymentAuthorization> GetAllPaymentAuthorizations()
        {
            return _paymentAuthorizationRepository.GetAll();
        }

        public PaymentAuthorization GetPaymentAuthorizationById(int id)
        {
            return _paymentAuthorizationRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdatePaymentAuthorization(params PaymentAuthorization[] paymentAuthorizations)
        {
            _paymentAuthorizationRepository.Update(paymentAuthorizations);
        }

        public void AddPaymentAuthorization(PaymentAuthorization paymentAuthorization)
        {
            _paymentAuthorizationRepository.Add(paymentAuthorization);
        }

        public void RemovePaymentAuthorization(params PaymentAuthorization[] paymentAuthorizations)
        {
            _paymentAuthorizationRepository.Remove(paymentAuthorizations);
        }

        /// <summary>
        /// TransferFund
        /// </summary>
        /// <returns></returns>
        public IQueryable<TransferFund> GetAllTransferFunds()
        {
            return _transferFundRepository.GetAll();
        }

        public TransferFund GetTransferFundById(int id)
        {
            return _transferFundRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateTransferFund(params TransferFund[] transferFunds)
        {
            _transferFundRepository.Update(transferFunds);
        }

        public void AddTransferFund(TransferFund transferFund)
        {
            _transferFundRepository.Add(transferFund);
        }

        public void RemoveTransferFund(params TransferFund[] transferFunds)
        {
            _transferFundRepository.Remove(transferFunds);
        }

        #region Disbursment
        public void AddDisbursment(params Disbursement[] disbursements)
        {
            _disbursementRepository.Add(disbursements);
        }

        public void AddDisbursmentDetail(params DisbursementDetail[] disbursementDetails)
        {
            _disbursementDetailRepository.Add(disbursementDetails);
        }
        #endregion

        public IQueryable<SuspenseTransactionHistory> GetAllSuspenseTransactionHistories()
        {
            return _suspenseTransactionHistoryRepository.GetAll();
        }
        public SuspenseTransactionHistory GetSuspenseTransactionHistoryById(int id)
        {
            return _suspenseTransactionHistoryRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdateSuspenseTransactionHistory(params SuspenseTransactionHistory[] suspenseTransactionHistories)
        {
            _suspenseTransactionHistoryRepository.Update(suspenseTransactionHistories);
        }
        public void AddSuspenseTransactionHistories(params SuspenseTransactionHistory[] suspenseTransactionHistories)
        {
            _suspenseTransactionHistoryRepository.Add(suspenseTransactionHistories);
        }
        public void RemoveSuspenseTransactionHistory(params SuspenseTransactionHistory[] suspenseTransactionHistories)
        {
            _suspenseTransactionHistoryRepository.Remove(suspenseTransactionHistories);
        }
        /// <summary>
        /// ReportInfo functions
        /// </summary>
        public IQueryable<ReportInfo> GetAllReportInfos()
        {
            return _reportInfoRepository.GetAll();
        }
        public ReportInfo GetReportInfoById(int id)
        {
            return _reportInfoRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdateReportInfo(params ReportInfo[] reportInfos)
        {
            _reportInfoRepository.Update(reportInfos);
        }
        public void AddReportInfo(ReportInfo reportInfo)
        {
            _reportInfoRepository.Add(reportInfo);
        }
        public void RemoveReportInfo(params ReportInfo[] reportInfos)
        {
            _reportInfoRepository.Remove(reportInfos);
        }


        public IQueryable<MasterToken> GetAllMasterTokens()
        {
            return _masterTokenRepository.GetAll();
        }
        public MasterToken GetMasterTokenById(int id) { 
            return _masterTokenRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public MasterToken GetMasterTokenByTokenNo(string tokenNo) {
            return _masterTokenRepository.GetAll().Where(x => x.Token == tokenNo).FirstOrDefault();
        }
        public void UpdateMasterToken(params MasterToken[] masterTokens) {
            _masterTokenRepository.Update(masterTokens);
        }
        public void AddMasterToken(MasterToken masterToken)
        {
            _masterTokenRepository.Add(masterToken);
        }
        public void RemoveMasterToken(params MasterToken[] masterTokens)
        {
            _masterTokenRepository.Remove(masterTokens);
        }



        public IQueryable<MasterTokenDetail> GetAllMasterTokenDetails()
        {
            return _masterTokenDetailRepository.GetAll();
        }
        public MasterTokenDetail GetMasterTokenDetailById(int id)
        {
            return _masterTokenDetailRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdateMasterTokenDetail(params MasterTokenDetail[] masterTokenDetails)
        {
            _masterTokenDetailRepository.Update(masterTokenDetails);
        }
        public void AddMasterTokenDetail(MasterTokenDetail masterToken)
        {
            _masterTokenDetailRepository.Add(masterToken);
        }
        public void RemoveMasterTokenDetail(params MasterTokenDetail[] masterTokens)
        {
            _masterTokenDetailRepository.Remove(masterTokens);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dBLogRepository.Dispose();
                    _groupRepository.Dispose();
                    _groupRoleManagementRepository.Dispose();
                    _iDTPPermissionRepository.Dispose();
                    _iIdtpUserRepository.Dispose();
                    _notificationRepository.Dispose();
                    _paymentRepository.Dispose();
                    _responseRepository.Dispose();
                    _rolePermissionManagementRepository.Dispose();
                    _roleRepository.Dispose();
                    _transactionRepository.Dispose();
                    _transactionResponseMapRepository.Dispose();
                    _userGroupManagementRepository.Dispose();
                    _externalTransactionRepository.Dispose();
                    _externalNotificationRepository.Dispose();
                    _transactionTypeRepository.Dispose();
                    _transactionStatusRepository.Dispose();
                    _beneficiaryRepository.Dispose();
                    _endUserLimitRepository.Dispose();
                    _finInstitutionInfoRepository.Dispose();
                    _govtInstitutionInfoRepository.Dispose();
                    _transactionValueLimitRepository.Dispose();
                    _participantCapHistoryRepository.Dispose();
                    _participantDebitCapRepository.Dispose();
                    _merchantRepository.Dispose();
                    _IDTPLog.Dispose();
                    _customerRepository.Dispose();
                    _transactionMonitoringRepository.Dispose();
                    _disputeTransactionRepository.Dispose();
                    _disputeActionRepository.Dispose();
                    _disputeSeverityRepository.Dispose();
                    _actionRepository.Dispose();
                    _bankRepository.Dispose();
                    _bankUserRepository.Dispose();
                    _transactionRequestLogRepository.Dispose();
                    _branchRepository.Dispose();
                    _suspenseTransactionRepository.Dispose();
                    _settlementRepository.Dispose();
                    _transactionBillRepository.Dispose();
                    _iDTPUserEntityRepository.Dispose();
                    _deviceLocationInfoRepository.Dispose();
                    _entityTypeRepository.Dispose();
                    _govtBillPaymentRepository.Dispose();
                    _identityTypeRepository.Dispose();
                    _paymentRecordRepository.Dispose();
                    _transferFundRepository.Dispose();
                    _suspenseTransactionHistoryRepository.Dispose();
                    _disbursementRepository.Dispose();
                    _disbursementDetailRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
