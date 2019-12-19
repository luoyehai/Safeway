using System.Collections.Generic;
using System.Linq;
using System.Web;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.SmallEntEvaluation;
using Safeway.Model.Enterprise;
using Safeway.Model.Project;
using Newtonsoft.Json;

namespace Safeway.ViewModel.HomeVMs
{
    public class IndexVM : BaseVM
    {
        public List<FrameworkMenu> AllMenu { get; set; }

        public List<TreeSelectListItem> Menu
        {
            get
            {
                return GetUserMenu();
            }
        }

        public List<TreeSelectListItem> GetUserMenu()
        {
            if (ConfigInfo.IsQuickDebug == true)
            {
                return AllMenu.AsQueryable().GetTreeSelectListItems(null, null, x => x.PageName, null, x => x.ICon, x => x.Url, SortByName: false); ;
            }
            else
            {
                var rv = AllMenu.Where(x => x.ShowOnMenu == true).AsQueryable().GetTreeSelectListItems(null, null, x => x.PageName, null, x => x.ICon, x => x.IsInside == true ? x.Url : "/_framework/outside?url=" + x.Url, SortByName: false);
                RemoveUnAccessableMenu(rv, LoginUserInfo);
                RemoveEmptyMenu(rv);
                return rv;
            }
        }

        /// <summary>
        /// 移除没有权限访问的菜单
        /// </summary>
        /// <param name="menus">菜单列表</param>
        /// <param name="info">用户信息</param>
        private void RemoveUnAccessableMenu(List<TreeSelectListItem> menus, LoginUserInfo info)
        {
            if (menus == null)
            {
                return;
            }

            List<TreeSelectListItem> toRemove = new List<TreeSelectListItem>();
            //如果没有指定用户信息，则用当前用户的登录信息
            if (info == null)
            {
                info = LoginUserInfo;
            }
            //循环所有菜单项
            foreach (var menu in menus)
            {
                //判断是否有权限，如果没有，则添加到需要移除的列表中
                var url = menu.Url;
                if (!string.IsNullOrEmpty(url) && url.StartsWith("/_framework/outside?url="))
                {
                    url = url.Replace("/_framework/outside?url=", "");
                }
                if (!string.IsNullOrEmpty(url) && info.IsAccessable(HttpUtility.UrlDecode(url)) == false)
                {
                    toRemove.Add(menu);
                }
                //如果有权限，则递归调用本函数检查子菜单
                else
                {
                    RemoveUnAccessableMenu(menu.Children, info);
                }
            }
            //删除没有权限访问的菜单
            foreach (var remove in toRemove)
            {
                menus.Remove(remove);
            }
        }

        private void RemoveEmptyMenu(List<TreeSelectListItem> menus)
        {
            for (int i = 0; i < menus.Count; i++)
            {
                if ((menus[i].Children == null || menus[i].Children.Count == 0) && (menus[i].Url == null))
                {
                    menus.RemoveAt(i);
                    i--;
                }
            }

        }
        public List<string> GetDashboardInfo() 
        {
            List<string> result = new List<string>();
            var evaluationInfo = DC.Set<SmallEntEvaluationBase>().Where(x => x.IsValid==true).ToList();
            var enterpriseInfo = DC.Set<EnterpriseBasicInfo>().ToList();
            var projectInfo = DC.Set<ProjectBasicInfo>().Where(x => x.IsValid == true).ToList();
            result.Add(JsonConvert.SerializeObject(projectInfo));
            var evaEnt = (from eva in evaluationInfo
                              join ent in enterpriseInfo
                              on eva.EnterpriseId.ToUpper() equals (ent.ID.ToString().ToUpper())
                              select new
                              {
                                  eva,
                                  ent.ComapanyName,
                                  ent.Street,
                              }).ToList();
            result.Add(JsonConvert.SerializeObject(evaEnt));
            var evaPro = (from eva in evaluationInfo
                         join proj in projectInfo
                         on eva.ProjectId equals proj.ID.ToString()
                         select new
                         {
                             eva,
                             proj.ProjectName,
                             proj.ProjectStartDate,
                             proj.ProjectStatus
                         }).ToList();
            result.Add(JsonConvert.SerializeObject(evaPro));

            return result;
        }

    }
}
