using Microsoft.VisualStudio.TestTools.UnitTesting;
using OKExSDKLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    [TestClass]
    public class UnitTestAccountApi
    {


        /// <summary>
        /// �鿴�˻����
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getBalance()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["ccy"] = "";
            var result = await UnitTestBasic.accountApi.GetBalance(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// �鿴�ֲ���Ϣ
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getPositions()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instType"] = "FUTURES";
            requestParameters["instId"] = "BTC-USDT-201225";
            var result = await UnitTestBasic.accountApi.GetPositions(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// �˵���ˮ��ѯ�������죩
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getBillsDetails()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instType"] = "FUTURES";
            requestParameters["ccy"] = "";
            requestParameters["mgnMode"] = "";
            requestParameters["ctType"] = "";
            requestParameters["type"] = "";
            requestParameters["subType"] = "";
            requestParameters["after"] = "";
            requestParameters["before"] = "";
            requestParameters["limit"] = "";
            var result = await UnitTestBasic.accountApi.GetBillsDetails(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// �˵���ˮ��ѯ���������£�
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getBillsDetails_archive()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instType"] = "FUTURES";
            requestParameters["ccy"] = "";
            requestParameters["mgnMode"] = "";
            requestParameters["ctType"] = "";
            requestParameters["type"] = "";
            requestParameters["subType"] = "";
            requestParameters["after"] = "";
            requestParameters["before"] = "";
            requestParameters["limit"] = "";
            var result = await UnitTestBasic.accountApi.GetBillsDetails_archive(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// �鿴�˻�����
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getAccountConfiguration()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["uid"] = "";
            requestParameters["acctLv"] = "";
            requestParameters["posMode"] = "";
            requestParameters["autoLoan"] = "";
            requestParameters["greeksType"] = "";
            var result = await UnitTestBasic.accountApi.GetAccountConfiguration(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ���óֲ�ģʽ
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task setPositionMode()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["posMode"] = "long_short_mode";
            var result = await UnitTestBasic.accountApi.GetAccountConfiguration(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ���øܸ˱���
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task setleverage()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT-201225";
            requestParameters["ccy"] = "";
            requestParameters["lever"] = "5";
            requestParameters["mgnMode"] = "cross";
            requestParameters["posSide"] = "";
            var result = await UnitTestBasic.accountApi.SetLeverage(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ���ɽ�������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getMaximumTradableSizeForInstrument()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT-201225";
            requestParameters["tdMode"] = "cross";
            requestParameters["ccy"] = "";
            requestParameters["px"] = "";
            var result = await UnitTestBasic.accountApi.GetAccountConfiguration(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getMaximumAvailableTradableAmount()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT-201225";
            requestParameters["ccy"] = "";
            requestParameters["tdMode"] = "cross";
            requestParameters["reduceOnly"] = "";
            var result = await UnitTestBasic.accountApi.GetMaximumAvailableTradableAmount(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ������֤��
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task increaseDecreaseMargin()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT-201225";
            requestParameters["posSide"] = "net";
            requestParameters["type"] = "add";
            requestParameters["amt"] = "10";
            var result = await UnitTestBasic.accountApi.IncreaseOrDecreaseMargin(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ�ܸ˱���
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getLeverage()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT-201225";
            requestParameters["mgnMode"] = "cross";
            var result = await UnitTestBasic.accountApi.GetLeverage(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ�ұ���ָܸ����ɽ�
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getTheMaximumLoanOfIsolatedMARGIN()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "BTC-USDT";
            var result = await UnitTestBasic.accountApi.GetTheMaximumLoanOfIsolatedMARGIN(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ��ǰ�˻����������ѷ���
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getFeeRates()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instType"] = "FUTURES";
            requestParameters["instId"] = "";
            requestParameters["uly"] = "BTC-USD";
            requestParameters["category"] = "";
            var result = await UnitTestBasic.accountApi.GetFeeRates(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��ȡ��Ϣ��¼
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getInterest_accrued()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["instId"] = "";
            requestParameters["ccy"] = "";
            requestParameters["mgnMode"] = "";
            requestParameters["after"] = "";
            requestParameters["before"] = "";
            requestParameters["limit"] = "";
            var result = await UnitTestBasic.accountApi.GetInterest_accrued(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// ��Ȩϣ����ĸPA/BS�л�
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task setGreeks()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["greeksType"] = "PA";
            var result = await UnitTestBasic.accountApi.SetGreeks(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }

        /// <summary>
        /// �鿴�˻�����ת���
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task getMaximumWithdrawals()
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters["greeksType"] = "";
            var result = await UnitTestBasic.accountApi.GetMaximumWithdrawals(UnitTestBasic.cleanNullKey(requestParameters));
            System.Console.WriteLine(result);
        }




    }
}
