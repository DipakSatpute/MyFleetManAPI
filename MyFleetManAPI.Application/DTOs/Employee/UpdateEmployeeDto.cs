using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFleetManAPI.Application.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int? CityServingCode { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;

        public string Address3 { get; set; } = string.Empty;

        public string PinCode { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public int? BranchId { get; set; }

        public string Mobile { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Guid? AspnetUserId { get; set; }

        public int? IsFirstLogin { get; set; }

        public DateTime? LastLoginDateTime { get; set; }

        public string RoleId { get; set; } = string.Empty;

        public int? CompanyClientId { get; set; }

        public string DigitalSignature { get; set; } = string.Empty;

        public DateTime? DateOfJoining { get; set; }

        public int? IdProofId { get; set; }

        public string IdProofNo { get; set; } = string.Empty;

        public string IdDocPath { get; set; } = string.Empty;

        public int? AddressProofId { get; set; }

        public string AddressProofNo { get; set; } = string.Empty;

        public string AddressDocPath { get; set; } = string.Empty;

        public bool? TdsApplicable { get; set; }

        public decimal? TdsPercentage { get; set; }

        public string TdsName { get; set; } = string.Empty;

        public long? InstallationId { get; set; }

        public long? BranchWithOutletId { get; set; }

        public string LoginIpAddress { get; set; } = string.Empty;

        public bool? IsLoginIpValidate { get; set; }

        public string PfNo { get; set; } = string.Empty;

        public string PanCardNo { get; set; } = string.Empty;

        public string PanCardDocPath { get; set; } = string.Empty;

        public string AdharCardNo { get; set; } = string.Empty;

        public string AdharCardDocPath { get; set; } = string.Empty;

        public string UanNo { get; set; } = string.Empty;

        public bool? IsBackgroundVerification { get; set; }

        public string BackgroundVerificationDocPath { get; set; } = string.Empty;

        public DateTime? BackgroundVerificationExpDate { get; set; }

        public bool? IsPoliceVerification { get; set; }

        public string PoliceVerificationDocPath { get; set; } = string.Empty;

        public DateTime? PoliceVerificationExpDate { get; set; }

        public string CountryPhoneCode { get; set; } = string.Empty;

        public DateTime? ChangePasswordDate { get; set; }

        public string RegistrationMobileNo { get; set; } = string.Empty;

        public bool? IsMobileNoVerify { get; set; }

        public bool? IsWhitelist { get; set; }

        public int? DeptId { get; set; }

        public int? ManagerId { get; set; }

        public int? IsCorporateUser { get; set; }

        public int? IsCorporateUserApprove { get; set; }

        public bool? IsVerified { get; set; }

        public string Remark { get; set; } = string.Empty;

        public int? LevelId { get; set; }

        public bool? IsAllowGuestBooking { get; set; }

        public int? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
