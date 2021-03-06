//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1590.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
public partial class WsHealthCareClaimStatus {
    
    private int vendorIdField;
    
    private string vendorSiteIdField;
    
    private string claimNumberField;
    
    private WsPayerClaimState currentStateField;
    
    private System.Nullable<System.DateTime> stateChangeDateField;
    
    private WsPayerClaimAction payerActionField;
    
    private System.Nullable<System.DateTime> payerActionDateField;
    
    private string payerControlNumberField;
    
    private System.Nullable<System.DateTime> createDateField;
    
    private System.Nullable<System.DateTime> lastUpdateDateField;
    
    private System.Nullable<WsDocumentType> relatedDocumentTypeField;
    
    private string relatedDocumentIdField;
    
    private System.Nullable<decimal> totalClaimAmountField;
    
    private System.Nullable<decimal> payerAmountField;
    
    private System.Nullable<decimal> adjustmentsField;
    
    private System.Nullable<decimal> patientAmountField;
    
    private string payerNameField;
    
    private System.Nullable<WsPaymentMethodCode> paymentMethodField;
    
    private string paymentReferenceNumberField;
    
    private System.Nullable<System.DateTime> paymentEffectiveDateField;
    
    private string vendorClaimIdField;
    
    /// <remarks/>
    public int VendorId {
        get {
            return this.vendorIdField;
        }
        set {
            this.vendorIdField = value;
        }
    }
    
    /// <remarks/>
    public string VendorSiteId {
        get {
            return this.vendorSiteIdField;
        }
        set {
            this.vendorSiteIdField = value;
        }
    }
    
    /// <remarks/>
    public string ClaimNumber {
        get {
            return this.claimNumberField;
        }
        set {
            this.claimNumberField = value;
        }
    }
    
