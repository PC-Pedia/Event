using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Event.Model.EntityModels
{
    public class Ewent : BaseEntity
    {
        public Ewent()
        {
            Guid = Guid.NewGuid(); 
        }

        public int UserId { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "شهر")]
        public int CityId { get; set; }

        public Guid Guid { get; set; }

        //public string ImageName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "عنوان بین 4 تا 25 حرف باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ برگذاری")]
        [Required(ErrorMessage ="{0} الزامی است")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.DateTime,ErrorMessage ="مقدار وارده شده صحیح نیست")]
        public DateTime Date { get; set; }

        [Display(Name = "قیمت")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار وارده شده صحیح نیست")]
        public int? Price { get; set; }

        [Display(Name = "ظرفیت")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار وارده شده صحیح نیست")]
        public int? Capacity { get; set; }

        [NotMapped]
        public int? TickLeft { get
            {
                if(Capacity.HasValue)
                {
                    return Capacity.Value - Purchases.Count;
                }

                return null;
            }
        }

        public bool HasImage { get; set; }

        public EventStatus Status { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual EventCategory Category { get; set; }
        public virtual City City{get;set;}
    }
}
