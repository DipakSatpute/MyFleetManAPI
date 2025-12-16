using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.DTOs.Employee
{
    public class CreateEmployeeDto : CreateDto
    {
        public string? EmployeeCode { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int? CityServingCode { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? PinCode { get; set; }
        public string? Gender { get; set; }
        public int? BranchId { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
        public string? DigitalSignature { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? IdProofId { get; set; }
        public string? IdProofNo { get; set; }
        public string? IdDocPath { get; set; }
        public int? AddressProofId { get; set; }
        public string? AddressProofNo { get; set; }
        public string? AddressDocPath { get; set; }
        public bool? TdsApplicable { get; set; }
        public decimal? TdsPercentage { get; set; }
        public string? TdsName { get; set; }
        public long? InstallationId { get; set; }
        public long? BranchWithOutletId { get; set; }
        public string? LoginIpAddress { get; set; }
        public bool? IsLoginIpValidate { get; set; }
        public string? PfNo { get; set; }
        public string? PanCardNo { get; set; }
        public string? PanCardDocPath { get; set; }
        public string? AadharCardNo { get; set; }
        public string? AadharCardDocPath { get; set; }
        public string? UanNo { get; set; }
        public bool? IsBackgroundVerification { get; set; }
        public string? BackgroundVerificationDocPath { get; set; }
        public DateTime? BackgroundVerificationExpDate { get; set; }
        public bool? IsPoliceVerification { get; set; }
        public string? PoliceVerificationDocPath { get; set; }
        public DateTime? PoliceVerificationExpDate { get; set; }
        public string? CountryPhoneCode { get; set; }
        public string? RegistrationMobileNo { get; set; }
        public bool? IsMobileNoVerify { get; set; }
        public int? DeptId { get; set; }
        public int? ManagerId { get; set; }
        public int? IsCorporateUser { get; set; }
        public int? IsCorporateUserApprove { get; set; }
        public bool? IsVerified { get; set; }
        public string? Remark { get; set; }
        public int? LevelId { get; set; }
        public bool? IsAllowGuestBooking { get; set; }
    }
}
