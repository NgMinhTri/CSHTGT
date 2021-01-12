using FluentValidation;

namespace CSHTGT.ViewModels
{
    public class PhuongTien_NTGGTValidator : AbstractValidator<PhuongTien_NTGGTViewModel>
    {
        public PhuongTien_NTGGTValidator()
        {

            RuleFor(x => x.TenPT).NotEmpty().WithMessage("Nhập tên phương tiện");
            RuleFor(x => x.BienSo).NotEmpty().WithMessage("Nhập biển số");
            RuleFor(x => x.NhanHieu).NotEmpty().WithMessage("Nhà sản xuất");
            RuleFor(x => x.SoChoNgoi).NotEmpty().WithMessage("Nhập số chỗ ngồi")
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.SoKhung).NotEmpty().WithMessage("Nhập số khung");
            RuleFor(x => x.SoMay).NotEmpty().WithMessage("Nhập số máy");

            //RuleFor(x => x.HoTen).NotEmpty().WithMessage("Nhập họ tên");
            //RuleFor(x => x.DiaChi).NotEmpty().WithMessage("Nhập địa chỉ");
           // RuleFor(x => x.CMND).NotEmpty().WithMessage("Nhập CMND");
            //RuleFor(x => x.Email).NotEmpty().WithMessage("Nhập Email")
                //.EmailAddress();

           // RuleFor(x => x.NgaySinh).NotEmpty().WithMessage("Nhập ngày sinh");
            //RuleFor(x => x.QueQuan).NotEmpty().WithMessage("Nhập quê quán");
           // RuleFor(x => x.SDT).NotEmpty().WithMessage("Nhập số điện thoại");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Nhập UserName");
            //RuleFor(x => x.PassWord).NotEmpty().WithMessage("Nhập Password");

        }
       
    }
}
