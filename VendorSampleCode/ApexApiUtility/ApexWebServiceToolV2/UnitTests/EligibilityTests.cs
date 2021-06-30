using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OnetouchRefTestWeb;

namespace OneTouchWebServiceTests
{
    [TestFixture]
    public class EligibilityTests
    {
        private const string VendorKey = "J3QGALPWNTTHRDPBFNUHUFXG";
        private const string Password = "YWEHUGTB1QHQQ5W14W5P33X4";
        private const string SiteId = "ABC";
        private const string MemberIdSimpleBenefits = "99887766";
        private const string MemberIdSubscriberErrors = "1004";
        private const string MemberIdComplexBenefits = "1007";
        private const string MemberIdDelayedBenefits = "1008";
        private const int DelayedBenefitsDelay = 15000;
        private const string SubscriberError = "E1007";
        private const string NoBenefits = "E1026";
        private const decimal SimpleBenefitAmount = 1000.00M;


        [TestFixtureSetUp]
        public static void ClassInit()
        {
        }

        private WsBenefitSubmitResult SubmitEligibilityRequest(WsBenefitSubmitRequest request)
        {
            OnetouchRefTestWeb.OneTouchServicesClient oneTouchServicesClient = new OnetouchRefTestWeb.OneTouchServicesClient();

            return oneTouchServicesClient.SubmitEligibilityRequest(VendorKey, Password, SiteId, request);
        }

        private WsBenefitResponseResult GetEligibilityResponses(long requestId)
        {
            OnetouchRefTestWeb.OneTouchServicesClient oneTouchServicesClient = new OnetouchRefTestWeb.OneTouchServicesClient();

            return oneTouchServicesClient.GetEligibilityResponses(VendorKey, Password, SiteId, requestId);
        }

        private OnetouchRefTestWeb.Payer[] GetEligibilityTestPayerObjects(OnetouchRefTestWeb.PayerType payerType)
        {
            OnetouchRefTestWeb.OneTouchServicesClient oneTouchServicesClient = new OnetouchRefTestWeb.OneTouchServicesClient();
            OnetouchRefTestWeb.Payer[] testPayers = oneTouchServicesClient.GetTestPayers(VendorKey, Password, payerType);
            return testPayers.Where(payer => payer.OffersEligibility).ToArray();
        }

        private OnetouchRefTestWeb.Payer[] GetLivePayerObjects(OnetouchRefTestWeb.PayerType payerType)
        {
            OnetouchRefTestWeb.OneTouchServicesClient oneTouchServicesClient = new OnetouchRefTestWeb.OneTouchServicesClient();

            return  oneTouchServicesClient.GetPayers(VendorKey, Password, OnetouchRefTestWeb.PayerType.Medical);
        }

        private string GetTestPayerId(OnetouchRefTestWeb.PayerType payerType)
        {
            OnetouchRefTestWeb.Payer[] testPayers = GetEligibilityTestPayerObjects(payerType);
            return testPayers[0].ApexPayerId;
        }

        private WsSubscriberBenefit[] CreateSimpleSubscriberBenefits()
        {
            WsSubscriberBenefit benefit = new WsSubscriberBenefit();
            benefit.Type = new WsServiceType[] { WsServiceType.HealthBenefitPlanCoverage };
            WsSubscriberBenefit[] rval = new WsSubscriberBenefit[] { benefit };
            return rval;
        }

        private WsBenefitInquiry[] CreateInquiries(WsSubscriberBenefit[] benefits,
                out WsEligibilityRequestPayer payer, out WsEligibilityRequestPayee payee,
                out WsEligibilityRequestSubscriber subscriber,  string memberId)
        {
            payer = CreatePayer(benefits, out payee, out subscriber, memberId);

            WsBenefitInquiry inquiry = new WsBenefitInquiry();
            inquiry.Payers = new WsEligibilityRequestPayer[] { payer };
            inquiry.RequestType = WsRequestType.Request;

            WsBenefitInquiry[] inquiries = new WsBenefitInquiry[] { inquiry };
            return inquiries;
        }

        private WsEligibilityRequestPayer CreatePayer(WsSubscriberBenefit[] benefits, out WsEligibilityRequestPayee payee, out WsEligibilityRequestSubscriber subscriber, string memberId)
        {
            WsTraceNumber traceNumber = new WsTraceNumber();
            traceNumber.Number = "12345678";
            traceNumber.OriginatorId = "9VENDOR999";

            subscriber = new WsEligibilityRequestSubscriber();
            subscriber.EntityType = WsEntityType.Individual;
            subscriber.MemberId = memberId;
            subscriber.CommonName = "Smith";
            subscriber.FirstName = "John";
            subscriber.BirthDate = new DateTime(1985, 1, 1);
            subscriber.PayeeTraceNumber = traceNumber;
            subscriber.RequestedBenefits = benefits;

            payee = new WsEligibilityRequestPayee();
            payee.Type = WsPayeeType.Provider;
            payee.EntityType = WsEntityType.Individual;
            payee.NationalProviderId = "123456789";
            payee.CommonName = "Doe";
            payee.FirstName = "Jane";
            payee.Subscribers = new WsEligibilityRequestSubscriber[] { subscriber };

            WsEligibilityRequestPayer payer = new WsEligibilityRequestPayer();
            payer.Type = WsPayerType.Payer;
            payer.PayerId = GetTestPayerId(OnetouchRefTestWeb.PayerType.Medical);
            payer.EntityType = WsEntityType.Organization;
            payer.CommonName = "Apex Test Payer";
            payer.Payees = new WsEligibilityRequestPayee[] { payee };

            return payer;
        }

