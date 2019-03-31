using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApniMaa.BLL.Models
{
    public enum ActionStatus
    {
        Successfull = 1,
        Error = 2,
        LoggedOut = 3,
        Unauthorized = 4
    }

    public enum RegisterVia
    {
        Website = 1,
        Android = 2,
        IPhone = 3,
        WebsiteFacebook = 4,
        AndroidFacebook = 5,
        IPhoneFacebook = 6,
        AdminWebsite = 7
    }
    public enum AvailibiltyType
    {
        [Description("Lunch")]
        Lunch = 1,
        [Description("Dinner")]
        Dinner = 2,
        [Description("Both")]
        Both = 3
    }

    public enum InvoicePaymentStatus
    {
        [Description("Submitted to Client")]
        Submitted = 1,
        [Description("Paid")]
        Paid = 2,

    }
    public enum TransactionType
    {
        [Description("New")]
        New = 1,
        [Description("Renew")]
        Renew = 2,
        [Description("Cancel")]
        Cancel = 3,
        [Description("Vehicle Change")]
        Vehicle_Change = 4
    }
    public enum CertificateStatus
    {
        [Description("Drafted")]
        Drafted = 1,
        [Description("Activated")]
        Activated = 2,
        [Description("Cancelled")]
        Cancelled = 3
    }

    public enum TemplateTypes
    {
        [Description("Sign Up")]
        SignUpEmail = 1,
        [Description("Forget Password")]
        ForgetPassword = 2,
        [Description("Reset Password")]
        ResetPassword = 3,
        [Description("Contact Us")]
        Contact = 4,
        [Description("Add Prospect")]
        Prospect = 5,
        [Description("Send Application")]
        Application = 6,
        [Description("MeetingSchduled")]
        MeetingSchduled = 7,
        [Description("EventScheduled")]
        EventScheduled = 10,
        [Description("PolicyStatus")]
        PolicyStatus = 13,
        [Description("Approve / Disapprove")]
        Approve = 14,
        [Description("Renewal Review")]
        RenewalReview = 15,
        [Description("New Driver Approval")]
        DriverApproval = 16,
        [Description("Fleet Driver Approval")]
        FleetDriverApproval = 17
    }

    public enum UserRoleTypes
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Mother")]
        Mother = 2,
        [Description("User")]
        User = 3

    }
    public enum UserStatuss
    {
        [Description("Registered")]
        Registered = 1,
        [Description("Verified")]
        Verified = 2,
        [Description("Approved")]
        Approved = 3,
        [Description("Subscribed")]
        Subscribed = 4,
        [Description("Blocked")]
        Blocked = 5,
        [Description("Deleted")]
        Deleted = 6,

    }
    public enum OmegaClaimStatuss
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Submitted to Omega")]
        SubmittedtoOmega = 2,
        [Description("Approved")]
        Approved = 3,
        [Description("Declined")]
        Declined = 4

    }
    public enum BulkType
    {
        [Description("Certificates")]
        Certificates = 1,

    }
    public enum RequestCancelationType
    {
        [Description("CutOff Cancelation")]
        CutOffCancelation = 1,
        [Description("RunOff Cancelation")]
        RunOffCancelation = 2
    }

    public enum RequestCancelationStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("Declined")]
        Declined = 3
    }

    public enum PaymentModes
    {
        [Description("Cheque")]
        Cheque = 1
    }

    public enum BalanceSheetEntryType
    {
        [Description("Case Addition")]
        CaseAddition = 1,
        [Description("Supplemental Addition")]
        SupplementalAddition = 2,
        [Description("Supplemental Plus Addition")]
        SupplementalPlusAddition = 3,
        [Description("Settled")]
        Settled = 4,
        [Description("Removal")]
        Removal = 5

    }
    public enum ClaimStatus
    {
        [Description("Decision Pending")]
        DecisionPending = 1,
        [Description("Submitted to Omega")]
        SubmittedtoOmega = 2,
        [Description("Claim Paid Ongoing")]
        ClaimPaidOngoing = 3,
        [Description("Claim Paid No Ongoing")]
        ClaimPaidNoOngoing = 4,
        [Description("Claim Declined Ongoing")]
        ClaimDeclinedOngoing = 5,
        [Description("Claim Declined No Ongoing")]
        ClaimDeclinedNoOngoing = 6

    }

    public enum PageType
    {
        [Description("ImageOnly")]
        ImageOnly = 1,
        [Description("ImageText")]
        ImageText = 2,
        [Description("Text")]
        Text = 3
    }
    public enum DocumentType
    {
        [Description("PolicyDeclaration")]
        PolicyDeclaration = 1,
        [Description("AnnualReniew")]
        AnnualReniew = 2,
        [Description("Policy")]
        Policy = 3,
        [Description("Schedule")]
        Schedule = 4,
        [Description("Endorsement")]
        Endorsement = 5
    }
    public enum MasterType
    {
        [Description("ActionType")]
        ActionType = 1,
        [Description("EventType")]
        EventType = 2,
        [Description("Other")]
        Other = 3
    }

    public enum CoverageType
    {
        [Description("LISC Firm Protect")]
        LISCFirmProtect = 1,
        [Description("LISC File Protect")]
        LISCFileProtect = 2
    }

    public enum LawyerCount
    {
        [Description("1-10")]
        First = 1,
        [Description("11-20")]
        Second = 2,
        [Description("21-30")]
        Third = 3,
        [Description("Over 30")]
        Fourth = 4
    }

    public enum ContactRole
    {
        [Description("Administrator")]
        Administrator = 1,
        [Description("Lawyer")]
        Lawyer = 2
    }

    public enum MeetType
    {
        [Description("ProblemSolving")]
        ProblemSolving = 1,
        [Description("DecisionMaking")]
        DecisionMaking = 2,
        [Description("Planning")]
        Planning = 3,
        [Description("Feedback")]
        Feedback = 4
    }

    public enum CaseStatus
    {
        [Description("Change of Coverage")]
        CoverageChange = 1,
        [Description("Files Transferred")]
        FilesTransferred = 2,
        [Description("Claim")]
        Claim = 3,
        [Description("Premium Waiver Request")]
        WaiverRequest = 4,
        [Description("Discontinued")]
        Discontinued = 5,
        [Description("Abandoned")]
        Abandoned = 6,
        [Description("Cancelled")]
        Cancelled = 7,
        [Description("File Settled with successful outcome")]
        FilesSettled = 8,
        [Description("Claim resolved")]
        claimresolved = 9,

        [Description("File settled")]
        FileSettled = 10,
        [Description("Premium waiver request")]
        PremiumWaiverRequest = 11,
        [Description("Client walked away")]
        ClientWalkedAway = 12,
        [Description("Firm not proceeding")]
        FirmNotProceeding = 13,
        [Description("Pre-coverage outcome")]
        PreCoverageOutcome = 14,
        [Description("Settle for zero")]
        SettleForZero = 15,
        [Description("Transferred to other lawyer")]
        TransferredToOtherLawyer = 16,
        [Description("Deceased")]
        Deceased = 17,
        [Description(" Submitted in error")]
        SubmittedInError = 18,
        [Description("AB only")]
        ABOnly = 19,
        [Description("File settled – unsuccessful outcome")]
        FileUnsuccessfulOutcome = 20,
        [Description("Active")]
        Active = 21
    }

    public enum PolicyStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("Declined")]
        Declined = 3

    }

    public enum AuditFilter
    {
        [Description("Case File update")]
        CaseUpdate = 1,
        [Description("Meeting update")]
        MeetingUpdate = 2,
        [Description("Policy update")]
        PolicyUpdate = 3,
        [Description("Premium Issued")]
        PremiumIssued = 4,
        [Description("Payment Received")]
        PaymentReceived = 5,
        [Description("Invoice Raised")]
        InvoiceRaised = 6,
        [Description("Endorsement Added")]
        EndorsementAdded = 7
    }

    public enum LawyerPractice
    {
        [Description("Personal Injury")]
        PersonalInjury = 1,
        [Description("Medical Malpractice")]
        MedicalMalpractice = 2,
        [Description("Corporate/Commercial")]
        Commercial = 3,
        [Description("Employment & Labour")]
        Labour = 4,
        [Description("Wills, Estates & Trusts")]
        Trusts = 5,
        [Description("Family")]
        Family = 6,
        [Description("Healthcare")]
        Healthcare = 7,
        [Description("Class Actions/Mass Tort")]
        Tort = 8,
        [Description("Franchise")]
        Franchise = 9,
        [Description("Real Estate")]
        RealEstate = 10,
        [Description("Securities")]
        Securities = 11,
        [Description("Tax")]
        Tax = 12,
        [Description("Aboriginal")]
        Aboriginal = 13,
        [Description("Other")]
        Other = 14
    }

    public enum CoverageProgram
    {
        [Description("Platinum")]
        Platinum = 1,
        [Description("Gold")]
        Gold = 2,
        [Description("Silver")]
        Silver = 3
    }

    public enum LawyerSanction
    {
        [Description("Warning")]
        Warning = 1,
        [Description("Suspension")]
        Suspension = 2,
        [Description("Disbarred")]
        Disbarred = 3
    }

    public enum FileCoverageType
    {
        [Description("MVA Pre-Discovery")]
        PreDiscovery = 1,
        [Description("MVA Post-Discovery")]
        PostDiscovery = 2,
        [Description("Other Claim Type Coverage Request")]
        Other = 3
    }

    public enum FileClaimType
    {
        [Description("Tort Only")]
        MVAPartyBenefits = 1,
        [Description("Tort and First Party Benefits")]
        MVAOnly = 2,
        [Description("First Party Benefits ONLY")]
        PartyOnly = 3
    }

    public enum FileStatusAction
    {
        [Description("Pleadings")]
        Pleadings = 1,
        [Description("Discoveries")]
        Discoveries = 2,
        [Description("Mediation")]
        Mediation = 3,
        [Description("Pre-Trial")]
        PreTrial = 4
    }

    public enum ApprovalStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("Not approved ")]
        NotApproved = 3,
        [Description("Needs more information")]
        NeedInformation = 4,
        [Description("Ready for underwriter")]
        UnderWriterReady = 5
    }

    public enum PersonalInjuryCategories
    {
        [Description("Broker or solicitor’s negligence")]
        BrokersNegligence = 1,
        [Description("Malicious prosecution")]
        MaliciousProsecution = 2,
        [Description("Claims for insurance or benefits that are not in connection with a personal injury claim")]
        InjuryClaim = 3,
        [Description("Unlawful arrest")]
        UnlawfulArrest = 4,
        [Description("Employment law")]
        EmploymentLaw = 5,
        [Description("Defamation, libel and/or slander")]
        Defamation = 6,
        [Description("Property damage")]
        PropertyDamage = 7,
        [Description("Landlord and tenant")]
        LandlordTenant = 8,
        [Description("Estates and trusts")]
        EstatesTrusts = 9,
        [Description("Bankruptcy and insolvency")]
        Bankruptcy = 10,
        [Description("Wrongful conviction")]
        WrongfulConviction = 11,
        [Description("Real Estate")]
        RealExtate = 12,

    }

    public enum MeetingTypes
    {

        [Description("InitialMeeting")]
        InitialMeeting = 1,
        [Description("FollowUp")]
        FollowUp = 2,
        [Description("ConfirmationClientWishesToProceed")]
        ConfirmationClientWishesToProceed = 3,
        [Description("ClientNotInteretsed")]
        ClientNotInteretsed = 4,
        [Description("ApplicationReceived")]
        ApplicationReceived = 6,
        [Description("IndicationLetterSent")]
        IndicationLetterSent = 7,
        [Description("ActiveFilesReceived")]
        ActiveFilesReceived = 8,
        [Description("QuoteSent")]
        QuoteSent = 9,
        [Description("QuoteAccepted")]
        QuoteAccepted = 10,
        [Description("PolicySetsent")]
        PolicySetsent = 11,
        [Description("RenewalPackageSent")]
        RenewalPackageSent = 12,
        [Description("RenewalPackageAccepted")]
        RenewalPackageAccepted = 13
    }

    public enum RatingMatrixCategories
    {
        [Description("Credibility")]
        Credibility = 1,
        [Description("Injuries")]
        Injuries = 2,
        [Description("Causation")]
        Causation = 3,
        [Description("Liability")]
        Liability = 4,
        [Description("Proxomity to Trial")]
        ProxomityTrial = 5,
        [Description("Overall Rating")]
        OverallRating = 6
    }

    public enum ProductType
    {
        [Description("Firm")]
        Firm = 1,
        [Description("File")]
        File = 2
    }
    public enum AttachmentTrigger
    {
        [Description("Retainer")]
        Retainer = 1,
        [Description("Prediscovery")]
        Prediscovery = 2,
        [Description("Statement of claim")]
        Statement_of_claim = 3
    }

    public enum CertificatesViewTypes
    {
        [Description("_generic.cshtml")]
        Generic = 1,
        [Description("_caledon.cshtml")]
        Caledon = 2,
        [Description("_brampton.cshtml")]
        Brampton = 3,
        [Description("_london.cshtml")]
        London = 4,
        [Description("_toronto.cshtml")]
        Toronto = 5,
        [Description("_vaughn.cshtml")]
        Vaughn = 6
    }

    public enum ReportTypes
    {
        PremiumBordereau = 1,
        LesseChange = 2,
        Driver = 3,
        Section = 4,
        Renewal = 5
    }

    public enum UpdateCertificateTypes
    {
        Lesse = 1,
        Lessor = 2,
        Driver = 3
    }

    public enum RenewalReportTypes
    {
        SameYear = 1,
        UpcomingMonths = 2,
        Expiry = 3
    }

    public enum CustomPageSize
    {
        Report = 30
    }

    public enum DriverStatus
    {
        Reject = 1,
        Approve = 2,
        Deleted = 3,
        InActive = 4
    }
}