    /// <remarks/>
    public WsPayerClaimState CurrentState {
        get {
            return this.currentStateField;
        }
        set {
            this.currentStateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<System.DateTime> StateChangeDate {
        get {
            return this.stateChangeDateField;
        }
        set {
            this.stateChangeDateField = value;
        }
    }
    
    /// <remarks/>
    public WsPayerClaimAction PayerAction {
        get {
            return this.payerActionField;
        }
        set {
            this.payerActionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<System.DateTime> PayerActionDate {
        get {
            return this.payerActionDateField;
        }
        set {
            this.payerActionDateField = value;
        }
    }
    
    /// <remarks/>
    public string PayerControlNumber {
        get {
            return this.payerControlNumberField;
        }
        set {
            this.payerControlNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<System.DateTime> CreateDate {
        get {
            return this.createDateField;
        }
        set {
            this.createDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<System.DateTime> LastUpdateDate {
        get {
            return this.lastUpdateDateField;
        }
        set {
            this.lastUpdateDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<WsDocumentType> RelatedDocumentType {
        get {
            return this.relatedDocumentTypeField;
        }
        set {
            this.relatedDocumentTypeField = value;
        }
    }
    
    /// <remarks/>
    public string RelatedDocumentId {
        get {
            return this.relatedDocumentIdField;
        }
        set {
            this.relatedDocumentIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<decimal> TotalClaimAmount {
        get {
            return this.totalClaimAmountField;
        }
        set {
            this.totalClaimAmountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<decimal> PayerAmount {
        get {
            return this.payerAmountField;
        }
        set {
            this.payerAmountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<decimal> Adjustments {
        get {
            return this.adjustmentsField;
        }
        set {
            this.adjustmentsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<decimal> PatientAmount {
        get {
            return this.patientAmountField;
        }
        set {
            this.patientAmountField = value;
        }
    }
    
    /// <remarks/>
    public string PayerName {
        get {
            return this.payerNameField;
        }
        set {
            this.payerNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<WsPaymentMethodCode> PaymentMethod {
        get {
            return this.paymentMethodField;
        }
        set {
            this.paymentMethodField = value;
        }
    }
    
    /// <remarks/>
    public string PaymentReferenceNumber {
        get {
            return this.paymentReferenceNumberField;
        }
        set {
            this.paymentReferenceNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<System.DateTime> PaymentEffectiveDate {
        get {
            return this.paymentEffectiveDateField;
        }
        set {
            this.paymentEffectiveDateField = value;
        }
    }
    
    /// <remarks/>
    public string VendorClaimId {
        get {
            return this.vendorClaimIdField;
        }
        set {
            this.vendorClaimIdField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
public enum WsPayerClaimState {
    
    /// <remarks/>
    Unknown,
    
    /// <remarks/>
    Submitted,
    
    /// <remarks/>
    Accepted,
    
    /// <remarks/>
    Rejected,
    
    /// <remarks/>
    Pending,
    
    /// <remarks/>
    Adjudicated,
    
    /// <remarks/>
    Paid,
    
    /// <remarks/>
    Complete,
    
    /// <remarks/>
    Denied,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
public enum WsPayerClaimAction {
    
    /// <remarks/>
    Unknown,
    
    /// <remarks/>
    None,
    
    /// <remarks/>
    Accepted,
    
    /// <remarks/>
    AcceptedWithErrors,
    
    /// <remarks/>
    ProcessedAsPrimary,
    
    /// <remarks/>
    ProcessedAsSecondary,
    
    /// <remarks/>
    ProcessedAsTertiary,
    
    /// <remarks/>
    Denied,
    
    /// <remarks/>
    ProcessedAsPrimaryForwarded,
    
    /// <remarks/>
    ProcessedAsSecondaryForwarded,
    
    /// <remarks/>
    ProcessedAsTertiaryForwarded,
    
    /// <remarks/>
    PaymentReversal,
    
    /// <remarks/>
    ForwardedNotOurs,
    
    /// <remarks/>
    PredeterminationOnly,
    
    /// <remarks/>
    AckForwarded,
    
    /// <remarks/>
    AckReceipt,
    
    /// <remarks/>
    AckAccept,
    
    /// <remarks/>
    AckReturned,
    
    /// <remarks/>
    AckNotFound,
    
    /// <remarks/>
    AckSplitClaim,
    
    /// <remarks/>
    AckRejectMissingInformation,
    
    /// <remarks/>
    AckRejectInvalidInformation,
    
    /// <remarks/>
    AckRejectRelationalField,
    
    /// <remarks/>
    ErrorSubmittedData,
    
    /// <remarks/>
    ErrorSystemStatus,
    
    /// <remarks/>
    ErrorNoResponse,
    
    /// <remarks/>
    ErrorRelationalCorrectionRequired,
    
    /// <remarks/>
    ErrorDataCorrectionRequired,
    
    /// <remarks/>
    Finalized,
    
    /// <remarks/>
    FinalizedPayment,
    
    /// <remarks/>
    FinalizedDenial,
    
    /// <remarks/>
    FinalizedRevised,
    
    /// <remarks/>
    FinalizedForwarded,
    
    /// <remarks/>
    FinalizedNotForwarded,
    
    /// <remarks/>
    FinalizedAdjudicationComplete,
    
    /// <remarks/>
    Pending,
    
    /// <remarks/>
    PendingInProcess,
    
    /// <remarks/>
    PendingPayerReview,
    
    /// <remarks/>
    PendingProviderRequestedInformation,
    
    /// <remarks/>
    PendingPatientRequestedInformation,
    
    /// <remarks/>
    PendingPayerAdministrative,
    
    /// <remarks/>
    RejectedMacFailed,
    
    /// <remarks/>
    AcceptedPartial,
    
    /// <remarks/>
    Rejected,
    
    /// <remarks/>
    RejectedValidityFailed,
    
    /// <remarks/>
    RejectedBadContent,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
public enum WsDocumentType {
    
    /// <remarks/>
    Unknown,
    
    /// <remarks/>
    Claim,
    
    /// <remarks/>
    ClaimStatus,
    
    /// <remarks/>
    InterchangeStatus,
    
    /// <remarks/>
    RemittanceAdvice,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
public enum WsPaymentMethodCode {
    
    /// <remarks/>
    Unknown,
    
    /// <remarks/>
    Ach,
    
    /// <remarks/>
    FinancialInstitution,
    
    /// <remarks/>
    Check,
    
    /// <remarks/>
    FedWire,
    
    /// <remarks/>
    None,
}
