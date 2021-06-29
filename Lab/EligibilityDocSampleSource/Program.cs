using System;
using EligibilityDocSampleSource.OneTouchService;

namespace EligibilityDocSampleSource
{
    class Program
    {
        private static string VendorKey { get; set; }
        private static string Password { get; set; }
        private static string SiteId { get; set; }

        //private const string MemberId = "1001"; // envelope errors
        //private const string MemberId = "1002"; // payer errors
        //private const string MemberId = "1003"; // payee errors
        //private const string MemberId = "1004"; // subscriber errors
        //private const string MemberId = "1005"; // dependent errors
        //private const string MemberId = "1006"; // syntax error
        private const string MemberId = "1007"; // complex benefits will be returned
        //private const string MemberId = "1008"; // simple benefits will be returned after a delay of approximately 65 seconds. Note that there
        //                                        // will be 65-second delay for each patient (subscriber or dependent)
        //                                        // where 1008 is the subscriber member ID
        //private const string MemberId = "99887766"; // (or any other member ID) simple benefits will be returned

        private const string DefaultVendorKey = "TY0W3N04KSGKQQCPQ2J514UD";
        private const string DefaultPassword = "BSXQZRCJC02ODZ5GI4F1B0AE";

        static void Main(string[] args)
        {
            VendorKey = DefaultVendorKey;
            Password = DefaultPassword;
            SiteId = "ZZZ";
            SubmitEligibilitySimpleBenefits();
        }
        public static void SubmitEligibilitySimpleBenefits()
        {
            WsBenefitSubmitRequest request =
                CreateSimpleBenefitsRequest(MemberId);
            WsBenefitSubmitResult result = SubmitEligibilityRequest(request);
            OneTouchServicesClient client = new OneTouchServicesClient();

            WsBenefitResponseResult responseResult = client.GetEligibilityResponses(VendorKey, Password, SiteId, result.RequestId);
        }

        private static WsBenefitSubmitRequest CreateSimpleBenefitsRequest(string memberId)
        {
            WsEligibilityRequestPayee payee = null;
            WsEligibilityRequestSubscriber subscriber = null;
            WsEligibilityRequestPayer payer = null;
            WsBenefitSubmitRequest request = new WsBenefitSubmitRequest();
            request.BenefitInquiries =
                CreateInquiries(CreateSimpleSubscriberBenefits(),
                    out payer, out payee, out subscriber, memberId);
            request.IsTest = true;
            return request;
        }

        private static WsSubscriberBenefit[] CreateSimpleSubscriberBenefits()
        {
            WsSubscriberBenefit benefit = new WsSubscriberBenefit();
            benefit.Type = new WsServiceType[] { WsServiceType.HealthBenefitPlanCoverage };
            WsSubscriberBenefit[] rval = new WsSubscriberBenefit[] { benefit };
            return rval;
        }
        private static WsBenefitInquiry[] CreateInquiries(WsSubscriberBenefit[] benefits,
            out WsEligibilityRequestPayer payer, out WsEligibilityRequestPayee payee,
            out WsEligibilityRequestSubscriber subscriber, string memberId)
        {
            payer = CreatePayer(benefits, out payee, out subscriber, memberId);
            WsBenefitInquiry inquiry = new WsBenefitInquiry();
            inquiry.Payers = new WsEligibilityRequestPayer[] { payer };
            inquiry.RequestType = WsRequestType.Request;
            WsBenefitInquiry[] inquiries = new WsBenefitInquiry[] { inquiry };
            return inquiries;
        }

        private static WsEligibilityRequestPayer CreatePayer(
            WsSubscriberBenefit[] benefits, out WsEligibilityRequestPayee payee,
            out WsEligibilityRequestSubscriber subscriber, string memberId)
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
            payer.PayerId = "APX14114";
            payer.EntityType = WsEntityType.Organization;
            payer.CommonName = "Apex Test Payer";
            payer.Payees = new WsEligibilityRequestPayee[] { payee };

            return payer;
        }

        private static WsBenefitSubmitResult SubmitEligibilityRequest(
            WsBenefitSubmitRequest request)
        {
            OneTouchServicesClient oneTouchServicesClient =
                new OneTouchServicesClient();

            WsBenefitSubmitResult result = oneTouchServicesClient.SubmitEligibilityRequest(VendorKey,
                Password, SiteId, request);

            return result;
        }

    }
}