using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class GPLXValidator : AbstractValidator<GPLXViewModel>
    {
        public GPLXValidator()
        {
            RuleFor(x => x.CMND).NotEmpty().WithMessage("Nhập CMND");
            RuleFor(x => x.Hang).NotEmpty().WithMessage("Nhập hãng");
            RuleFor(x => x.NgayTao).NotEmpty().WithMessage("Nhập Ngày Tạo");
            RuleFor(x => x.NgayHetHan).NotEmpty().WithMessage("Nhập ngày hết hạn");
            RuleFor(x => x.SoGPLX).NotEmpty().WithMessage("Nhập số GPLX");
                
            RuleFor(x => x.TrangThai).NotEmpty().WithMessage("Nhập trạng thái");         
        }
        

    }
}
