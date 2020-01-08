using NLog;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// ConnectionMultiplexer对象管理帮助类
    /// </summary>
    public class RedisConnectionHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //系统自定义Key前缀
        public static readonly string SysCustomKey = ConfigurationManager.AppSettings["redisKey"] ?? "";

        //"127.0.0.1:6379,allowadmin=true
        private static readonly string RedisConnectionString = ConfigurationManager.ConnectionStrings["RedisExchangeHosts"].ConnectionString;

        private static readonly object Locker = new object();
        private static ConnectionMultiplexer _instance;
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 缓存获取
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString)
        {
            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }
            return ConnectionCache[connectionString];
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString = connectionString ?? RedisConnectionString;
            var connect = ConnectionMultiplexer.Connect(connectionString);

            //注册如下事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region 事件

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\nConfiguration changed: {0}{1}", e.EndPoint, split);
            Logger.Error(exception);
            Console.WriteLine("Configuration changed: " + e.EndPoint);
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine("ErrorMessage: " + e.Message);
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\nErrorMessage: {0}{1}", e.Message, split);
            Logger.Error(exception);
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\nConfiguration changed: {0}{1}", e.EndPoint, split);
            Logger.Error(exception);
            Console.WriteLine("ConnectionRestored: " + e.EndPoint);
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\n重新连接：Endpoint failed: {0}, {1}{2}", e.EndPoint, e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)), split);
            Logger.Error(exception);
            Console.WriteLine("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)));
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\nHashSlotMoved:NewEndPoint{0}, OldEndPoint{1}{2}", e.NewEndPoint, e.OldEndPoint, split);
            Logger.Error(exception);
            Console.WriteLine("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint);
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            // 方法执行中抛异常时记录日志
            string split = "\r\n------------" + DateTime.Now.ToString() + "------------\r\n";
            string exception = string.Format("\r\nnternalError:Message{0}{1}", e.Exception.Message, split);
            Logger.Error(exception);
            Console.WriteLine("InternalError:Message" + e.Exception.Message);
        }

        #endregion 事件
    }
}
