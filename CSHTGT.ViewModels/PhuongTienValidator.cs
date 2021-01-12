using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class PhuongTienValidator : AbstractValidator<PhuongTienViewModel>
    {
        public PhuongTienValidator()
        {
            RuleFor(x => x.TenPT).NotEmpty().WithMessage("Nhập tên phương tiện");
            RuleFor(x => x.BienSo).NotEmpty().WithMessage("Nhập biển số");
            RuleFor(x => x.NhanHieu).NotEmpty().WithMessage("Nhà sản xuất");
            RuleFor(x => x.SoChoNgoi).NotEmpty().WithMessage("Nhập số chỗ ngồi")
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.SoKhung).NotEmpty().WithMessage("Nhập số khung");
            RuleFor(x => x.SoMay).NotEmpty().WithMessage("Nhập số máy");
        }
    }
    
}
