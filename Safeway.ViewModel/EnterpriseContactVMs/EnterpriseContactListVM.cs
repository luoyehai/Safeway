﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;
using Safeway.ViewModel.CommonClass;

namespace Safeway.ViewModel.EnterpriseContactVMs
{
    public partial class EnterpriseContactListVM : BasePagedListVM<EnterpriseContact_View, EnterpriseContactSearcher>
    {
        public Guid basicInfoID { get; set; }
        public EnterpriseContactListVM(string id) 
        {
            basicInfoID = new Guid(id);
            //EntityList = EntityList.Where(x => x.EnterpriseBasicInfoId == new Guid(id)).ToList();        
        }
        public EnterpriseContactListVM()
        {
            
        }
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseContact", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseContact_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseContact_View>>{
                this.MakeGridHeader(x => x.Dept),
                this.MakeGridHeader(x => x.Position),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Tele),
                this.MakeGridHeader(x => x.MobilePhone),
                this.MakeGridHeader(x => x.Email),
                this.MakeGridHeader(x => x.ComapanyName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseContact_View> GetSearchQuery()
        {
            if (basicInfoID != null && !string.IsNullOrEmpty(basicInfoID.ToString()))
            {
                var queryfilter = DC.Set<EnterpriseContact>()
                    .CheckContain(Searcher.Dept, x => x.Dept)
                    .CheckEqual(Searcher.EnterpriseBasicInfoId, x => x.EnterpriseBasicInfoId)
                    .Select(x => new EnterpriseContact_View
                    {
                        ID = x.ID,
                        Dept = x.Dept,
                        Position = x.Position,
                        Name = x.Name,
                        Tele = x.Tele,
                        MobilePhone = x.MobilePhone,
                        Email = x.Email,
                        ComapanyName_view = DC.Set<EnterpriseBasicInfo>().Where(y => y.ID == x.EnterpriseBasicInfoId).Select(y => y.ComapanyName).FirstOrDefault(),
                    })
                    .Where(x => x.EnterpriseBasicInfoId == basicInfoID)
                    .OrderBy(x => x.ID);
                return queryfilter;
            }
            var query = DC.Set<EnterpriseContact>()
                .CheckContain(Searcher.Dept, x => x.Dept)
                .CheckEqual(Searcher.EnterpriseBasicInfoId, x => x.EnterpriseBasicInfoId)
                .Select(x => new EnterpriseContact_View
                {
                    ID = x.ID,
                    Dept = x.Dept,
                    Position = x.Position,
                    Name = x.Name,
                    Tele = x.Tele,
                    MobilePhone = x.MobilePhone,
                    Email = x.Email,
                    ComapanyName_view = DC.Set<EnterpriseBasicInfo>().Where(y => y.ID == x.EnterpriseBasicInfoId).Select(y => y.ComapanyName).FirstOrDefault(),
                })
                .OrderBy(x => x.ID);

            return query;
        }

        public List<ViewFormatClass> SearchPeople(string keyword) 
        {
            var query = DC.Set<EnterpriseContact>()
                  .Where(x => x.Name.Contains(keyword)).Select(x => new ViewFormatClass { Text = x.Name,Value= x.Name}).ToList();
            return query;

        } 
    }

    public class EnterpriseContact_View : EnterpriseContact{
        [Display(Name = "公司名称")]
        public String ComapanyName_view { get; set; }

    }
}
