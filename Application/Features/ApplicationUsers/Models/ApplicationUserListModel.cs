using Application.Features.ApplicationUsers.Dtos;
using Core.Application.Requests;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Models
{
    public class ApplicationUserListModel : BasePageableModel
    {
        public IList<ApplicationUserListDto> Items { get; set; }
    }
}