        [Test]
        public void SubmitEligibilityRequestNullBenefits()
        {
            WsEligibilityRequestPayee payee = null;
            WsEligibilityRequestSubscriber subscriber = null;
            WsEligibilityRequestPayer payer = null;
            WsBenefitSubmitRequest request = new WsBenefitSubmitRequest();
            request.BenefitInquiries = CreateInquiries(null, out payer, out payee, out subscriber, MemberIdSimpleBenefits);
            request.IsTest = true;

            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            Assert.IsTrue(result.Status == WsBenefitStatus.AllInvalid);
            Assert.IsTrue(result.ValidationResults[0].ValidationPayers[0].Payees[0].Subscribers[0].Errors.Any(error => error.ErrorCode == NoBenefits));
        }

        [Test]
        public void SubmitEligibilityRequestSubscriberError()
        {
            WsEligibilityRequestPayee payee = null;
            WsEligibilityRequestSubscriber subscriber = null;
            WsEligibilityRequestPayer payer = null;
            WsBenefitSubmitRequest request = new WsBenefitSubmitRequest();
            request.BenefitInquiries = CreateInquiries(CreateSimpleSubscriberBenefits(), out payer, out payee, out subscriber, MemberIdSubscriberErrors);
            request.IsTest = true;

            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            Assert.IsTrue(result.Status == WsBenefitStatus.ResultsComplete);
            Assert.AreEqual(0, result.ErrorResponses.Length);
            WsEligibilityResponseSubscriber responseSub = result.Responses[0].Payers[0].Payees[0].Subscribers[0];
            WsBenefitInformation[] benefits = responseSub.Benefits;
            Assert.IsTrue((benefits == null) || (benefits.Length == 0));
            Assert.IsTrue(responseSub.Errors.Length > 0);
        }

        [Test]
        public void SubmitEligibilitySimpleBenefits()
        {
            WsBenefitSubmitRequest request = CreateSimpleBenefitsRequest(MemberIdSimpleBenefits);
            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            ValidateSimpleBenefitsSubmitResult(result);
        }

        private WsBenefitSubmitRequest CreateSimpleBenefitsRequest(string memberId)
        {
            WsEligibilityRequestPayee payee = null;
            WsEligibilityRequestSubscriber subscriber = null;
            WsEligibilityRequestPayer payer = null;
            WsBenefitSubmitRequest request = new WsBenefitSubmitRequest();
            request.BenefitInquiries = CreateInquiries(CreateSimpleSubscriberBenefits(), out payer, out payee, out subscriber, memberId);
            request.IsTest = true;
            return request;
        }

        private void ValidateSimpleBenefitsSubmitResult(WsBenefitSubmitResult result)
        {
            ValidateSimpleBenefitsResult(result.Status, result.ValidationResults, result.ErrorResponses, result.Responses);
        }

        private void ValidateSimpleBenefitsResponseResult(WsBenefitResponseResult result)
        {
            ValidateSimpleBenefitsResult(result.Status, result.ValidationResults, result.ErrorResponses, result.Responses);
        }

        private void ValidateSimpleBenefitsResult(WsBenefitStatus status, WsValidationResult[] validationResults, WsErrorResponse[] errorResponses, WsBenefitResponse[] responses)
        {
            Assert.IsTrue(status == WsBenefitStatus.ResultsComplete);
            Assert.AreEqual(0, validationResults.Length);
            Assert.AreEqual(0, errorResponses.Length);
            Assert.IsTrue(responses.Length == 1);
            Assert.IsTrue(responses[0].Payers[0].Payees[0].Subscribers[0].Benefits.Length > 0);
            Assert.IsTrue(responses[0].Payers[0].Payees[0].Subscribers[0].Benefits[0].TypesOfService.Length > 0);
            Assert.AreEqual(SimpleBenefitAmount, responses[0].Payers[0].Payees[0].Subscribers[0].Benefits[0].BenefitAmount);
        }

        [Test]
        public void SubmitEligibilitySimpleBenefitsDelayed()
        {
            WsBenefitSubmitRequest request = CreateSimpleBenefitsRequest(MemberIdDelayedBenefits);
            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            Assert.IsTrue(result.Status == WsBenefitStatus.ResultsIncomplete);
            // Wait a little longer.
            System.Threading.Thread.Sleep(DelayedBenefitsDelay);
            WsBenefitResponseResult responseResult = GetEligibilityResponses(result.RequestId);
            ValidateSimpleBenefitsResponseResult(responseResult);
        }

        [Test]
        public void SubmitEligibilityComplexBenefits()
        {
            WsEligibilityRequestPayee payee = null;
            WsEligibilityRequestSubscriber subscriber = null;
            WsEligibilityRequestPayer payer = null;
            WsBenefitSubmitRequest request = new WsBenefitSubmitRequest();
            request.BenefitInquiries = CreateInquiries(CreateSimpleSubscriberBenefits(), out payer, out payee, out subscriber, MemberIdComplexBenefits);
            request.IsTest = true;

            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            Assert.IsTrue(result.Status == WsBenefitStatus.ResultsComplete);
            Assert.IsTrue(result.ErrorResponses.Length == 0);
            Assert.IsTrue(result.Responses.Length == 1);
            Assert.IsTrue(result.Responses[0].Payers[0].Payees[0].Subscribers[0].Benefits.Length > 1);
        }

        [Test]
        public void GetTestPayers()
        {
            OnetouchRefTestWeb.Payer[] payers = GetEligibilityTestPayerObjects(OnetouchRefTestWeb.PayerType.Medical);
            Assert.Greater(payers.Length, 0);
        }

        [Test]
        public void GetLivePayers()
        {
            OnetouchRefTestWeb.Payer[] payers = GetLivePayerObjects(OnetouchRefTestWeb.PayerType.Medical);
            Assert.Greater(payers.Length, 0);
        }
    }
}
