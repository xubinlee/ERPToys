using Common;
using DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    [ServiceContract(Name = "OrderService")]
    public interface IOrderService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        string GetMaxBillNo();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<OrderHd> GetOrderHd();

        [OperationContract(Name = "GetOrderHdForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        OrderHd GetOrderHd(Guid id);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<OrderDtl> GetOrderDtl(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VOrder> GetOrder();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VOrderDtlByBOM> GetVOrderDtlByBOM(Guid hdID, int bomType);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<OrderDtl> GetVFSMOrderDtlByMoldList(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<OrderDtl> GetVFSMOrderDtlByMoldMaterial(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VFSMOrder> GetFSMOrder();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VProductionOrder> GetProductionOrder();

        [OperationContract(Name = "GetProductionOrderDtlForPrintForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint(Guid hdID);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VProductionOrderDtlForPrint> GetProductionOrderDtlForPrint();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Audit(OrderHd orderhd, StockOutBillHd hd, List<StockOutBillDtl> dtl, OrderHd poHd, List<OrderDtl> poDtlList, List<Alert> delList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(OrderHd hd, List<OrderDtl> dtl);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(OrderHd hd, List<OrderDtl> dtl);

        [OperationContract(Name = "GetUsersInfoForID")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Update(OrderHd hd);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Delete(Guid id);
    }
}
