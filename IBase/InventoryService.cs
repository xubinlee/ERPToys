using Common;
using DBML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IBase
{
    [ServiceContract(Name = "InventoryService")]
    public interface IInventoryService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Inventory> GetInventory(Guid warehouseID, Guid goodsID, int pcs);

        [OperationContract(Name = "GetAllInventory")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VInventory> GetInventory();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VInventoryGroupByGoods> GetInventoryGroupByGoods();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VMaterialInventory> GetMaterialInventory();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VMaterialInventoryGroupByGoods> GetMaterialInventoryGroupByGoods();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VAccountBook> GetAccountBook();

        #region 盘点

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VStocktaking> GetStocktaking();

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<VProfitAndLoss> GetProfitAndLoss();

        [OperationContract(Name = "InsertForList")]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(List<Stocktaking> stList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void StocktakingUpdate(Guid warehouseID, int goodsBigType, Guid? supplierID, List<Inventory> list, List<AccountBook> abList);

        #endregion

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void Insert(Object hd, IList dtl, List<Inventory> ityList, List<AccountBook> abList, List<Alert> delList, List<Alert> alertList);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void CancelAudit(Object hd, List<Inventory> ityList, List<AccountBook> abList);
    }
}
