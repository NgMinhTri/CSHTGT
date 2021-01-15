using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class CanBoValidator : AbstractValidator<CanBoViewModel>
    {
        public CanBoValidator()
        {
            RuleFor(x => x.HoTen).NotEmpty().WithMessage("Nhập họ tên");
            RuleFor(x => x.CMND).NotEmpty().WithMessage("Nhập CMND");
            RuleFor(x => x.DiaChi).NotEmpty().WithMessage("Nhập địa chỉ");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Nhập Email")
                .EmailAddress();
            
            RuleFor(x => x.NgaySinh).NotEmpty().WithMessage("Nhập ngày sinh")
                .LessThan(x => DateTime.Now);
            RuleFor(x => x.SDT).NotEmpty().WithMessage("Nhập số điện thoại");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Nhập email")
                .EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Nhập password");
                
            

           
        }
       
    }
}
